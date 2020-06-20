using System;
using InvoiceSystem.Application.Interfaces;
using InvoiceSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InvoiceSystem.Infrastructure.Persistance
{
    public partial class InvoiceSystemDbContext : DbContext //, IApplicationDbContext
    {
        public InvoiceSystemDbContext()
        {
        }

        public InvoiceSystemDbContext(DbContextOptions<InvoiceSystemDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<InvoiceItems> InvoiceItems { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Stores> Stores { get; set; }
        public virtual DbSet<Units> Units { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=InvoiceSystemDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.Property(e => e.InvoiceDate).HasColumnType("datetime");

                entity.Property(e => e.InvoiceNo).HasMaxLength(100);

                entity.Property(e => e.NetPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_Invoice_Stores");
            });

            modelBuilder.Entity<InvoiceItems>(entity =>
            {
                entity.Property(e => e.NetPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.InvoiceItems)
                    .HasForeignKey(d => d.UnitId)
                    .HasConstraintName("FK_InvoiceItems_Units");
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.Property(e => e.ItemName).HasMaxLength(100);

                entity.Property(e => e.ItemQty).HasMaxLength(100);
            });

            modelBuilder.Entity<Stores>(entity =>
            {
                entity.Property(e => e.StoreName).HasMaxLength(100);
            });

            modelBuilder.Entity<Units>(entity =>
            {
                entity.Property(e => e.UnitName).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
