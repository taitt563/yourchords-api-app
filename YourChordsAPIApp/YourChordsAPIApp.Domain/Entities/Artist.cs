using System;
using System.Collections.Generic;

namespace YourChordsAPIApp.Domain.Entities
{
    public partial class Artist
    {
        public Artist()
        {
            ArtistGenres = new HashSet<ArtistGenre>();
            SongArtists = new HashSet<SongArtist>();
        }

        public int Id { get; set; }
        public string ArtistName { get; set; } = null!;
        public DateTime? Dob { get; set; }
        public string? Country { get; set; }
        public string? Bio { get; set; }
        public string? ProfilePic { get; set; }
        public string? SocialMediaLink { get; set; }

        public virtual ICollection<ArtistGenre> ArtistGenres { get; set; }
        public virtual ICollection<SongArtist> SongArtists { get; set; }
    }
}
