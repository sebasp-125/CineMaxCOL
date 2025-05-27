using System;
using System.Collections.Generic;
using CineMaxColEntity;
using Microsoft.EntityFrameworkCore;

namespace CineMaxColDal.DBContext;

public partial class CineMaxColContext : DbContext
{
    public CineMaxColContext()
    {
    }

    public CineMaxColContext(DbContextOptions<CineMaxColContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CategoriaComidum> CategoriaComida { get; set; }

    public virtual DbSet<Cine> Cines { get; set; }

    public virtual DbSet<CineComidum> CineComida { get; set; }

    public virtual DbSet<Comidum> Comida { get; set; }

    public virtual DbSet<ConfiguracionCloud> ConfiguracionClouds { get; set; }

    public virtual DbSet<Funcion> Funcions { get; set; }

    public virtual DbSet<HistorialCompra> HistorialCompras { get; set; }

    public virtual DbSet<Horario> Horarios { get; set; }

    public virtual DbSet<Municipio> Municipios { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Pelicula> Peliculas { get; set; }

    public virtual DbSet<PromocionComidum> PromocionComida { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sala> Salas { get; set; }

    public virtual DbSet<TipoPago> TipoPagos { get; set; }

    public virtual DbSet<Ubicacion> Ubicacions { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-URHTSV2\\SQLEXPRESS;Database=CineMaxCOL;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoriaComidum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC07F448F646");
        });

        modelBuilder.Entity<Cine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cine__3214EC07334FC5B9");

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
                .HasConstraintName("FK__Cine__Id_Ubicaci__52593CB8");
        });

        modelBuilder.Entity<CineComidum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CineComi__3214EC07D4F5012E");

            entity.Property(e => e.IdCine).HasColumnName("Id_Cine");
            entity.Property(e => e.IdComida).HasColumnName("Id_Comida");

            entity.HasOne(d => d.IdCineNavigation).WithMany(p => p.CineComida)
                .HasForeignKey(d => d.IdCine)
                .HasConstraintName("FK__CineComid__Id_Ci__08B54D69");

            entity.HasOne(d => d.IdComidaNavigation).WithMany(p => p.CineComida)
                .HasForeignKey(d => d.IdComida)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__CineComid__Id_Co__09A971A2");
        });

        modelBuilder.Entity<Comidum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comida__3214EC07323B6D0F");

            entity.Property(e => e.Descripción).HasMaxLength(255);
            entity.Property(e => e.ImagenUrl).HasMaxLength(200);
            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.Categoria).WithMany(p => p.Comida)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Producto_Categoria");
        });

        modelBuilder.Entity<ConfiguracionCloud>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Configur__3214EC071BC2EA4A");

            entity.ToTable("ConfiguracionCloud");

            entity.Property(e => e.ApiKey).HasMaxLength(100);
            entity.Property(e => e.ApiSecret).HasMaxLength(255);
            entity.Property(e => e.CloudName).HasMaxLength(100);
            entity.Property(e => e.Folder).HasMaxLength(100);
        });

        modelBuilder.Entity<Funcion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Funcion__3214EC073B20E338");

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
                .HasConstraintName("FK__Funcion__Id_Peli__5EBF139D");

            entity.HasOne(d => d.IdSalaNavigation).WithMany(p => p.Funcions)
                .HasForeignKey(d => d.IdSala)
                .HasConstraintName("FK__Funcion__Id_Sala__5DCAEF64");
        });

        modelBuilder.Entity<HistorialCompra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Historia__3214EC07AC5039FC");

            entity.Property(e => e.IdReserva).HasColumnName("Id_Reserva");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

            entity.HasOne(d => d.IdReservaNavigation).WithMany(p => p.HistorialCompras)
                .HasForeignKey(d => d.IdReserva)
                .HasConstraintName("FK__Historial__Id_Re__6EF57B66");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.HistorialCompras)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Historial__Id_Us__6E01572D");
        });

        modelBuilder.Entity<Horario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Horarios__3214EC07B0757A9D");

            entity.Property(e => e.IdCine).HasColumnName("Id_Cine");

            entity.HasOne(d => d.IdCineNavigation).WithMany(p => p.Horarios)
                .HasForeignKey(d => d.IdCine)
                .HasConstraintName("FK__Horarios__Id_Cin__5812160E");
        });

        modelBuilder.Entity<Municipio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Municipi__3214EC07D6D91043");

            entity.Property(e => e.NombreMunicipio)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pago__3214EC0741200901");

            entity.ToTable("Pago");

            entity.Property(e => e.FechaPago)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Pago");
            entity.Property(e => e.IdReserva).HasColumnName("Id_Reserva");
            entity.Property(e => e.IdTipoPago).HasColumnName("Id_TipoPago");
            entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdReservaNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdReserva)
                .HasConstraintName("FK__Pago__Id_Reserva__6A30C649");

            entity.HasOne(d => d.IdTipoPagoNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdTipoPago)
                .HasConstraintName("FK__Pago__Id_TipoPag__6B24EA82");
        });

        modelBuilder.Entity<Pelicula>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pelicula__3214EC079C6D4696");

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
                .HasConstraintName("FK__Pelicula__Id_Cin__5AEE82B9");
        });

        modelBuilder.Entity<PromocionComidum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Promocio__3214EC075A1867F7");

            entity.Property(e => e.FechaFin).HasColumnType("datetime");
            entity.Property(e => e.FechaInicio).HasColumnType("datetime");
            entity.Property(e => e.IdCineComida).HasColumnName("Id_CineComida");

            entity.HasOne(d => d.IdCineComidaNavigation).WithMany(p => p.PromocionComida)
                .HasForeignKey(d => d.IdCineComida)
                .HasConstraintName("FK__Promocion__Id_Ci__0C85DE4D");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reserva__3214EC07080340E0");

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
                .HasConstraintName("FK__Reserva__Id_Clie__66603565");

            entity.HasOne(d => d.IdFuncionNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdFuncion)
                .HasConstraintName("FK__Reserva__Id_Func__6754599E");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC0794E1381A");

            entity.Property(e => e.TipoRol)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Sala>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sala__3214EC07D84C1DD1");

            entity.ToTable("Sala");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.IdCine).HasColumnName("Id_Cine");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCineNavigation).WithMany(p => p.Salas)
                .HasForeignKey(d => d.IdCine)
                .HasConstraintName("FK__Sala__Id_Cine__5535A963");
        });

        modelBuilder.Entity<TipoPago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TipoPago__3214EC0775200AC0");

            entity.Property(e => e.NombreTipo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Ubicacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ubicacio__3214EC0741FB1E72");

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
                .HasConstraintName("FK__Ubicacion__Id_Mu__4F7CD00D");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC076D048362");

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

            entity.HasOne(d => d.IdHorarioNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdHorario)
                .HasConstraintName("FK__Usuarios__Id_Hor__6383C8BA");

            entity.HasOne(d => d.IdMunicipioNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdMunicipio)
                .HasConstraintName("FK__Usuarios__Id_Mun__619B8048");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__Usuarios__Id_Rol__628FA481");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
