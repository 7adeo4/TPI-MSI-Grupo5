using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SuperMamiApi.Models
{
    public partial class super_mami_entregasContext : DbContext
    {
        public super_mami_entregasContext()
        {
        }

        public super_mami_entregasContext(DbContextOptions<super_mami_entregasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Barrio> Barrios { get; set; }
        public virtual DbSet<DetalleEnvio> DetalleEnvios { get; set; }
        public virtual DbSet<DetalleRetiro> DetalleRetiros { get; set; }
        public virtual DbSet<EmpresaTransporte> EmpresaTransportes { get; set; }
        public virtual DbSet<Envio> Envios { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<LiquidacionEnvio> LiquidacionEnvios { get; set; }
        public virtual DbSet<Retiro> Retiros { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Sucursale> Sucursales { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }
        public virtual DbSet<TipoEnvio> TipoEnvios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("User ID=prog3; Password=Admin1234;Server=localhost; Database=super_mami_entregas;Integrated Security=true;Pooling=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Spanish_Argentina.1252");

            modelBuilder.Entity<Barrio>(entity =>
            {
                entity.HasKey(e => e.IdBarrio)
                    .HasName("barrios_pkey");

                entity.ToTable("barrios");

                entity.Property(e => e.IdBarrio)
                    .HasColumnName("id_barrio")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Barrio1)
                    .HasMaxLength(50)
                    .HasColumnName("barrio");
            });

            modelBuilder.Entity<DetalleEnvio>(entity =>
            {
                entity.HasKey(e => e.IdDetalleEnvio)
                    .HasName("detalle_envio_pkey");

                entity.ToTable("detalle_envio");

                entity.Property(e => e.IdDetalleEnvio)
                    .HasColumnName("id_detalle_envio")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.EsGratuito)
                    .HasColumnType("bit(1)")
                    .HasColumnName("es_gratuito");

                entity.Property(e => e.IdEnvio).HasColumnName("id_envio");

                entity.Property(e => e.MontoEnvio).HasColumnName("monto_envio");

                entity.Property(e => e.Peso).HasColumnName("peso");

                entity.Property(e => e.Volumen).HasColumnName("volumen");

                entity.HasOne(d => d.IdEnvioNavigation)
                    .WithMany(p => p.DetalleEnvios)
                    .HasForeignKey(d => d.IdEnvio)
                    .HasConstraintName("fk_detalle_envio_id_envio");
            });

            modelBuilder.Entity<DetalleRetiro>(entity =>
            {
                entity.HasKey(e => e.IdDetalleRetiro)
                    .HasName("detalle_retiro_pkey");

                entity.ToTable("detalle_retiro");

                entity.Property(e => e.IdDetalleRetiro)
                    .HasColumnName("id_detalle_retiro")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.IdRetiro).HasColumnName("id_retiro");

                entity.Property(e => e.Peso).HasColumnName("peso");

                entity.Property(e => e.Volumen).HasColumnName("volumen");

                entity.HasOne(d => d.IdRetiroNavigation)
                    .WithMany(p => p.DetalleRetiros)
                    .HasForeignKey(d => d.IdRetiro)
                    .HasConstraintName("fk_detalle_retiro_id_retiro");
            });

            modelBuilder.Entity<EmpresaTransporte>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa)
                    .HasName("empresa_transporte_pkey");

                entity.ToTable("empresa_transporte");

                entity.Property(e => e.IdEmpresa)
                    .HasColumnName("id_empresa")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Calle)
                    .HasMaxLength(50)
                    .HasColumnName("calle");

                entity.Property(e => e.Cuit).HasColumnName("cuit");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Horario)
                    .HasColumnType("time without time zone")
                    .HasColumnName("horario");

                entity.Property(e => e.IdTipoEnvio).HasColumnName("id_tipo_envio");

                entity.Property(e => e.Localidad)
                    .HasMaxLength(50)
                    .HasColumnName("localidad");

                entity.Property(e => e.Numero).HasColumnName("numero");

                entity.Property(e => e.RazonSocial)
                    .HasMaxLength(50)
                    .HasColumnName("razon_social");

                entity.Property(e => e.Telefono).HasColumnName("telefono");

                entity.HasOne(d => d.IdTipoEnvioNavigation)
                    .WithMany(p => p.EmpresaTransportes)
                    .HasForeignKey(d => d.IdTipoEnvio)
                    .HasConstraintName("fk_empresa_transporte_id_tipo_envio");
            });

            modelBuilder.Entity<Envio>(entity =>
            {
                entity.HasKey(e => e.IdEnvio)
                    .HasName("envios_pkey");

                entity.ToTable("envios");

                entity.Property(e => e.IdEnvio)
                    .HasColumnName("id_envio")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .HasColumnName("apellido");

                entity.Property(e => e.Dia)
                    .HasColumnType("date")
                    .HasColumnName("dia");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .HasColumnName("direccion");

                entity.Property(e => e.EsTitular).HasColumnName("es_titular");

                entity.Property(e => e.Horario)
                    .HasColumnType("time without time zone")
                    .HasColumnName("horario");

                entity.Property(e => e.IdBarrio).HasColumnName("id_barrio");

                entity.Property(e => e.IdEmpresa).HasColumnName("id_empresa");

                entity.Property(e => e.IdEstado).HasColumnName("id_estado");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.Property(e => e.NroOrdenEntrega).HasColumnName("nro_orden_entrega");

                entity.Property(e => e.Telefono).HasColumnName("telefono");

                entity.HasOne(d => d.IdBarrioNavigation)
                    .WithMany(p => p.Envios)
                    .HasForeignKey(d => d.IdBarrio)
                    .HasConstraintName("fk_envios_id_barrio");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Envios)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("fk_envios_id_empresa");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Envios)
                    .HasForeignKey(d => d.IdEstado)
                    .HasConstraintName("fk_envios_id_estado");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Envios)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("fk_envios_id_usuario");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("estados_pkey");

                entity.ToTable("estados");

                entity.Property(e => e.IdEstado)
                    .HasColumnName("id_estado")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Estado1)
                    .HasMaxLength(30)
                    .HasColumnName("estado");
            });

            modelBuilder.Entity<LiquidacionEnvio>(entity =>
            {
                entity.HasKey(e => e.IdLiquidacion)
                    .HasName("liquidacion_envios_pkey");

                entity.ToTable("liquidacion_envios");

                entity.Property(e => e.IdLiquidacion)
                    .HasColumnName("id_liquidacion")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdDetalleEnvio).HasColumnName("id_detalle_envio");

                entity.Property(e => e.MontoTotal).HasColumnName("monto_total");

                entity.HasOne(d => d.IdDetalleEnvioNavigation)
                    .WithMany(p => p.LiquidacionEnvios)
                    .HasForeignKey(d => d.IdDetalleEnvio)
                    .HasConstraintName("fk_liquidacion_envios_id_detalle_envio");
            });

            modelBuilder.Entity<Retiro>(entity =>
            {
                entity.HasKey(e => e.IdRetiro)
                    .HasName("retiros_pkey");

                entity.ToTable("retiros");

                entity.Property(e => e.IdRetiro)
                    .HasColumnName("id_retiro")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .HasColumnName("apellido");

                entity.Property(e => e.Dia)
                    .HasColumnType("date")
                    .HasColumnName("dia");

                entity.Property(e => e.EsTitular).HasColumnName("es_titular");

                entity.Property(e => e.Horario)
                    .HasColumnType("time without time zone")
                    .HasColumnName("horario");

                entity.Property(e => e.IdEstado).HasColumnName("id_estado");

                entity.Property(e => e.IdSucursal).HasColumnName("id_sucursal");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.Property(e => e.NroOrdenEntrega).HasColumnName("nro_orden_entrega");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Retiros)
                    .HasForeignKey(d => d.IdEstado)
                    .HasConstraintName("fk_retiros_id_estado");

                entity.HasOne(d => d.IdSucursalNavigation)
                    .WithMany(p => p.Retiros)
                    .HasForeignKey(d => d.IdSucursal)
                    .HasConstraintName("fk_retiros_id_sucursal");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Retiros)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("fk_retiros_id_usuario");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("roles_pkey");

                entity.ToTable("roles");

                entity.Property(e => e.IdRol)
                    .HasColumnName("id_rol")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Rol)
                    .HasMaxLength(50)
                    .HasColumnName("rol");
            });

            modelBuilder.Entity<Sucursale>(entity =>
            {
                entity.HasKey(e => e.IdSucursal)
                    .HasName("sucursales_pkey");

                entity.ToTable("sucursales");

                entity.Property(e => e.IdSucursal)
                    .HasColumnName("id_sucursal")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CodPostal)
                    .HasMaxLength(50)
                    .HasColumnName("cod_postal");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .HasColumnName("direccion");

                entity.Property(e => e.IdBarrio).HasColumnName("id_barrio");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdBarrioNavigation)
                    .WithMany(p => p.Sucursales)
                    .HasForeignKey(d => d.IdBarrio)
                    .HasConstraintName("fk_sucursales_id_barrio");
            });

            modelBuilder.Entity<TipoDocumento>(entity =>
            {
                entity.HasKey(e => e.IdTipoDocumento)
                    .HasName("tipo_documento_pkey");

                entity.ToTable("tipo_documento");

                entity.Property(e => e.IdTipoDocumento)
                    .HasColumnName("id_tipo_documento")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.TipoDocumento1)
                    .HasMaxLength(50)
                    .HasColumnName("tipo_documento");
            });

            modelBuilder.Entity<TipoEnvio>(entity =>
            {
                entity.HasKey(e => e.IdTipoEnvio)
                    .HasName("tipo_envio_pkey");

                entity.ToTable("tipo_envio");

                entity.Property(e => e.IdTipoEnvio)
                    .HasColumnName("id_tipo_envio")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CantidadBolsasMax).HasColumnName("cantidad_bolsas_max");

                entity.Property(e => e.CapacidadPesoMax).HasColumnName("capacidad_peso_max");

                entity.Property(e => e.CapacidadVolumenMax)
                    .HasMaxLength(50)
                    .HasColumnName("capacidad_volumen_max");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("usuarios_pkey");

                entity.ToTable("usuarios");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("id_usuario")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .HasColumnName("apellido");

                entity.Property(e => e.Contrasenia)
                    .HasMaxLength(50)
                    .HasColumnName("contrasenia");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.IdRol).HasColumnName("id_rol");

                entity.Property(e => e.IdTipoDocumento).HasColumnName("id_tipo_documento");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.Property(e => e.NroDocumento)
                    .HasMaxLength(50)
                    .HasColumnName("nro_documento");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("fk_usuarios_id_rol");

                entity.HasOne(d => d.IdTipoDocumentoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoDocumento)
                    .HasConstraintName("fk_usuarios_id_tipo_documento");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
