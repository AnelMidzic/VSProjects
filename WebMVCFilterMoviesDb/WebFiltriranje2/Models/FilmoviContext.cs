using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebFiltriranje2.Models
{
    public partial class FilmoviContext : DbContext
    {
        public FilmoviContext()
        {
        }

        public FilmoviContext(DbContextOptions<FilmoviContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Film> Filmovi { get; set; }
        public virtual DbSet<Zanr> Zanrovi { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Film>(entity =>
            {
                entity.HasOne(d => d.Zanr)
                    .WithMany(p => p.Filmovi)
                    .HasForeignKey(d => d.ZanrId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Film__ZanrId__25869641");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}