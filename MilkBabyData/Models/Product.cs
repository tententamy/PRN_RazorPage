using System;
using System.Collections.Generic;

namespace MilkBabyData.Models;

public partial class Product
{
    public Guid ProductId { get; set; }

    public Guid? VendorId { get; set; }

    public string ProductName { get; set; } = null!;

    public string? ProductDescription { get; set; }

    public decimal? ProductPrice { get; set; }

    public int? ProductQuantity { get; set; }

    public DateOnly? ProductDateStart { get; set; }

    public DateOnly? ProductDateEnd { get; set; }

    public string? ProductCategory { get; set; }

    public string? ProductImg { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual Vendor? Vendor { get; set; }
}
