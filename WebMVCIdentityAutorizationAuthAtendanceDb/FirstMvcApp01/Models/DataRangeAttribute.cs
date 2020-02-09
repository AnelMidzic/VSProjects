using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstMvcApp.Models
{
    public class DataRangeAttribute : ValidationAttribute
    {
        public string From { get; set; }

        public override bool IsValid(object value)
        {
            if(value == null)
            {
                return false;
            }

            DateTime from = DateTime.Parse(From);
            DateTime dateValue = (DateTime)value;

            if (dateValue > from && dateValue <= DateTime.Now)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
