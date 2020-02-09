using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebCoreControleri.Models
{
    public class OsobaContext : DbContext
    {
        public DbSet<Osoba> Osobe { get; set; }
        public OsobaContext(DbContextOptions<OsobaContext> opcije) : base(opcije)
        {
        }
    }
}
