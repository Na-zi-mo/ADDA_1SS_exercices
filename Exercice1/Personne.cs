using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice1
{
    public class Personne
    {
        private string phone;

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string surname;

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public Personne(string nom, string prenom, string telephone) { 

            Surname = nom;
            Name = prenom;
            Phone = telephone;
        }
    }
}
