using ExerciceMockEtTdd.Models;
using ExerciceMockEtTdd.ViewModels;
using ExerciceMockEtTdd.ViewModels.Interfaces;
using Moq;

namespace ExercicesMocksEtTdd.Tests
{
    public class PersonneViewModelTest
    {
        // Variables d'instances, nos Mocks
        private readonly Mock<IInteractionUtilisateur> _interUtilMock = new Mock<IInteractionUtilisateur>();
        private readonly Mock<IDataService<Personne>> _pDataService = new Mock<IDataService<Personne>>();

        // Constructeur de la classe de tests
        public PersonneViewModelTest()
        {
            // Configuration du Mock pour IInteractionUtilisateur dans le constructeur
            // car nous voulons le même comportement partout dans les tests
            _interUtilMock.Setup(iu => iu.AfficherMessageErreur(It.IsAny<string>()));
            _interUtilMock.Setup(iu => iu.PoserQuestion(It.IsAny<string>())).Returns(true);
        }

        [Fact]
        public void Constructeur_ShouldBeValid()
        {
            // Préparation
            _pDataService.Setup(pds => pds.GetAll()).Returns(ListePersonnesAttendues());

            // Exécution. PersonneViewModel utilisera nos mocks et non des classes "réelles".
            PersonneViewModel pvm = new PersonneViewModel(_interUtilMock.Object, _pDataService.Object);

            // Affirmation
            Assert.Equal(3, pvm.Personnes.Count);
            Assert.Equal(ListePersonnesAttendues(), pvm.Personnes);
            Assert.Empty(pvm.Nom);
            Assert.Empty(pvm.Prenom);
            Assert.Empty(pvm.Telephone);
            Assert.True(pvm.ModeAjout);
            Assert.Null(pvm.PersonneSelectionnee);
        }

        private List<Personne> ListePersonnesAttendues()
        {
            return new List<Personne>()
        {
            new Personne(1, "Carnaval", "Bonhomme", "418-123-4567"),
            new Personne(2, "Gratton", "Bob", "450-659-8854"),
            new Personne(3, "Troudeau", "Justun", "514-465-4785")
        };
        }
    }
}