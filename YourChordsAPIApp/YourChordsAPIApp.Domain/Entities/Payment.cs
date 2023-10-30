using System;
using System.Collections.Generic;

namespace YourChordsAPIApp.Domain.Entities;

public partial class Payment
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int OrderId { get; set; }

    public DateTime PaymentDate { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public decimal PaymentAmount { get; set; }

    public int PaymentStatus { get; set; }

    public string? Notes { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual UserAccount User { get; set; } = null!;
}
