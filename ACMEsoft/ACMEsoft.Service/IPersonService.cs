using ACMEsoft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMEsoft.Service
{
    public interface IPersonService : IEntityService<Person>
    {
        Person GetById(long Id);
    }
}
