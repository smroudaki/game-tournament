using GameTournament.Application.Common.Interfaces;
using GameTournament.Application.Common.ViewModels;
using GameTournament.Application.ContactUsMessages.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameTournament.Application.ContactUsMessages.Handlers
{
    public class CreateContactUsMessageCommandHandler : IRequestHandler<CreateContactUsMessageCommand, ResultViewModel>
    {
        private readonly IEmailService _emailService;

        public CreateContactUsMessageCommandHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task<ResultViewModel> Handle(CreateContactUsMessageCommand request, CancellationToken cancellationToken)
        {
            string to = "sinmimr@gmail.com";
            string subject = "ارتباط با ما";
            string body = request.FirstName + " " + request.LastName + '\n' + request.Email + '\n' + request.Message;

            await _emailService.SendAsync(to, subject, body);

            return ResultViewModel.Success();
        }
    }
}
