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
                new Region{ Id = 1, Nom = "Shawinigan", Latitude = 46.56984172477484, Longitude = -72.73811285651442 },
                new Region{ Id = 2, Nom = "Algiers", Latitude = 36.7538, Longitude = 3.0588 },
                new Region{ Id = 3, Nom = "Oran", Latitude = 35.6971, Longitude = -0.6308 },
                new Region{ Id = 4, Nom = "Constantine", Latitude = 36.365, Longitude = 6.6147 },
                new Region{ Id = 5, Nom = "Annaba", Latitude = 36.9, Longitude = 7.766 },
                new Region{ Id = 6, Nom = "Blida", Latitude = 36.4701, Longitude = 2.8277 },
                new Region{ Id = 7, Nom = "Batna", Latitude = 35.555, Longitude = 6.1744 },
                new Region{ Id = 8, Nom = "Tlemcen", Latitude = 34.8783, Longitude = -1.315 },
                new Region{ Id = 9, Nom = "Sétif", Latitude = 36.192, Longitude = 5.4138 },
                new Region{ Id = 10, Nom = "Béjaïa", Latitude = 36.7509, Longitude = 5.0566 },
                new Region{ Id = 11, Nom = "Ghardaïa", Latitude = 32.4908, Longitude = 3.6735 },
                new Region{ Id = 12, Nom = "Tizi Ouzou", Latitude = 36.717, Longitude = 4.0459 },
                new Region{ Id = 13, Nom = "Skikda", Latitude = 36.8662, Longitude = 6.9067 },
                new Region{ Id = 14, Nom = "Biskra", Latitude = 34.8504, Longitude = 5.728 },
                new Region{ Id = 15, Nom = "Adrar", Latitude = 27.8761, Longitude = -0.2832 },
                new Region{ Id = 16, Nom = "Laghouat", Latitude = 33.8036, Longitude = 2.8829 },
                new Region{ Id = 17, Nom = "Tamanrasset", Latitude = 22.785, Longitude = 5.5228 }
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
