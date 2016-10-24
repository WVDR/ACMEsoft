using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACMEsoft.Model;

namespace ACMEsoft.DataAccessRepository
{
    public class clsDataAccessRepository : IDataAccessRepository<Employee, long>
    {
        //The dendency for the DbContext specified the current class. 
        [Dependency]
        public ACMEsoftContext ctx { get; set; }

        //Get all Employees
        public IEnumerable<Employee> Get()
        {
            return ctx.Employees.ToList();
        }
        //Get Specific Employee based on Id
        public Employee Get(long id)
        {
            return ctx.Employees.Find(id);
        }

        //Create a new Employee
        public void Post(Employee entity)
        {
            ctx.Employees.Add(entity);
            ctx.SaveChanges();
        }
        //Update Exisitng Employee
        public void Put(long id, Employee entity)
        {
            var employee = ctx.Employees.Find(id);
            if (employee != null)
            {
                employee.EmployeeID = entity.EmployeeID;
                employee.PersonID = entity.PersonID;
                employee.EmployeeNumber = entity.EmployeeNumber;
                employee.EmployeeDate = entity.EmployeeDate;
                employee.TerminatedDate = entity.TerminatedDate;                
                ctx.SaveChanges();
            }
        }
        //Delete an Employee based on Id
        public void Delete(long id)
        {
            var Emp = ctx.Employees.Find(id);
            if (Emp != null)
            {
                ctx.Employees.Remove(Emp);
                ctx.SaveChanges();
            }
        }
    }
}