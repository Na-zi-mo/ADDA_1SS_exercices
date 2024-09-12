using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Exercice1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Visibility visibilityAdd;
            
        public Visibility VisibilityAdd
        {
            get { return visibilityAdd; }
            set { 
                visibilityAdd = value;
                OnPropertyChanged();
            }
        }

        private Visibility visibilityEdit;

        public Visibility VisibilityEdit
        {
            get { return visibilityEdit; }
            set
            {
                visibilityEdit = value;
                OnPropertyChanged();
            }
        }


        private ObservableCollection<Personne> personnes;

        public ObservableCollection<Personne> Personnes
        {
            get { return personnes; }
            set { 
                personnes = value;
                OnPropertyChanged();
            }
        }

        private Personne personne;

        public Personne Personne
        {
            get { return personne; }
            set { 
                personne = value;
                OnPropertyChanged();
            }
        }

        private Personne currentItem;

        public Personne CurrentItem
        {
            get { return currentItem; }
            set
            {
                if (value != null)
                {
                    currentItem = value;
                    VisibilityAdd = Visibility.Hidden;
                    VisibilityEdit = Visibility.Visible;
                    OnPropertyChanged();
                }
            }
        }



        public MainWindow()
        {
            InitializeComponent();
            //Personne = new Personne("","","");
            this.Personnes = new ObservableCollection<Personne>();
            VisibilityAdd = Visibility.Visible;
            VisibilityEdit = Visibility.Hidden;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void AddPersonne(object sender, RoutedEventArgs e)
        {
            string erreurs = "";
            if (Personne.Name.Length < 5)
            {
                erreurs += "Le prénom doit avoir au moins 5 charactères\n";
            }
            if (Personne.Surname.Length < 5)
            {
                erreurs += "Le nom doit avoir au moins 5 charactères\n";
            }
            if (Personne.Phone.Length < 7)
            {
                erreurs += "Le téléphone doit avoir au moins 7 charactères\n";
            }

            if (erreurs == "")
            {
                Personnes.Add(new Personne(Personne.Surname,Personne.Name, Personne.Phone));
                Personne.Name = string.Empty;
                Personne.Surname = string.Empty;
                Personne.Phone = string.Empty;
                OnPropertyChanged(nameof(Personne));
            }
            else
            {
                MessageBox.Show(erreurs);
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            Personne.Name = string.Empty;
            Personne.Surname = string.Empty;
            Personne.Phone = string.Empty;
            OnPropertyChanged(nameof(Personne));
        }

        private void DeleteAll(object sender, RoutedEventArgs e)
        {
            Personnes.Clear();
        }

        private void DeleteSelection(object sender, RoutedEventArgs e)
        {
            Personnes.Remove(CurrentItem);
            //OnPropertyChanged(nameof(Personnes));
        }

        private void EditPersonne(object sender, RoutedEventArgs e)
        {
            this.CurrentItem = new Personne(Personne.Surname,Personne.Name,Personne.Phone);
            Personne.Name = string.Empty;
            Personne.Surname = string.Empty;
            Personne.Phone = string.Empty;
            OnPropertyChanged(nameof(Personne));
        }
    }
}