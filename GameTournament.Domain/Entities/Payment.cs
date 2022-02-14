using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Domain.Entities
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public Guid PaymentGuid { get; set; }
        public int UserId { get; set; }
        public long Cost { get; set; }
        public long Discount { get; set; }
        public string TrackingToken { get; set; }
        public bool IsSuccessful { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual User User { get; set; }
    }
}
