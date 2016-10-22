using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACMEsoft.Model;

namespace ACMEsoft.Service
{
    public interface IEmployeeService : IEntityService<Employee>
    {
        Employee GetById(long Id);
    }
}
