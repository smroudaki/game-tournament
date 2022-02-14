using GameTournament.Application.Common.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.ContactUsMessages.Commands
{
    public class CreateContactUsMessageCommand : IRequest<ResultViewModel>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
