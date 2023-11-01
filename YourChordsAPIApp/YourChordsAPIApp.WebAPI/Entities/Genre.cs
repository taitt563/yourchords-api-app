using System;
using System.Collections.Generic;

namespace YourChordsAPIApp.WebAPI.Entities;

public partial class Genre
{
    public int Id { get; set; }

    public string GenreName { get; set; } = null!;

    public virtual ICollection<ArtistGenre> ArtistGenres { get; set; } = new List<ArtistGenre>();

    public virtual ICollection<BeatGenre> BeatGenres { get; set; } = new List<BeatGenre>();

    public virtual ICollection<SongGenre> SongGenres { get; set; } = new List<SongGenre>();
}
