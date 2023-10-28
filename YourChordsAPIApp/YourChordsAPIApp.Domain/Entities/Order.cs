using System;
using System.Collections.Generic;

namespace YourChordsAPIApp.Domain.Entities
{
    public partial class Order
    {
        public Order()
        {
            Requests = new HashSet<Request>();
        }

        public int Id { get; set; }
        public DateTime DateOrder { get; set; }
        public int UserId { get; set; }
        public bool Status { get; set; }
        public string VoiceRecord { get; set; } = null!;
        public decimal TotalPrice { get; set; }

        public virtual UserAccount User { get; set; } = null!;
        public virtual ICollection<Request> Requests { get; set; }
    }
}
