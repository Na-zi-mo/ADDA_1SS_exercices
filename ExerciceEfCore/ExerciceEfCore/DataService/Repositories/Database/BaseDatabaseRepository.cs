using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceEfCore.DataService.Repositories.Database
{
    public abstract class BaseDatabaseRepository
    {
        protected readonly BlogDbContext _context;

        protected BaseDatabaseRepository(BlogDbContext context)
        {
            _context = context;
        }
    }
}
