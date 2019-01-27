using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ExWebApiAutos
{
    public partial class AutosDbContext : DbContext
    {
        public AutosDbContext()
        {
        }

        public AutosDbContext(DbContextOptions<AutosDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autos> Autos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("data source = DESKTOP-908S3MO\\SQLEXPRESS; initial catalog = ExWebApiAutos; user id = sa; password = desarrollo2019");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autos>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AnioFab)
                    .IsRequired()
                    .HasColumnName("anio_fab")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasColumnName("color")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EsFull).HasColumnName("es_full");

                entity.Property(e => e.EsMeca).HasColumnName("es_meca");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasColumnName("marca")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NroAsientos)
                    .IsRequired()
                    .HasColumnName("nro_asientos")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.NroPlaca)
                    .IsRequired()
                    .HasColumnName("nro_placa")
                    .HasMaxLength(6)
                    .IsUnicode(false);
            });
        }
    }
}
