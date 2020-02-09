using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebCoreControleri.Models
{
    [Table("Osoba")]
    public class Osoba
    {
        public int OsobaId { get; set; }
        [Required(ErrorMessage ="Unesite ime")]
        [StringLength(30, ErrorMessage ="Unesite maksimalno 30 karaktera")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Unesite ime")]
        [StringLength(30, ErrorMessage = "Unesite maksimalno 30 karaktera")]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Unesite ime")]
        [StringLength(30, ErrorMessage = "Unesite maksimalno 20 karaktera")]
        public string Telefon { get; set; }
    }
}
