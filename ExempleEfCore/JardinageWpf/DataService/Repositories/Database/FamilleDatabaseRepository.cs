using JardinageWpf.DataService.Repositories.Interfaces;
using JardinageWpf.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JardinageWpf.DataService.Repositories.Database
{
    public class FamilleDatabaseRepository : BaseDatabaseRepository, IFamilleRepository
    {
        public FamilleDatabaseRepository(JardinageDbContext context) : base(context) { }

        public List<Famille> GetAll()
        {
            return _context.Familles.OrderBy(f => f.Nom).ToList();
        }

        public async Task<List<Famille>> GetAllAsync()
        {
            return await _context.Familles.OrderBy(f => f.Nom).ToListAsync();
        }
    }
}
