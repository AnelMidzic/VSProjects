using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServiceAplikacija.Models;

namespace WcfServiceAplikacija
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMagacinService" in both code and config file together.
    [ServiceContract]
    public interface IMagacinService
    {
        [OperationContract]
        List<Kategorija> VratiKategorije();
        [OperationContract]
        List<Proizvod> VratiProizvode(int id = 0);
    }
}
