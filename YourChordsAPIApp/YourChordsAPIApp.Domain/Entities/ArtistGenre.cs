using System;
using System.Collections.Generic;

namespace YourChordsAPIApp.Domain.Entities;

public partial class ArtistGenre
{
    public int Id { get; set; }

    public int ArtistId { get; set; }

    public int GenreId { get; set; }

    public virtual Artist Artist { get; set; } = null!;

    public virtual Genre Genre { get; set; } = null!;
}
