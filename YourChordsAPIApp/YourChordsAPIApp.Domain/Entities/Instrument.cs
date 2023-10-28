using System;
using System.Collections.Generic;

namespace YourChordsAPIApp.Domain.Entities
{
    public partial class Instrument
    {
        public Instrument()
        {
            BeatInstruments = new HashSet<BeatInstrument>();
            Chords = new HashSet<Chord>();
        }

        public int Id { get; set; }
        public string InstrumentName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool Status { get; set; }

        public virtual ICollection<BeatInstrument> BeatInstruments { get; set; }
        public virtual ICollection<Chord> Chords { get; set; }
    }
}
