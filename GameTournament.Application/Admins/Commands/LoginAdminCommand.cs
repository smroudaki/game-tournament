using GameTournament.Application.Common.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.Admins.Commands
{
    public class LoginAdminCommand : IRequest<ResultViewModel>
    {
        public string PhoneNumber { get; set; }
    }
}
