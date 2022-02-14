using GameTournament.Application.Common.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace GameTournament.Application.Payments.Commands
{
    public class VerifyPaymentCommand : IRequest<ResultViewModel>
    {
        [JsonIgnore]
        public Guid PaymentGuid { get; set; }
        public string Authority { get; set; }
    }
}
