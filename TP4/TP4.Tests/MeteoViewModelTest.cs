using Moq;
using TP4.DataService.Repositories.Interfaces;
using TP4.Models;
using TP4.ViewModels;
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
        public void Constructeur_ShouldBeValid()
        {
            // Arrange
            _regionRepositoryMock.Setup(r => r.GetAll()).Returns(ListeRegionsAttendues());
            

            // Act
            MeteoViewModel mvm = new MeteoViewModel(_interactionUtilisateurMock.Object, _regionRepositoryMock.Object);

            // Assert
            Assert.Equal(ListeRegionsAttendues().Count, mvm.Regions.Count);
            Assert.Equal(ListeRegionsAttendues(), mvm.Regions);
            Assert.Null(mvm.Region);
            Assert.Equal(0, mvm.Latitude);
            Assert.Equal(0, mvm.Longitude);
            Assert.Null(mvm.RegionSelectionnee);
        }


        private List<Region> ListeRegionsAttendues()
        {
            return new List<Region>()
            {
                new Region{ Id = 1, Nom = "Algiers", Latitude = 36.7538, Longitude = 3.0588 },
                new Region{ Id = 2, Nom = "Oran", Latitude = 35.6971, Longitude = -0.6308 },
                new Region{ Id = 3, Nom = "Constantine", Latitude = 36.365, Longitude = 6.6147 },
                new Region{ Id = 4, Nom = "Annaba", Latitude = 36.9, Longitude = 7.766 }
            };
        }
    }
}