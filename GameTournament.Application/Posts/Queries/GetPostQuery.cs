using GameTournament.Application.Posts.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.Posts.Queries
{
    public class GetPostQuery : IRequest<PostViewModel>
    {
        public Guid PostGuid { get; set; }
    }
}
