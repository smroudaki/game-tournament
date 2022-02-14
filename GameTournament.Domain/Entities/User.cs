using GameTournament.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Domain.Entities
{
    public partial class User
    {
        public User()
        {
            Payment = new HashSet<Payment>();
            Post = new HashSet<Post>();
            InverseUserIntroduced = new HashSet<User>();
            UserToken = new HashSet<UserToken>();
        }

        public int UserId { get; set; }
        public Guid UserGuid { get; set; }
        public int? ProfileDocumentId { get; set; }
        public int? ProvinceId { get; set; }
        public int? UserIntroducedId { get; set; }
        public string Identifier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LatinFirstName { get; set; }
        public string LatinLastName { get; set; }
        public string NickName { get; set; }
        public Gender? Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string Address { get; set; }
        public string ActivitiesIds { get; set; }
        public string ActivitiesStartYear { get; set; }
        public string Description { get; set; }
        public string RawInfo { get; set; }
        public AccountState AccountState { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Document ProfileDocument { get; set; }
        public virtual Province Province { get; set; }
        public virtual User UserIntroduced { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
        public virtual ICollection<Post> Post { get; set; }
        public virtual ICollection<User> InverseUserIntroduced { get; set; }
        public virtual ICollection<UserToken> UserToken { get; set; }
    }
}
