using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace ExerciceInjection.Models
{
    public class Personne : INotifyPropertyChanged
    {
        private static string pattern = "^(\\(\\d{3}\\) |\\d{3}-)?\\d{3}-\\d{4}$";
        private static Regex regexTel = new Regex(pattern);

        private long _id;
        private string _nom;
        private string _prenom;
        private string _telephone;

        internal Personne(long id, string nom, string prenom, string telephone)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Telephone = telephone;
        }

        public long Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        public string Nom
        {
            get { return _nom; }
            set
            {
                if (value == null || value.Length == 0) 
                    throw new ArgumentException(ExerciceInjection.Properties.traduction.msg_erreur_nom);
                _nom = value;
                OnPropertyChanged();
            }
        }

        public string Prenom
        {
            get { return _prenom; }
            set
            {
                if (value == null || value.Length == 0) 
                    throw new ArgumentException(ExerciceInjection.Properties.traduction.msg_erreur_prenom);
                _prenom = value;
                OnPropertyChanged();
            }
        }

        public string Telephone
        {
            get { return _telephone; }
            set
            {
                if (value == null || !regexTel.IsMatch(value.Trim())) 
                    throw new ArgumentException(ExerciceInjection.Properties.traduction.msg_erreur_tel);                
                _telephone = value.Trim();
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
