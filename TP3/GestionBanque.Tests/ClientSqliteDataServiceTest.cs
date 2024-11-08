
using GestionBanque.Models.DataService;
using GestionBanque.Models;
using System.Numerics;

namespace GestionBanque.Tests
{
    // Ce décorateur s'assure que toutes les classes de tests ayant le tag "Dataservice" soit
    // exécutées séquentiellement. Par défaut, xUnit exécute les différentes suites de tests
    // en parallèle. Toutefois, si nous voulons forcer l'Act séquentielle entre certaines
    // suites, nous pouvons utiliser un décorateur avec un nom unique. Pour les tests sur les DataService,
    // il est important que cela soit séquentiel afin d'éviter qu'un test d'une classe supprime la 
    // bd de tests pendant qu'un test d'une autre classe utilise la bd. Bref, c'est pour éviter un
    // accès concurrent à la BD de tests!
    [Collection("Dataservice")]
    public class ClientSqliteDataServiceTest
    {
        private const string CheminBd = "test.bd";

        [Fact]
        [AvantApresDataService(CheminBd)]
        public void Get_ShouldBeValid()
        {
            // Arrange
            ClientSqliteDataService ds = new ClientSqliteDataService(CheminBd);
            Client clientAttendu = new Client(1, "Amar", "Quentin", "quentin@gmail.com");
            clientAttendu.Comptes.Add(new Compte(1, "9864", 831.76, 1));
            clientAttendu.Comptes.Add(new Compte(2, "2370", 493.04, 1));

            // Act
            Client? clientActuel = ds.Get(1);

            // Assert
            Assert.Equal(clientAttendu, clientActuel);
        }

        [Fact]
        [AvantApresDataService(CheminBd)]
        public void SetterNom_ShouldBeValid_AlternateCase()
        {
            // Arrange
            ClientSqliteDataService ds = new ClientSqliteDataService(CheminBd);
            Client client = new Client(1, "Amar", "Quentin", "quentin@gmail.com");
            string expectedNom = "Toto";

            // Act
            client.Nom = "  Toto    ";

            // Assert
            Assert.Equal(client.Nom, expectedNom);
        }

        [Fact]
        [AvantApresDataService(CheminBd)]
        public void SetterNom_ShouldBeValid_MainCase()
        {
            // Arrange
            ClientSqliteDataService ds = new ClientSqliteDataService(CheminBd);
            Client client = new Client(1, "Amar", "Quentin", "quentin@gmail.com");
            string expectedNom = "Toto";

            // Act
            client.Nom = "Toto";

            // Assert
            Assert.Equal(client.Nom, expectedNom);
        }


        [Fact]
        [AvantApresDataService(CheminBd)]
        public void SetterNom_ShouldNotBeValid_NullCase()
        {
            // Arrange
            ClientSqliteDataService ds = new ClientSqliteDataService(CheminBd);
            Client client = new Client(1, "Amar", "Quentin", "quentin@gmail.com");

            // Act
            // Assert         
            Assert.Throws<ArgumentException>(() => client.Nom = null);

        }

        [Fact]
        [AvantApresDataService(CheminBd)]
        public void SetterNom_ShouldNotBeValid_EmptyCase_MainCase()
        {
            // Arrange
            ClientSqliteDataService ds = new ClientSqliteDataService(CheminBd);
            Client client = new Client(1, "Amar", "Quentin", "quentin@gmail.com");
            
            // Act
            // Assert         
            Assert.Throws<ArgumentException>(() => client.Nom = "");
        }

        [Fact]
        [AvantApresDataService(CheminBd)]
        public void SetterNom_ShouldNotBeValid_EmptyCase_AlternateCase()
        {
            // Arrange
            ClientSqliteDataService ds = new ClientSqliteDataService(CheminBd);
            Client client = new Client(1, "Amar", "Quentin", "quentin@gmail.com");

            // Act
            // Assert         
            Assert.Throws<ArgumentException>(() => client.Nom = "     ");
        }


        [Fact]
        [AvantApresDataService(CheminBd)]
        public void SetterPrenom_ShouldBeValid_AlternateCase()
        {
            // Arrange
            ClientSqliteDataService ds = new ClientSqliteDataService(CheminBd);
            Client client = new Client(1, "Amar", "Quentin", "quentin@gmail.com");
            string expectedPrenom = "Tata";

            // Act
            client.Prenom = "  Tata    ";

            // Assert
            Assert.Equal(client.Prenom, expectedPrenom);
        }

        [Fact]
        [AvantApresDataService(CheminBd)]
        public void SetterPrenom_ShouldBeValid_MainCase()
        {
            // Arrange
            ClientSqliteDataService ds = new ClientSqliteDataService(CheminBd);
            Client client = new Client(1, "Amar", "Quentin", "quentin@gmail.com");
            string expectedPrenom = "Tata";

            // Act
            client.Prenom = "Tata";

            // Assert
            Assert.Equal(client.Prenom, expectedPrenom);
        }


