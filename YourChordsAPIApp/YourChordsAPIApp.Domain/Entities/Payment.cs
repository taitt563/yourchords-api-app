using System;
using System.Collections.Generic;

namespace YourChordsAPIApp.Domain.Entities
{
    public partial class Payment
    {
        public int Id { get; set; }
        public DateTime? DatePayment { get; set; }
        public string? Method { get; set; }
        public int RequestId { get; set; }
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual Request Request { get; set; } = null!;
        public virtual UserAccount User { get; set; } = null!;
    }
}
