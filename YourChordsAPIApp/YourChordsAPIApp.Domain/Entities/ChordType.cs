using System;
using System.Collections.Generic;

namespace YourChordsAPIApp.Domain.Entities
{
    public partial class ChordType
    {
        public ChordType()
        {
            Chords = new HashSet<Chord>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Chord> Chords { get; set; }
    }
}
