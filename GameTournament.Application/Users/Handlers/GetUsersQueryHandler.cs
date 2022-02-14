using GameTournament.Application.Activities.ViewModels;
using GameTournament.Application.Common.Extensions;
using GameTournament.Application.Common.Interfaces;
using GameTournament.Application.Documents.ViewModels;
using GameTournament.Application.Provinces.ViewModels;
using GameTournament.Application.Users.Queries;
using GameTournament.Application.Users.ViewModels;
using GameTournament.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameTournament.Application.Users.Handlers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, UsersViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUsersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UsersViewModel> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            // Get users
            var users = await _unitOfWork.Users
                .Get(u => u.PhoneNumberConfirmed, u => u.OrderByDescending(u => u.CreationDate), "ProfileDocument,Province,UserIntroduced")
                .Select(u => new UserDto
                {
                    UserGuid = u.UserGuid,
                    ProfileImage = u.ProfileDocument == null ? null : new FilepondDto
                    {
                        Guid = u.ProfileDocument.DocumentGuid,
                        Source = u.ProfileDocument.Path,
                        Options = new FilepondOptions
                        {
                            Type = "local",
                            File = new FilepondFile
                            {
                                Name = u.ProfileDocument.FileName,
                                Size = u.ProfileDocument.Size.ToString(),
                                Type = _unitOfWork.Documents.GetDocumentType(u.ProfileDocument.Type)
                            },
                            Metadata = new FilepondMetadata
                            {
                                Poster = u.ProfileDocument.Path
                            }
                        }
                    },
                    Province = u.ProvinceId == null ? null : new ProvinceDto
                    {
                        ProvinceGuid = u.Province.ProvinceGuid,
                        Name = u.Province.Name
                    },
                    UserIdentifierIntroduced = u.UserIntroduced.Identifier,
                    Identifier = u.Identifier,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    LatinFirstName = u.LatinFirstName,
                    LatinLastName = u.LatinLastName,
                    NickName = u.NickName,
                    Gender = u.Gender == null ? null : new GenderDto
                    {
                        GenderId = u.Gender,
                        Name = u.Gender.Equals(Gender.Male) ? "مرد" : "زن"
                    },
                    Birthday = u.Birthday == null ?
                        null : PersianDateExtensions.ToPeString(u.Birthday.Value, "yyyy/MM/dd"),
                    Email = u.Email,
                    Telephone = u.Telephone,
                    PhoneNumber = u.PhoneNumber,
                    Address = u.Address,
                    ActivitiesIds = u.ActivitiesIds,
                    ActivitiesStartYear = u.ActivitiesStartYear,
                    Description = u.Description,
                    RawInfo = u.RawInfo,
                    AccountStateEnum = u.AccountState,
                    IsActive = u.IsActive,
                    CreationDate = PersianDateExtensions.ToPeString(u.CreationDate, "yyyy/MM/dd HH:mm"),
                    ModifiedDate = u.ModifiedDate == null ?
                        null : PersianDateExtensions.ToPeString(u.ModifiedDate.Value, "yyyy/MM/dd HH:mm")

                }).ToListAsync();

            // Check if there're any users exist
            if (users.Count <= 0)
            {
                string[] errors = new string[] { "موردی یافت نشد" };
                return new UsersViewModel(false, errors);
            }

            foreach (var user in users)
            {
                if (user.ActivitiesIds != null)
                {
                    user.Activities = await SplitActivities(user.ActivitiesIds);
                }

                user.AccountState = await GetAccountStateName(user.AccountStateEnum);
            }

            return new UsersViewModel(true, new string[] { }) { Users = users };
        }

        #region Helpers Methods

        private async Task<List<LiteActivityDto>> SplitActivities(string activitiesIds)
        {
            // Define an empty string list for returning activities dtos
            var activitiesDtos = new List<LiteActivityDto>();

            // Split activities ids into an array
            var activitiesIdsArray = activitiesIds.Split(" ");

            foreach (var activityId in activitiesIdsArray)
            {
                // Get the activity
                var activity = await _unitOfWork.Activities
                    .Get(a => a.ActivityId.Equals(int.Parse(activityId)))
                    .SingleOrDefaultAsync();

                // Check if the activity's exist and not deleted
                if (activity == null)
                {
                    continue;
                }

                // Create an activity dto
                var activityDto = new LiteActivityDto
                {
                    ActivityGuid = activity.ActivityGuid,
                    Name = activity.Name
                };

                // Add the activity dto to activities dtos list
                activitiesDtos.Add(activityDto);
            }

            // Return activities dtos
            return activitiesDtos;
        }

        private Task<string> GetAccountStateName(AccountState accountState)
        {
            return accountState switch
            {
                AccountState.InitialRegistration => Task.FromResult("ثبت نام اولیه"),
                AccountState.Pending => Task.FromResult("در حال بررسی"),
                AccountState.CallingForChange => Task.FromResult("خواستار تغییر"),
                AccountState.Confirmed => Task.FromResult("تایید شده"),
                _ => null
            };
        }

        #endregion
    }
}
