using DogApi.ViewModels.Commands;
using System;
using System.Threading.Tasks;

namespace DogApi.ViewModels
{
    public class GalerieViewModel : BaseViewModel
    {
        private readonly static string URL_BASE_API = "https://api.thedogapi.com/v1";
        private readonly static string TOKEN = "live_R8rDnw79hLPmnNwRc4Upmb3BNknv3unXbFxRHcC9vGU4VmJD9ueR0x0tpxf7UJrM";

        private string _urlPhoto;
        private bool _enExecution;
        private int _nbPhotoAffichees;
        private string _races;


        public GalerieViewModel()
        {
            _nbPhotoAffichees = 0;
            CmdProchainePhoto = new AsyncCommand(AfficherProchainePhoto, CanExecuteAfficherProchainePhoto);
        }

        private async Task AfficherProchainePhoto(object? obj)
        {
            try
            {
                _enExecution = true;
            }
            catch (Exception ex) { }
            finally 
            { 
                _enExecution = false;
            }
        }

        private bool CanExecuteAfficherProchainePhoto(object? obj)
        {
            return !_enExecution;
        }

        public AsyncCommand CmdProchainePhoto { get; private set; }

        public string UrlPhoto
        {
            get { return _urlPhoto; }
            set
            {
                _urlPhoto = value;
                OnPropertyChanged();
            }
        }

        public int NbPhotoAffichees
        {
            get { return _nbPhotoAffichees; }
            set
            {
                _nbPhotoAffichees = value;
                OnPropertyChanged();
            }
        }

        public string Races
        {
            get { return _races; }
            set 
            { 
                _races = value;
                OnPropertyChanged();
            }
        }
    }
}
