using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CineMaxCOL_Entity;

public partial class CineMaxColContext : DbContext
{
    public CineMaxColContext()
    {
    }

    public CineMaxColContext(DbContextOptions<CineMaxColContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cine> Cines { get; set; }

    public virtual DbSet<ConfiguracionCloud> ConfiguracionClouds { get; set; }

    public virtual DbSet<Funcion> Funcions { get; set; }

    public virtual DbSet<HistorialCompra> HistorialCompras { get; set; }

    public virtual DbSet<Horario> Horarios { get; set; }

    public virtual DbSet<Municipio> Municipios { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Pelicula> Peliculas { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sala> Salas { get; set; }

    public virtual DbSet<TipoPago> TipoPagos { get; set; }

    public virtual DbSet<Ubicacion> Ubicacions { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-CJE8DS1\\SQLEXPRESS;Database=CineMaxCOL;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cine__3214EC0760C8E44D");

            entity.ToTable("Cine");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IdEmpleado).HasColumnName("Id_Empleado");
            entity.Property(e => e.IdUbicacion).HasColumnName("Id_Ubicacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUbicacionNavigation).WithMany(p => p.Cines)
                .HasForeignKey(d => d.IdUbicacion)
                .HasConstraintName("FK__Cine__Id_Ubicaci__628FA481");
        });

        modelBuilder.Entity<ConfiguracionCloud>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Configur__3214EC07F6717005");

            entity.ToTable("ConfiguracionCloud");

            entity.Property(e => e.ApiKey).HasMaxLength(100);
            entity.Property(e => e.ApiSecret).HasMaxLength(255);
            entity.Property(e => e.CloudName).HasMaxLength(100);
            entity.Property(e => e.Folder).HasMaxLength(100);
        });

        modelBuilder.Entity<Funcion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Funcion__3214EC07B03C6C57");

            entity.ToTable("Funcion");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.FechaHora)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Hora");
            entity.Property(e => e.IdPelicula).HasColumnName("Id_Pelicula");
            entity.Property(e => e.IdSala).HasColumnName("Id_Sala");
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdPeliculaNavigation).WithMany(p => p.Funcions)
                .HasForeignKey(d => d.IdPelicula)
                .HasConstraintName("FK__Funcion__Id_Peli__6383C8BA");

            entity.HasOne(d => d.IdSalaNavigation).WithMany(p => p.Funcions)
                .HasForeignKey(d => d.IdSala)
                .HasConstraintName("FK__Funcion__Id_Sala__6477ECF3");
        });

        modelBuilder.Entity<HistorialCompra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Historia__3214EC074D09C0D5");

            entity.Property(e => e.IdReserva).HasColumnName("Id_Reserva");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

            entity.HasOne(d => d.IdReservaNavigation).WithMany(p => p.HistorialCompras)
                .HasForeignKey(d => d.IdReserva)
                .HasConstraintName("FK__Historial__Id_Re__656C112C");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.HistorialCompras)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Historial__Id_Us__66603565");
        });

        modelBuilder.Entity<Horario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Horarios__3214EC078615D9CE");

            entity.Property(e => e.IdCine).HasColumnName("Id_Cine");

            entity.HasOne(d => d.IdCineNavigation).WithMany(p => p.Horarios)
                .HasForeignKey(d => d.IdCine)
                .HasConstraintName("FK__Horarios__Id_Cin__6754599E");
        });

        modelBuilder.Entity<Municipio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Municipi__3214EC075C3B0AD1");

            entity.Property(e => e.NombreMunicipio)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pago__3214EC07A8A2FAB4");

            entity.ToTable("Pago");

            entity.Property(e => e.FechaPago)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Pago");
            entity.Property(e => e.IdReserva).HasColumnName("Id_Reserva");
            entity.Property(e => e.IdTipoPago).HasColumnName("Id_TipoPago");
            entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdReservaNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdReserva)
                .HasConstraintName("FK__Pago__Id_Reserva__68487DD7");

            entity.HasOne(d => d.IdTipoPagoNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdTipoPago)
                .HasConstraintName("FK__Pago__Id_TipoPag__693CA210");
        });

        modelBuilder.Entity<Pelicula>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pelicula__3214EC073F5105A4");

            entity.ToTable("Pelicula");

            entity.Property(e => e.Clasificacion)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Director)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Genero)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdCine).HasColumnName("Id_Cine");
            entity.Property(e => e.ImagenUrl)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Pais)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sinopsis).HasColumnType("text");
            entity.Property(e => e.Titulo)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCineNavigation).WithMany(p => p.Peliculas)
                .HasForeignKey(d => d.IdCine)
                .HasConstraintName("FK__Pelicula__Id_Cin__6A30C649");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reserva__3214EC07351E0685");

            entity.ToTable("Reserva");

            entity.Property(e => e.CantidadBoletos).HasColumnName("Cantidad_Boletos");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaReserva)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Reserva");
            entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");
            entity.Property(e => e.IdFuncion).HasColumnName("Id_Funcion");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Reserva__Id_Clie__6B24EA82");

            entity.HasOne(d => d.IdFuncionNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdFuncion)
                .HasConstraintName("FK__Reserva__Id_Func__6C190EBB");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC07666C6FFD");

            entity.Property(e => e.TipoRol)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Sala>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sala__3214EC07F1C1E701");

            entity.ToTable("Sala");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.IdCine).HasColumnName("Id_Cine");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCineNavigation).WithMany(p => p.Salas)
                .HasForeignKey(d => d.IdCine)
                .HasConstraintName("FK__Sala__Id_Cine__6D0D32F4");
        });

        modelBuilder.Entity<TipoPago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TipoPago__3214EC07A0AB2903");

            entity.Property(e => e.NombreTipo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Ubicacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ubicacio__3214EC07B14557FE");

            entity.ToTable("Ubicacion");

            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.IdMunicipio).HasColumnName("Id_Municipio");
            entity.Property(e => e.Localidad)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdMunicipioNavigation).WithMany(p => p.Ubicacions)
                .HasForeignKey(d => d.IdMunicipio)
                .HasConstraintName("FK__Ubicacion__Id_Mu__6E01572D");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC07D89FA91D");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Dni)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DNI");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.IdHorario).HasColumnName("Id_Horario");
            entity.Property(e => e.IdMunicipio).HasColumnName("Id_Municipio");
            entity.Property(e => e.IdRol).HasColumnName("Id_Rol");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdHorarioNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdHorario)
                .HasConstraintName("FK__Usuarios__Id_Hor__6EF57B66");

            entity.HasOne(d => d.IdMunicipioNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdMunicipio)
                .HasConstraintName("FK__Usuarios__Id_Mun__6FE99F9F");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__Usuarios__Id_Rol__70DDC3D8");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
