using GameTournament.Application.Posts.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.Posts.Queries
{
    public class GetPostsQuery : IRequest<PostsViewModel>
    {
        public int Page { get; set; }
        public int Take { get; set; }
    }
}
