using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FirstMvcApp.Models
{
    public partial class Person
    {
        public int Id { get; set; }
        [Display(Name = "FirstName")]
        [Required(ErrorMessage = "FirstNameRequired")]
        public string FirstName { get; set; }
        [Display(Name = "LastName")]
        [Required(ErrorMessage = "LastNameRequired")]
        public string LastName { get; set; }
        [Display(Name = "DateOfBirth")]
        [Required(ErrorMessage = "DateOfBirthRequired")]
        [DataRange(From = "1880/01/01", ErrorMessage = "DateOfBirthDateRange")]
        public DateTime? DateOfBirth { get; set; }
        public int? IsDeleted { get; set; }
    }
}
