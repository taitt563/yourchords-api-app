using System;
using System.Collections.Generic;

namespace YourChordsAPIApp.Domain.Entities;

public partial class ChordType
{
    public int Id { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<Chord> Chords { get; set; } = new List<Chord>();
}
