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

    public virtual DbSet<AsientosTemporale> AsientosTemporales { get; set; }

    public virtual DbSet<CategoriaComidum> CategoriaComida { get; set; }

    public virtual DbSet<Cine> Cines { get; set; }

    public virtual DbSet<CineComidum> CineComida { get; set; }

    public virtual DbSet<Comidum> Comida { get; set; }

    public virtual DbSet<ConfiguracionCloud> ConfiguracionClouds { get; set; }

    public virtual DbSet<ConfiguracionEmail> ConfiguracionEmails { get; set; }

    public virtual DbSet<DiasSemana> DiasSemanas { get; set; }

    public virtual DbSet<Funcion> Funcions { get; set; }

    public virtual DbSet<HistorialCompra> HistorialCompras { get; set; }

    public virtual DbSet<Horario> Horarios { get; set; }

    public virtual DbSet<Municipio> Municipios { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Pelicula> Peliculas { get; set; }

    public virtual DbSet<Precio> Precios { get; set; }

    public virtual DbSet<PromocionComidum> PromocionComida { get; set; }

    public virtual DbSet<Puesto> Puestos { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sala> Salas { get; set; }

    public virtual DbSet<Silla> Sillas { get; set; }

    public virtual DbSet<SillasPorFuncion> SillasPorFuncions { get; set; }

    public virtual DbSet<Tarjetum> Tarjeta { get; set; }

    public virtual DbSet<TipoPago> TipoPagos { get; set; }

    public virtual DbSet<Ubicacion> Ubicacions { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AsientosTemporale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Asientos__3214EC0791A30E8C");

            entity.ToTable("AsientosTemporale");

            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.ReservadoHasta).HasColumnType("datetime");

            entity.HasOne(d => d.IdFuncionNavigation).WithMany(p => p.AsientosTemporales)
                .HasForeignKey(d => d.IdFuncion)
                .HasConstraintName("FK_AsientosTemporale_Funcion");

            entity.HasOne(d => d.IdSillaNavigation).WithMany(p => p.AsientosTemporales)
                .HasForeignKey(d => d.IdSilla)
                .HasConstraintName("FK_AsientosTemporale_Silla");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.AsientosTemporales)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_AsientosTemporale_Usuario");
        });

        modelBuilder.Entity<CategoriaComidum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC07C01DD8A6");
        });

        modelBuilder.Entity<Cine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cine__3214EC073C76C052");

            entity.ToTable("Cine");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(150);
            entity.Property(e => e.Telefono).HasMaxLength(50);

            entity.HasOne(d => d.IdUbicacionNavigation).WithMany(p => p.Cines)
                .HasForeignKey(d => d.IdUbicacion)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Cine_Ubicacion");
        });

        modelBuilder.Entity<CineComidum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CineComi__3214EC079473E86B");

            entity.Property(e => e.IdCine).HasColumnName("Id_Cine");
            entity.Property(e => e.IdComida).HasColumnName("Id_Comida");

            entity.HasOne(d => d.IdCineNavigation).WithMany(p => p.CineComida)
                .HasForeignKey(d => d.IdCine)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_CineComid_Id_Ci_10566F31");

            entity.HasOne(d => d.IdComidaNavigation).WithMany(p => p.CineComida)
                .HasForeignKey(d => d.IdComida)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__CineComid__Id_Co__114A936A");
        });

        modelBuilder.Entity<Comidum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comida__3214EC07C99162A1");

            entity.Property(e => e.Descripción).HasMaxLength(255);
            entity.Property(e => e.ImagenUrl).HasMaxLength(200);
            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.Categoria).WithMany(p => p.Comida)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Comida__Categori__0D7A0286");
        });

        modelBuilder.Entity<ConfiguracionCloud>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Configur__3214EC0774780CBB");

            entity.ToTable("ConfiguracionCloud");

            entity.Property(e => e.ApiKey).HasMaxLength(250);
            entity.Property(e => e.ApiSecret).HasMaxLength(250);
            entity.Property(e => e.CloudName).HasMaxLength(150);
            entity.Property(e => e.Folder).HasMaxLength(150);
        });

        modelBuilder.Entity<ConfiguracionEmail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ConfiguracionEmail");

            entity.Property(e => e.Propiedad).HasMaxLength(200);
            entity.Property(e => e.Recurso).HasMaxLength(200);
            entity.Property(e => e.Valor).HasMaxLength(500);
        });

        modelBuilder.Entity<DiasSemana>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DiasSema__3214EC074BC36CE6");

            entity.ToTable("DiasSemana");

            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Funcion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Funcion__3214EC07E0DC48B8");

            entity.ToTable("Funcion");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.FechaHora).HasColumnType("datetime");
            entity.Property(e => e.IdentificadorMovies).HasMaxLength(100);
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdPeliculaNavigation).WithMany(p => p.Funcions)
                .HasForeignKey(d => d.IdPelicula)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Funcion_Pelicula");

            entity.HasOne(d => d.IdSalaNavigation).WithMany(p => p.Funcions)
                .HasForeignKey(d => d.IdSala)
                .HasConstraintName("FK_Funcion_Sala");
        });

        modelBuilder.Entity<HistorialCompra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Historia__3214EC07A4C29A33");

            entity.ToTable("HistorialCompra");

            entity.HasOne(d => d.IdReservaNavigation).WithMany(p => p.HistorialCompras)
                .HasForeignKey(d => d.IdReserva)
                .HasConstraintName("FK_HistorialCompra_Reserva");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.HistorialCompras)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_HistorialCompra_Usuario");
        });

        modelBuilder.Entity<Horario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Horario__3214EC07C674C621");

            entity.ToTable("Horario");

            entity.HasOne(d => d.IdCineNavigation).WithMany(p => p.Horarios)
                .HasForeignKey(d => d.IdCine)
                .HasConstraintName("FK_Horario_Cine");
        });

        modelBuilder.Entity<Municipio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Municipi__3214EC07FF993E54");

            entity.ToTable("Municipio");

            entity.Property(e => e.NombreMunicipio).HasMaxLength(100);
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pago__3214EC07F0119E92");

            entity.ToTable("Pago");

            entity.Property(e => e.FechaPago).HasColumnType("datetime");
            entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdReservaNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdReserva)
                .HasConstraintName("FK_Pago_Reserva");

            entity.HasOne(d => d.IdTipoPagoNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdTipoPago)
                .HasConstraintName("FK_Pago_TipoPago");
        });

        modelBuilder.Entity<Pelicula>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pelicula__3214EC07559277F0");

            entity.ToTable("Pelicula");

            entity.Property(e => e.Clasificacion).HasMaxLength(50);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Director).HasMaxLength(150);
            entity.Property(e => e.Genero).HasMaxLength(100);
            entity.Property(e => e.Identificador).HasMaxLength(100);
            entity.Property(e => e.ImagenUrl).HasMaxLength(300);
            entity.Property(e => e.Pais).HasMaxLength(100);
            entity.Property(e => e.Titulo).HasMaxLength(200);

            entity.HasOne(d => d.IdCineNavigation).WithMany(p => p.Peliculas)
                .HasForeignKey(d => d.IdCine)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Pelicula_Cine");
        });

        modelBuilder.Entity<Precio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Precio__3214EC079336B935");

            entity.ToTable("Precio");

            entity.Property(e => e.Precio1).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdDiaSemanaNavigation).WithMany(p => p.Precios)
                .HasForeignKey(d => d.IdDiaSemana)
                .HasConstraintName("FK_Precio_DiasSemana");
        });

        modelBuilder.Entity<PromocionComidum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Promocio__3214EC079EAA05F0");

            entity.Property(e => e.FechaFin).HasColumnType("datetime");
            entity.Property(e => e.FechaInicio).HasColumnType("datetime");
            entity.Property(e => e.IdCineComida).HasColumnName("Id_CineComida");

            entity.HasOne(d => d.IdCineComidaNavigation).WithMany(p => p.PromocionComida)
                .HasForeignKey(d => d.IdCineComida)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Promocion__Id_Ci__14270015");
        });

        modelBuilder.Entity<Puesto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Puesto__3214EC0743D8FC96");

            entity.ToTable("Puesto");

            entity.Property(e => e.Fila).HasMaxLength(5);

            entity.HasOne(d => d.IdSalaNavigation).WithMany(p => p.Puestos)
                .HasForeignKey(d => d.IdSala)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Puesto_Sala");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reserva__3214EC07C80FD841");

            entity.ToTable("Reserva");

            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.FechaReserva).HasColumnType("datetime");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK_Reserva_Usuario");

            entity.HasOne(d => d.IdFuncionNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdFuncion)
                .HasConstraintName("FK_Reserva_Funcion");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Role__3214EC0704484E18");

            entity.ToTable("Role");

            entity.Property(e => e.TipoRol).HasMaxLength(100);
        });

        modelBuilder.Entity<Sala>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sala__3214EC0776D6542E");

            entity.ToTable("Sala");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(150);

            entity.HasOne(d => d.IdCineNavigation).WithMany(p => p.Salas)
                .HasForeignKey(d => d.IdCine)
                .HasConstraintName("FK_Sala_Cine");
        });

        modelBuilder.Entity<Silla>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Silla__3214EC0751C403C2");

            entity.ToTable("Silla");

            entity.Property(e => e.Fila).HasMaxLength(5);

            entity.HasOne(d => d.IdSalaNavigation).WithMany(p => p.Sillas)
                .HasForeignKey(d => d.IdSala)
                .HasConstraintName("FK__Silla__IdSala__282DF8C2");
        });

        modelBuilder.Entity<SillasPorFuncion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SillasPo__3214EC077EC16772");

            entity.ToTable("SillasPorFuncion");

            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.ReservadoHasta).HasColumnType("datetime");

            entity.HasOne(d => d.IdFuncionNavigation).WithMany(p => p.SillasPorFuncions)
                .HasForeignKey(d => d.IdFuncion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SillasPorFuncion_Funcion");

            entity.HasOne(d => d.IdSillaNavigation).WithMany(p => p.SillasPorFuncions)
                .HasForeignKey(d => d.IdSilla)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SillasPorFuncion_Silla");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.SillasPorFuncions)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_SillasPorFuncion_Usuario");
        });

        modelBuilder.Entity<Tarjetum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tarjeta__3214EC07A9D2C8CD");

            entity.Property(e => e.CorreoElectronico).HasMaxLength(150);
            entity.Property(e => e.NombreTitular).HasMaxLength(200);
            entity.Property(e => e.NumeroTarjeta).HasMaxLength(50);
            entity.Property(e => e.TipoTarjeta).HasMaxLength(50);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Tarjeta)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_Tarjeta_Usuario");
        });

        modelBuilder.Entity<TipoPago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TipoPago__3214EC07D44BF9B2");

            entity.ToTable("TipoPago");

            entity.Property(e => e.NombreTipo).HasMaxLength(100);
        });

        modelBuilder.Entity<Ubicacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ubicacio__3214EC07C2E6F7F1");

            entity.ToTable("Ubicacion");

            entity.Property(e => e.Direccion).HasMaxLength(200);
            entity.Property(e => e.Localidad).HasMaxLength(100);

            entity.HasOne(d => d.IdMunicipioNavigation).WithMany(p => p.Ubicacions)
                .HasForeignKey(d => d.IdMunicipio)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Ubicacion_Municipio");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC0795194989");

            entity.ToTable("Usuario");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Dni).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.FullName).HasMaxLength(200);
            entity.Property(e => e.Password).HasMaxLength(250);

            entity.HasOne(d => d.IdHorarioNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdHorario)
                .HasConstraintName("FK_Usuario_Horario");

            entity.HasOne(d => d.IdMunicipioNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdMunicipio)
                .HasConstraintName("FK_Usuario_Municipio");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK_Usuario_Role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
