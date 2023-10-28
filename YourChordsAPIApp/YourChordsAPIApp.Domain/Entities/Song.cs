using System;
using System.Collections.Generic;

namespace YourChordsAPIApp.Domain.Entities
{
    public partial class Song
    {
        public Song()
        {
            CollectionSongs = new HashSet<CollectionSong>();
            SongArtists = new HashSet<SongArtist>();
            SongBeats = new HashSet<SongBeat>();
            SongChords = new HashSet<SongChord>();
            SongGenres = new HashSet<SongGenre>();
            UserLikedSongs = new HashSet<UserLikedSong>();
        }

        public int Id { get; set; }
        public string SongTitle { get; set; } = null!;
        public int YearReleased { get; set; }
        public string Lyrics { get; set; } = null!;
        public string Tone { get; set; } = null!;
        public string SongWriter { get; set; } = null!;
        public string? ExternalLink { get; set; }
        public bool Status { get; set; }
        public string Image { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public int? LastModifiedBy { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsVerified { get; set; }
        public bool IsDeleted { get; set; }

        public virtual UserAccount CreatedByNavigation { get; set; } = null!;
        public virtual ICollection<CollectionSong> CollectionSongs { get; set; }
        public virtual ICollection<SongArtist> SongArtists { get; set; }
        public virtual ICollection<SongBeat> SongBeats { get; set; }
        public virtual ICollection<SongChord> SongChords { get; set; }
        public virtual ICollection<SongGenre> SongGenres { get; set; }
        public virtual ICollection<UserLikedSong> UserLikedSongs { get; set; }
    }
}
