using GameTournament.Application.Common.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.Posts.Commands
{
    public class CreatePostCommand : IRequest<ResultViewModel>
    {
        public Guid CoverImageGuid { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Description { get; set; }
        public List<Guid> Categories { get; set; } = new List<Guid>();
    }
}
