using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Domain.Entities
{
    public partial class Post
    {
        public Post()
        {
            PostCategory = new HashSet<PostCategory>();
        }

        public int PostId { get; set; }
        public Guid PostGuid { get; set; }
        public int UserId { get; set; }
        public int CoverDocumentId { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Description { get; set; }
        public bool IsShow { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Document CoverDocument { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<PostCategory> PostCategory { get; set; }
    }
}
