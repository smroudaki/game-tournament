using GameTournament.Application.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.Categories.ViewModels
{
    public class LiteCategoriesViewModel : ResultViewModel
    {
        public LiteCategoriesViewModel(bool succeeded, IEnumerable<string> errors)
                  : base(succeeded, errors)
        {
        }

        public List<LiteCategoryDto> LiteCategories { get; set; }
    }
}
