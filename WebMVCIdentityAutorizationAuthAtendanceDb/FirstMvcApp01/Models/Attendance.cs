using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace FirstMvcApp.Models
{
    public class Attendance
    {

        public static void AddAttendant(Person person)
        {
            if (person != null)
            {
                TestContext dataContext = new TestContext();
                dataContext.Person.Add(person);
                dataContext.SaveChanges();
            }
        }

        public static List<Person> GetAttendants()
        {
            TestContext dataContext = new TestContext();
            return dataContext.Person.ToList();
            //return attendants;
        }

    }

}
