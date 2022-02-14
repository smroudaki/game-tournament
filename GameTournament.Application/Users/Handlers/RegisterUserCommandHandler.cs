using GameTournament.Application.Common.Interfaces;
using GameTournament.Application.Common.ViewModels;
using GameTournament.Application.Users.Commands;
using GameTournament.Domain.Entities;
using GameTournament.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameTournament.Application.Users.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, ResultViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISmsService _smsService;

        public RegisterUserCommandHandler(IUnitOfWork unitOfWork,
            ISmsService smsService)
        {
            _unitOfWork = unitOfWork;
            _smsService = smsService;
        }

        public async Task<ResultViewModel> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            // Get the user
            var user = await _unitOfWork.Users.GetByPhoneNumberAsync(request.PhoneNumber);

            // Check if the user exist
            if (user == null)
            {
                // Create an identifier
                string prefix = "gamer-";
                int randomNumber = new Random().Next(100000, 999999);
                string identifier = prefix + randomNumber.ToString();

                // Create a new user

                user = new User
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    PhoneNumber = request.PhoneNumber,
                    Identifier = identifier,
                    AccountState = AccountState.InitialRegistration
                };

                _unitOfWork.Users.Insert(user);
            }
            else
            {
                // Check if the existing user's phone number's confirmed
                var phoneNumberConfirmed = await _unitOfWork.Users.IsValidAsync(request.PhoneNumber);

                if (phoneNumberConfirmed)
                {
                    string[] errors = new string[] { "کاربر مورد نظر قبلا ثبت شده است" };
                    return ResultViewModel.Failure(errors);
                }

                // Get and update the existing user
                user = await _unitOfWork.Users.GetByPhoneNumberAsync(request.PhoneNumber);
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;

                _unitOfWork.Users.Update(user);
            }

            // Create a token
            string token = new Random().Next(100000, 999999).ToString();
            //token = "111111";

            var userToken = new UserToken
            {
                User = user,
                Value = token
            };

            _unitOfWork.UserTokens.Insert(userToken);

            // Commit the changes
            await _unitOfWork.CommitAsync();

            // Send SMS
            await _smsService.SendServiceableAsync(SmsTemplate.VerifyAccount.ToString(),
                user.PhoneNumber,
                userToken.Value);

            return ResultViewModel.Success();
        }
    }
}
