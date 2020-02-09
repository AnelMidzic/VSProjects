using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebWcfServisHost01.Models
{
    [DataContract]
    public class EmployeeCon
    {
        [DataMember]
        public int EmployeeID { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string TitleOfCourtesy { get; set; }
        [DataMember]
        public DateTime? BirthDate { get; set; }
        [DataMember]
        public DateTime? HireDate { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Region { get; set; }
        [DataMember]
        public string PostalCode { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string HomePhone { get; set; }
        [DataMember]
        public string Extension { get; set; }
        [DataMember]
        public byte[] Photo { get; set; }
        [DataMember]
        public string Notes { get; set; }
        [DataMember]
        public int? ReportsTo { get; set; }
        [DataMember]
        public string PhotoPath { get; set; }
    }
}