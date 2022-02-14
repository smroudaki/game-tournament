using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Domain.Entities
{
    public partial class PostCategory
    {
        public int PostCategoryId { get; set; }
        public Guid PostCategoryGuid { get; set; }
        public int PostId { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Post Post { get; set; }
    }
}
