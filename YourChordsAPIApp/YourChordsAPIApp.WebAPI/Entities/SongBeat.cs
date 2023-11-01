using System;
using System.Collections.Generic;

namespace YourChordsAPIApp.WebAPI.Entities;

public partial class SongBeat
{
    public int Id { get; set; }

    public int SongId { get; set; }

    public int BeatId { get; set; }

    public virtual Beat Beat { get; set; } = null!;

    public virtual Song Song { get; set; } = null!;
}
