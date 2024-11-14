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

        /// <summary>
        /// Méthode appelée seulement à la création des tables. Nous pouvons apporter des changements
        /// à la création par défaut des tables (ex: renommer le nom des tables). 
        /// Aussi, nous pouvons en profiter pour faire du seeding.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Famille> familles = new List<Famille>()
            {
                new Famille{ Id = 1, Nom = "Graminé" },
                new Famille{ Id = 2, Nom = "Orchidé" },
                new Famille{ Id = 3, Nom = "Labié" },
            };
            modelBuilder.Entity<Famille>().HasData(familles);

            List<Region> regions = new List<Region>()
            {
                new Region{ Id = 1, Nom = "Désertique" },
                new Region{ Id = 2, Nom = "Aride" },
                new Region{ Id = 3, Nom = "Tempéré" },
            };
            modelBuilder.Entity<Region>().HasData(regions);

            List<Plante> plantes = new List<Plante>()
            {
                new Plante{ Id = 1, Hauteur = 20, NomCommun = "Pissenlit" , NomScientifique = "Taraxacum officinale F.H. Wigg.", FamilleId = 1},
                new Plante{ Id = 2, Hauteur = 50, NomCommun = "Blé" , NomScientifique = "Triticum turgidum ssp. durum", FamilleId = 1},
                new Plante{ Id = 3, Hauteur = 20, NomCommun = "Orchidée papillon" , NomScientifique = "Phalaenopsis", FamilleId = 2},
            };
            modelBuilder.Entity<Plante>().HasData(plantes);

            modelBuilder
            .Entity<Plante>()
            .HasMany(p => p.Regions)
            .WithMany(r => r.Plantes)
            .UsingEntity<Dictionary<string, object>>(
                "PlanteRegion",
                planteRegion =>
                {
                    planteRegion.HasData(
                        new { PlantesId = 1, RegionsId = 1 },
                        new { PlantesId = 1, RegionsId = 3 },
                        new { PlantesId = 2, RegionsId = 2 },
                        new { PlantesId = 3, RegionsId = 1 });
                }
            );
        }
    }
}