using System;
using System.Collections.Generic;

namespace MilkBabyData.Models;

public partial class Review
{
    public Guid ReviewId { get; set; }

    public Guid? ProductId { get; set; }

    public Guid? CustomerId { get; set; }

    public int? Rating { get; set; }

    public string? ReviewText { get; set; }

    public DateOnly? ReviewDate { get; set; }

    public string? ReviewImg { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Product? Product { get; set; }
}
