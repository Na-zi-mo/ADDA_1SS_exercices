using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace JardinageWpf.DataService
{
    public class SqliteJardinageDbContext : JardinageDbContext
    {
        public SqliteJardinageDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // Ici, on s'assure que la BD sera créée dans le home directory de l'utilisateur
            string chaineConnexion = $"Data Source = " +
                $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}" +
                $"{Path.DirectorySeparatorChar}" +
                $"{Properties.Settings.Default.nomBdSqlite}";
            options.UseSqlite(chaineConnexion);
        }
    }
}