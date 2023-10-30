using System;
using System.Collections.Generic;

namespace YourChordsAPIApp.Domain.Entities;

public partial class Chord
{
    public int Id { get; set; }

    public string ChordName { get; set; } = null!;

    public string Notation { get; set; } = null!;

    public string Components { get; set; } = null!;

    public int TypeId { get; set; }

    public int InstrumentId { get; set; }

    public string Tone { get; set; } = null!;

    public string ChordDiagram { get; set; } = null!;

    public string? ExternalLink { get; set; }

    public string? ChordSound { get; set; }

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public int? LastModifiedBy { get; set; }

    public bool IsPrivate { get; set; }

    public bool IsVerified { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<ChordProgression> ChordProgressions { get; set; } = new List<ChordProgression>();

    public virtual UserAccount CreatedByNavigation { get; set; } = null!;

    public virtual Instrument Instrument { get; set; } = null!;

    public virtual ChordType Type { get; set; } = null!;
}
