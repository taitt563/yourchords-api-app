using System;
using System.Collections.Generic;

namespace YourChordsAPIApp.Domain.Entities
{
    public partial class Genre
    {
        public Genre()
        {
            ArtistGenres = new HashSet<ArtistGenre>();
            BeatGenres = new HashSet<BeatGenre>();
            SongGenres = new HashSet<SongGenre>();
        }

        public int Id { get; set; }
        public string GenreName { get; set; } = null!;

        public virtual ICollection<ArtistGenre> ArtistGenres { get; set; }
        public virtual ICollection<BeatGenre> BeatGenres { get; set; }
        public virtual ICollection<SongGenre> SongGenres { get; set; }
    }
}
