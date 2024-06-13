﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace MilkBabyData.Models;

public partial class OrderItem
{
    public Guid OrderItemId { get; set; }

    public Guid? OrderId { get; set; }

    public Guid? ProductId { get; set; }

    public int? Quantity { get; set; }

    public decimal? Price { get; set; }

    public decimal? Discount { get; set; }

    public decimal? Tax { get; set; }

    public decimal? TotalPrice { get; set; }

    public string OrderItemStatus { get; set; }

    public DateOnly? OrderItemCreatedDate { get; set; }

    public DateOnly? OrderItemUpdatedDate { get; set; }

    public virtual Order Order { get; set; }

    public virtual Product Product { get; set; }
}