using System;
using System.Collections.Generic;
using System.Configuration;
using HoaLacLaptopShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace HoaLacLaptopShop.Data;

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
        const int VERY_SHORT_TEXT_LENGTH = 20;
        const int SHORT_TEXT_LENGTH = 256;
        const int MEDIUM_TEXT_LENGTH = 1024;
        const int LONG_TEXT_LENGTH = 2048;

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.ID);
            entity.ToTable("Brands");
            entity.HasIndex(e => e.Name).IsUnique();

            entity.Property(e => e.ID).HasColumnName("id");
            entity.Property(e => e.Name).HasMaxLength(SHORT_TEXT_LENGTH).HasColumnName("name");
            entity.Property(e => e.Country).HasMaxLength(SHORT_TEXT_LENGTH).HasColumnName("country");
            entity.Property(e => e.Description).HasMaxLength(MEDIUM_TEXT_LENGTH).HasColumnName("description");
        });

        modelBuilder.Entity<Laptop>(entity =>
        {
            entity.HasKey(e => e.ProductID);
            entity.ToTable("Laptops");

            entity.Property(e => e.ProductID).ValueGeneratedNever().HasColumnName("productID");
            entity.Property(e => e.CPUSeriesID).HasColumnName("cpuSeries");
            entity.Property(e => e.GPUSeriesID).HasColumnName("gpuSeries");
            entity.Property(e => e.ScreenSize).HasColumnName("screenSize");
            entity.Property(e => e.ScreenAspectRatio).HasMaxLength(VERY_SHORT_TEXT_LENGTH).IsUnicode(false).HasColumnName("screenAspectRatio");
            entity.Property(e => e.ScreenResolution).HasMaxLength(VERY_SHORT_TEXT_LENGTH).IsUnicode(false).HasColumnName("screenResolution");
            entity.Property(e => e.StorageType).HasConversion<byte>().HasColumnName("storageType");
            entity.Property(e => e.StorageSize).HasColumnName("storageSize");
            entity.Property(e => e.RefreshRate).HasColumnName("refreshRate");
            entity.Property(e => e.RAM).HasColumnName("ram");

            entity.HasOne(d => d.CPUSeries).WithMany(p => p.Laptops).HasForeignKey(d => d.CPUSeriesID);
            entity.HasOne(d => d.GPUSeries).WithMany(p => p.Laptops).HasForeignKey(d => d.GPUSeriesID);
            entity.HasOne(d => d.Product).WithOne(p => p.Laptop).HasForeignKey<Laptop>(d => d.ProductID).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<LaptopCPUSeries>(entity =>
        {
            entity.HasKey(e => e.ID);
            entity.ToTable("LaptopCPUSeries");

            entity.Property(e => e.ID).HasColumnName("id");
            entity.Property(e => e.ManufacturerID).HasColumnName("manufacturerID");
            entity.Property(e => e.Name).HasMaxLength(SHORT_TEXT_LENGTH).HasColumnName("name");

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.LaptopCPUSeries).HasForeignKey(d => d.ManufacturerID);
        });

        modelBuilder.Entity<LaptopGPUSeries>(entity =>
        {
            entity.HasKey(e => e.ID);
            entity.ToTable("LaptopGPUSeries");

            entity.Property(e => e.ID).HasColumnName("id");
            entity.Property(e => e.ManufacturerID).HasColumnName("manufacturerID");
            entity.Property(e => e.Name).HasMaxLength(SHORT_TEXT_LENGTH).HasColumnName("name");

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.LaptopGPUSeries).HasForeignKey(d => d.ManufacturerID);
        });

        modelBuilder.Entity<NewsPost>(entity =>
        {
            entity.HasKey(e => e.ID);
            entity.ToTable("NewsPosts");

            entity.Property(e => e.ID).HasColumnName("id");
            entity.Property(e => e.AuthorId).HasColumnName("authorID");
            entity.Property(e => e.Token).HasMaxLength(SHORT_TEXT_LENGTH).IsUnicode(false).HasColumnName("token");
            entity.Property(e => e.Time).HasColumnType("datetime").HasColumnName("postTime");
            entity.Property(e => e.Title).HasMaxLength(SHORT_TEXT_LENGTH).HasColumnName("title");
            entity.Property(e => e.WordCount).HasColumnName("wordCount");
            entity.Property(e => e.ImageCount).HasColumnName("imageCount");
            entity.Property(e => e.ReadingTime).HasColumnName("readingTime");

            entity.HasOne(d => d.Author).WithMany(p => p.NewsPosts).HasForeignKey(d => d.AuthorId);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.ID);
            entity.ToTable("Orders");

            entity.Property(e => e.ID).HasColumnName("id");
            entity.Property(e => e.BuyerID).HasColumnName("buyerID");
            entity.Property(e => e.Status).HasConversion<byte>().HasColumnName("status");
            entity.Property(e => e.OrderTime).HasColumnType("datetime").HasColumnName("orderTime");
            entity.Property(e => e.Province).HasMaxLength(SHORT_TEXT_LENGTH).HasColumnName("province");
            entity.Property(e => e.District).HasMaxLength(SHORT_TEXT_LENGTH).HasColumnName("district");
            entity.Property(e => e.Ward).HasMaxLength(SHORT_TEXT_LENGTH).HasColumnName("ward");
            entity.Property(e => e.Street).HasMaxLength(SHORT_TEXT_LENGTH).HasColumnName("street");
            entity.Property(e => e.RecipientName).HasMaxLength(SHORT_TEXT_LENGTH).HasColumnName("recipientName");
            entity.Property(e => e.PhoneNumber).HasMaxLength(VERY_SHORT_TEXT_LENGTH).IsUnicode(false).HasColumnName("phoneNumber");
            entity.Property(e => e.Note).HasMaxLength(MEDIUM_TEXT_LENGTH).HasColumnName("note");
            entity.Property(e => e.TotalPrice).HasColumnType("money").HasColumnName("totalPrice");
            entity.Property(e => e.DiscountedPrice).HasColumnType("money").HasColumnName("discountedPrice");
            entity.Property(e => e.PaymentMethod).HasConversion<byte>().HasColumnName("paymentMethod");
            entity.Property(e => e.VoucherID).HasColumnName("voucherID");

            entity.HasOne(d => d.Buyer).WithMany(p => p.Orders).HasForeignKey(d => d.BuyerID);
            entity.HasOne(d => d.Voucher).WithMany(p => p.Orders).HasForeignKey(d => d.VoucherID);
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ProductId });
            entity.ToTable("OrderDetails");

            entity.Property(e => e.OrderId).HasColumnName("orderID");
            entity.Property(e => e.ProductId).HasColumnName("productID");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.ProductPrice).HasColumnName("productPrice");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails).HasForeignKey(d => d.OrderId).OnDelete(DeleteBehavior.ClientSetNull);
            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails).HasForeignKey(d => d.ProductId).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ID);
            entity.ToTable("Products");

            entity.Property(e => e.ID).HasColumnName("id");
            entity.Property(e => e.BrandId).HasColumnName("brandID");
            entity.Property(e => e.Name).HasMaxLength(SHORT_TEXT_LENGTH).HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Stock).HasColumnName("stock");
            entity.Property(e => e.Description).HasMaxLength(LONG_TEXT_LENGTH).HasColumnName("description");
            entity.Property(e => e.IsDisabled).HasColumnName("isDisabled");
            entity.Property(e => e.IsLaptop).HasColumnName("isLaptop");
            entity.Property(e => e.ReviewCount).HasColumnName("reviewCount");
            entity.Property(e => e.ReviewTotal).HasColumnName("reviewTotal");
            entity.Property(e => e.RowVersion).HasColumnName("rowVersion").IsRowVersion();

            entity.HasOne(d => d.Brand).WithMany(p => p.Products).HasForeignKey(d => d.BrandId);
        });

        modelBuilder.Entity<ProductImage>(entity =>
        {
            entity.HasKey(e => new { e.ProductId, e.DisplayIndex });
            entity.ToTable("ProductImages");

            entity.Property(e => e.ProductId).HasColumnName("productID");
            entity.Property(e => e.DisplayIndex).HasColumnName("displayIndex");
            entity.Property(e => e.Token).IsUnicode(false).HasMaxLength(SHORT_TEXT_LENGTH).HasColumnName("token");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductImages).HasForeignKey(d => d.ProductId).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ProductReview>(entity =>
        {
            entity.HasKey(e => new { e.ProductId, e.ReviewerId });
            entity.ToTable("ProductReviews");

            entity.Property(e => e.ProductId).HasColumnName("productID");
            entity.Property(e => e.ReviewerId).HasColumnName("reviewerID");
            entity.Property(e => e.ReviewTime).HasColumnName("reviewTime");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Content).HasMaxLength(MEDIUM_TEXT_LENGTH).HasColumnName("content");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductReviews).HasForeignKey(d => d.ProductId).OnDelete(DeleteBehavior.ClientSetNull);
            entity.HasOne(d => d.Reviewer).WithMany(p => p.ProductReviews).HasForeignKey(d => d.ReviewerId).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.ID);
            entity.HasIndex(e => e.Email).IsUnique();
            entity.ToTable("Users");

            entity.Property(e => e.ID).HasColumnName("id");
            entity.Property(e => e.Name).HasMaxLength(SHORT_TEXT_LENGTH).HasColumnName("name");
            entity.Property(e => e.Email).HasMaxLength(SHORT_TEXT_LENGTH).HasColumnName("email");
            entity.Property(e => e.PassHash).HasMaxLength(SHORT_TEXT_LENGTH).IsUnicode(false).IsFixedLength().HasColumnName("passHash");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.PhoneNumber).HasMaxLength(VERY_SHORT_TEXT_LENGTH).IsUnicode(false).HasColumnName("phoneNumber");
            entity.Property(e => e.IsSales).HasColumnName("isSales");
            entity.Property(e => e.IsMarketing).HasColumnName("isMarketing");
            entity.Property(e => e.IsAdmin).HasColumnName("isAdmin");
            entity.Property(e => e.IsDisabled).HasColumnName("isDisabled");
        });

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.HasKey(e => e.ID);
            entity.ToTable("Vouchers");
            entity.HasIndex(e => e.Code).IsUnique();

            entity.Property(e => e.ID).HasColumnName("id");
            entity.Property(e => e.IssuerId).HasColumnName("issuerID");
            entity.Property(e => e.Code).HasMaxLength(VERY_SHORT_TEXT_LENGTH).IsUnicode(false).HasColumnName("code");
            entity.Property(e => e.MinimumOrderPrice).HasColumnType("money").HasColumnName("minimumOrderPrice");
            entity.Property(e => e.DiscountValue).HasColumnType("money").HasColumnName("discountValue");
            entity.Property(e => e.IsPercentageDiscount).HasColumnName("isPercentageDiscount");
            entity.Property(e => e.ExpiryDate).HasColumnName("expiryDate");
            entity.Property(e => e.IsDisabled).HasColumnName("isDisabled");

            entity.HasOne(d => d.Issuer).WithMany(p => p.Vouchers).HasForeignKey(d => d.IssuerId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
