using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebMvcModel03.Models
{
    public partial class OsobaContext : DbContext
    {        
        public OsobaContext(DbContextOptions<OsobaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Osoba> Osobe { get; set; }
                       
    }
}