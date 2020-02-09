namespace WpfEf05.Models
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
        [StringLength(120)]
        public string Naziv { get; set; }

        public decimal Cena { get; set; }

        [StringLength(120)]
        public string Opis { get; set; }

        public virtual Kategorija Kategorija { get; set; }
    }
}
