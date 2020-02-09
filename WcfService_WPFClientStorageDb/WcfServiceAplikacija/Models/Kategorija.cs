using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WcfServiceAplikacija.Models
{
    [DataContract]
    public class Kategorija
    {
        [DataMember]
        public int KategorijaId { get; set; }
        [DataMember]
        public string NazivKategorije { get; set; }
        [DataMember]
        public string OpisKategorije { get; set; }
    }
}