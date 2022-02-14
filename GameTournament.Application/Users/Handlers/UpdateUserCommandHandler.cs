using GameTournament.Application.Common.Extensions;
using GameTournament.Application.Common.Interfaces;
using GameTournament.Application.Common.ViewModels;
using GameTournament.Application.Users.Commands;
using GameTournament.Domain.Entities;
using GameTournament.Domain.Enums;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace GameTournament.Application.Users.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ResultViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _uploadFolderName;

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork,
            IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _uploadFolderName = configuration.GetValue<string>("UploadFolderName").ToString();
        }

        public async Task<ResultViewModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            // Get the user
            var user = await _unitOfWork.Users.GetByGuidAsync(request.UserGuid);

            // Check if the user exist
            if (user == null)
            {
                string[] errors = new string[] { "کاربر مورد نظر یافت نشد" };
                return ResultViewModel.Failure(errors);
            }

            // Check if the user's account's not pending or confirmed
            if (user.AccountState.Equals(AccountState.Pending) ||
                user.AccountState.Equals(AccountState.Confirmed))
            {
                string[] errors = new string[] { "وضعیت کاربر مورد نظر در حال بررسی یا تایید شده می باشد" };
                return ResultViewModel.Failure(errors);
            }

            // Defines a variable to set if the user's user identifier introduced isn't null
            User userIntroduced = null;

            if (!string.IsNullOrEmpty(request.UserIdentifierIntroduced))
            {
                // Check if the user's input user identifier's not the user's identifier
                if (user.Identifier == request.UserIdentifierIntroduced)
                {
                    string[] errors = new string[] { "کد معرف نامعتبر است" };
                    return ResultViewModel.Failure(errors);
                }

                // Get the user's input user identifier introduced
                userIntroduced = await _unitOfWork.Users.GetByIdentifierAsync(request.UserIdentifierIntroduced);

                // Check if the user's input user identifier introduced exist
                if (userIntroduced == null)
                {
                    string[] errors = new string[] { "کاربری با کد معرف مورد نظر یافت نشد" };
                    return ResultViewModel.Failure(errors);
                }
            }

            // Get the user's input birthday
            var regexBirth = Regex.Match(request.Birthday, @"(\d{4})\/(\d{2})\/(\d{2})");

            // Check if the user's input birthday's valid
            if (!regexBirth.Success)
            {
                string[] errors = new string[] { "تاریخ تولد نامعتبر است" };
                return ResultViewModel.Failure(errors);
            }

            // Update user

            // Check if the user's input profile image is empty
            if (request.ProfileImageGuid == null)
            {
                // Check if the user's got an image
                if (user.ProfileDocumentId != null)
                {
                    // Get the user's old image
                    var oldDocument = await _unitOfWork.Documents.GetByIdAsync(user.ProfileDocumentId.Value);

                    // Update the user's image
                    user.ProfileDocumentId = null;

                    // Delete the user's old image
                    DeleteDocument(oldDocument);
                }
            }
            else
            {
                // Get the user's input profile image
                var image = await _unitOfWork.Documents.GetByGuidAsync(request.ProfileImageGuid.Value);

                // Check if the user's input profile image exist
                if (image == null)
                {
                    string[] errors = new string[] { "تصویر مورد نظر یافت نشد" };
                    return ResultViewModel.Failure(errors);
                }

                if (user.ProfileDocumentId != image.DocumentId)
                {
                    // Check if the user's got an image
                    if (user.ProfileDocumentId == null)
                    {
                        // Update the user's image
                        user.ProfileDocumentId = image.DocumentId;
                    }
                    else
                    {
                        // Get the user's old image
                        var oldDocument = await _unitOfWork.Documents.GetByIdAsync(user.ProfileDocumentId.Value);

                        // Update the user's image
                        user.ProfileDocumentId = image.DocumentId;

                        // Delete the user's old image
                        DeleteDocument(oldDocument);
                    }
                }
            }

            // Get the user's input province
            var province = await _unitOfWork.Provinces.GetByGuidAsync(request.ProvinceGuid);

            // Check if user's input province exist
            if (province == null)
            {
                string[] errors = new string[] { "استان مورد نظر یافت نشد" };
                return ResultViewModel.Failure(errors);
            }

            // Define variables to join activities id later
            string activities = string.Empty, splitter = " ";

            // Get the user's input activities
            foreach (var activityGuid in request.ActivitiesGuids)
            {
                // Get the user's input activity
                var activity = await _unitOfWork.Activities.GetByGuidAsync(activityGuid);

                // Check if the user's input activity exist
                if (activity == null)
                {
                    string[] errors = new string[] { $"فعالیتی با آیدی {activityGuid} یافت نشد" };
                    return ResultViewModel.Failure(errors);
                }

                // Join the user's input activity id
                activities += splitter + activity.ActivityId.ToString();
            }

            int year = int.Parse(regexBirth.Groups[1].Value);
            int month = int.Parse(regexBirth.Groups[2].Value);
            int day = int.Parse(regexBirth.Groups[3].Value);

            user.ProvinceId = province.ProvinceId;
            user.UserIntroducedId = userIntroduced?.UserId;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.LatinFirstName = request.LatinFirstName;
            user.LatinLastName = request.LatinLastName;
            user.NickName = request.NickName;
            user.Gender = request.Gender;
            user.Birthday = new DateTime(year, month, day, new PersianCalendar());
            user.Email = request.Email;
            user.Telephone = request.Telephone;
            user.Address = request.Address;
            user.ActivitiesIds = activities.TrimStart();
            user.ActivitiesStartYear = request.ActivitiesStartYear;
            user.Description = request.Description;
            user.AccountState = AccountState.Pending;
            user.ModifiedDate = DateTime.Now;

            _unitOfWork.Users.Update(user);

            // Commit the changes
            await _unitOfWork.CommitAsync();

            return ResultViewModel.Success();
        }

        #region Helpers Methods

        private void DeleteDocument(Document oldDocument)
        {
            // Get the upload folder name index
            var uploadFolderNameIndex = oldDocument.Path.IndexOf(_uploadFolderName);

            // Get the file's relative path
            var relativePath = oldDocument.Path.Substring(uploadFolderNameIndex);

            // Get the current directory
            var currentDirectory = Directory.GetCurrentDirectory();

            // Get web root path
            string webRootPath = Path.Combine(currentDirectory, "wwwroot");

            // Get the file's path
            var path = Path.Combine(currentDirectory, webRootPath, relativePath);

            // Check if the physical file exist
            if (File.Exists(path))
            {
                // Delete the physical file
                File.Delete(path);
            }

            // Delete the file from database
            _unitOfWork.Documents.Delete(oldDocument);
        }

        #endregion
    }
}
