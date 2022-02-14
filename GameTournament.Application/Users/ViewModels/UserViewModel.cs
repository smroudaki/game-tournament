using GameTournament.Application.Activities.ViewModels;
using GameTournament.Application.Common.ViewModels;
using GameTournament.Application.Documents.ViewModels;
using GameTournament.Application.Provinces.ViewModels;
using GameTournament.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace GameTournament.Application.Users.ViewModels
{
    public class UserViewModel : ResultViewModel
    {
        public UserViewModel(bool succeeded, IEnumerable<string> errors)
            : base(succeeded, errors)
        {
        }

        public UserDto User { get; set; }
    }

    public class UserDto
    {
        public Guid UserGuid { get; set; }
        public FilepondDto ProfileImage { get; set; }
        public ProvinceDto Province { get; set; }
        public string UserIdentifierIntroduced { get; set; }
        public string Identifier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LatinFirstName { get; set; }
        public string LatinLastName { get; set; }
        public string NickName { get; set; }
        public GenderDto Gender { get; set; }
        public string Birthday { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        [JsonIgnore]
        public string ActivitiesIds { get; set; }
        public List<LiteActivityDto> Activities { get; set; }
        public string ActivitiesStartYear { get; set; }
        public string Description { get; set; }
        public string RawInfo { get; set; }
        [JsonIgnore]
        public AccountState AccountStateEnum { get; set; }
        public string AccountState { get; set; }
        public bool? IsActive { get; set; }
        public string CreationDate { get; set; }
        public string ModifiedDate { get; set; }
    }

    public class GenderDto
    {
        public Gender? GenderId { get; set; }
        public string Name { get; set; }
    }
}
