using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Linq;
using ACMEsoft.Models;

namespace ACMEsoft.DataAccessRepository
{
    public class clsDataAccessRepository : IDataAccessRepository<Employee, long>
    {
        //The dendency for the DbContext specified the current class. 
        [Dependency]
        public ACMEsoftEntities ctx { get; set; }

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
                employee.EmployeeId = entity.EmployeeId;
                employee.PersonId = entity.PersonId;
                employee.EmployeeNumber = entity.EmployeeNumber;
                employee.EmployedDate = entity.EmployedDate;
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