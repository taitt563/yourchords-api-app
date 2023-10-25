using System;
using System.Collections.Generic;

namespace YourChordsAPIApp.Domain.Entities
{
    public partial class SongArtist
    {
        public int Id { get; set; }
        public int SongId { get; set; }
        public int ArtistId { get; set; }

        public virtual Artist Artist { get; set; } = null!;
        public virtual Song Song { get; set; } = null!;
    }
}
