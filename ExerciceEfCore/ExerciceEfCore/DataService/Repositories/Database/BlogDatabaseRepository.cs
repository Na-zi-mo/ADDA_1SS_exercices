using ExerciceEfCore.DataService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExerciceEfCore.Entities;
using System.Numerics;

namespace ExerciceEfCore.DataService.Repositories.Database
{
    public class BlogDatabaseRepository : BaseDatabaseRepository, IBlogRepository
    {
        public BlogDatabaseRepository(BlogDbContext context) : base(context) { }

        public async Task<Blog?> GetAsync(int id)
        {
            return await _context.Blogs
                .Include(b => b.Posts)
                .FirstOrDefaultAsync(p => p.BlogId == id);
        }

        public async Task<List<Blog>> GetAllAsync()
        {
            return await _context.Blogs
                .ToListAsync();
        }

        public async Task<Blog> AddAsync(Blog blog)
        {
            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();
            return blog;
        }

        public async Task<Blog> UpdateAsync(Blog blog)
        {
            _context.Blogs.Update(blog);
            await _context.SaveChangesAsync();
            return blog;
        }

        public async Task<bool> DeleteAsync(Blog blog)
        {
            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
