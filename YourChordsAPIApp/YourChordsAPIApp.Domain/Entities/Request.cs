using System;
using System.Collections.Generic;

namespace YourChordsAPIApp.Domain.Entities
{
    public partial class Request
    {
        public Request()
        {
            Payments = new HashSet<Payment>();
            RequestBeats = new HashSet<RequestBeat>();
        }

        public int Id { get; set; }
        public string TransactionIdCustomer { get; set; } = null!;
        public string TransactionIdMusician { get; set; } = null!;
        public int OrderId { get; set; }
        public int UserId { get; set; }

        public virtual UserAccount User { get; set; } = null!;
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<RequestBeat> RequestBeats { get; set; }
    }
}
