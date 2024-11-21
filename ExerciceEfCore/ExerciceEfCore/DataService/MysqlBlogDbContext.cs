using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceEfCore.DataService
{
    public class MysqlBlogDbContext : BlogDbContext
    {
        public MysqlBlogDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string chaineConnexion = "server=localhost;port=3306;database=blog;userid=dev;password=dev123";
            options.UseMySql(chaineConnexion, ServerVersion.AutoDetect(chaineConnexion));
        }
    }
}
