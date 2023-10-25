﻿using System;
using System.Collections.Generic;

namespace YourChordsAPIApp.Domain.Entities
{
    public partial class Role
    {
        public Role()
        {
            UserAccounts = new HashSet<UserAccount>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<UserAccount> UserAccounts { get; set; }
    }
}
