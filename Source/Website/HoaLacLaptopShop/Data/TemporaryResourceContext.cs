using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace HoaLacLaptopShop.Models;

public partial class TemporaryResourceContext : DbContext
{
    public virtual DbSet<TemporaryResource> Resources { get; set; }

    public TemporaryResourceContext()
    {
    }
    public TemporaryResourceContext(DbContextOptions<TemporaryResourceContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TemporaryResource>(entity =>
        {
            entity.ToTable("TempResources");
            entity.HasKey(x => x.ID);

            entity.Property(x => x.ID).HasColumnName("id").IsUnicode(false);
            entity.Property(x => x.Extension).HasColumnName("extension").IsUnicode(false);
            entity.Property(x => x.Length).HasColumnName("length");
            entity.Property(x => x.Bag).HasColumnName("bag").IsUnicode(false);
            entity.Property(x => x.UploaderID).HasColumnName("uploaderID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
