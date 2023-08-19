using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PracticaFinal.Models;

public partial class FinalProjectContext : DbContext
{
    public FinalProjectContext()
    {
    }

    public FinalProjectContext(DbContextOptions<FinalProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Cuentum> Cuenta { get; set; }

    public virtual DbSet<CuotaInversion> CuotaInversions { get; set; }

    public virtual DbSet<CuotaPrestamo> CuotaPrestamos { get; set; }

    public virtual DbSet<InversionGarantium> InversionGarantia { get; set; }

    public virtual DbSet<Inversione> Inversiones { get; set; }

    public virtual DbSet<Prestamo> Prestamos { get; set; }

    public virtual DbSet<PrestamoGarantium> PrestamoGarantia { get; set; }

    public virtual DbSet<TipoCuentum> TipoCuenta { get; set; }

    public virtual DbSet<TipoPago> TipoPagos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=REVISION-PC\\SQLEXPRESS; Database=SistemaDePrestamosv2; Trusted_Connection=SSPI; Encrypt=false; TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Cedula).HasName("PK__cliente__415B7BE4A7B0630E");

            entity.ToTable("cliente");

            entity.Property(e => e.Cedula)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cedula");
            entity.Property(e => e.Apellido)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Cuentum>(entity =>
        {
            entity.HasKey(e => e.IdCuenta).HasName("PK__cuenta__BBC6DF32D98DE6C7");

            entity.ToTable("cuenta");

            entity.Property(e => e.IdCuenta).HasColumnName("idCuenta");
            entity.Property(e => e.Banco)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("banco");
            entity.Property(e => e.IdCliente)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("idCliente");
            entity.Property(e => e.Tipo).HasColumnName("tipo");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Cuenta)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__cuenta__idClient__5AEE82B9");

            entity.HasOne(d => d.TipoNavigation).WithMany(p => p.Cuenta)
                .HasForeignKey(d => d.Tipo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__cuenta__tipo__5BE2A6F2");
        });

