using System;
using System.Collections.Generic;

namespace YourChordsAPIApp.Domain.Entities
{
    public partial class UserLoginDatum
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string PasswordSalt { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string ConfirmationToken { get; set; } = null!;
        public bool IsVerified { get; set; }

        public virtual UserAccount User { get; set; } = null!;
    }
}
