namespace WpfEf05.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Magacin : DbContext
    {
        public Magacin()
            : base("name=Magacin")
        {
        }

        public virtual DbSet<Kategorija> Kategorije { get; set; }
        public virtual DbSet<Proizvod> Proizvodi { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kategorija>()
                .HasMany(e => e.Proizvodi)
                .WithRequired(e => e.Kategorija)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proizvod>()
                .Property(e => e.Cena)
                .HasPrecision(10, 2);
        }
    }
}
