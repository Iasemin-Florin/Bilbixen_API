using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Bilbixen_API.EF
{
    public partial class BilbixenContext : DbContext
    {
        public BilbixenContext()
        {
        }

        public BilbixenContext(DbContextOptions<BilbixenContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bruger> Brugers { get; set; }
        public virtual DbSet<Ordre> Ordres { get; set; }
        public virtual DbSet<OrdreLinje> OrdreLinjes { get; set; }
        public virtual DbSet<PostNr> PostNrs { get; set; }
        public virtual DbSet<Produkter> Produkters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=Bilbixen");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Bruger>(entity =>
            {
                entity.ToTable("Bruger");

                entity.Property(e => e.BrugerId).HasColumnName("brugerID");

                entity.Property(e => e.Admin).HasColumnName("admin");

                entity.Property(e => e.Adresse)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("adresse");

                entity.Property(e => e.ENavn)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("eNavn");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("email");

                entity.Property(e => e.FNavn)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("fNavn");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("password");

                entity.Property(e => e.PostNr).HasColumnName("postNR");

                entity.Property(e => e.TlfNr)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("tlfNR");

                entity.HasOne(d => d.PostNrNavigation)
                    .WithMany(p => p.Brugers)
                    .HasForeignKey(d => d.PostNr)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bruger__admin__267ABA7A");
            });

            modelBuilder.Entity<Ordre>(entity =>
            {
                entity.ToTable("Ordre");

                entity.Property(e => e.OrdreId).HasColumnName("ordreID");

                entity.Property(e => e.BrugerId).HasColumnName("brugerID");

                entity.Property(e => e.OrdreDato)
                    .HasColumnType("datetime")
                    .HasColumnName("ordreDato");

                entity.Property(e => e.TotalPris).HasColumnName("totalPris");
            });

            modelBuilder.Entity<OrdreLinje>(entity =>
            {
                entity.ToTable("OrdreLinje");

                entity.Property(e => e.OrdreLinjeId).HasColumnName("ordreLinjeID");

                entity.Property(e => e.Antal).HasColumnName("antal");

                entity.Property(e => e.OrdreId).HasColumnName("ordreID");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProduktId).HasColumnName("produktID");

                entity.HasOne(d => d.Ordre)
                    .WithMany(p => p.OrdreLinjes)
                    .HasForeignKey(d => d.OrdreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrdreLinj__ordre__2D27B809");

                entity.HasOne(d => d.Produkt)
                    .WithMany(p => p.OrdreLinjes)
                    .HasForeignKey(d => d.ProduktId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrdreLinj__produ__2E1BDC42");
            });

            modelBuilder.Entity<PostNr>(entity =>
            {
                entity.HasKey(e => e.PostNr1)
                    .HasName("PK__PostNR__DD0C0A0E33E7A5BE");

                entity.ToTable("PostNR");

                entity.Property(e => e.PostNr1).HasColumnName("postNR");

                entity.Property(e => e.PostBy)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("postBy");
            });

            modelBuilder.Entity<Produkter>(entity =>
            {
                entity.HasKey(e => e.ProduktId)
                    .HasName("PK__Produkte__F08027C51C9C0D16");

                entity.ToTable("Produkter");

                entity.Property(e => e.ProduktId).HasColumnName("produktID");

                entity.Property(e => e.Pris).HasColumnName("pris");

                entity.Property(e => e.ProduktNavn)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("produktNavn");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
