using System;
using System.Collections.Generic;

namespace YourChordsAPIApp.Domain.Entities;

public partial class BeatInstrument
{
    public int Id { get; set; }

    public int InstrumentId { get; set; }

    public int BeatId { get; set; }

    public virtual Beat Beat { get; set; } = null!;

    public virtual Instrument Instrument { get; set; } = null!;
}
