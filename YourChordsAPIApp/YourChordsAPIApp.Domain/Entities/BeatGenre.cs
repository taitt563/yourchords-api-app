using System;
using System.Collections.Generic;

namespace YourChordsAPIApp.Domain.Entities
{
    public partial class BeatGenre
    {
        public int Id { get; set; }
        public int BeatId { get; set; }
        public int GenreId { get; set; }

        public virtual Beat Beat { get; set; } = null!;
        public virtual Genre Genre { get; set; } = null!;
    }
}
