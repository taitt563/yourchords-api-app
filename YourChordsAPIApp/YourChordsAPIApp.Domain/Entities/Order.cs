using System;
using System.Collections.Generic;

namespace YourChordsAPIApp.Domain.Entities
{
    public partial class Order
    {
        public int Id { get; set; }
        public DateTime DateOrder { get; set; }
        public int UserId { get; set; }
        public bool Status { get; set; }
        public string VoiceRecord { get; set; } = null!;
        public decimal TotalPrice { get; set; }
    }
}
