using System;
using System.Collections.Generic;
using Entidades.Models;
using Microsoft.EntityFrameworkCore;

namespace Entidades.Context;

public partial class PracticaContext : DbContext
{
    public PracticaContext()
    {
    }

    public PracticaContext(DbContextOptions<PracticaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CabFact> CabFacts { get; set; }

    public virtual DbSet<DetFact> DetFacts { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CabFact>(entity =>
        {
            entity.HasKey(e => e.IdFactura).HasName("PK__CAB_FACT__4A921BED88C9BADC");

            entity.ToTable("CAB_FACT");

            entity.Property(e => e.IdFactura).HasColumnName("ID_FACTURA");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_CREACION");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");
            entity.Property(e => e.Identificacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("IDENTIFICACION");
            entity.Property(e => e.Iva)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("IVA");
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_CLIENTE");
            entity.Property(e => e.SubTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("SUB_TOTAL");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TELEFONO");
            entity.Property(e => e.Total)
                .HasComputedColumnSql("([SUB_TOTAL]+[IVA])", true)
                .HasColumnType("decimal(11, 2)")
                .HasColumnName("TOTAL");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.CabFacts)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__CAB_FACT__ID_USU__4E88ABD4");
        });

        modelBuilder.Entity<DetFact>(entity =>
        {
            entity.HasKey(e => e.IdDetFact).HasName("PK__DET_FACT__DB7964826AEAEBB8");

            entity.ToTable("DET_FACT");

            entity.Property(e => e.IdDetFact).HasColumnName("ID_DET_FACT");
            entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");
            entity.Property(e => e.IdFactura).HasColumnName("ID_FACTURA");
            entity.Property(e => e.IdProducto).HasColumnName("ID_PRODUCTO");

            entity.HasOne(d => d.IdFacturaNavigation).WithMany(p => p.DetFacts)
                .HasForeignKey(d => d.IdFactura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DET_FACT__ID_FAC__5165187F");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetFacts)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DET_FACT__ID_PRO__52593CB8");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PRODUCTO__3214EC27E28BDE65");

            entity.ToTable("PRODUCTOS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ESTADO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PRECIO");
            entity.Property(e => e.Stock).HasColumnName("STOCK");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__USUARIOS__91136B90208DD43E");

            entity.ToTable("USUARIOS");

            entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");
            entity.Property(e => e.CodigoUsuario)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CODIGO_USUARIO");
            entity.Property(e => e.Contrasenia)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CONTRASENIA");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ESTADO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
