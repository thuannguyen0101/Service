using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfService2.Data;
using WcfService2.Models;

namespace WcfService2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public Connection db = new Connection();
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public string AddEmployyeeRecord(Employee emp)
        {
            db.Employees.Add(emp);
            db.SaveChanges();
            return "success";
        }

        public List<Employee> GetEmployeeRecords(string searchString)
        {
            if (searchString != null)
            {
                return db.Employees.Where(s => s.Name.Contains(searchString)).ToList();
            }
            return db.Employees.ToList();
            
        }

        public string DeleteRecords(int? Id)
        {
            if (Id == null)
            {
                return null;
            }
            Employee employee = db.Employees.Find(Id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return "done";
        }

        public Employee SearchEmployeeRecord(int? Id)
        {
            if (Id == null)
            {
                return null;
            }
            Employee employee = db.Employees.Find(Id);
            return employee;
        }

        public string UpdateEmployeeContact(Employee emp)
        {
            db.Entry(emp).State = EntityState.Modified;
            db.SaveChanges();
            return "done";
        }
    }
}
