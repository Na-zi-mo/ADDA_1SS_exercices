using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JardinageWpf.DataService.Repositories.Database
{
    public abstract class BaseDatabaseRepository
    {
        protected readonly JardinageDbContext _context;

        protected BaseDatabaseRepository(JardinageDbContext context)
        {
            _context = context;
        }
    }
}
