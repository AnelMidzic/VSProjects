using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WebWCFServisHost.Models
{
    [DataContract]
    public class ProizvodCon
    {
        [DataMember]
        public int ProizvodId { get; set; }
        [DataMember]
        public int KategorijaId { get; set; }
        [DataMember]
        public string NazivProizvoda { get; set; }
        [DataMember]
        public decimal Cijena { get; set; }
        [DataMember]
        public int KolicinaNaLageru { get; set; }
    }
}