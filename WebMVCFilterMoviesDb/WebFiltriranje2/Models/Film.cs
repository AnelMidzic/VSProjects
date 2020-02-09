using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebFiltriranje2.Models
{
    [Table("Film")]
    public partial class Film
    {
        public int FilmId { get; set; }
        [Required]
        [StringLength(70)]
        public string Naziv { get; set; }
        public int ZanrId { get; set; }
        public int Godina { get; set; }

        [ForeignKey("ZanrId")]
        [InverseProperty("Filmovi")]
        public virtual Zanr Zanr { get; set; }
    }
}