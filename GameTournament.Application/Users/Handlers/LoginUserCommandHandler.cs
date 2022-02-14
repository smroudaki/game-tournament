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
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, ResultViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISmsService _smsService;

        public LoginUserCommandHandler(IUnitOfWork unitOfWork,
            ISmsService smsService)
        {
            _unitOfWork = unitOfWork;
            _smsService = smsService;
        }

        public async Task<ResultViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            // Get the user
            var user = await _unitOfWork.Users.GetByPhoneNumberAsync(request.PhoneNumber);

            // Check if the user exist and is not an admin
            if (user == null || user.IsAdmin)
            {
                string[] errors = new string[] { "کاربر مورد نظر یافت نشد" };
                return ResultViewModel.Failure(errors);
            }

            // Check if the user's account is active
            if (!user.IsActive)
            {
                string[] errors = new string[] { "حساب کاربر مورد نظر مسدود است" };
                return ResultViewModel.Failure(errors);
            };

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
