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
        private readonly Mock<ApiClient> _apiClient = new Mock<ApiClient>("https://api.weatherbit.io/v2.0/forecast/daily");


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
            MeteoViewModel mvm = new MeteoViewModel(_interactionUtilisateurMock.Object, _regionRepositoryMock.Object, _apiClient.Object);

            // Assert
            Assert.Equal(ListeRegionsAttendues().Count, mvm.Regions.Count);
            Assert.Equal(ListeRegionsAttendues(), mvm.Regions);
            Assert.Null(mvm.Region);
            Assert.Equal(0, mvm.Latitude);
            Assert.Equal(0, mvm.Longitude);
            Assert.Null(mvm.RegionSelectionnee);
        }

        [Fact]
        public async Task AjouterRegion_ShouldBeAdded()
        {
            Region expectedRegion = new Region("Québec", -71.21282419393238, 46.81313351998989);

            _regionRepositoryMock.Setup(r => r.GetAll()).Returns(ListeRegionsAttendues());
            _regionRepositoryMock.Setup(r => r.AddAsync(It.IsAny<Region>())).Returns(() => Task.FromResult(expectedRegion));
            MeteoViewModel mvm = new MeteoViewModel(_interactionUtilisateurMock.Object, _regionRepositoryMock.Object, _apiClient.Object);

            mvm.Region = expectedRegion.Nom;
            mvm.Longitude = expectedRegion.Longitude;
            mvm.Latitude = expectedRegion.Latitude;

            await mvm.Ajouter(null);


            Assert.Equal(5, mvm.Regions.Count());
            Assert.Equivalent(expectedRegion, mvm.Regions.Last());
            Assert.Empty(mvm.Region);
            Assert.Equal(0, mvm.Latitude); 
            Assert.Equal(0, mvm.Longitude);
        }


        [Fact]
        public async Task AjouterRegion_ShouldNotBeAdded()
        {
            _regionRepositoryMock.Setup(r => r.GetAll()).Returns(ListeRegionsAttendues());
            _regionRepositoryMock.Setup(r => r.AddAsync(It.IsAny<Region>()));


            MeteoViewModel mvm = new MeteoViewModel(_interactionUtilisateurMock.Object, _regionRepositoryMock.Object, _apiClient.Object);

            await mvm.Ajouter(null);


            Assert.Equal(4, mvm.Regions.Count());
        }


        [Fact]
        public async Task SupprimerRegion_ShouldBeDeleted()
        {
            _regionRepositoryMock.Setup(r => r.GetAll()).Returns(ListeRegionsAttendues());
            _regionRepositoryMock.Setup(r => r.DeleteAsync(It.IsAny<Region>())).Returns(() => Task.FromResult(true));


            MeteoViewModel mvm = new MeteoViewModel(_interactionUtilisateurMock.Object, _regionRepositoryMock.Object, _apiClient.Object);


            mvm.RegionSelectionnee = mvm.Regions[0];
            await mvm.Supprimer(null);


            Assert.Equal(3, mvm.Regions.Count());
        }

        [Fact]
        public async Task SupprimerRegion_ShouldNotBeDeleted()
        {
            _regionRepositoryMock.Setup(r => r.GetAll()).Returns(ListeRegionsAttendues());
            _regionRepositoryMock.Setup(r => r.DeleteAsync(It.IsAny<Region>())).Returns(() => Task.FromResult(true));


            MeteoViewModel mvm = new MeteoViewModel(_interactionUtilisateurMock.Object, _regionRepositoryMock.Object, _apiClient.Object);


            await mvm.Supprimer(null);


            Assert.Equal(4, mvm.Regions.Count());
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