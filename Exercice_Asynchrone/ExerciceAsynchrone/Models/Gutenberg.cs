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
    public class Gutenberg
    {
        public string Path { get; set; }
        public string Content { get; set; }

        public int Occurences { get; set; } = 0;

        public Gutenberg(string path)
        {
            Path = path;

            using (StreamReader sr = new StreamReader(Path, Encoding.UTF8))
            {
                Content = sr.ReadToEnd();
            }

        }

        public Gutenberg SearchOccurences(string regexPattern) { 
            var regexp = new Regex(regexPattern);

            List<Match> matches =  regexp.Matches(Content).ToList();
            
            Occurences = matches.Count;

            return this;
        }

    }
}
