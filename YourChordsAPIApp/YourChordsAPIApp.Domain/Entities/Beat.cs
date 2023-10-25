using System;
using System.Collections.Generic;

namespace YourChordsAPIApp.Domain.Entities
{
    public partial class Beat
    {
        public Beat()
        {
            BeatGenres = new HashSet<BeatGenre>();
            BeatInstruments = new HashSet<BeatInstrument>();
            RequestBeats = new HashSet<RequestBeat>();
            SongBeats = new HashSet<SongBeat>();
        }

        public int Id { get; set; }
        public string BeatName { get; set; } = null!;
        public string? Description { get; set; }
        public string? AudioLink { get; set; }
        public string Tone { get; set; } = null!;
        public int Tempo { get; set; }
        public int Duration { get; set; }
        public decimal Price { get; set; }
        public DateTime DateReleased { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsSold { get; set; }
        public bool IsPrivate { get; set; }

        public virtual UserAccount CreatedByNavigation { get; set; } = null!;
        public virtual ICollection<BeatGenre> BeatGenres { get; set; }
        public virtual ICollection<BeatInstrument> BeatInstruments { get; set; }
        public virtual ICollection<RequestBeat> RequestBeats { get; set; }
        public virtual ICollection<SongBeat> SongBeats { get; set; }
    }
}
