using ACMEsoft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMEsoft.Service
{
    public class PersonService : EntityService<Person>, IPersonService
    {
        IContext _context;

        public PersonService(IContext context)
            : base(context)
        {
            _context = context;
            _dbset = _context.Set<Person>();
        }

        public Person GetById(long Id)
        {
            return _dbset.FirstOrDefault(x => x.Id == Id);
        }
    }
}
