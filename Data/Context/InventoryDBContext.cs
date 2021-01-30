using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Inventory.Domain.Model;
#nullable disable

namespace Inventory.Data.Context
{
    public partial class InventoryDBContext : DbContext
    {
        public InventoryDBContext()
        {
        }

        public InventoryDBContext(DbContextOptions<InventoryDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Almacen> Almacenes { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<Ubicacion> Ubicaciones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\;Database=INVENTARIO;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Almacen>(entity =>
            {
                entity.HasKey(e => e.AlmacenId);

                entity.ToTable("ALMACENES", "WEBAP");

                entity.Property(e => e.AlmacenId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ALMACEN_ID");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("ITEMS", "WEBAP");

                entity.Property(e => e.ItemId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ITEM_ID");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasKey(e => new { e.ItemId, e.UbicacionId, e.AlmacenId });

                entity.ToTable("STOCK", "WEBAP");

                entity.Property(e => e.ItemId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ITEM_ID");

                entity.Property(e => e.UbicacionId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("UBICACION_ID");

                entity.Property(e => e.AlmacenId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ALMACEN_ID");

                entity.Property(e => e.Cantidad)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CANTIDAD");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK_STOCK_ITEMS");

                entity.HasOne(d => d.Ubicacione)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => new { d.UbicacionId, d.AlmacenId })
                    .HasConstraintName("FK_STOCK_UBICACIONES");
            });

            modelBuilder.Entity<Ubicacion>(entity =>
            {
                entity.HasKey(e => new { e.UbicacionId, e.AlmacenId });

                entity.ToTable("UBICACIONES", "WEBAP");

                entity.Property(e => e.UbicacionId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("UBICACION_ID");

                entity.Property(e => e.AlmacenId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ALMACEN_ID");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.HasOne(d => d.Almacen)
                    .WithMany(p => p.Ubicaciones)
                    .HasForeignKey(d => d.AlmacenId)
                    .HasConstraintName("FK_UBICACIONES_ALMACENES");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
