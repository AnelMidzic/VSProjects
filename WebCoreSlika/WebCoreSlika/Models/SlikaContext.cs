using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebCoreSlika.Models
{
    public class SlikaContext : DbContext
    {
        public DbSet<Slika> Slike { get; set; }

        public SlikaContext(DbContextOptions<SlikaContext> opcije) : base(opcije)
        {

        }
    }
}
