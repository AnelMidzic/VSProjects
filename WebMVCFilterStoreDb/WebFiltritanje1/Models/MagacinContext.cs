using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebFiltritanje1.Models
{
    public partial class MagacinContext : DbContext
    {
        public MagacinContext()
        {
        }

        public MagacinContext(DbContextOptions<MagacinContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Kategorija> Kategorije { get; set; }
        public virtual DbSet<Proizvod> Proizvodi { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Kategorija>(entity =>
            {
                entity.HasIndex(e => e.Naziv)
                    .HasName("UQ__Kategori__603E8146A70BB08D")
                    .IsUnique();
            });

            modelBuilder.Entity<Proizvod>(entity =>
            {
                entity.HasIndex(e => e.Naziv)
                    .HasName("UQ__Proizvod__603E8146BA83D92F")
                    .IsUnique();

                entity.HasOne(d => d.Kategorija)
                    .WithMany(p => p.Proizvodi)
                    .HasForeignKey(d => d.KategorijaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Proizvod__Katego__145C0A3F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}