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
    public class RegionDatabaseRepository : BaseDatabaseRepository, IRegionRepository
    {
        public RegionDatabaseRepository(JardinageDbContext context) : base(context) { }

        public List<Region> GetAll()
        {
            return _context.Regions.OrderBy(r => r.Nom).ToList();
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await _context.Regions.OrderBy(r => r.Nom).ToListAsync();
        }
    }
}
