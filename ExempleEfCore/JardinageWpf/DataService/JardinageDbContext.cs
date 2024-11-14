using JardinageWpf.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace JardinageWpf.DataService
{
    /// <summary>
    /// Comme le nom l'indique, le contexte permet de faire le lien entre notre code (entités) et la base de données.
    /// C'est à l'aide de cette classe que nous pourrons accéder à nos tables (DBSet).
    /// Nous héritons de DbContext qui est la classe générique de Entity Framework Core.
    /// </summary>
    public abstract class JardinageDbContext : DbContext
    {
        public JardinageDbContext() { }

        // Un DbSet représente une table de la base de données.
        // Il peut être utilisé pour faire des requêtes (select, insert, update, delete).
        // On utilise LINQ avec ces derniers.
        // Les commandes LINQ sont traduites en SQL par Entity Framework Core.
        public DbSet<Region> Regions { get; set; }

        public DbSet<Famille> Familles { get; set; }

        public DbSet<Plante> Plantes { get; set; }
    }
}