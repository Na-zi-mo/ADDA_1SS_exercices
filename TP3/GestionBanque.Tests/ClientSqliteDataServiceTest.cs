
using GestionBanque.Models.DataService;
using GestionBanque.Models;
using System.Numerics;

namespace GestionBanque.Tests
{
    // Ce décorateur s'assure que toutes les classes de tests ayant le tag "Dataservice" soit
    // exécutées séquentiellement. Par défaut, xUnit exécute les différentes suites de tests
    // en parallèle. Toutefois, si nous voulons forcer l'exécution séquentielle entre certaines
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
            // Préparation
            ClientSqliteDataService ds = new ClientSqliteDataService(CheminBd);
            Client clientAttendu = new Client(1, "Amar", "Quentin", "quentin@gmail.com");
            clientAttendu.Comptes.Add(new Compte(1, "9864", 831.76, 1));
            clientAttendu.Comptes.Add(new Compte(2, "2370", 493.04, 1));

            // Exécution
            Client? clientActuel = ds.Get(1);

            // Affirmation
            Assert.Equal(clientAttendu, clientActuel);
        }

        [Fact]
        [AvantApresDataService(CheminBd)]
        public void SetterNom_ShouldBeValid_AlternateCase()
        {
            // Préparation
            ClientSqliteDataService ds = new ClientSqliteDataService(CheminBd);
            Client client = new Client(1, "Amar", "Quentin", "quentin@gmail.com");
            string expectedName = "Toto";

            // Exécution
            client.Nom = "  Toto    ";

            // Affirmation
            Assert.Equal(client.Nom, expectedName);
        }

        [Fact]
        [AvantApresDataService(CheminBd)]
        public void SetterNom_ShouldBeValid_MainCase()
        {
            // Préparation
            ClientSqliteDataService ds = new ClientSqliteDataService(CheminBd);
            Client client = new Client(1, "Amar", "Quentin", "quentin@gmail.com");
            string expectedName = "Toto";

            // Exécution
            client.Nom = "Toto";

            // Affirmation
            Assert.Equal(client.Nom, expectedName);
        }


        [Fact]
        [AvantApresDataService(CheminBd)]
        public void SetterNom_ShouldNotBeValid_NullCase()
        {
            // Préparation
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
            // Préparation
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
            // Préparation
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
            // Préparation
            ClientSqliteDataService ds = new ClientSqliteDataService(CheminBd);
            Client client = new Client(1, "Amar", "Quentin", "quentin@gmail.com");
            string expectedName = "Tata";

            // Exécution
            client.Prenom = "  Tata    ";

            // Affirmation
            Assert.Equal(client.Prenom, expectedName);
        }

        [Fact]
        [AvantApresDataService(CheminBd)]
        public void SetterPrenom_ShouldBeValid_MainCase()
        {
            // Préparation
            ClientSqliteDataService ds = new ClientSqliteDataService(CheminBd);
            Client client = new Client(1, "Amar", "Quentin", "quentin@gmail.com");
            string expectedName = "Tata";

            // Exécution
            client.Prenom = "Tata";

            // Affirmation
            Assert.Equal(client.Prenom, expectedName);
        }


        [Fact]
        [AvantApresDataService(CheminBd)]
        public void SetterPrenom_ShouldNotBeValid_NullCase()
        {
            // Préparation
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
            // Préparation
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
            // Préparation
            ClientSqliteDataService ds = new ClientSqliteDataService(CheminBd);
            Client client = new Client(1, "Amar", "Quentin", "quentin@gmail.com");

            // Act
            // Assert         
            Assert.Throws<ArgumentException>(() => client.Prenom = "     ");
        }
    }
}
