using JardinageWpf.Models;
using JardinageWpf.ViewModels.Commands;
using JardinageWpf.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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

        public JardinageViewModel(IInteractionUtilisateur interaction) : base(interaction)
        {
            Plantes = new ObservableCollection<Plante>();
            Regions = new ObservableCollection<Region>();
            Familles = new ObservableCollection<Famille>();

            CommandeAjouter = new RelayCommand(Ajouter, null);
            CommandeNouvellePlante = new RelayCommand(NouvellePlante, null);
            CommandeModifier = new RelayCommand(Modifier, CanExecuteModifierSupprimer);
            CommandeSupprimer = new RelayCommand(Supprimer, CanExecuteModifierSupprimer);

            Seed();

            SelectionDeRegions = new SelectionDeRegions(new List<Region>(), Regions);
        }

        private void NouvellePlante(object? obj)
        {
            PlanteSelectionnee = null;
        }

        private void Ajouter(object? obj)
        {
            try
            {
                Plante nvllePlante = new Plante
                {
                    Id = 0,
                    NomCommun = NomCommun,
                    NomScientifique = NomScientifique,
                    Hauteur = Hauteur,
                    Famille = FamilleSelectionnee,
                    Regions = SelectionDeRegions.GetRegionsSelectionnees()
                };
                Plantes.Add(nvllePlante);
                PlanteSelectionnee = nvllePlante;
                _interaction.AfficherMessageInfo("Plante ajoutée avec succès!");
            }
            catch (Exception ex)
            {
                _interaction.AfficherMessageErreur(ex.Message);
            }
        }

        private void Modifier(object? obj)
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

        private void Supprimer(object? obj)
        {
            if (PlanteSelectionnee != null && _interaction.PoserQuestion("Voulez-vous vraiment supprimer la plante?"))
            {
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

        public RelayCommand CommandeAjouter { get; set; }
        public RelayCommand CommandeNouvellePlante { get; set; }
        public RelayCommand CommandeModifier { get; set; }
        public RelayCommand CommandeSupprimer { get; set; }

        public Plante? PlanteSelectionnee
        {
            get { return _planteSelectionnee; }
            set
            {
                _planteSelectionnee = value;

                NomCommun = value?.NomCommun ?? "";
                NomScientifique = value?.NomScientifique ?? "";
                Hauteur = value?.Hauteur ?? 0;
                FamilleSelectionnee = value?.Famille ?? null;
                SelectionDeRegions = new SelectionDeRegions(value?.Regions ?? new List<Region>(), Regions);

                ModeAjout = value == null;
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

        private void Seed()
        {
            Famille f1 = new Famille { Id = 1, Nom = "Graminé" };
            Famille f2 = new Famille { Id = 2, Nom = "Orchidé" };
            Famille f3 = new Famille { Id = 3, Nom = "Labié" };
            Familles.Add(f1);
            Familles.Add(f2);
            Familles.Add(f3);

            Region r1 = new Region { Id = 1, Nom = "Désertique" };
            Region r2 = new Region { Id = 2, Nom = "Aride" };
            Region r3 = new Region { Id = 3, Nom = "Tempéré" };
            Regions.Add(r1);
            Regions.Add(r2);
            Regions.Add(r3);

            Plante p1 = new Plante { Id = 1, Hauteur = 20, NomCommun = "Pissenlit", NomScientifique = "Taraxacum officinale F.H. Wigg.", Famille = f1 };
            p1.Regions.Add(r1);
            p1.Regions.Add(r3);
            Plante p2 = new Plante { Id = 2, Hauteur = 50, NomCommun = "Blé", NomScientifique = "Triticum turgidum ssp. durum", Famille = f1 };
            p2.Regions.Add(r2);
            Plante p3 = new Plante { Id = 3, Hauteur = 20, NomCommun = "Orchidée papillon", NomScientifique = "Phalaenopsis", Famille = f2 };
            p3.Regions.Add(r1);
            Plantes.Add(p1);
            Plantes.Add(p2);
            Plantes.Add(p3);
        }
    }
}
