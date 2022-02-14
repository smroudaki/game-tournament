using GameTournament.Application.Payments.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace GameTournament.Application.Payments.Commands
{
    public class CreatePaymentCommand : IRequest<CreatePaymentViewModel>
    {
        [JsonIgnore]
        public Guid UserGuid { get; set; }
    }
}
