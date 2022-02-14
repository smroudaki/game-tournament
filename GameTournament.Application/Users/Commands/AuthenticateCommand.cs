using GameTournament.Application.Users.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.Users.Commands
{
    public class AuthenticateCommand : IRequest<AuthenticateViewModel>
    {
        public string PhoneNumber { get; set; }
        public string Token { get; set; }
        public bool RememberMe { get; set; }
    }
}
