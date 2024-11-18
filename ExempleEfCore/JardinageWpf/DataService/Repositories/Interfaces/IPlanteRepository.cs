using JardinageWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JardinageWpf.DataService.Repositories.Interfaces
{
    public interface IPlanteRepository
    {
        Plante? Get(int id);

        List<Plante> GetAll();

        Task<List<Plante>> GetAllAsync();

        Task<Plante> AddAsync(Plante plante);

        Task<Plante> UpdateAsync(Plante plante);

        Task<bool> DeleteAsync(Plante plante);
    }
}
