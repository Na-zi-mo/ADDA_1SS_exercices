using JardinageWpf.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace JardinageWpf.ViewModels
{
    public class SelectionDeRegions : ObservableCollection<RegionInfo>
    {
        public SelectionDeRegions(ICollection<Region> regionsDeLaPlante, ICollection<Region> toutesLesRegions)
        {
            foreach (var region in toutesLesRegions)
            {
                this.Add(new RegionInfo(region, regionsDeLaPlante.Contains(region)));
            }
        }

        public ICollection<Region> GetRegionsSelectionnees()
        { 
            List<Region> regions = new List<Region>();
            foreach (var ri in this.Items)
            {
                if (ri.EstCochee) regions.Add(ri.Region);
            }

            return regions;
        }
    }

    public class RegionInfo : INotifyPropertyChanged
    {
        private bool _estCochee;

        public RegionInfo(Region region, bool estCochee) 
        { 
            Region = region;
            EstCochee = estCochee;
        }

        public Region Region { get; set; }

        public bool EstCochee 
        {
            get { return _estCochee; }
            set 
            { 
                _estCochee = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
