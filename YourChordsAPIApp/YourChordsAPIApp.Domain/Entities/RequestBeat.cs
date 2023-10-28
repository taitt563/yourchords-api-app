using System;
using System.Collections.Generic;

namespace YourChordsAPIApp.Domain.Entities
{
    public partial class RequestBeat
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public int BeatId { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }

        public virtual Beat Beat { get; set; } = null!;
        public virtual Request Request { get; set; } = null!;
    }
}
