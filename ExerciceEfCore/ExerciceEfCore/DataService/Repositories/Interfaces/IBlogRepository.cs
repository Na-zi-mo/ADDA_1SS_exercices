using ExerciceEfCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceEfCore.DataService.Repositories.Interfaces
{
    public interface IBlogRepository
    {
        Task<Blog?> GetAsync(int id);

        Task<List<Blog>> GetAllAsync();

        Task<Blog> AddAsync(Blog blog);

        Task<Blog> UpdateAsync(Blog blog);

        Task<bool> DeleteAsync(Blog blog);
    }
}
