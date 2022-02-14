using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Domain.Entities
{
    public partial class UserToken
    {
        public int UserTokenId { get; set; }
        public Guid UserTokenGuid { get; set; }
        public int UserId { get; set; }
        public string Value { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual User User { get; set; }
    }
}
