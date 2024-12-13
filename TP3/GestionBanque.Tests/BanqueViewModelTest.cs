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

        [Fact]
        public void Modifier_ShouldBeModified()
        {
            // Arrange
            _clientDataService.Setup(clinetDS => clinetDS.GetAll()).Returns(ListeClientsAttendues);
            _clientDataService.Setup(clinetDS => clinetDS.Insert(It.IsAny<Client>())).Returns(true);
            BanqueViewModel bvm = new BanqueViewModel(_interUtilMock.Object, _clientDataService.Object, _compteDataService.Object);

            
            bvm.ClientSelectionne = bvm.Clients.Last();

            bvm.Nom = "Ziri";
            bvm.Prenom = "Bouloughine";
            bvm.Courriel = "ziri@mazghana.dz";

            // Act
            bvm.Modifier(null);


            // Assert
            Assert.Equal("Ziri", bvm.Clients.Last().Nom);
            Assert.Equal("Bouloughine", bvm.Clients.Last().Prenom);
            Assert.Equal("ziri@mazghana.dz", bvm.Clients.Last().Courriel);
        }

        [Fact]
        public void Modifier_ShouldNotBeModified()
        {
            // Arrange
            _clientDataService.Setup(clinetDS => clinetDS.GetAll()).Returns(ListeClientsAttendues);
            _clientDataService.Setup(clinetDS => clinetDS.Insert(It.IsAny<Client>())).Returns(true);
            BanqueViewModel bvm = new BanqueViewModel(_interUtilMock.Object, _clientDataService.Object, _compteDataService.Object);


            bvm.ClientSelectionne = null;

            bvm.Nom = "Ziri";
            bvm.Prenom = "Bouloughine";
            bvm.Courriel = "ziri@mazghana.dz";

            // Act
            bvm.Modifier(null);


            // Assert
            Assert.NotEqual("Ziri", bvm.Clients.Last().Nom);
            Assert.NotEqual("Bouloughine", bvm.Clients.Last().Prenom);
            Assert.NotEqual("ziri@mazghana.dz", bvm.Clients.Last().Courriel);
        }

        [Fact]
        public void Modifier_ShouldNotBeModified_InvalidAttributes()
        {
            // Arrange
            _clientDataService.Setup(clinetDS => clinetDS.GetAll()).Returns(ListeClientsAttendues);
            _clientDataService.Setup(clinetDS => clinetDS.Insert(It.IsAny<Client>())).Returns(true);
            BanqueViewModel bvm = new BanqueViewModel(_interUtilMock.Object, _clientDataService.Object, _compteDataService.Object);


            string vieuxNom = bvm.Clients.Last().Nom;
            string vieuxPrenom = bvm.Clients.Last().Prenom;
            string vieuxCourriel = bvm.Clients.Last().Courriel;

            bvm.ClientSelectionne = bvm.Clients.Last();

            bvm.Nom = "Ziri";
            bvm.Prenom = "Bouloughine";
            bvm.Courriel = "zirimazghana.dz";

            // Act
            bvm.Modifier(null);


            // Assert
            Assert.NotEqual("Ziri", bvm.Clients.Last().Nom);
            Assert.NotEqual("Bouloughine", bvm.Clients.Last().Prenom);
            Assert.NotEqual("ziri@mazghana.dz", bvm.Clients.Last().Courriel);

            Assert.Equal(vieuxNom, bvm.Clients.Last().Nom);
            Assert.Equal(vieuxPrenom, bvm.Clients.Last().Prenom);
            Assert.Equal(vieuxCourriel, bvm.Clients.Last().Courriel);
        }


        [Fact]
        public void Retirer_ShouldBeWithdrew()
        {
            // Arrange
            _clientDataService.Setup(clinetDS => clinetDS.GetAll()).Returns(ListeClientsAttendues);
            _clientDataService.Setup(clinetDS => clinetDS.Insert(It.IsAny<Client>())).Returns(true);
            BanqueViewModel bvm = new BanqueViewModel(_interUtilMock.Object, _clientDataService.Object, _compteDataService.Object);


            bvm.CompteSelectionne = new Compte(1, "7698", 906.72, 3);
            bvm.MontantTransaction = 100;


            // Act
            bvm.Retirer(null);


            // Assert
            Assert.Equal(806.72, bvm.CompteSelectionne.Balance);
            Assert.Equal(0, bvm.MontantTransaction);
        }


        [Fact]
        public void Retirer_ShouldNotBeWithdrew()
        {
            // Arrange
            _clientDataService.Setup(clinetDS => clinetDS.GetAll()).Returns(ListeClientsAttendues);
            _clientDataService.Setup(clinetDS => clinetDS.Insert(It.IsAny<Client>())).Returns(true);
            BanqueViewModel bvm = new BanqueViewModel(_interUtilMock.Object, _clientDataService.Object, _compteDataService.Object);


            bvm.CompteSelectionne = new Compte(1, "7698", 906.72, 3);
            bvm.MontantTransaction = 1000;


            // Act
            bvm.Retirer(null);


            // Assert
            Assert.Equal(906.72, bvm.CompteSelectionne.Balance);
            Assert.NotEqual(0, bvm.MontantTransaction);
        }

        [Fact]
        public void Deposer_ShouldBeDeposited()
        {
            // Arrange
            _clientDataService.Setup(clinetDS => clinetDS.GetAll()).Returns(ListeClientsAttendues);
            _clientDataService.Setup(clinetDS => clinetDS.Insert(It.IsAny<Client>())).Returns(true);
            BanqueViewModel bvm = new BanqueViewModel(_interUtilMock.Object, _clientDataService.Object, _compteDataService.Object);


            bvm.CompteSelectionne = new Compte(1, "7698", 906.72, 3);
            bvm.MontantTransaction = 100;


            // Act
            bvm.Deposer(null);


            // Assert
            Assert.Equal(1006.72, bvm.CompteSelectionne.Balance);
            Assert.Equal(0, bvm.MontantTransaction);
        }


        [Fact]
        public void Deposer_ShouldNotBeDeposited()
        {
            // Arrange
            _clientDataService.Setup(clinetDS => clinetDS.GetAll()).Returns(ListeClientsAttendues);
            _clientDataService.Setup(clinetDS => clinetDS.Insert(It.IsAny<Client>())).Returns(true);
            BanqueViewModel bvm = new BanqueViewModel(_interUtilMock.Object, _clientDataService.Object, _compteDataService.Object);


            bvm.CompteSelectionne = new Compte(1, "7698", 906.72, 3);
            bvm.MontantTransaction = -1000;


            // Act
            bvm.Deposer(null);


            // Assert
            Assert.Equal(906.72, bvm.CompteSelectionne.Balance);
            Assert.NotEqual(0, bvm.MontantTransaction);
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
