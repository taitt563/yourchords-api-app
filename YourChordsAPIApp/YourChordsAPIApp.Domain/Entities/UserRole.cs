using System;
using System.Collections.Generic;

namespace YourChordsAPIApp.Domain.Entities
{
    public partial class UserRole
    {
        public UserRole()
        {
            UserAccounts = new HashSet<UserAccount>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<UserAccount> UserAccounts { get; set; }
    }
}
