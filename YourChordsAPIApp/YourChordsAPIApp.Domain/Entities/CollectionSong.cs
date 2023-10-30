using System;
using System.Collections.Generic;

namespace YourChordsAPIApp.Domain.Entities;

public partial class CollectionSong
{
    public int Id { get; set; }

    public int CollectionId { get; set; }

    public int SongId { get; set; }

    public DateTime DateAdded { get; set; }

    public virtual Collection Collection { get; set; } = null!;

    public virtual Song Song { get; set; } = null!;
}
