using GameTournament.Application.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace GameTournament.Application.Categories.ViewModels
{
    public class CategoryViewModel : ResultViewModel
    {
        public CategoryViewModel(bool succeeded, IEnumerable<string> errors)
                  : base(succeeded, errors)
        {
        }

        public CategoryDto Category { get; set; }
    }

    public class CategoryDto
    {
        [JsonIgnore]
        public int CategoryId { get; set; }
        public Guid CategoryGuid { get; set; }
        [JsonIgnore]
        public int? ParentCategoryId { get; set; }
        public string Title { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public List<CategoryDto> Children { get; set; } = new List<CategoryDto>();
    }
}
