using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP4.DataService.Repositories.Interfaces;
using TP4.Models;

namespace TP4.DataService.Repositories.Database
{
    public class RegionDatabaseRepository : BaseDatabaseRepository, IRegionRepository
    {
        public RegionDatabaseRepository(MeteoDbContext context) : base(context) { }

        public async Task<Region?> GetAsync(int id)
        {
            return await _context.Regions
                .FirstOrDefaultAsync(p=> p.Id ==id);
        }
        public Region? Get(int id) => _context.Regions
                .FirstOrDefault(p => p.Id == id);

        public List<Region> GetAll()
        {
            return _context.Regions.ToList();
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await _context.Regions
                .ToListAsync();
        }

        public async Task<Region> AddAsync(Region region)
        {
            _context.Regions.Add(region);
            await _context.SaveChangesAsync();
            return region;
        }

        public async Task<bool> DeleteAsync(Region region)
        {
            _context.Regions.Remove(region);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
