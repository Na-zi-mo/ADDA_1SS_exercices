using GestionBanque.Models;
using GestionBanque.Models.DataService;

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
    public class CompteSqliteDataServiceTest
    {
        private const string CheminBd = "test.bd";

        [Fact]
        [AvantApresDataService(CheminBd)]
        public void Get_ShouldBeValid()
        {
            // Préparation
            CompteSqliteDataService ds = new CompteSqliteDataService(CheminBd);
            Compte compteAttendu = new Compte(1, "9864", 831.76, 1);

            // Exécution
            Compte? compteActuel = ds.Get(1);

            // Affirmation
            Assert.Equal(compteAttendu, compteActuel);
        }

        [Fact]
        [AvantApresDataService(CheminBd)]
        public void Retirer_ShouldBeValid()
        {
            // Arrange
            CompteSqliteDataService ds = new CompteSqliteDataService(CheminBd);
            double initialBalance = 300;
            Compte compte = new Compte(1, "0001", initialBalance, 1);
            double drawAmount = 100;
            double expectedBalance = 200;

            // Act
            compte.Retirer(drawAmount);

            // Assert
            Assert.Equal(compte.Balance, expectedBalance);
        }

        [Fact]
        [AvantApresDataService(CheminBd)]
        public void Retirer_ShouldNotBeValid()
        {
            // Arrange
            CompteSqliteDataService ds = new CompteSqliteDataService(CheminBd);
            double initialBalance = 300;
            Compte compte = new Compte(1, "0001", initialBalance, 1);
            double drawAmount = 400;

            // Act
            // Assert         
            Assert.Throws<ArgumentOutOfRangeException>(() => compte.Retirer(drawAmount));
        }

        [Fact]
        [AvantApresDataService(CheminBd)]
        public void Deposer_ShouldBeValid()
        {
            // Arrange
            CompteSqliteDataService ds = new CompteSqliteDataService(CheminBd);
            double initialBalance = 300;
            Compte compte = new Compte(1, "0001", initialBalance, 1);
            double depositAmount = 100;
            double expectedBalance = 400;

            // Act
            compte.Deposer(depositAmount);

            // Assert
            Assert.Equal(compte.Balance, expectedBalance);
        }

        [Fact]
        [AvantApresDataService(CheminBd)]
        public void Deposer_ShouldNotBeValid()
        {
            // Arrange
            CompteSqliteDataService ds = new CompteSqliteDataService(CheminBd);
            double initialBalance = 300;
            Compte compte = new Compte(1, "0001", initialBalance, 1);
            double depositAmount = -100;

            // Act
            // Assert         
            Assert.Throws<ArgumentOutOfRangeException>(() => compte.Deposer(depositAmount));
        }
    }
}
