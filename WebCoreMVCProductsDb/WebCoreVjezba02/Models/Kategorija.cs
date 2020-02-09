using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCoreVjezba02.Models
{
    [Table("Kategorija")]
    public partial class Kategorija
    {
        public Kategorija()
        {
            Proizvodi = new HashSet<Proizvod>();
        }

        public int KategorijaId { get; set; }
        [Required]
        [StringLength(70)]
        public string Naziv { get; set; }
        [StringLength(120)]
        public string Opis { get; set; }

        [InverseProperty("Kategorija")]
        public virtual ICollection<Proizvod> Proizvodi { get; set; }
    }
}