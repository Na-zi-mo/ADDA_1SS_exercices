using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TP4.Models
{
    public class Region
    {
        public Region()
        {
        }


        public Region(string Nom, double Longitude, double Latitude)
        {
            string error_messages = string.Empty;


            if (string.IsNullOrWhiteSpace(Nom))
                error_messages += $"{TP4.Properties.traduction.empty_region_message}\n";

            if (Longitude < -180 || Longitude > 180)
                error_messages += $"{TP4.Properties.traduction.out_of_range_longitude}\n";

            if (Latitude < -90 || Latitude > 90)
                error_messages += $"{TP4.Properties.traduction.out_of_range_latitude}\n";

            if (error_messages != string.Empty)
                throw new Exception(error_messages);

            this.Nom = Nom;
            this.Longitude = Longitude;
            this.Latitude = Latitude;
        }

        [Key]
        public int Id {  get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        public double Longitude { get; set; }

        [Required]
        public double Latitude { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Region region &&
                   Id == region.Id &&
                   Nom == region.Nom;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nom);
        }

        public override string ToString() 
        {
            return $"{Nom}\nLat: {Latitude}\nLon: {Longitude}";
        }
        
    }
}
