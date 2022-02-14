using GameTournament.Application.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.Categories.ViewModels
{
    public class CategoriesViewModel : ResultViewModel
    {
        public CategoriesViewModel(bool succeeded, IEnumerable<string> errors)
               : base(succeeded, errors)
        {
        }

        public List<CategoryDto> Categories { get; set; }
    }
}
