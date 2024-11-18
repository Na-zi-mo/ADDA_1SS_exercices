using JardinageWpf.DataService.Repositories.Interfaces;
using JardinageWpf.Models;
using JardinageWpf.ViewModels.Commands;
using JardinageWpf.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace JardinageWpf.ViewModels
{
    public class JardinageViewModel : BaseViewModel
    {
        private Plante? _planteSelectionnee;
        private bool _modeAjout = true;
        private string _nomCommun;
        private string _nomScientifique;
        private double _hauteur;
        private Famille? _familleSelectionnee;
        private SelectionDeRegions _selectionDeRegions;

        private IRegionRepository _regionRepository;
        private IFamilleRepository _familleRepository;
        private IPlanteRepository _planteRepository;

        public JardinageViewModel(IInteractionUtilisateur interaction,
            IRegionRepository regionRepository,
            IFamilleRepository familleRepository,
            IPlanteRepository planteRepository) : base(interaction)
        {
            _regionRepository = regionRepository;
            _familleRepository = familleRepository;
            _planteRepository = planteRepository;

            Plantes = new ObservableCollection<Plante>(_planteRepository.GetAll());
            Regions = new ObservableCollection<Region>(_regionRepository.GetAll());
            Familles = new ObservableCollection<Famille>(_familleRepository.GetAll());

            CommandeAjouter = new AsyncCommand(Ajouter, null);
            CommandeNouvellePlante = new RelayCommand(NouvellePlante, null);
            CommandeModifier = new AsyncCommand(Modifier, CanExecuteModifierSupprimer);
            CommandeSupprimer = new AsyncCommand(Supprimer, CanExecuteModifierSupprimer);

            SelectionDeRegions = new SelectionDeRegions(new List<Region>(), Regions);
        }

        private void NouvellePlante(object? obj)
        {
            PlanteSelectionnee = null;
        }

        private async Task Ajouter(object? obj)
        {
            try
            {
                Plante nvllePlante = new Plante
                {
                    //Id = 0,
                    NomCommun = NomCommun,
                    NomScientifique = NomScientifique,
                    Hauteur = Hauteur,
                    Famille = FamilleSelectionnee,
                    Regions = SelectionDeRegions.GetRegionsSelectionnees()
                };
                await _planteRepository.AddAsync(nvllePlante);
                Plantes.Add(nvllePlante);
                PlanteSelectionnee = nvllePlante;
                _interaction.AfficherMessageInfo("Plante ajoutée avec succès!");
            }
            catch (Exception ex)
            {
                _interaction.AfficherMessageErreur(ex.Message);
            }
        }

        private async Task Modifier(object? obj)
        {
            if (PlanteSelectionnee != null)
            {
                string vieuxNomCommun = PlanteSelectionnee.NomCommun;
                string vieuxNomScientifique = PlanteSelectionnee.NomScientifique;
                double vieilleHauteur = PlanteSelectionnee.Hauteur;
                Famille vieilleFamille = PlanteSelectionnee.Famille;
                ICollection<Region> vieillesRegions = PlanteSelectionnee.Regions;
                try
                {
                    PlanteSelectionnee.NomCommun = NomCommun;
                    PlanteSelectionnee.NomScientifique = NomScientifique;
                    PlanteSelectionnee.Hauteur = Hauteur;
                    PlanteSelectionnee.Famille = FamilleSelectionnee;
                    PlanteSelectionnee.Regions = SelectionDeRegions.GetRegionsSelectionnees();
                    await _planteRepository.UpdateAsync(PlanteSelectionnee);
                    _interaction.AfficherMessageInfo("Plante modifiée avec succès!");
                }
                catch (Exception ex)
                {
                    PlanteSelectionnee.NomCommun = vieuxNomCommun;
                    PlanteSelectionnee.NomScientifique = vieuxNomScientifique;
                    PlanteSelectionnee.Hauteur = vieilleHauteur;
                    PlanteSelectionnee.Famille = vieilleFamille;
                    PlanteSelectionnee.Regions = vieillesRegions;
                    _interaction.AfficherMessageErreur(ex.Message);
                }
            }
        }

        private async Task Supprimer(object? obj)
        {
            if (PlanteSelectionnee != null && _interaction.PoserQuestion("Voulez-vous vraiment supprimer la plante?"))
            {
                await _planteRepository.DeleteAsync(PlanteSelectionnee);
                Plantes.Remove(PlanteSelectionnee);
                _interaction.AfficherMessageInfo("Plante supprimée avec succès!");
            }
        }

        private bool CanExecuteModifierSupprimer(object? obj)
        {
            return PlanteSelectionnee != null;
        }

        public ObservableCollection<Plante> Plantes { get; set; }
        public ObservableCollection<Region> Regions { get; set; }
        public ObservableCollection<Famille> Familles { get; set; }

        public AsyncCommand CommandeAjouter { get; set; }
        public RelayCommand CommandeNouvellePlante { get; set; }
        public AsyncCommand CommandeModifier { get; set; }
        public AsyncCommand CommandeSupprimer { get; set; }

        public Plante? PlanteSelectionnee
        {
            get { return _planteSelectionnee; }
            set
            {
                _planteSelectionnee = value;

                if (value != null) _planteSelectionnee = _planteRepository.Get(value.Id);

                NomCommun = _planteSelectionnee?.NomCommun ?? "";
                NomScientifique = _planteSelectionnee?.NomScientifique ?? "";
                Hauteur = _planteSelectionnee?.Hauteur ?? 0;
                FamilleSelectionnee = _planteSelectionnee?.Famille ?? null;
                SelectionDeRegions = new SelectionDeRegions(_planteSelectionnee?.Regions ?? new List<Region>(), Regions);

                ModeAjout = _planteSelectionnee == null;
                OnPropertyChanged();
            }
        }

        public bool ModeAjout
        {
            get { return _modeAjout; }
            set
            {
                _modeAjout = value;
                OnPropertyChanged();
            }
        }

        public string NomCommun
        {
            get { return _nomCommun; }
            set
            {
                _nomCommun = value;
                OnPropertyChanged();
            }
        }

        public string NomScientifique
        {
            get { return _nomScientifique; }
            set
            {
                _nomScientifique = value;
                OnPropertyChanged();
            }
        }

        public double Hauteur
        {
            get { return _hauteur; }
            set
            {
                _hauteur = value;
                OnPropertyChanged();
            }
        }

        public Famille? FamilleSelectionnee
        {
            get { return _familleSelectionnee; }
            set
            {
                _familleSelectionnee = value;
                OnPropertyChanged();
            }
        }

        public SelectionDeRegions SelectionDeRegions
        {
            get { return _selectionDeRegions; }
            set
            {
                _selectionDeRegions = value;
                OnPropertyChanged();
            }
        }
    }
}
