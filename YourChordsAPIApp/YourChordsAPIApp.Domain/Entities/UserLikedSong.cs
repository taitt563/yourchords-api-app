using System;
using System.Collections.Generic;

namespace YourChordsAPIApp.Domain.Entities
{
    public partial class UserLikedSong
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SongId { get; set; }
        public DateTime DateAdded { get; set; }

        public virtual Song Song { get; set; } = null!;
        public virtual UserAccount User { get; set; } = null!;
    }
}
