using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebMvcModel03.Models
{
    [Table("Osoba")]
    public partial class Osoba
    {
        public int OsobaId { get; set; }
        [Required(ErrorMessage ="Unesite ime")]
        [StringLength(30,ErrorMessage ="Maksimalno 30 karaktera")]
        public string Ime { get; set; }
        [Required(ErrorMessage ="Unesite prezime")]
        [StringLength(30, ErrorMessage ="Maksimalno 30 karaktera")]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Unesite telefon")]
        [StringLength(20, ErrorMessage ="Maksimalno 20 karaktera")]        
        public string Telefon { get; set; }
        [Column(TypeName = "date")]
        [Required(ErrorMessage = "Unesite datum rodjenja")]
        [Display(Name ="Datum rodjenja")]
        [DisplayFormat(DataFormatString ="{0:d.M.yyyy}",ApplyFormatInEditMode =true)]
        public DateTime DatumRodjenja { get; set; }
    }
}