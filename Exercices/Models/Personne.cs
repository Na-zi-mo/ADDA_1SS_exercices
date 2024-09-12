using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace test.Models
{
    public class Personne : INotifyPropertyChanged
    {
        private string _nom;
        private string _prenom;
        private string _telephone;

        internal Personne(string nom, string prenom, string telephone)
        {
            Nom = nom;
            Prenom = prenom;
            Telephone = telephone;
        }

        public string Nom
        {
            get { return _nom; }
            set
            {
                if (value == null || value.Length == 0) throw new ArgumentException("Nom non valide");
                _nom = value;
                OnPropertyChanged();
            }
        }

        public string Prenom
        {
            get { return _prenom; }
            set
            {
                if (value == null || value.Length == 0) throw new ArgumentException("Prénom non valide");
                _prenom = value;
                OnPropertyChanged();
            }
        }

        public string Telephone
        {
            get { return _telephone; }
            set
            {
                if (value == null || value.Length < 7) throw new ArgumentException("Téléphone non valide");
                _telephone = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
