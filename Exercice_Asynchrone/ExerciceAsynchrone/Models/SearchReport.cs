using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceAsynchrone.Models
{
    public class SearchReport
    {
        public List<Gutenberg> FilesSearched { get; set; } = new List<Gutenberg>();
        public int PourcentageCompleted { get; set; } = 0;
        public int FilesCount { get; private set; }

        public SearchReport(int filesCount)
        {
            FilesCount = filesCount;
        }

        public void AddSearchedFile(Gutenberg file)
        {
            FilesSearched.Add(file);
            PourcentageCompleted = (FilesSearched.Count * 100) / FilesCount;
        }
    }
}
