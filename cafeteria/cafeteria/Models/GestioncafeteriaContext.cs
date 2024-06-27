using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace cafeteria.Models;

public partial class GestioncafeteriaContext : DbContext
{
    public GestioncafeteriaContext()
    {
    }

    public GestioncafeteriaContext(DbContextOptions<GestioncafeteriaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TCategoria> TCategorias { get; set; }

    public virtual DbSet<TEstadoProducto> TEstadoProductos { get; set; }

    public virtual DbSet<TGenero> TGeneros { get; set; }

    public virtual DbSet<TProducto> TProductos { get; set; }

    public virtual DbSet<TProductosxVenta> TProductosxVentas { get; set; }

    public virtual DbSet<TProductoxProveedore> TProductoxProveedores { get; set; }

    public virtual DbSet<TProveedore> TProveedores { get; set; }

    public virtual DbSet<TRole> TRoles { get; set; }

    public virtual DbSet<TTiposDoc> TTiposDocs { get; set; }

    public virtual DbSet<TTrabajadore> TTrabajadores { get; set; }

    public virtual DbSet<TVenta> TVentas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-NCDOF8R\\SQLEXPRESS; Database=gestioncafeteria; trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TCategoria>(entity =>
        {
            entity.ToTable("tCategorias");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TEstadoProducto>(entity =>
        {
            entity.ToTable("tEstadoProductos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("estado");
        });

        modelBuilder.Entity<TGenero>(entity =>
        {
            entity.ToTable("tGeneros");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Genero)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("genero");
        });

        modelBuilder.Entity<TProducto>(entity =>
        {
            entity.ToTable("tProductos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaVencimiento).HasColumnName("fechaVencimiento");
            entity.Property(e => e.IdCategoria).HasColumnName("id_Categoria");
            entity.Property(e => e.IdEstado).HasColumnName("id_Estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio).HasColumnName("precio");
            entity.Property(e => e.Referencia)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("referencia");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.TProductos)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK_tProductos_tCategorias");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.TProductos)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("FK_tProductos_tEstadoProductos");
        });

        modelBuilder.Entity<TProductosxVenta>(entity =>
        {
            entity.ToTable("tProductosxVentas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.IdProductos).HasColumnName("id_Productos");
            entity.Property(e => e.IdVenta).HasColumnName("id_Venta");
            entity.Property(e => e.Precioxcantidad)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("precioxcantidad");

            entity.HasOne(d => d.IdProductosNavigation).WithMany(p => p.TProductosxVenta)
                .HasForeignKey(d => d.IdProductos)
                .HasConstraintName("FK_tProductosxVentas_tProductos");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.TProductosxVenta)
                .HasForeignKey(d => d.IdVenta)
                .HasConstraintName("FK_tProductosxVentas_tVentas");
        });

        modelBuilder.Entity<TProductoxProveedore>(entity =>
        {
            entity.ToTable("tProductoxProveedores");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdProducto).HasColumnName("id_Producto");
            entity.Property(e => e.IdProveedor).HasColumnName("id_Proveedor");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.TProductoxProveedores)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK_tProductoxProveedores_tProductos");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.TProductoxProveedores)
                .HasForeignKey(d => d.IdProveedor)
                .HasConstraintName("FK_tProductoxProveedores_tProveedores");
        });

        modelBuilder.Entity<TProveedore>(entity =>
        {
            entity.ToTable("tProveedores");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Contacto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("contacto");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Nit).HasColumnName("nit");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TRole>(entity =>
        {
            entity.ToTable("tRoles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TTiposDoc>(entity =>
        {
            entity.ToTable("tTiposDoc");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TTrabajadore>(entity =>
        {
            entity.ToTable("tTrabajadores");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Contrasenia)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("contrasenia");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.IdGenero).HasColumnName("id_Genero");
            entity.Property(e => e.IdRol).HasColumnName("id_Rol");
            entity.Property(e => e.IdTipoDoc).HasColumnName("id_TipoDoc");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.NumDocumento).HasColumnName("numDocumento");
            entity.Property(e => e.Telefono).HasColumnName("telefono");
            entity.Property(e => e.Usuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("usuario");

            entity.HasOne(d => d.IdGeneroNavigation).WithMany(p => p.TTrabajadores)
                .HasForeignKey(d => d.IdGenero)
                .HasConstraintName("FK_tTrabajadores_tGeneros");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.TTrabajadores)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK_tTrabajadores_tRoles");

            entity.HasOne(d => d.IdTipoDocNavigation).WithMany(p => p.TTrabajadores)
                .HasForeignKey(d => d.IdTipoDoc)
                .HasConstraintName("FK_tTrabajadores_tTiposDoc");
        });

        modelBuilder.Entity<TVenta>(entity =>
        {
            entity.ToTable("tVentas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.IdTrabajador).HasColumnName("id_Trabajador");
            entity.Property(e => e.TotalPagado)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("totalPagado");

            entity.HasOne(d => d.IdTrabajadorNavigation).WithMany(p => p.TVenta)
                .HasForeignKey(d => d.IdTrabajador)
                .HasConstraintName("FK_tVentas_tTrabajadores");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
