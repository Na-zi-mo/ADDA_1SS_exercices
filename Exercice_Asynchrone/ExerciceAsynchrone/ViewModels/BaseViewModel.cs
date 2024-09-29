using System.ComponentModel;
using System.Runtime.CompilerServices;
using static ExerciceAsynchrone.ViewModels.Delegates.ViewModelDelegates;

namespace ExerciceAsynchrone.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected ChoisirDossier _choisirDossier;
        protected Info _info;
        protected Erreur _erreur;

        public BaseViewModel(Info info, Erreur erreur, ChoisirDossier choisirDossier)
        {
            _info = info;
            _erreur = erreur;
            _choisirDossier = choisirDossier;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
