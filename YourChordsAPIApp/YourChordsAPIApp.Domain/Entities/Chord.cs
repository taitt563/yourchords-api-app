using System;
using System.Collections.Generic;

namespace YourChordsAPIApp.Domain.Entities
{
    public partial class Chord
    {
        public Chord()
        {
            SongChords = new HashSet<SongChord>();
        }

        public int Id { get; set; }
        public string ChordName { get; set; } = null!;
        public string? Notation { get; set; }
        public string? Components { get; set; }
        public int TypeId { get; set; }
        public int InstrumentId { get; set; }
        public string? Tone { get; set; }
        public string? ChordDiagram { get; set; }
        public string? VideoLink { get; set; }
        public string? ChordSound { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsVerified { get; set; }
        public bool IsDeleted { get; set; }

        public virtual UserAccount? CreatedByNavigation { get; set; }
        public virtual Instrument Instrument { get; set; } = null!;
        public virtual ChordType Type { get; set; } = null!;
        public virtual ICollection<SongChord> SongChords { get; set; }
    }
}
