using ExerciceMockEtTdd.ViewModels.Interfaces;

namespace ExerciceMockEtTdd.ViewModels
{
    public class AccueilViewModel : BaseViewModel
    {
        public AccueilViewModel(IInteractionUtilisateur interaction) : base(interaction) { }
    }
}
