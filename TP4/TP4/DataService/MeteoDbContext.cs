using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP4.Models;

namespace TP4.DataService
{
    public abstract class MeteoDbContext : DbContext
    {
        public MeteoDbContext() {}

        public DbSet<Region> Regions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Region> regions = new List<Region>()
            {
                new Region{ Id = 1, Nom = "Shawinigan", Latitude = 46.56984172477484, Longitude =  -72.73811285651442 },
                new Region{ Id = 2, Nom = "Algiers", Latitude = 36.7538, Longitude = 3.0588 }
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
