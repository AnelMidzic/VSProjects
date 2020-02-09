using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCoreVjezba02.Models
{
    [Table("Proizvod")]
    public partial class Proizvod
    {
        public int ProizvodId { get; set; }
        public int KategorijaId { get; set; }
        [Required]
        [StringLength(120)]
        public string Naziv { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Cena { get; set; }
        [StringLength(120)]
        public string Opis { get; set; }

        [ForeignKey("KategorijaId")]
        [InverseProperty("Proizvodi")]
        public virtual Kategorija Kategorija { get; set; }
    }
}