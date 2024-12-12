using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace TP4.Models
{
    public class Prevision
    {
        public BitmapImage? image {  get; set; }
        public double app_max_temp { get; set; }
        public double app_min_temp { get; set; }
        public int clouds { get; set; }
        public int clouds_hi { get; set; }
        public int clouds_low { get; set; }
        public int clouds_mid { get; set; }
        public string datetime { get; set; }
        public double dewpt { get; set; }
        public double high_temp { get; set; }
        public double low_temp { get; set; }
        public object max_dhi { get; set; }
        public double max_temp { get; set; }
        public double min_temp { get; set; }
        public double moon_phase { get; set; }
        public double moon_phase_lunation { get; set; }
        public int moonrise_ts { get; set; }
        public int moonset_ts { get; set; }
        public int ozone { get; set; }
        public int pop { get; set; }
        public double precip { get; set; }
        public int pres { get; set; }
        public int rh { get; set; }
        public int slp { get; set; }
        public double snow { get; set; }
        public double snow_depth { get; set; }
        public int sunrise_ts { get; set; }
        public int sunset_ts { get; set; }
        public double temp { get; set; }
        public int ts { get; set; }
        public int uv { get; set; }
        public string valid_date { get; set; }
        public double vis { get; set; }
        public Weather weather { get; set; }
        public string wind_cdir { get; set; }
        public string wind_cdir_full { get; set; }
        public int wind_dir { get; set; }
        public double wind_gust_spd { get; set; }
        public double wind_spd { get; set; }
    }
}
