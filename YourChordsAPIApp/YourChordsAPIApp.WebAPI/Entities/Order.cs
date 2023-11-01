using System;
using System.Collections.Generic;

namespace YourChordsAPIApp.WebAPI.Entities;

public partial class Order
{
    public int Id { get; set; }

    public DateTime DateOrder { get; set; }

    public int UserId { get; set; }

    public bool Status { get; set; }

    public string VoiceRecord { get; set; } = null!;

    public decimal TotalPrice { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual UserAccount User { get; set; } = null!;
}
