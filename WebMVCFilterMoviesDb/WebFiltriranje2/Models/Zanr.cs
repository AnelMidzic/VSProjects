using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebFiltriranje2.Models
{
    [Table("Zanr")]
    public partial class Zanr
    {
        public Zanr()
        {
            Filmovi = new HashSet<Film>();
        }

        public int ZanrId { get; set; }
        [Required]
        [StringLength(30)]
        public string Naziv { get; set; }

        [InverseProperty("Zanr")]
        public virtual ICollection<Film> Filmovi { get; set; }
    }
}