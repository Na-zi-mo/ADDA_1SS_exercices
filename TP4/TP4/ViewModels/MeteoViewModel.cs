﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP4.DataService.Repositories.Interfaces;
using TP4.Models;
using TP4.ViewModels.Interfaces;
using Newtonsoft.Json;
using System.Windows.Media.Imaging;
using System.Reflection.Metadata;
using System.Windows;
using TP4.ViewModels.Commands;
using System.Windows.Controls;

namespace TP4.ViewModels
{
    public class MeteoViewModel : BaseViewModel
    {

        private Region _regionSelectionnee;
        private ObservableCollection<Prevision>? _previsions;

        private Visibility isDeleteVisisble = Visibility.Hidden;
        private string _nomVille;
        private string _codePays;

        private string _region;
        private double _latitude;
        private double _longitude;

       
        private IRegionRepository _regionRepository;



        public MeteoViewModel(IInteractionUtilisateur interaction, IRegionRepository regionRepository) : base(interaction)
        {
            _regionRepository = regionRepository;          
            
            Regions = new ObservableCollection<Region>(_regionRepository.GetAll());

            AjouterRegionCmd = new RelayCommand(Ajouter, null);
        }

        public void Ajouter(object? obj)
        {
            try
            {
                string error_messages = string.Empty;

                if (Region == string.Empty || Region is null)
                    error_messages += $"{TP4.Properties.traduction.empty_region_message}\n";


              
                if (error_messages != string.Empty)
                    throw new Exception(error_messages);
            }
            catch (Exception e)
            {

                _interaction.ShowErrorMessage(e.Message);
            }
        }

        private async Task GatherPrevisions(Region region)
        {
            try
            {
                if (TP4.Properties.Settings.Default.token == string.Empty || TP4.Properties.Settings.Default.token is null)
                    throw new Exception(TP4.Properties.traduction.error_empty_token);

                ApiClient client = new ApiClient("https://api.weatherbit.io/v2.0/forecast/daily");

                string json = await client.RequeteGetAsync($"?key={TP4.Properties.Settings.Default.token}&days=7&lat={region.Latitude}&lon={region.Longitude}");

                Meteo meteo = JsonConvert.DeserializeObject<Meteo>(json) ?? new Meteo();

                Previsions = new ObservableCollection<Prevision>(meteo.data);

                foreach (var p in Previsions)
                {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri($"https://www.weatherbit.io/static/img/icons/{p.weather.icon}.png", UriKind.Absolute);
                    bitmap.EndInit();

                    p.image = bitmap;
                }

                NomVille = meteo.city_name;
                CodePays = meteo.country_code;


                client.Dispose();
            }
            catch (Exception e)
            {

                _interaction.ShowErrorMessage(e.Message);
            }
        }


        public ObservableCollection<Prevision>? Previsions
        {
            get { return _previsions; }
            set
            {
                _previsions = value;
                OnPropertyChanged();
            }
        }

        public Region? RegionSelectionnee
        {
            get { return _regionSelectionnee;}
            set
            {
                if (value != null)
                {
                    _regionSelectionnee = _regionRepository.Get(value.Id);
                    IsDeleteVisisble = Visibility.Visible;
                    GatherPrevisions(_regionSelectionnee);
                    OnPropertyChanged();
                }
            }
            
        }

        public Visibility IsDeleteVisisble
        {
            get { return isDeleteVisisble; }
            set { isDeleteVisisble = value; OnPropertyChanged(); }
        }

        public string NomVille
        {
            get { return _nomVille; }
            set
            {
                if (value != null)
                {
                    _nomVille = value;
                    OnPropertyChanged();
                }
            }

        }

        public string CodePays
        {
            get { return _codePays; }
            set
            {
                if (value != null)
                {
                    _codePays = value;
                    OnPropertyChanged();
                }
            }

        }

        public string Region
        {
            get { return _region; }
            set
            {
                _region = value;
                OnPropertyChanged();
            }
        }

        public double Latitude
        {
            get { return _latitude; }
            set
            {
                _latitude = value;
                OnPropertyChanged();
            }
        }

        public double Longitude
        {
            get { return _longitude; }
            set
            {
                _longitude = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Region> Regions { get; set; }


        public RelayCommand AjouterRegionCmd { get; private set; }

    }
}
