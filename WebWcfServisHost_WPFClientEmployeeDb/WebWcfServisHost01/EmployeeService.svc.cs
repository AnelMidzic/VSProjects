using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WebWcfServisHost01.Models;

namespace WebWcfServisHost01
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeeService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EmployeeService.svc or EmployeeService.svc.cs at the Solution Explorer and start debugging.
    public class EmployeeService : IEmployeeService
    {
        private Model db = new Model();
        public int ChangeEmployee(EmployeeCon e)
        {
            Employee e1 = null;

            try
            {
                e1 = db.Employees.Find(e.EmployeeID);
                e1.FirstName = e.FirstName;
                e1.LastName = e.LastName;
                e1.BirthDate = e.BirthDate;
                db.SaveChanges();
                return 0;
            }
            catch (Exception)
            {
                db.Entry(e1).State = EntityState.Unchanged;
                return -1;
            }
        }

        public int DeleteEmployee(EmployeeCon e)
        {
            Employee e1 = null;

            try
            {
                e1 = db.Employees.Find(e.EmployeeID);
                db.Employees.Remove(e1);
                db.SaveChanges();
                return 0;
            }
            catch (Exception)
            {
                db.Entry(e1).State = EntityState.Unchanged;
                return -1;
            }
        }

        public int InsertEmployees(Employee e)
        {
            
            try
            {
                 
                db.Employees.Add(e);
                db.SaveChanges();
                return e.EmployeeID;
            }
            catch (Exception)
            {
                db.Entry(e).State = EntityState.Detached;
                return -1;
            }
        }

        public IEnumerable<EmployeeCon> ReturnEmployees()
        {
            IEnumerable<EmployeeCon> employeeList = db.Employees.Select(e => new EmployeeCon
            {
                EmployeeID = e.EmployeeID,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Address = e.Address,
                City = e.City,
                Title = e.Title,
                TitleOfCourtesy = e.TitleOfCourtesy,
                BirthDate = e.BirthDate,
                HireDate = e.HireDate,
                Region = e.Region,
                PostalCode = e.PostalCode,
                Country = e.Country,
                HomePhone = e.HomePhone,
                Extension = e.Extension,
                //Photo = e.Photo,
                Notes = e.Notes,
                ReportsTo = e.ReportsTo
                //PhotoPath = e.PhotoPath
            });

            return employeeList;
        }
    }
}
