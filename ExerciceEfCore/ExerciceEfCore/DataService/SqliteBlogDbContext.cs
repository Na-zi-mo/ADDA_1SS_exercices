using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceEfCore.DataService
{
    public class SqliteBlogDbContext : BlogDbContext
    {
        public SqliteBlogDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string chaineConnexion = $"Data Source = "+
                 $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}" +
                $"{Path.DirectorySeparatorChar}" +
                 $"blog.db";
            options.UseSqlite(chaineConnexion);

        }
    }
}
