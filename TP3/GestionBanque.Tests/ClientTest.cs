using GestionBanque.Models.DataService;
using GestionBanque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanque.Tests
{
    public  class ClientTest
    {
        [Fact]
        public void SetterNom_ShouldBeValid_AlternateCase()
        {
            // Arrange
            Client client = new Client(1, "Amar", "Quentin", "quentin@gmail.com");
            string expectedNom = "Toto";

            // Act
            client.Nom = "  Toto    ";

            // Assert
            Assert.Equal(client.Nom, expectedNom);
        }

        [Fact]
        public void SetterNom_ShouldBeValid_MainCase()
        {
            // Arrange
            Client client = new Client(1, "Amar", "Quentin", "quentin@gmail.com");
            string expectedNom = "Toto";

            // Act
            client.Nom = "Toto";

            // Assert
            Assert.Equal(client.Nom, expectedNom);
        }


        [Fact]
        public void SetterNom_ShouldNotBeValid_NullCase()
        {
            // Arrange
            Client client = new Client(1, "Amar", "Quentin", "quentin@gmail.com");

            // Act
            // Assert         
            Assert.Throws<ArgumentException>(() => client.Nom = null);

        }

        [Fact]
        public void SetterNom_ShouldNotBeValid_EmptyCase_MainCase()
        {
            // Arrange
            Client client = new Client(1, "Amar", "Quentin", "quentin@gmail.com");

            // Act
            // Assert         
            Assert.Throws<ArgumentException>(() => client.Nom = "");
        }

        [Fact]
        public void SetterNom_ShouldNotBeValid_EmptyCase_AlternateCase()
        {
            // Arrange
            Client client = new Client(1, "Amar", "Quentin", "quentin@gmail.com");

            // Act
            // Assert         
            Assert.Throws<ArgumentException>(() => client.Nom = "     ");
        }


        [Fact]
        public void SetterPrenom_ShouldBeValid_AlternateCase()
        {
            // Arrange
            Client client = new Client(1, "Amar", "Quentin", "quentin@gmail.com");
            string expectedPrenom = "Tata";

            // Act
            client.Prenom = "  Tata    ";

            // Assert
            Assert.Equal(client.Prenom, expectedPrenom);
        }

        [Fact]
        public void SetterPrenom_ShouldBeValid_MainCase()
        {
            // Arrange
            
            Client client = new Client(1, "Amar", "Quentin", "quentin@gmail.com");
            string expectedPrenom = "Tata";

            // Act
            client.Prenom = "Tata";

            // Assert
            Assert.Equal(client.Prenom, expectedPrenom);
        }


        [Fact]
        public void SetterPrenom_ShouldNotBeValid_NullCase()
        {
            // Arrange
            
            Client client = new Client(1, "Amar", "Quentin", "quentin@gmail.com");

            // Act
            // Assert         
            Assert.Throws<ArgumentException>(() => client.Prenom = null);

        }

        [Fact]
        public void SetterPrenom_ShouldNotBeValid_EmptyCase_MainCase()
        {
            // Arrange
            Client client = new Client(1, "Amar", "Quentin", "quentin@gmail.com");

            // Act
            // Assert         
            Assert.Throws<ArgumentException>(() => client.Prenom = "");
        }

        [Fact]
        
        public void SetterPrenom_ShouldNotBeValid_EmptyCase_AlternateCase()
        {
            // Arrange
            Client client = new Client(1, "Amar", "Quentin", "quentin@gmail.com");

            // Act
            // Assert         
            Assert.Throws<ArgumentException>(() => client.Prenom = "     ");
        }


        [Fact]
        public void SetterCourriel_ShouldBeValid_MainCase()
        {
            // Arrange
            Client client = new Client(1, "Amar", "Quentin", "quentin@gmail.com");
            string expectedCourriel = "quentin123@gmail.com";

            // Act
            client.Courriel = "quentin123@gmail.com";

            // Assert
            Assert.Equal(client.Courriel, expectedCourriel);
        }


        [Fact]
        public void SetterCourriel_ShouldBeValid_AlternateCase()
        {
            // Arrange
            Client client = new Client(1, "Amar", "Quentin", "quentin@gmail.com");
            string expectedCourriel = "pass@test.test";

            // Act
            client.Courriel = "    pass@test.test    ";

            // Assert
            Assert.Equal(client.Courriel, expectedCourriel);
        }


        [Fact]
        public void SetterCourriel_ShouldNotBeValid_NullCase()
        {
            // Arrange
            Client client = new Client(1, "Amar", "Quentin", "quentin@gmail.com");

            // Act
            // Assert         
            Assert.Throws<ArgumentException>(() => client.Courriel = null);
        }

        [Fact]
        public void SetterCourriel_ShouldNotBeValid_InvalidEmail()
        {
            // Arrange
            
            Client client = new Client(1, "Amar", "Quentin", "quentin@gmail.com");

            // Act
            // Assert         
            Assert.Throws<ArgumentException>(() => client.Courriel = "aaaaa.com");
        }
    }
}
