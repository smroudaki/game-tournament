using GameTournament.Application.Common.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace GameTournament.Application.Posts.Commands
{
    public class UpdatePostCommand : IRequest<ResultViewModel>
    {
        [JsonIgnore]
        public Guid PostGuid { get; set; }
        public Guid CoverImageGuid { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Description { get; set; }
        public bool IsShow { get; set; }
        public List<Guid> Categories { get; set; } = new List<Guid>();
    }
}
