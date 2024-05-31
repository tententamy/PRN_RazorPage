using System;
using System.Collections.Generic;

namespace MilkBabyData.Models;

public partial class Vendor
{
    public Guid VendorId { get; set; }

    public string VendorName { get; set; } = null!;

    public string? VendorAddress { get; set; }

    public string? VendorPhone { get; set; }

    public string? VendorEmail { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
