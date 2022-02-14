using GameTournament.Application.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.Categories.ViewModels
{
    public class LiteCategoryViewModel : ResultViewModel
    {
        public LiteCategoryViewModel(bool succeeded, IEnumerable<string> errors)
                  : base(succeeded, errors)
        {
        }

        public LiteCategoryDto Category { get; set; }
    }

    public class LiteCategoryDto
    {
        public Guid CategoryGuid { get; set; }
        public string Title { get; set; }
    }
}
