using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACMEsoft.Model;

namespace ACMEsoft.Service
{
    public class EmployeeService : EntityService<Employee>, IEmployeeService
    {
        IContext _context;

        public EmployeeService(IContext context)
            : base(context)
        {
            _context = context;
            _dbset = _context.Set<Employee>();
        }

        public Employee GetById(long Id)
        {
            return _dbset.FirstOrDefault(x => x.Id == Id);
        }
    }
}
