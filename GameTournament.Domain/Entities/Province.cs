using System;
using System.Collections.Generic;

namespace GameTournament.Domain.Entities
{
    public partial class Province
    {
        public Province()
        {
            User = new HashSet<User>();
        }

        public int ProvinceId { get; set; }
        public Guid ProvinceGuid { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
