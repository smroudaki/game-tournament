using GameTournament.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Domain.Entities
{
    public partial class Document
    {
        public Document()
        {
            Post = new HashSet<Post>();
            User = new HashSet<User>();
        }

        public int DocumentId { get; set; }
        public Guid DocumentGuid { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }
        public DocumentType Type { get; set; }
        public long Size { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual ICollection<Post> Post { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
