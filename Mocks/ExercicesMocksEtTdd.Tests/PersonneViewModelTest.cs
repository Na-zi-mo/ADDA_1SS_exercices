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
            // car nous voulons le m�me comportement partout dans les tests
            _interUtilMock.Setup(iu => iu.AfficherMessageErreur(It.IsAny<string>()));
            _interUtilMock.Setup(iu => iu.PoserQuestion(It.IsAny<string>())).Returns(true);
        }

        [Fact]
        public void Constructeur_ShouldBeValid()
        {
            // Pr�paration
            _pDataService.Setup(pds => pds.GetAll()).Returns(ListePersonnesAttendues());

            // Ex�cution. PersonneViewModel utilisera nos mocks et non des classes "r�elles".
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

        [Fact]
        public void AjouterPersonne_ShouldBeAdded()
        {
            // Pr�paration (le mock est d�j� configur� pour vous ici pour vous aider � d�marrer...)
            _pDataService.Setup(pds => pds.GetAll()).Returns(ListePersonnesAttendues());
            _pDataService.Setup(pds => pds.Insert(It.IsAny<Personne>())).Returns(true);
            // Suite pr�paration
            PersonneViewModel pvm = new PersonneViewModel(_interUtilMock.Object, _pDataService.Object);

            // Ex�cution (l'ex�cution est d�j� fournie pour vous aidez � d�marrer...)
            pvm.Nom = "Massinissa";
            pvm.Prenom = "Massyla";
            pvm.Telephone = "(123) 456-7890";

            pvm.AjouterPersonne(null);

            // Affirmation
            Assert.Equal(4, pvm.Personnes.Count());
            //Personne personneAJoutee = pvm.Personnes[3];

        }

        [Fact]
        public void AjouterPersonne_ShouldNotBeAdded()
        {
            // Pr�paration (entre autres, configurer le mock...)
            _pDataService.Setup(pds => pds.GetAll()).Returns(ListePersonnesAttendues());
            _pDataService.Setup(pds => pds.Insert(It.IsAny<Personne>())).Returns(true);
            // Suite pr�paration
            PersonneViewModel pvm = new PersonneViewModel(_interUtilMock.Object, _pDataService.Object);


            // Ex�cution
            pvm.AjouterPersonne(null);


            // Affirmation
            Assert.Equal(3, pvm.Personnes.Count());
        }

        [Fact]
        public void SupprimerTout_ShouldBeDeleted()
        {
            // Pr�paration
            _pDataService.Setup(pds => pds.GetAll()).Returns(ListePersonnesAttendues());
            _pDataService.Setup(pds => pds.Insert(It.IsAny<Personne>())).Returns(true);
            // Suite pr�paration
            PersonneViewModel pvm = new PersonneViewModel(_interUtilMock.Object, _pDataService.Object);

            // Ex�cution
            pvm.SupprimerTout(null);

            // Affirmation
            Assert.Empty(pvm.Personnes);
        }

        [Fact]
        public void SupprimerPersonne_ShouldBeDeleted()
        {
            // Pr�paration
            _pDataService.Setup(pds => pds.GetAll()).Returns(ListePersonnesAttendues());
            _pDataService.Setup(pds => pds.Insert(It.IsAny<Personne>())).Returns(true);
            // Suite pr�paration
            PersonneViewModel pvm = new PersonneViewModel(_interUtilMock.Object, _pDataService.Object);

            // Ex�cution

            pvm.PersonneSelectionnee = pvm.Personnes.Last();


            pvm.SupprimerPersonne(null);

            // Affirmation
            Assert.Equal(2, pvm.Personnes.Count());
        }

        [Fact]
        public void SupprimerPersonne_ShouldNotBeDeleted()
        {
            // Pr�paration
            _pDataService.Setup(pds => pds.GetAll()).Returns(ListePersonnesAttendues());
            _pDataService.Setup(pds => pds.Insert(It.IsAny<Personne>())).Returns(true);
            // Suite pr�paration
            PersonneViewModel pvm = new PersonneViewModel(_interUtilMock.Object, _pDataService.Object);

            // Ex�cution
            pvm.SupprimerPersonne(null);

            // Affirmation
            Assert.Equal(3, pvm.Personnes.Count());
        }

        [Fact]
        public void ModifierPersonne_ShouldBeModified()
        {
            // Pr�paration
            _pDataService.Setup(pds => pds.GetAll()).Returns(ListePersonnesAttendues());
            _pDataService.Setup(pds => pds.Insert(It.IsAny<Personne>())).Returns(true);
            // Suite pr�paration
            PersonneViewModel pvm = new PersonneViewModel(_interUtilMock.Object, _pDataService.Object);

            pvm.PersonneSelectionnee = pvm.Personnes.Last();

            pvm.Nom = "Massinissa";
            pvm.Prenom = "Massyla";
            pvm.Telephone = "(123) 456-7890";

            // Ex�cution
            pvm.ModifierPersonne(null);

            // Affirmation
            Assert.Equal("Massinissa", pvm.Personnes.Last().Nom);
        }

        [Fact]
        public void ModifierPersonne_ShouldNotBeModified()
        {
            // Pr�paration
            _pDataService.Setup(pds => pds.GetAll()).Returns(ListePersonnesAttendues());
            _pDataService.Setup(pds => pds.Insert(It.IsAny<Personne>())).Returns(true);
            // Suite pr�paration
            PersonneViewModel pvm = new PersonneViewModel(_interUtilMock.Object, _pDataService.Object);

            pvm.PersonneSelectionnee = null;

            pvm.Nom = "Massinissa";
            pvm.Prenom = "Massyla";
            pvm.Telephone = "(123) 456-7890";

            // Ex�cution
            pvm.ModifierPersonne(null);

            // Affirmation
            Assert.NotEqual("Massinissa", pvm.Personnes.Last().Nom);
        }

        [Fact]
        public void AnnulerPersonne_ShouldBeCancelled()
        {
            // Pr�paration
            _pDataService.Setup(pds => pds.GetAll()).Returns(ListePersonnesAttendues());
            _pDataService.Setup(pds => pds.Insert(It.IsAny<Personne>())).Returns(true);
            // Suite pr�paration
            PersonneViewModel pvm = new PersonneViewModel(_interUtilMock.Object, _pDataService.Object);

            pvm.PersonneSelectionnee = pvm.Personnes.First();

            pvm.Nom = pvm.Personnes.First().Nom;
            pvm.Prenom = pvm.Personnes.First().Prenom;
            pvm.Telephone = pvm.Personnes.First().Telephone;

            // Ex�cution
            pvm.Annuler(null);

            // Affirmation
            Assert.True(pvm.ModeAjout);
        }

        [Fact]
        public void SetPersonneSelectionnee_ShouldBeSelected()
        {
            // Pr�paration
            _pDataService.Setup(pds => pds.GetAll()).Returns(ListePersonnesAttendues());
            _pDataService.Setup(pds => pds.Insert(It.IsAny<Personne>())).Returns(true);
            // Suite pr�paration
            PersonneViewModel pvm = new PersonneViewModel(_interUtilMock.Object, _pDataService.Object);

            // Ex�cution
            pvm.PersonneSelectionnee = pvm.Personnes.First();

            // Affirmation
            Assert.NotNull(pvm.PersonneSelectionnee);
        }

        [Fact]
        public void SetPersonneSelectionnee_ShouldNotBeSelected()
        {
            // Pr�paration
            _pDataService.Setup(pds => pds.GetAll()).Returns(ListePersonnesAttendues());
            _pDataService.Setup(pds => pds.Insert(It.IsAny<Personne>())).Returns(true);
            // Suite pr�paration
            PersonneViewModel pvm = new PersonneViewModel(_interUtilMock.Object, _pDataService.Object);

            // Ex�cution
            pvm.PersonneSelectionnee = null;

            // Affirmation
            Assert.Null(pvm.PersonneSelectionnee);
        }


        [Fact]
        public void CopierPersonne_ShouldBeCopied()
        {
            // Pr�paration
            _pDataService.Setup(pds => pds.GetAll()).Returns(ListePersonnesAttendues());
            _pDataService.Setup(pds => pds.Insert(It.IsAny<Personne>())).Returns(true);
            // Suite pr�paration
            PersonneViewModel pvm = new PersonneViewModel(_interUtilMock.Object, _pDataService.Object);

            pvm.PersonneSelectionnee = new Personne(0, "Massinissa", "Massinissaaa", "819-123-4567");

            pvm.Nom = pvm.PersonneSelectionnee.Nom;
            pvm.Prenom = pvm.PersonneSelectionnee.Prenom;
            pvm.Telephone = pvm.PersonneSelectionnee.Telephone;

            // Ex�cution
            pvm.CopierPersonne(null);

            // Affirmation
            Assert.Equal(4, pvm.Personnes.Count());
            Assert.Equal("Massinissa", pvm.Personnes.Last().Nom);
            Assert.Equal("Massinissaaa", pvm.Personnes.Last().Prenom);
            Assert.Equal("819-123-4567", pvm.Personnes.Last().Telephone);
        }
    }
}