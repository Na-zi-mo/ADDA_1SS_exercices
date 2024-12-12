using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace TP4.DataService
{
    public class SqliteMeteoDbContext : MeteoDbContext
    {
        public SqliteMeteoDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string chaineConnexion = $"Data Source = " +
                $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}" +
                $"{Path.DirectorySeparatorChar}" +
                $"{Properties.Settings.Default.nomBdSqlite}";
            optionsBuilder.UseSqlite(chaineConnexion);
        }
    }
}
