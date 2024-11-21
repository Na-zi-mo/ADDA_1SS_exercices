using System;
using ExerciceEfCore.DataService;
using ExerciceEfCore.DataService.Repositories.Interfaces;
using ExerciceEfCore.DataService.Repositories.Database;
using ExerciceEfCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExerciceEfCore
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                SqliteBlogDbContext context = new SqliteBlogDbContext();
                context.Database.Migrate();

                IBlogRepository bRepo = new BlogDatabaseRepository(context);


                // Création de blogues avec leur posts
                Blog b1 = new Blog { Url = "http://google.com", Posts = new List<Post> { new Post { Title = "Test", Content = "Un texte" } } };
                Blog b2 = new Blog
                {
                    Url = "http://yahoo.com",
                    Posts = new List<Post> {
                        new Post { Title = "Test2", Content = "Un texte2" },
                        new Post { Title = "Test3", Content = "Un texte3" }
                    }
                };

                // Persistance des blogues
                b1 = await bRepo.AddAsync(b1);
                b2 = await bRepo.AddAsync(b2);

                // On récupère l'ensemble des blogues persistés pour les afficher
                List<Blog> blogs = await bRepo.GetAllAsync();
                foreach (Blog blog in blogs)
                {
                    Console.WriteLine(blog + "\n");
                }

                // Mise à jour du blogues #2 ainsi que son premier post
                b2.Url = "http://altavista.com";
                b2.Posts[0].Title = "Yolaaaaaaaaaa";
                b2 = await bRepo.UpdateAsync(b2);
                Console.WriteLine(b2 + "\n");

                // Suppression du blogue #2
                await bRepo.DeleteAsync(b2);

                // On récupère l'ensemble des blogues persistés pour les afficher
                blogs = await bRepo.GetAllAsync();
                foreach (Blog blog in blogs)
                {
                    Console.WriteLine(blog + "\n");
                }

                await bRepo.DeleteAsync(b1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}