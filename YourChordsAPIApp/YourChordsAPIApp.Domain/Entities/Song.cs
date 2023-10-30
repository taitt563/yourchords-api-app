using System;
using System.Collections.Generic;

namespace YourChordsAPIApp.Domain.Entities;

public partial class Song
{
    public int Id { get; set; }

    public string SongTitle { get; set; } = null!;

    public int YearReleased { get; set; }

    public string Lyrics { get; set; } = null!;

    public string Tone { get; set; } = null!;

    public string SongWriter { get; set; } = null!;

    public int Duration { get; set; }

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

    public virtual ICollection<ChordProgression> ChordProgressions { get; set; } = new List<ChordProgression>();

    public virtual ICollection<CollectionSong> CollectionSongs { get; set; } = new List<CollectionSong>();

    public virtual UserAccount CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<SongArtist> SongArtists { get; set; } = new List<SongArtist>();

    public virtual ICollection<SongBeat> SongBeats { get; set; } = new List<SongBeat>();

    public virtual ICollection<SongGenre> SongGenres { get; set; } = new List<SongGenre>();

    public virtual ICollection<UserLikedSong> UserLikedSongs { get; set; } = new List<UserLikedSong>();
}
