using GestionBanque.Models.DataService;
using GestionBanque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanque.Tests
{
    public class CompteTest
    {
        [Fact]
        public void Retirer_ShouldBeValid()
        {
            // Arrange
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
        public void Retirer_ShouldNotBeValid()
        {
            // Arrange
            double initialBalance = 300;
            Compte compte = new Compte(1, "0001", initialBalance, 1);
            double drawAmount = 400;

            // Act
            // Assert         
            Assert.Throws<ArgumentOutOfRangeException>(() => compte.Retirer(drawAmount));
        }

        [Fact]
        public void Deposer_ShouldBeValid()
        {
            // Arrange
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
        public void Deposer_ShouldNotBeValid()
        {
            // Arrange
            double initialBalance = 300;
            Compte compte = new Compte(1, "0001", initialBalance, 1);
            double depositAmount = -100;

            // Act
            // Assert         
            Assert.Throws<ArgumentOutOfRangeException>(() => compte.Deposer(depositAmount));
        }
    }
}
