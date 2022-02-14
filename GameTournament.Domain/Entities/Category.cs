using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Domain.Entities
{
    public partial class Category
    {
        public Category()
        {
            InverseParentCategory = new HashSet<Category>();
            PostCategory = new HashSet<PostCategory>();
        }

        public int CategoryId { get; set; }
        public Guid CategoryGuid { get; set; }
        public int? ParentCategoryId { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Category ParentCategory { get; set; }
        public virtual ICollection<Category> InverseParentCategory { get; set; }
        public virtual ICollection<PostCategory> PostCategory { get; set; }
    }
}
