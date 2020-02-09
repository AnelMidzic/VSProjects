namespace WebWCFServisHost.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Proizvod")]
    public partial class Proizvod
    {
        public int ProizvodId { get; set; }

        public int KategorijaId { get; set; }

        [Required]
        [StringLength(50)]
        public string NazivProizvoda { get; set; }

        public decimal Cijena { get; set; }

        public int KolicinaNaLageru { get; set; }

        public virtual Kategorija Kategorija { get; set; }
    }
}
