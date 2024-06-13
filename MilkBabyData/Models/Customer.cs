﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace MilkBabyData.Models;

public partial class Customer
{
    public Guid CustomerId { get; set; }

    public string CustomerName { get; set; }

    public string CustomerEmail { get; set; }

    public string CustomerPhone { get; set; }

    public string CustomerAddress { get; set; }

    public string CustomerPassword { get; set; }

    public string CustomerImg { get; set; }

    public DateOnly? CustomerBirthDate { get; set; }

    public string CustomerGender { get; set; }

    public string CustomerStatus { get; set; }

    public DateOnly? CustomerCreatedDate { get; set; }

    public DateOnly? CustomerUpdatedDate { get; set; }

    public string CustomerNotes { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}