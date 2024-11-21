using ExerciceEfCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceEfCore.DataService
{
    public abstract class BlogDbContext : DbContext
    {

        protected BlogDbContext() { }

        public DbSet<Blog> Blogs {  get; set; }

        public DbSet<Post> Posts { get; set; }



        
    }
}
