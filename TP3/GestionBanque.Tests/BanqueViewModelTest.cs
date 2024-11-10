using GestionBanque.Models;
using GestionBanque.Models.DataService;
using GestionBanque.ViewModels;
using GestionBanque.ViewModels.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanque.Tests
{
    public class BanqueViewModelTest
    {
        private readonly Mock<IInteractionUtilisateur> _interUtilMock = new Mock<IInteractionUtilisateur>();
        private readonly Mock<IDataService<Client>> _clientDataService = new Mock<IDataService<Client>>();
        private readonly Mock<IDataService<Compte>> _compteDataService = new Mock<IDataService<Compte>>();


        public BanqueViewModelTest()
        {
            _interUtilMock.Setup(iu => iu.AfficherMessageErreur(It.IsAny<string>()));
            _interUtilMock.Setup(iu => iu.PoserQuestion(It.IsAny<string>())).Returns(true);
        }

        [Fact]
        public void Constructeur_ShouldBeValid()
        {
            // Arrange
            _clientDataService.Setup(clinetDS => clinetDS.GetAll()).Returns(ListeClientsAttendues);

            // Act
            BanqueViewModel bvm = new BanqueViewModel(_interUtilMock.Object, _clientDataService.Object, _compteDataService.Object);

            // Assert
            Assert.Equal(ListeClientsAttendues().Count(), bvm.Clients.Count());
            Assert.Equal(ListeClientsAttendues(), bvm.Clients);
            Assert.Empty(bvm.Nom);
            Assert.Empty(bvm.Prenom);
            Assert.Empty(bvm.Courriel);
            Assert.Null(bvm.CompteSelectionne);
            Assert.Null(bvm.ClientSelectionne);
        }

        [Fact]
        public void SetterClientSelectionne_ShouldBeSelected()
        {
            // Arrange
            _clientDataService.Setup(clinetDS => clinetDS.GetAll()).Returns(ListeClientsAttendues);
            _clientDataService.Setup(clinetDS => clinetDS.Insert(It.IsAny<Client>())).Returns(true);
            BanqueViewModel bvm = new BanqueViewModel(_interUtilMock.Object, _clientDataService.Object, _compteDataService.Object);

            // Act
            bvm.ClientSelectionne = bvm.Clients.First();


            // Assert
            Assert.NotNull(bvm.ClientSelectionne);
            Assert.NotEmpty(bvm.Nom);
            Assert.NotEmpty(bvm.Prenom);
            Assert.NotEmpty(bvm.Courriel);
        }

        [Fact]
        public void SetterClientSelectionne_ShouldNotBeSelected()
        {
            // Arrange
            _clientDataService.Setup(clinetDS => clinetDS.GetAll()).Returns(ListeClientsAttendues);
            _clientDataService.Setup(clinetDS => clinetDS.Insert(It.IsAny<Client>())).Returns(true);
            BanqueViewModel bvm = new BanqueViewModel(_interUtilMock.Object, _clientDataService.Object, _compteDataService.Object);

            // Act
            bvm.ClientSelectionne = null;


            // Assert
            Assert.Null(bvm.ClientSelectionne);
        }

        private List<Client> ListeClientsAttendues()
        {
            return new List<Client>()
            {
                new Client(1, "Amar", "Quentin", "quentin@gmail.com"),
                new Client(2, "Agère", "Tex", "tex@gmail.com"),
                new Client(3, "Vigote", "Sarah", "sarah@gmail.com")
            };
        }

    }
}
