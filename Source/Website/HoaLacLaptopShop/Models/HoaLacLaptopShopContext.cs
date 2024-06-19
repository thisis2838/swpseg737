using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HoaLacLaptopShop.Models;

public partial class HoaLacLaptopShopContext : DbContext
{
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Brand> Brands { get; set; }
    public virtual DbSet<Laptop> Laptops { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<LaptopCPUSeries> LaptopCPUSeries { get; set; }
    public virtual DbSet<LaptopGPUSeries> LaptopGPUSeries { get; set; }
    public virtual DbSet<ProductImage> ProductImages { get; set; }
    public virtual DbSet<ProductReview> ProductReviews { get; set; }
    public virtual DbSet<NewsPost> NewsPosts { get; set; }
    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<OrderDetail> OrderDetails { get; set; }
    public virtual DbSet<Voucher> Vouchers { get; set; }

    public HoaLacLaptopShopContext()
    {
    }

    public HoaLacLaptopShopContext(DbContextOptions<HoaLacLaptopShopContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__Brands__3213E83FADFD3A46");

            entity.Property(e => e.ID).HasColumnName("id");
            entity.Property(e => e.Country).HasMaxLength(255).HasColumnName("country");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Laptop>(entity =>
        {
            entity.HasKey(e => e.ProductID).HasName("PK__Laptops__2D10D14AC18029F9");

            entity.Property(e => e.ProductID).ValueGeneratedNever().HasColumnName("productID");
            entity.Property(e => e.CPUSeriesID).HasColumnName("cpuSeries");
            entity.Property(e => e.GPUSeriesID).HasColumnName("gpuSeries");
            entity.Property(e => e.RAM).HasColumnName("ram");
            entity.Property(e => e.RefreshRate).HasColumnName("refreshRate");
            entity.Property(e => e.ScreenAspectRatio).HasMaxLength(20).IsUnicode(false).HasColumnName("screenAspectRatio");
            entity.Property(e => e.ScreenResolution).HasMaxLength(20).IsUnicode(false).HasColumnName("screenResolution");
            entity.Property(e => e.ScreenSize).HasColumnName("screenSize");
            entity.Property(e => e.StorageSize).HasColumnName("storageSize");
            entity.Property(e => e.StorageType).HasConversion<byte>().HasColumnName("storageType");

            entity.HasOne(d => d.CPUSeries).WithMany(p => p.Laptops)
                .HasForeignKey(d => d.CPUSeriesID)
                .HasConstraintName("FK__Laptops__cpuSeri__34C8D9D1");

            entity.HasOne(d => d.GPUSeries).WithMany(p => p.Laptops)
                .HasForeignKey(d => d.GPUSeriesID)
                .HasConstraintName("FK__Laptops__gpuSeri__35BCFE0A");

            entity.HasOne(d => d.Product).WithOne(p => p.Laptop)
                .HasForeignKey<Laptop>(d => d.ProductID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Laptops__product__33D4B598");
        });

        modelBuilder.Entity<LaptopCPUSeries>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__LaptopCP__3213E83F91A5ABDE");

            entity.ToTable("LaptopCPUSeries");

            entity.Property(e => e.ID).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.ManufacturerID).HasColumnName("manufacturerID");
            entity.Property(e => e.Name).HasColumnName("name");

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.LaptopCPUSeries)
                .HasForeignKey(d => d.ManufacturerID)
                .HasConstraintName("FK__LaptopCPU__manuf__2E1BDC42");
        });

        modelBuilder.Entity<LaptopGPUSeries>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__LaptopGP__3213E83F94E0AC02");

            entity.ToTable("LaptopGPUSeries");

            entity.Property(e => e.ID).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.ManufacturerID).HasColumnName("manufacturerID");
            entity.Property(e => e.Name).HasColumnName("name");

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.LaptopGPUSeries)
                .HasForeignKey(d => d.ManufacturerID)
                .HasConstraintName("FK__LaptopGPU__manuf__30F848ED");
        });

        modelBuilder.Entity<NewsPost>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__NewsPost__3213E83F70570594");

            entity.Property(e => e.ID).HasColumnName("id");
            entity.Property(e => e.AuthorId).HasColumnName("authorID");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.Time)
                .HasColumnType("datetime")
                .HasColumnName("time");
            entity.Property(e => e.Title).HasColumnName("title");

            entity.HasOne(d => d.Author).WithMany(p => p.NewsPosts)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK__NewsPosts__autho__46E78A0C");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__Orders__3213E83F06EE3152");

            entity.Property(e => e.ID).HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.BuyerID).HasColumnName("buyerID");
            entity.Property(e => e.CreationTime)
                .HasColumnType("datetime")
                .HasColumnName("creationTime");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.PaymentMethod).HasConversion<byte>().HasColumnName("paymentMethod");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.Status).HasConversion<byte>().HasColumnName("status");
            entity.Property(e => e.TotalPrice).HasColumnName("totalPrice");
            entity.Property(e => e.VoucherID).HasColumnName("voucherID");

            entity.HasOne(d => d.Buyer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.BuyerID)
                .HasConstraintName("FK__Orders__buyerID__3B75D760");

            entity.HasOne(d => d.Voucher).WithMany(p => p.Orders)
                .HasForeignKey(d => d.VoucherID)
                .HasConstraintName("FK__Orders__voucherI__3C69FB99");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ProductId }).HasName("PK__OrderDet__BAD83E698EBBE4D9");

            entity.Property(e => e.OrderId).HasColumnName("orderID");
            entity.Property(e => e.ProductId).HasColumnName("productID");
            entity.Property(e => e.Amount).HasColumnName("amount");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__order__3F466844");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__produ__403A8C7D");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__Products__3213E83FADA3C068");

            entity.Property(e => e.ID).HasColumnName("id");
            entity.Property(e => e.BrandId).HasColumnName("brandID");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IsLaptop).HasColumnName("isLaptop");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Stock).HasColumnName("stock");

            entity.HasOne(d => d.Brand).WithMany(p => p.Products)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("FK__Products__brandI__286302EC");
        });

        modelBuilder.Entity<ProductImage>(entity =>
        {
            entity.HasKey(e => new { e.ProductId, e.DisplayIndex }).HasName("PK__ProductI__0BA8325D28D0C147");

            entity.Property(e => e.ProductId).HasColumnName("productID");
            entity.Property(e => e.DisplayIndex).HasColumnName("displayIndex");
            entity.Property(e => e.Link).HasColumnName("link");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductImages)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductIm__produ__2B3F6F97");
        });

        modelBuilder.Entity<ProductReview>(entity =>
        {
            entity.HasKey(e => new { e.ProductId, e.ReviewerId }).HasName("PK__ProductR__D0B0ECA9C4398442");

            entity.ToTable("ProductReview");

            entity.Property(e => e.ProductId).HasColumnName("productID");
            entity.Property(e => e.ReviewerId).HasColumnName("reviewerID");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.Rating).HasColumnName("rating");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductReviews)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductRe__produ__4316F928");

            entity.HasOne(d => d.Reviewer).WithMany(p => p.ProductReviews)
                .HasForeignKey(d => d.ReviewerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductRe__revie__440B1D61");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__Users__3213E83FF649F4D9");

            entity.Property(e => e.ID).HasColumnName("id");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.PassHash)
                .HasMaxLength(32)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("passHash");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.Role).HasConversion<byte>().HasColumnName("role");
        });

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__Vouchers__3213E83FD53F6DFD");

            entity.Property(e => e.ID).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.DiscountValue).HasColumnName("discountValue");
            entity.Property(e => e.ExpiryDate).HasColumnName("expiryDate");
            entity.Property(e => e.IsPercentageDiscount).HasColumnName("isPercentageDiscount");
            entity.Property(e => e.IssuerId).HasColumnName("issuerID");
            entity.Property(e => e.MinimumOrderPrice).HasColumnName("minimumOrderPrice");

            entity.HasOne(d => d.Issuer).WithMany(p => p.Vouchers)
                .HasForeignKey(d => d.IssuerId)
                .HasConstraintName("FK__Vouchers__issuer__38996AB5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
