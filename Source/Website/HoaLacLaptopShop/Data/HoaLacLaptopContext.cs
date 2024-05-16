using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HoaLacLaptopShop.Data;

public partial class HoaLacLaptopContext : DbContext
{
    public HoaLacLaptopContext()
    {
    }

    public HoaLacLaptopContext(DbContextOptions<HoaLacLaptopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asset> Assets { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Laptop> Laptops { get; set; }

    public virtual DbSet<LaptopCpuseries> LaptopCpuseries { get; set; }

    public virtual DbSet<LaptopGpuseries> LaptopGpuseries { get; set; }

    public virtual DbSet<NewsPost> NewsPosts { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductImage> ProductImages { get; set; }

    public virtual DbSet<ProductReview> ProductReviews { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Voucher> Vouchers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LEKHANG;Initial Catalog=HoaLacLaptop;User ID=sa;Password=sa;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asset>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Assets__3213E83F154A50D5");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ProductId).HasColumnName("productID");

            entity.HasOne(d => d.Product).WithMany(p => p.Assets)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Assets__productI__3C69FB99");
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Brands__3213E83FF54E9F86");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Country)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("country");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Laptop>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Laptops__2D10D14A5CAD96CA");

            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("productID");
            entity.Property(e => e.CpuSeries).HasColumnName("cpuSeries");
            entity.Property(e => e.GpuSeries).HasColumnName("gpuSeries");
            entity.Property(e => e.Ram).HasColumnName("ram");
            entity.Property(e => e.RefreshRate).HasColumnName("refreshRate");
            entity.Property(e => e.ScreenAspectRatio)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("screenAspectRatio");
            entity.Property(e => e.ScreenResolution)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("screenResolution");
            entity.Property(e => e.ScreenSize).HasColumnName("screenSize");
            entity.Property(e => e.StorageSize).HasColumnName("storageSize");
            entity.Property(e => e.StorageType)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("storageType");

            entity.HasOne(d => d.CpuSeriesNavigation).WithMany(p => p.Laptops)
                .HasForeignKey(d => d.CpuSeries)
                .HasConstraintName("FK__Laptops__cpuSeri__38996AB5");

            entity.HasOne(d => d.GpuSeriesNavigation).WithMany(p => p.Laptops)
                .HasForeignKey(d => d.GpuSeries)
                .HasConstraintName("FK__Laptops__gpuSeri__398D8EEE");

            entity.HasOne(d => d.Product).WithOne(p => p.Laptop)
                .HasForeignKey<Laptop>(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Laptops__product__37A5467C");
        });

        modelBuilder.Entity<LaptopCpuseries>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LaptopCP__3213E83F5CDCEE0C");

            entity.ToTable("LaptopCPUSeries");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.ManufacturerId).HasColumnName("manufacturerID");
            entity.Property(e => e.Name).HasColumnName("name");

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.LaptopCpuseries)
                .HasForeignKey(d => d.ManufacturerId)
                .HasConstraintName("FK__LaptopCPU__manuf__31EC6D26");
        });

        modelBuilder.Entity<LaptopGpuseries>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LaptopGP__3213E83F56F82956");

            entity.ToTable("LaptopGPUSeries");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.ManufacturerId).HasColumnName("manufacturerID");
            entity.Property(e => e.Name).HasColumnName("name");

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.LaptopGpuseries)
                .HasForeignKey(d => d.ManufacturerId)
                .HasConstraintName("FK__LaptopGPU__manuf__34C8D9D1");
        });

        modelBuilder.Entity<NewsPost>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NewsPost__3213E83F1DEBC74C");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Author).HasColumnName("author");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.Time)
                .HasColumnType("datetime")
                .HasColumnName("time");
            entity.Property(e => e.Title).HasColumnName("title");

            entity.HasOne(d => d.AuthorNavigation).WithMany(p => p.NewsPosts)
                .HasForeignKey(d => d.Author)
                .HasConstraintName("FK__NewsPosts__autho__46E78A0C");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3213E83FFE8E82D1");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.AssetId).HasColumnName("assetID");
            entity.Property(e => e.BuyerId).HasColumnName("buyerID");
            entity.Property(e => e.CreationTime)
                .HasColumnType("datetime")
                .HasColumnName("creationTime");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.PaymentMethod).HasColumnName("paymentMethod");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TotalPrice).HasColumnName("totalPrice");
            entity.Property(e => e.VoucherId).HasColumnName("voucherID");

            entity.HasOne(d => d.Asset).WithMany(p => p.Orders)
                .HasForeignKey(d => d.AssetId)
                .HasConstraintName("FK__Orders__assetID__4316F928");

            entity.HasOne(d => d.Buyer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.BuyerId)
                .HasConstraintName("FK__Orders__buyerID__4222D4EF");

            entity.HasOne(d => d.Voucher).WithMany(p => p.Orders)
                .HasForeignKey(d => d.VoucherId)
                .HasConstraintName("FK__Orders__voucherI__440B1D61");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3213E83F1DDBBC73");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BrandId).HasColumnName("brandID");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IsLaptop).HasColumnName("isLaptop");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");

            entity.HasOne(d => d.Brand).WithMany(p => p.Products)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("FK__Products__brandI__286302EC");
        });

        modelBuilder.Entity<ProductImage>(entity =>
        {
            entity.HasKey(e => new { e.ProductId, e.ImageIndex }).HasName("PK__ProductI__122862B012C4BDCD");

            entity.Property(e => e.ProductId).HasColumnName("productID");
            entity.Property(e => e.ImageIndex).HasColumnName("imageIndex");
            entity.Property(e => e.Link).HasColumnName("link");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductImages)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductIm__produ__2B3F6F97");
        });

        modelBuilder.Entity<ProductReview>(entity =>
        {
            entity.HasKey(e => new { e.ProductId, e.UserId }).HasName("PK__ProductR__C1A97087B61E6045");

            entity.ToTable("ProductReview");

            entity.Property(e => e.ProductId).HasColumnName("productID");
            entity.Property(e => e.UserId).HasColumnName("userID");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Time)
                .HasColumnType("datetime")
                .HasColumnName("time");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductReviews)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductRe__produ__2E1BDC42");

            entity.HasOne(d => d.User).WithMany(p => p.ProductReviews)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductRe__userI__2F10007B");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3213E83F0B8E5CA9");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.PassHash)
                .HasMaxLength(32)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("passHash");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("phoneNumber");
            entity.Property(e => e.Role).HasColumnName("role");
        });

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vouchers__3213E83FBF442645");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.DiscountValue).HasColumnName("discountValue");
            entity.Property(e => e.ExpiryDate).HasColumnName("expiryDate");
            entity.Property(e => e.IsPercentageDiscount).HasColumnName("isPercentageDiscount");
            entity.Property(e => e.IssuerId).HasColumnName("issuerID");
            entity.Property(e => e.MinimumOrderPrice).HasColumnName("minimumOrderPrice");

            entity.HasOne(d => d.Issuer).WithMany(p => p.Vouchers)
                .HasForeignKey(d => d.IssuerId)
                .HasConstraintName("FK__Vouchers__issuer__3F466844");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
