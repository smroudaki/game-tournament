using GameTournament.Application.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.Posts.ViewModels
{
    public class PostsViewModel : ResultViewModel
    {
        public PostsViewModel(bool succeeded, IEnumerable<string> errors)
               : base(succeeded, errors)
        {
        }

        public List<PostDto> Posts { get; set; }
    }
}
