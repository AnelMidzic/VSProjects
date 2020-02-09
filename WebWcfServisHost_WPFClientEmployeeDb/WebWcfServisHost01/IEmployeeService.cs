using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WebWcfServisHost01.Models;

namespace WebWcfServisHost01
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEmployeeService" in both code and config file together.
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        IEnumerable<EmployeeCon> ReturnEmployees();
        [OperationContract]
        int InsertEmployees(Employee e);
        [OperationContract]
        int ChangeEmployee(EmployeeCon e);
        [OperationContract]
        int DeleteEmployee(EmployeeCon e);
    }
}
