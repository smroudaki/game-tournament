using GameTournament.Application.Categories.ViewModels;
using GameTournament.Application.Common.ViewModels;
using GameTournament.Application.Documents.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.Posts.ViewModels
{
    public class PostViewModel : ResultViewModel
    {
        public PostViewModel(bool succeeded, IEnumerable<string> errors)
               : base(succeeded, errors)
        {
        }

        public PostDto Post { get; set; }
    }

    public class PostDto
    {
        public Guid? PostGuid { get; set; }
        public string User { get; set; }
        public FilepondDto CoverImage { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Description { get; set; }
        public bool? IsShow { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public List<LiteCategoryDto> Categories { get; set; }
    }
}
