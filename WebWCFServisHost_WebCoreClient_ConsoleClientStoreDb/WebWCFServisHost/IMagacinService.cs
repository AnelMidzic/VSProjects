using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WebWCFServisHost.Models;

namespace WebWCFServisHost
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMagacinService" in both code and config file together.
    [ServiceContract]
    public interface IMagacinService
    {
        [OperationContract]
        IEnumerable<KategorijaCon> VratiKategorije();
        [OperationContract]
        KategorijaCon VratiKategoriju(int id);
        [OperationContract]
        IEnumerable<ProizvodCon> VratiProizvode(int id = 0);
    }
}
