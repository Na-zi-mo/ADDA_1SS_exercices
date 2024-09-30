using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;


namespace ExerciceAsynchrone.Models
{
    public class Searcher
    {
        public string DirPath { get; set; }

        List<string> FileEntries { get; set; }


        public Searcher(string dirPath)
        {
            DirPath = dirPath;
            FileEntries = new List<string>(Directory.GetFiles(dirPath));
        }

        public List<Gutenberg> Search(string regexPattern)
        {
            List<Gutenberg> Results = new List<Gutenberg>();

            for (int i = 0; i < 100; i++)
            {
                Gutenberg File = new Gutenberg(FileEntries[i]);
                
                Results.Add(File.SearchOccurences(regexPattern));
            }

            return Results;
        }


        public async Task<List<Gutenberg>> SearchAsync(string regexPattern)
        {
            List<Gutenberg> Results = new List<Gutenberg>();

            for (int i = 0; i < 100; i++)
            {
                Gutenberg File = new Gutenberg(FileEntries[i]);

                Results.Add(await File.SearchOccurencesAsync(regexPattern));
            }

            return Results;
        }

        public async Task<List<Gutenberg>> SearchAsyncWhenAll(string regexPattern)
        {
            List<Task<Gutenberg>> Tasks = new List<Task<Gutenberg>>();

            for (int i = 0; i < 100; i++)
            {
                Gutenberg File = new Gutenberg(FileEntries[i]);

                Tasks.Add(File.SearchOccurencesAsync(regexPattern));
            }

            Gutenberg[] Results = await Task.WhenAll(Tasks);
            
            return new List<Gutenberg>(Results);
        }
    }
}
