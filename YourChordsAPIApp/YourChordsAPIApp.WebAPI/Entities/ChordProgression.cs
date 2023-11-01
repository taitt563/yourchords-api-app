using System;
using System.Collections.Generic;

namespace YourChordsAPIApp.WebAPI.Entities;

public partial class ChordProgression
{
    public int Id { get; set; }

    public int SongId { get; set; }

    public int ChordId { get; set; }

    public virtual Chord Chord { get; set; } = null!;

    public virtual Song Song { get; set; } = null!;
}
