﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MilkBabyData.Models;

public partial class NET1702_PRN221_MilkBabyContext : DbContext
{
    public NET1702_PRN221_MilkBabyContext(DbContextOptions<NET1702_PRN221_MilkBabyContext> options)
        : base(options)
    {
    }

    public NET1702_PRN221_MilkBabyContext()
    {

    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

    public static string GetConnectionString(string connectionStringName)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        string connectionString = config.GetConnectionString(connectionStringName);
        return connectionString;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(GetConnectionString("DefaultConnection"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D852B73A12");

            entity.Property(e => e.CustomerId).ValueGeneratedNever();
            entity.Property(e => e.CustomerAddress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CustomerEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CustomerGender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CustomerImg).IsUnicode(false);
            entity.Property(e => e.CustomerName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CustomerNotes).HasColumnType("text");
            entity.Property(e => e.CustomerPassword)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CustomerPhone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BCF746CAC66");

            entity.Property(e => e.OrderId).ValueGeneratedNever();
            entity.Property(e => e.OrderBillingAddress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.OrderPaymentMethod)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OrderShippingAddress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.OrderShippingMethod)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OrderStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OrderTrackingNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Voucher).HasMaxLength(50);

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Orders__Customer__6B24EA82");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("PK__OrderIte__57ED0681FFA9E08A");

            entity.Property(e => e.OrderItemId).ValueGeneratedNever();
            entity.Property(e => e.Discount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Tax).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderItem__Order__6E01572D");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__OrderItem__Produ__6EF57B66");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6CD1012DD1F");

            entity.Property(e => e.ProductId).ValueGeneratedNever();
            entity.Property(e => e.ProductCategory)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProductDescription)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ProductDimensions)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ProductImg).IsUnicode(false);
            entity.Property(e => e.ProductName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ProductPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductWeight).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Vendor).WithMany(p => p.Products)
                .HasForeignKey(d => d.VendorId)
                .HasConstraintName("FK__Products__Vendor__66603565");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Reviews__74BC79CEFCCAF3B3");

            entity.Property(e => e.ReviewId).ValueGeneratedNever();
            entity.Property(e => e.ReviewImg).IsUnicode(false);
            entity.Property(e => e.ReviewText)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ReviewTitle)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Customer).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Reviews__Custome__72C60C4A");

            entity.HasOne(d => d.Product).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Reviews__Product__71D1E811");
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.HasKey(e => e.VendorId).HasName("PK__Vendors__FC8618F3A27CB264");

            entity.Property(e => e.VendorId).ValueGeneratedNever();
            entity.Property(e => e.VendorAddress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.VendorContactPerson)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.VendorEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.VendorName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.VendorNotes).HasColumnType("text");
            entity.Property(e => e.VendorPhone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.VendorWebsite)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}