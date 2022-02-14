using GameTournament.Application.Common.Interfaces;
using GameTournament.Application.Users.Commands;
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
    public class AuthenticateCommandHandler : IRequestHandler<AuthenticateCommand, AuthenticateViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtService _jwtService;
        private readonly ISmsService _smsService;

        public AuthenticateCommandHandler(IUnitOfWork unitOfWork,
            IJwtService jwtService,
            ISmsService smsService)
        {
            _unitOfWork = unitOfWork;
            _jwtService = jwtService;
            _smsService = smsService;
        }

        public async Task<AuthenticateViewModel> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            // Get the user
            var user = await _unitOfWork.Users.GetByPhoneNumberAsync(request.PhoneNumber);

            // Check if the user exist
            if (user == null)
            {
                string[] errors = new string[] { "کاربر مورد نظر یافت نشد" };
                return AuthenticateViewModel.Failure(errors);
            }

            // Check if the user's account is active
            if (!user.IsActive)
            {
                string[] errors = new string[] { "حساب کاربر مورد نظر مسدود است" };
                return AuthenticateViewModel.Failure(errors);
            };

            // Get recent user's token
            var userToken = await _unitOfWork.UserTokens
                .Get(ut => ut.UserId.Equals(user.UserId) && ut.CreationDate.AddMinutes(2) >= DateTime.Now,
                    ut => ut.OrderByDescending(ut => ut.CreationDate))
                        .FirstOrDefaultAsync();

            // Check if there's a token and not expired
            if (userToken == null)
            {
                string[] errors = new string[] { "کد اعتبارسنجی یافت نشد" };
                return AuthenticateViewModel.Failure(errors);
            }

            // Check if the token is valid
            if (!userToken.Value.Equals(request.Token))
            {
                string[] errors = new string[] { "کد اعتبارسنجی وارد شده اشتباه است" };
                return AuthenticateViewModel.Failure(errors);
            };

            // Check if the phone number is confirmed
            if (!user.PhoneNumberConfirmed)
            {
                // Confirm the phone number
                user.PhoneNumberConfirmed = true;

                // Commit the changes
                await _unitOfWork.CommitAsync();

                // Send SMS
                string userFullName = user.FirstName + " " + user.LastName;

                await _smsService.SendServiceableAsync(SmsTemplate.RegisterMessage.ToString(),
                    user.PhoneNumber,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    userFullName);
            }

            // Specify expire date
            DateTime expireDate = request.RememberMe ? DateTime.Now.AddDays(7) : DateTime.Now.AddDays(1);

            // Generate jason web token
            string token = await _jwtService.GenerateToken(user, expireDate);

            return AuthenticateViewModel.Success(token, expireDate.ToString());
        }
    }
}
