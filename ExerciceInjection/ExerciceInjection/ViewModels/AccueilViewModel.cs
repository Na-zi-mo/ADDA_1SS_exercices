using ExerciceInjection.ViewModels.Interfaces;

namespace ExerciceInjection.ViewModels
{
    public class AccueilViewModel : BaseViewModel
    {
        public AccueilViewModel(IInteractionUtilisateur interaction) : base(interaction) { }
    }
}
