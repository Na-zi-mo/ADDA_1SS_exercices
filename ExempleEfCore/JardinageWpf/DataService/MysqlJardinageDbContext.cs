using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JardinageWpf.DataService
{
    public class MysqlJardinageDbContext : JardinageDbContext
    {
        public MysqlJardinageDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string chaineConnexion = Properties.Settings.Default.chaineConnexionMysql;
            options.UseMySql(chaineConnexion, ServerVersion.AutoDetect(chaineConnexion));
        }
    }
}
