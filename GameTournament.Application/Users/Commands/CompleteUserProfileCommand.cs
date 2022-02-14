using GameTournament.Application.Common.ViewModels;
using GameTournament.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.Users.Commands
{
    public class CompleteUserProfileCommand : IRequest<ResultViewModel>
    {
        public Guid UserGuid { get; set; }
        public Guid ProfileImageGuid { get; set; }
        public Guid ProvinceGuid { get; set; }
        public string LatinFirstName { get; set; }
        public string LatinLastName { get; set; }
        public string NickName { get; set; }
        public Gender Gender { get; set; }
        public string Birthday { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public List<Guid> Activities { get; set; }
        public string StartYear { get; set; }
        public string Description { get; set; }
        public string Identifier { get; set; }
    }
}
