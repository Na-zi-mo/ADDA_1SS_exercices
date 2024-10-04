using DogApi.Models;
using DogApi.ViewModels.Commands;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Windows;

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

        private List<Dog> Dogs;


        public GalerieViewModel()
        {
            _nbPhotoAffichees = 0;
            CmdProchainePhoto = new AsyncCommand(AfficherProchainePhoto, CanExecuteAfficherProchainePhoto);

            Dogs = new List<Dog>();
        }

        private async Task AfficherProchainePhoto(object? obj)
        {
            try
            {
                _enExecution = true;

                if (Dogs.Count == 0)
                {
                    _urlPhoto = "";
                    _nbPhotoAffichees = 0;
                    _races = "";

                    ApiClient client = new ApiClient(URL_BASE_API);

                    client.SetHttpRequestHeader("x-api-key", TOKEN);

                    string json = await client.RequeteGetAsync("/images/search?limit=20");

                    Dogs = JsonConvert.DeserializeObject<List<Dog>>(json) ?? new List<Dog>();

                    client.Dispose();
                }
                else
                {
                    Dog dog = Dogs[0];
                    Dogs.RemoveAt(0);


                    UrlPhoto = dog.url;
                    NbPhotoAffichees = 20 - Dogs.Count;
                    Races = dog.breeds.ToString();
                    
                }
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
