using GameTournament.Application.Common.ViewModels;
using GameTournament.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace GameTournament.Application.Admins.Commands
{
    public class ChangeUserStateCommand : IRequest<ResultViewModel>
    {
        [JsonIgnore]
        public Guid UserGuid { get; set; }
        public AccountState AccountState { get; set; }
    }
}
