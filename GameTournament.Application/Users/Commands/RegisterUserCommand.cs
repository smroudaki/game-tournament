using GameTournament.Application.Common.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.Users.Commands
{
    public class RegisterUserCommand : IRequest<ResultViewModel>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
