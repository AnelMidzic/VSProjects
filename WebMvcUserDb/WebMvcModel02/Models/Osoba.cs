using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebMvcModel02.Models
{
    [Table("Osoba")]
    public class Osoba
    {
        public int OsobaId { get; set; }
        [Required(ErrorMessage ="Unesite ime")]
        [StringLength(30,ErrorMessage ="Maksimalno 30 karaktera")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Unesite prezime")]
        [StringLength(30, ErrorMessage = "Maksimalno 30 karaktera")]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Unesite telefon")]
        [StringLength(30, ErrorMessage = "Maksimalno 30 karaktera")]
        public string Telefon { get; set; }
    }
}
