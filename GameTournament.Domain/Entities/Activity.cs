using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Domain.Entities
{
    public partial class Activity
    {
        public int ActivityId { get; set; }
        public Guid ActivityGuid { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
