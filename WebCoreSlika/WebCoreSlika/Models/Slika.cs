using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCoreSlika.Models
{
    [Table("Slika")]
    public class Slika
    {
        public int SlikaId { get; set; }
        [Required(ErrorMessage ="Unesite naziv")]
        [StringLength(50, ErrorMessage ="Maksimalno 50 karaktera")]
        public string Naziv { get; set; }
        [Display(Name ="Fotografija")]
        [MaxLength]
        public byte[] BinarniPodaci { get; set; }
        [StringLength(20)]
        public string TipFajla { get; set; }
        [StringLength(100,ErrorMessage ="Min 5 a maksimalnno 100 karaktera", MinimumLength =5)]
        [Required(ErrorMessage ="Unesite opis")]
        [DataType(DataType.MultilineText)]
        public string Opis { get; set; }

    }
}
