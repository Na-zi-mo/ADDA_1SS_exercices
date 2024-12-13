using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TP4.Models;

namespace TP4.DataService.Repositories.Interfaces
{
    public interface IRegionRepository
    {
        List<Region> GetAll();

        Task<List<Region>> GetAllAsync();

        Task<Region> AddAsync(Region region);

        Task<bool> DeleteAsync(Region region);
    }
}
