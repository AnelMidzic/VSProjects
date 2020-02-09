using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCorePogledi.Models
{
    [Table("Osoba")]
    public class Osoba
    {
        public int OsobaId { get; set; }
        [Required(ErrorMessage ="Unesite ime")]
        [StringLength(30,ErrorMessage ="Najmanje 3 a najvise 30 karaktera", MinimumLength =3)]
        [Display(Name ="Ime osobe")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Unesite prezime")]
        [StringLength(30, ErrorMessage = "Najvise 30 karaktera")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Unesite telefon")]
        [StringLength(30, ErrorMessage = "Najvise 20 karaktera")]
        public string Telefon { get; set; }
    }
}