        [Fact]
        [AvantApresDataService(CheminBd)]
        public void SetterPrenom_ShouldNotBeValid_NullCase()
        {
            // Arrange
            ClientSqliteDataService ds = new ClientSqliteDataService(CheminBd);
            Client client = new Client(1, "Amar", "Quentin", "quentin@gmail.com");

            // Act
            // Assert         
            Assert.Throws<ArgumentException>(() => client.Prenom = null);

        }

        [Fact]
        [AvantApresDataService(CheminBd)]
        public void SetterPrenom_ShouldNotBeValid_EmptyCase_MainCase()
        {
            // Arrange
            ClientSqliteDataService ds = new ClientSqliteDataService(CheminBd);
            Client client = new Client(1, "Amar", "Quentin", "quentin@gmail.com");

            // Act
            // Assert         
            Assert.Throws<ArgumentException>(() => client.Prenom = "");
        }

        [Fact]
        [AvantApresDataService(CheminBd)]
        public void SetterPrenom_ShouldNotBeValid_EmptyCase_AlternateCase()
        {
            // Arrange
            ClientSqliteDataService ds = new ClientSqliteDataService(CheminBd);
            Client client = new Client(1, "Amar", "Quentin", "quentin@gmail.com");

            // Act
            // Assert         
            Assert.Throws<ArgumentException>(() => client.Prenom = "     ");
        }


        [Fact]
        [AvantApresDataService(CheminBd)]
        public void SetterCourriel_ShouldBeValid_MainCase()
        {
            // Arrange
            ClientSqliteDataService ds = new ClientSqliteDataService(CheminBd);
            Client client = new Client(1, "Amar", "Quentin", "quentin@gmail.com");
            string expectedCourriel = "quentin123@gmail.com";

            // Act
            client.Courriel = "quentin123@gmail.com";

            // Assert
            Assert.Equal(client.Courriel, expectedCourriel);
        }


        [Fact]
        [AvantApresDataService(CheminBd)]
        public void SetterCourriel_ShouldBeValid_AlternateCase()
        {
            // Arrange
            ClientSqliteDataService ds = new ClientSqliteDataService(CheminBd);
            Client client = new Client(1, "Amar", "Quentin", "quentin@gmail.com");
            string expectedCourriel = "pass@test.test";

            // Act
            client.Courriel = "    pass@test.test    ";

            // Assert
            Assert.Equal(client.Courriel, expectedCourriel);
        }


        [Fact]
        [AvantApresDataService(CheminBd)]
        public void SetterCourriel_ShouldNotBeValid_NullCase()
        {
            // Arrange
            ClientSqliteDataService ds = new ClientSqliteDataService(CheminBd);
            Client client = new Client(1, "Amar", "Quentin", "quentin@gmail.com");

            // Act
            // Assert         
            Assert.Throws<ArgumentException>(() => client.Courriel = null);
        }

        [Fact]
        [AvantApresDataService(CheminBd)]
        public void SetterCourriel_ShouldNotBeValid_InvalidEmail()
        {
            // Arrange
            ClientSqliteDataService ds = new ClientSqliteDataService(CheminBd);
            Client client = new Client(1, "Amar", "Quentin", "quentin@gmail.com");

            // Act
            // Assert         
            Assert.Throws<ArgumentException>(() => client.Courriel = "aaaaa.com");
        }


        [Fact]
        [AvantApresDataService(CheminBd)]
        public void GetAll_ShouldBeValid()
        {
            // Arrange
            ClientSqliteDataService ds = new ClientSqliteDataService(CheminBd);
            Client expectedClient = new Client(1, "Amar", "Quentin", "quentin@gmail.com");

            // Act
            IEnumerable<Client> clients =  ds.GetAll();

            // Assert
            Assert.Equal(3, clients.Count());
            Assert.Equivalent(expectedClient, clients.First());
        }


        [Fact]
        [AvantApresDataService(CheminBd)]
        public void RecupererComptes_ShouldBeValid()
        {
            // Arrange
            ClientSqliteDataService ds = new ClientSqliteDataService(CheminBd);
            Client client = new Client(1, "Amar", "Quentin", "quentin@gmail.com");
            List<Compte> comptes = new List<Compte> { new Compte(1, "9864", 831.76, 1), new Compte(2, "2370", 493.04, 1) };

            // Act
            ds.RecupererComptes(client);


            // Assert
            Assert.Equal(2, client.Comptes.Count());
            Assert.Equivalent(comptes, client.Comptes);
        }


        [Fact]
        [AvantApresDataService(CheminBd)]
        public void Update_ShouldBeUpdated()
        {
            // Arrange
            ClientSqliteDataService ds = new ClientSqliteDataService(CheminBd);
            Client client = ds.Get(1);
            string expectedNom = "Toto";
            client.Nom = expectedNom;


            // Act
            // Assert         
            Assert.True(ds.Update(client));
            Assert.Equal(expectedNom, ds.Get(1).Nom);
        }


        [Fact]
        [AvantApresDataService(CheminBd)]
        public void Update_ShouldNotBeUpdated()
        {
            // Arrange
            ClientSqliteDataService ds = new ClientSqliteDataService(CheminBd);
            // Act
            // Assert         
            Assert.False(ds.Update(new Client(5, "tata", "toto", "aaa@aaa.com")));
        }
    }
}
