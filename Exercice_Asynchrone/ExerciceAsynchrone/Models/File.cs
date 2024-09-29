using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace ExerciceAsynchrone.Models
{
    public class File
    {
        public string Path { get; set; }    
        public string Content { get; set; }

        public File(string content, string path)
        {
            Content = content;
            Path = path;
        }

        public void Search(string regexPattern) { 
            var regexp = new Regex(regexPattern);

            List<Match> matches =  regexp.Matches(Content).ToList();

            MessageBox.Show($"{Path} : {matches.Count} found");
        }

    }
}
