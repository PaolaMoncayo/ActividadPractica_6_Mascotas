using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AdopcionWeb.Models
{
    public partial class mascotasContext : DbContext
    {
        public mascotasContext()
        {
        }

        public mascotasContext(DbContextOptions<mascotasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MascotaPersona> MascotaPersonas { get; set; } = null!;
        public virtual DbSet<Mascotum> Mascota { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
 //               optionsBuilder.UseSqlServer("server=DESKTOP-PQVEJI8\\SQLEXPRESS; database=mascotas; integrated security=true; TrustServerCertificate=Yes");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MascotaPersona>(entity =>
            {
                entity.HasKey(e => e.IdRelacion)
                    .HasName("PK__Mascota___ACD3B48CD5B03866");

                entity.ToTable("Mascota_Persona");

                entity.Property(e => e.IdRelacion).HasColumnName("Id_relacion");

                entity.Property(e => e.IdMascota).HasColumnName("Id_mascota");

                entity.Property(e => e.IdPersona).HasColumnName("Id_persona");

                entity.HasOne(d => d.IdMascotaAdoptada)
                    .WithMany(p => p.MascotaPersonas)
                    .HasForeignKey(d => d.IdMascota)
                    .HasConstraintName("FK__Mascota_P__Id_ma__5812160E");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.MascotaPersonas)
                    .HasForeignKey(d => d.IdPersona)
                    .HasConstraintName("FK__Mascota_P__Id_pe__59063A47");
            });

            modelBuilder.Entity<Mascotum>(entity =>
            {
                entity.HasKey(e => e.IdMascota)
                    .HasName("PK__Mascota__03DE4D28841D529B");

                entity.Property(e => e.IdMascota)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_mascota");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TiempoRescatada)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Tiempo_rescatada");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona)
                    .HasName("PK__Persona__13DCD245C4E63BBA");

                entity.ToTable("Persona");

                entity.Property(e => e.IdPersona).HasColumnName("Id_persona");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdMascota).HasColumnName("Id_mascota");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMascotaAdoptada)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.IdMascota)
                    .HasConstraintName("FK__Persona__Id_masc__5165187F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
