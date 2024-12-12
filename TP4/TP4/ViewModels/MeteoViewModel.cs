using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP4.DataService.Repositories.Interfaces;
using TP4.Models;
using TP4.ViewModels.Interfaces;

namespace TP4.ViewModels
{
    public class MeteoViewModel : BaseViewModel
    {

        private Region _regionSelectionnee;

        private IRegionRepository _regionRepository;



        public MeteoViewModel(IInteractionUtilisateur interaction, IRegionRepository regionRepository) : base(interaction)
        {
            _regionRepository = regionRepository;          
            
            Regions = new ObservableCollection<Region>(_regionRepository.GetAll());
        }

        public Region? RegionSelectionnee
        {
            get { return _regionSelectionnee;}
            set
            {
                if (value != null) _regionSelectionnee = _regionRepository.Get(value.Id);
            }
            
        }

        public ObservableCollection<Region> Regions { get; set; }

    }
}
