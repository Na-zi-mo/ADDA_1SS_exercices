using Moq;
using TP4.DataService.Repositories.Interfaces;
using TP4.ViewModels.Interfaces;

namespace TP4.Tests
{
    public class MeteoViewModelTest
    {
        private readonly Mock<IInteractionUtilisateur> _interactionUtilisateurMock= new Mock<IInteractionUtilisateur>();
        private readonly Mock<IRegionRepository> _regionRepositoryMock = new Mock<IRegionRepository>();


        public MeteoViewModelTest()
        {
            _interactionUtilisateurMock.Setup(iu => iu.ShowErrorMessage(It.IsAny<string>()));
            _interactionUtilisateurMock.Setup(iu => iu.ShowInformationMessage(It.IsAny<string>()));
        }

        [Fact]
        public void Test1()
        {

        }
    }
}