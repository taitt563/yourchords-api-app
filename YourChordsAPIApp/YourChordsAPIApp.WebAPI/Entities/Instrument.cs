using System;
using System.Collections.Generic;

namespace YourChordsAPIApp.WebAPI.Entities;

public partial class Instrument
{
    public int Id { get; set; }

    public string InstrumentName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool Status { get; set; }

    public virtual ICollection<BeatInstrument> BeatInstruments { get; set; } = new List<BeatInstrument>();

    public virtual ICollection<Chord> Chords { get; set; } = new List<Chord>();
}
