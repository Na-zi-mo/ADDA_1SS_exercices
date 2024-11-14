using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class Personne
    {
        public Personne(string prenom, string nom, int age, string ville)
        {
            Prenom = prenom;
            Nom = nom;
            Age = age;
            Ville = ville;
        }


        public string Prenom { get; set; }
        public string Nom { get; set; }
        public int Age { get; set; }
        public string Ville { get; set; }

        public override string ToString()
        {
            return $"{Prenom} {Nom} - {Age} - {Ville}";
        }
    }
}
