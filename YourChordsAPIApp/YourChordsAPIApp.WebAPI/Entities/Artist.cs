using System;
using System.Collections.Generic;

namespace YourChordsAPIApp.WebAPI.Entities;

public partial class Artist
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? Dob { get; set; }

    public string? Country { get; set; }

    public string? Bio { get; set; }

    public string? ProfilePic { get; set; }

    public string? ExternalLink { get; set; }

    public int? Popularity { get; set; }

    public virtual ICollection<ArtistGenre> ArtistGenres { get; set; } = new List<ArtistGenre>();

    public virtual ICollection<SongArtist> SongArtists { get; set; } = new List<SongArtist>();
}
