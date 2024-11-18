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
    public class PlanteDatabaseRepository : BaseDatabaseRepository, IPlanteRepository
    {
        public PlanteDatabaseRepository(JardinageDbContext context) : base(context) { }

        public Plante? Get(int id)
        {
            return _context.Plantes
                .Include(p => p.Famille)
                .Include(p => p.Regions)
                .FirstOrDefault(p => p.Id == id);
        }

        public List<Plante> GetAll()
        {
            return _context.Plantes
                .OrderBy(p => p.NomCommun)
                .ToList();
        }

        public async Task<List<Plante>> GetAllAsync()
        {
            return await _context.Plantes
                .OrderBy(p => p.NomCommun)
                .ToListAsync();
        }

        public async Task<Plante> AddAsync(Plante plante)
        {
            _context.Plantes.Add(plante);
            await _context.SaveChangesAsync();
            return plante;
        }

        public async Task<Plante> UpdateAsync(Plante plante)
        {
            _context.Plantes.Update(plante);
            await _context.SaveChangesAsync();
            return plante;
        }

        public async Task<bool> DeleteAsync(Plante plante)
        {
            _context.Plantes.Remove(plante);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
