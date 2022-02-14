using GameTournament.Application.Common.ViewModels;
using GameTournament.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace GameTournament.Application.Users.Commands
{
    public class UpdateUserCommand : IRequest<ResultViewModel>
    {
        [JsonIgnore]
        public Guid UserGuid { get; set; }
        public Guid? ProfileImageGuid { get; set; }
        public Guid ProvinceGuid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LatinFirstName { get; set; }
        public string LatinLastName { get; set; }
        public string NickName { get; set; }
        public Gender Gender { get; set; }
        public string Birthday { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public List<Guid> ActivitiesGuids { get; set; }
        public string ActivitiesStartYear { get; set; }
        public string Description { get; set; }
        public string UserIdentifierIntroduced { get; set; }
    }
}