        modelBuilder.Entity<CuotaInversion>(entity =>
        {
            entity.HasKey(e => e.CodCuota).HasName("PK__cuota_in__8F95D218A9246A51");

            entity.ToTable("cuota_inversion");

            entity.Property(e => e.CodCuota).HasColumnName("cod_cuota");
            entity.Property(e => e.CodComprobante)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cod_comprobante");
            entity.Property(e => e.FechaPlanificada)
                .HasColumnType("date")
                .HasColumnName("fecha_planificada");
            entity.Property(e => e.FechaRealizada)
                .HasColumnType("date")
                .HasColumnName("fecha_realizada");
            entity.Property(e => e.IdInversion).HasColumnName("idInversion");
            entity.Property(e => e.Monto).HasColumnName("monto");
            entity.Property(e => e.TipoTransaccion).HasColumnName("tipoTransaccion");

            entity.HasOne(d => d.IdInversionNavigation).WithMany(p => p.CuotaInversions)
                .HasForeignKey(d => d.IdInversion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__cuota_inv__idInv__5CD6CB2B");

            entity.HasOne(d => d.TipoTransaccionNavigation).WithMany(p => p.CuotaInversions)
                .HasForeignKey(d => d.TipoTransaccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__cuota_inv__tipoT__5DCAEF64");
        });

        modelBuilder.Entity<CuotaPrestamo>(entity =>
        {
            entity.HasKey(e => e.CodCuota).HasName("PK__cuota_pr__8F95D218D8E811B4");

            entity.ToTable("cuota_prestamo");

            entity.Property(e => e.CodCuota).HasColumnName("cod_cuota");
            entity.Property(e => e.CodComprobante)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cod_comprobante");
            entity.Property(e => e.FechaPlanificada)
                .HasColumnType("date")
                .HasColumnName("fecha_planificada");
            entity.Property(e => e.FechaRealizada)
                .HasColumnType("date")
                .HasColumnName("fecha_realizada");
            entity.Property(e => e.IdPrestamo).HasColumnName("idPrestamo");
            entity.Property(e => e.Monto).HasColumnName("monto");
            entity.Property(e => e.TipoTransaccion).HasColumnName("tipoTransaccion");

            entity.HasOne(d => d.IdPrestamoNavigation).WithMany(p => p.CuotaPrestamos)
                .HasForeignKey(d => d.IdPrestamo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__cuota_pre__idPre__5EBF139D");

            entity.HasOne(d => d.TipoTransaccionNavigation).WithMany(p => p.CuotaPrestamos)
                .HasForeignKey(d => d.TipoTransaccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__cuota_pre__tipoT__5FB337D6");
        });

        modelBuilder.Entity<InversionGarantium>(entity =>
        {
            entity.HasKey(e => e.IdGarantia).HasName("PK__inversio__BB73805F7A4172A8");

            entity.ToTable("inversion_garantia");

            entity.Property(e => e.IdGarantia).HasColumnName("idGarantia");
            entity.Property(e => e.IdInversion).HasColumnName("idInversion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tipo");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ubicacion");
            entity.Property(e => e.Valor)
                .HasColumnType("decimal(11, 0)")
                .HasColumnName("valor");

            entity.HasOne(d => d.IdInversionNavigation).WithMany(p => p.InversionGarantia)
                .HasForeignKey(d => d.IdInversion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__inversion__idInv__60A75C0F");
        });

        modelBuilder.Entity<Inversione>(entity =>
        {
            entity.HasKey(e => e.IdInversion).HasName("PK__inversio__50D915005FE76EDD");

            entity.ToTable("inversiones");

            entity.Property(e => e.IdInversion).HasColumnName("idInversion");
            entity.Property(e => e.FechaFinal)
                .HasColumnType("date")
                .HasColumnName("fecha_final");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("date")
                .HasColumnName("fecha_inicio");
            entity.Property(e => e.IdCuenta).HasColumnName("idCuenta");
            entity.Property(e => e.Interes)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("interes");
            entity.Property(e => e.Monto)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("monto");

            entity.HasOne(d => d.IdCuentaNavigation).WithMany(p => p.Inversiones)
                .HasForeignKey(d => d.IdCuenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__inversion__idCue__619B8048");
        });

        modelBuilder.Entity<Prestamo>(entity =>
        {
            entity.HasKey(e => e.Idprestamo).HasName("PK__prestamo__CB759CB197124089");

            entity.ToTable("prestamos");

            entity.Property(e => e.Idprestamo).HasColumnName("idprestamo");
            entity.Property(e => e.FechaAprobacion)
                .HasColumnType("date")
                .HasColumnName("fecha_aprobacion");
            entity.Property(e => e.FechaFinal)
                .HasColumnType("date")
                .HasColumnName("fecha_final");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("date")
                .HasColumnName("fecha_inicio");
            entity.Property(e => e.IdCliente)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("idCliente");
            entity.Property(e => e.Interes)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("interes");
            entity.Property(e => e.Monto)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("monto");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__prestamos__idCli__6383C8BA");
        });

        modelBuilder.Entity<PrestamoGarantium>(entity =>
        {
            entity.HasKey(e => e.IdGarantia).HasName("PK__prestamo__BB73805F50BA95D2");

            entity.ToTable("prestamo_garantia");

            entity.Property(e => e.IdGarantia).HasColumnName("idGarantia");
            entity.Property(e => e.IdPrestamo).HasColumnName("idPrestamo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tipo");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ubicacion");
            entity.Property(e => e.Valor)
                .HasColumnType("decimal(11, 0)")
                .HasColumnName("valor");

            entity.HasOne(d => d.IdPrestamoNavigation).WithMany(p => p.PrestamoGarantia)
                .HasForeignKey(d => d.IdPrestamo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__prestamo___idPre__628FA481");
        });

        modelBuilder.Entity<TipoCuentum>(entity =>
        {
            entity.HasKey(e => e.IdTipo).HasName("PK__tipoCuen__BDD0DFE1C2DC79D9");

            entity.ToTable("tipoCuenta");

            entity.Property(e => e.IdTipo).HasColumnName("idTipo");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoPago>(entity =>
        {
            entity.HasKey(e => e.IdTipo).HasName("PK__tipoPago__BDD0DFE1CED5784F");

            entity.ToTable("tipoPago");

            entity.Property(e => e.IdTipo).HasColumnName("idTipo");
            entity.Property(e => e.TipoPago1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipoPago");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
