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

    public virtual DbSet<ConfiguracionCorreo> ConfiguracionCorreos { get; set; }

    public virtual DbSet<Funcion> Funcions { get; set; }

    public virtual DbSet<HistorialCompra> HistorialCompras { get; set; }

    public virtual DbSet<Horario> Horarios { get; set; }

    public virtual DbSet<Municipio> Municipios { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Pelicula> Peliculas { get; set; }

    public virtual DbSet<Puesto> Puestos { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<ReservaPuesto> ReservaPuestos { get; set; }

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
            entity.HasKey(e => e.Id).HasName("PK__Cine__3214EC073D90D9D2");

            entity.ToTable("Cine");

            entity.Property(e => e.Id).ValueGeneratedNever();
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
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Cine__Id_Ubicaci__4E88ABD4");
        });

        modelBuilder.Entity<ConfiguracionCloud>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Configur__3214EC073719ADEF");

            entity.ToTable("ConfiguracionCloud");

            entity.Property(e => e.ApiKey).HasMaxLength(100);
            entity.Property(e => e.ApiSecret).HasMaxLength(255);
            entity.Property(e => e.CloudName).HasMaxLength(100);
            entity.Property(e => e.Folder).HasMaxLength(100);
        });

        modelBuilder.Entity<ConfiguracionCorreo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Configur__3214EC0791670F88");

            entity.ToTable("ConfiguracionCorreo");

            entity.Property(e => e.Propiedad).HasMaxLength(50);
            entity.Property(e => e.Recurso).HasMaxLength(50);
            entity.Property(e => e.Valor).HasMaxLength(255);
        });

        modelBuilder.Entity<Funcion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Funcion__3214EC07DA69B2B2");

            entity.ToTable("Funcion");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaHora)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Hora");
            entity.Property(e => e.IdPelicula).HasColumnName("Id_Pelicula");
            entity.Property(e => e.IdSala).HasColumnName("Id_Sala");
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdPeliculaNavigation).WithMany(p => p.Funcions)
                .HasForeignKey(d => d.IdPelicula)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Funcion__Id_Peli__787EE5A0");

            entity.HasOne(d => d.IdSalaNavigation).WithMany(p => p.Funcions)
                .HasForeignKey(d => d.IdSala)
                .HasConstraintName("FK__Funcion__Id_Sala__778AC167");
        });

        modelBuilder.Entity<HistorialCompra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Historia__3214EC07CBFB6CB9");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.IdReserva).HasColumnName("Id_Reserva");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

            entity.HasOne(d => d.IdReservaNavigation).WithMany(p => p.HistorialCompras)
                .HasForeignKey(d => d.IdReserva)
                .HasConstraintName("FK__Historial__Id_Re__09A971A2");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.HistorialCompras)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Historial__Id_Us__08B54D69");
        });

        modelBuilder.Entity<Horario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Horarios__3214EC07D4680896");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.IdCine).HasColumnName("Id_Cine");

            entity.HasOne(d => d.IdCineNavigation).WithMany(p => p.Horarios)
                .HasForeignKey(d => d.IdCine)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Horarios__Id_Cin__5165187F");
        });

        modelBuilder.Entity<Municipio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Municipi__3214EC0797478FC7");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.NombreMunicipio)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pago__3214EC07F34EC1F6");

            entity.ToTable("Pago");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FechaPago)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Pago");
            entity.Property(e => e.IdReserva).HasColumnName("Id_Reserva");
            entity.Property(e => e.IdTipoPago).HasColumnName("Id_TipoPago");
            entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdReservaNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdReserva)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Pago__Id_Reserva__01142BA1");

            entity.HasOne(d => d.IdTipoPagoNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdTipoPago)
                .HasConstraintName("FK__Pago__Id_TipoPag__02084FDA");
        });

        modelBuilder.Entity<Pelicula>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pelicula__3214EC076882E568");

            entity.ToTable("Pelicula");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Clasificacion)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Director)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Genero)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdCine).HasColumnName("Id_Cine");
            entity.Property(e => e.Pais)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sinopsis).HasColumnType("text");
            entity.Property(e => e.Titulo)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCineNavigation).WithMany(p => p.Peliculas)
                .HasForeignKey(d => d.IdCine)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Pelicula__Id_Cin__59063A47");
        });

        modelBuilder.Entity<Puesto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Puestos__3214EC075D1E2403");

            entity.Property(e => e.Fila)
                .HasMaxLength(2)
                .IsUnicode(false);

            entity.HasOne(d => d.IdSalaNavigation).WithMany(p => p.Puestos)
                .HasForeignKey(d => d.IdSala)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Puestos_Sala");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reserva__3214EC0754C5C7FA");

            entity.ToTable("Reserva");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CantidadBoletos).HasColumnName("Cantidad_Boletos");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaReserva)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Reserva");
            entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");
            entity.Property(e => e.IdFuncion).HasColumnName("Id_Funcion");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Reserva__Id_Clie__7C4F7684");

            entity.HasOne(d => d.IdFuncionNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdFuncion)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Reserva__Id_Func__7D439ABD");
        });

        modelBuilder.Entity<ReservaPuesto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ReservaP__3214EC07C7A255D9");

            entity.HasOne(d => d.IdPuestoNavigation).WithMany(p => p.ReservaPuestos)
                .HasForeignKey(d => d.IdPuesto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReservaPuestos_Puesto");

            entity.HasOne(d => d.IdReservaNavigation).WithMany(p => p.ReservaPuestos)
                .HasForeignKey(d => d.IdReserva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReservaPuestos_Reserva");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC07BFFDC52F");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.TipoRol)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Sala>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sala__3214EC0716B1E9A5");

            entity.ToTable("Sala");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IdCine).HasColumnName("Id_Cine");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCineNavigation).WithMany(p => p.Salas)
                .HasForeignKey(d => d.IdCine)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Sala__Id_Cine__5535A963");
        });

        modelBuilder.Entity<TipoPago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TipoPago__3214EC07FA146403");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.NombreTipo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Ubicacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ubicacio__3214EC070535EB33");

            entity.ToTable("Ubicacion");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.IdMunicipio).HasColumnName("Id_Municipio");
            entity.Property(e => e.Localidad)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdMunicipioNavigation).WithMany(p => p.Ubicacions)
                .HasForeignKey(d => d.IdMunicipio)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Ubicacion__Id_Mu__4BAC3F29");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC07E3432BDA");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
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

            entity.HasOne(d => d.IdHorarioNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdHorario)
                .HasConstraintName("FK__Usuarios__Id_Hor__656C112C");

            entity.HasOne(d => d.IdMunicipioNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdMunicipio)
                .HasConstraintName("FK__Usuarios__Id_Mun__6383C8BA");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__Usuarios__Id_Rol__6477ECF3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
