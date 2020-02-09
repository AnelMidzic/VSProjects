namespace WebWCFServisHost.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kategorija")]
    public partial class Kategorija
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kategorija()
        {
            Proizvodi = new HashSet<Proizvod>();
        }

        public int KategorijaId { get; set; }

        [Required]
        [StringLength(50)]
        public string NazivKategorije { get; set; }

        [Required]
        [StringLength(100)]
        public string OpisKategorije { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proizvod> Proizvodi { get; set; }
    }
}
