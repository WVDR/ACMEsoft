using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ACMEsoft.DataAccessRepository;
using ACMEsoft.Models;

namespace ACMEsoft.Controllers
{
    public class EmployeeAPIController : ApiController
    {
        private IDataAccessRepository<Employee, int> _repository;
        //Inject the DataAccessRepository using Construction Injection 
        public EmployeeAPIController(IDataAccessRepository<Employee, int> r)
        {
            _repository = r;
        }
        public IEnumerable<Employee> Get()
        {
            return _repository.Get();
        }

        [ResponseType(typeof(Employee))]
        public IHttpActionResult Get(int id)
        {
            return Ok(_repository.Get(id));
        }

        [ResponseType(typeof(Employee))]
        public IHttpActionResult Post(Employee emp)
        {
            _repository.Post(emp);
            return Ok(emp);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, Employee emp)
        {
            _repository.Put(id, emp);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(int id)
        {
            _repository.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
