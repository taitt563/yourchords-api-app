using System;
using System.Collections.Generic;

namespace YourChordsAPIApp.WebAPI.Entities;

public partial class OrderDetail
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int BeatId { get; set; }

    public string? Description { get; set; }

    public int Quantity { get; set; }

    public virtual Beat Beat { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
