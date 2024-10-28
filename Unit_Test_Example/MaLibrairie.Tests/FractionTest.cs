using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MaLibrairie.Tests
{
    public class FractionTest
    {
        [Fact]
        public void ConstructeurFraction_ShouldBeValid()
        {
            // Préparation du test (Arrange)
            int numerateurAttendu = 1, denominateurAttendu = 4;

            // Exécution du test (Act)
            Fraction fractionActuelle = new Fraction(numerateurAttendu, denominateurAttendu);

            // Affirmation (Assert) entre la valeur attendue (expected) et la la valeur actuelle (actual) 
            Assert.Equal(numerateurAttendu, fractionActuelle.Numerateur);
            Assert.Equal(denominateurAttendu, fractionActuelle.Denominateur);
        }

        [Theory]
        [InlineData(1, 4)]
        [InlineData(8, 3)]
        [InlineData(-5, 6)]
        public void ConstructeurFraction_ShouldBeValid2(int num, int denom)
        {
            int numerateurAttendu = num, denominateurAttendu = denom;

            Fraction fractionActuelle = new Fraction(numerateurAttendu, denominateurAttendu);

            Assert.Equal(numerateurAttendu, fractionActuelle.Numerateur);
            Assert.Equal(denominateurAttendu, fractionActuelle.Denominateur);
        }

        [Fact]
        public void ConstructeurFraction_ShouldNotBeValid()
        {
            Assert.Throws<ArgumentException>(() => new Fraction(10, 0));
        }

        [Theory]
        [InlineData(1, 4, 2, 8)]
        [InlineData(1, 1, 10, 10)]
        [InlineData(10, 2, 5, 1)]
        public void Equals_ShouldBeValid(int num1, int denom1, int num2, int denom2)
        {
            Fraction fraction1 = new Fraction(num1, denom1);

            Fraction fraction2 = new Fraction(num2, denom2);

            //Assert.True(Fraction.Equals(new Fraction(num1, denom1), new Fraction(num2, denom2)));

            Assert.True(Fraction.Equals(fraction1, fraction2));
        }

        [Theory]
        [InlineData(1, 4, 1, 8)]
        [InlineData(1, 1, 100, 10)]
        [InlineData(-1, 4, 1, 4)]
        public void Equals_ShouldNotBeValid(int num1, int denom1, int num2, int denom2)
        {
            Fraction fraction1 = new Fraction(num1, denom1);

            Fraction fraction2 = new Fraction(num2, denom2);

            //Assert.False(Fraction.Equals(new Fraction(num1, denom1), new Fraction(num2, denom2)));

            Assert.False(Fraction.Equals(fraction1, fraction2));
        }

        [Theory]
        [InlineData(0, 4)]
        [InlineData(0, 1)]
        [InlineData(0, 2)]
        public void EstZero_ShouldBeValid(int num, int denom)
        {
            Fraction fraction = new Fraction(num, denom);

            //Assert.True(Fraction.Equals(new Fraction(num1, denom1), new Fraction(num2, denom2)));

            Assert.True(fraction.EstZero());
        }

        [Theory]
        [InlineData(1, 4)]
        [InlineData(1, 1)]
        [InlineData(-1, 2)]
        public void EstZero_ShouldNotBeValid(int num, int denom)
        {
            Fraction fraction = new Fraction(num, denom);

            //Assert.True(Fraction.Equals(new Fraction(num1, denom1), new Fraction(num2, denom2)));

            Assert.False(fraction.EstZero());
        }

        [Theory]
        [InlineData(1, 4, -1, 4, 0, 4)]
        [InlineData(8, 3, 8, 3, 16, 3)]
        [InlineData(1, 2, 1, 2, 1, 1)]
        public void Plus_ShouldBeValid(int num1, int denom1, int num2, int denom2, int numAttendu, int denomAttendu)
        {
            Fraction fraction1 = new Fraction(num1, denom1);

            Fraction fraction2 = new Fraction(num2, denom2);

            Fraction fractionAttendu = new Fraction(numAttendu, denomAttendu);

            Assert.Equal(fraction1.Plus(fraction2), fractionAttendu);
        }

        [Theory]
        [InlineData(1, 4, -1, 4, 2, 4)]
        [InlineData(8, 3, 8, 3, 0, 3)]
        [InlineData(1, 2, 1, 4, 1, 4)]
        public void Moins_ShouldBeValid(int num1, int denom1, int num2, int denom2, int numAttendu, int denomAttendu)
        {
            Fraction fraction1 = new Fraction(num1, denom1);

            Fraction fraction2 = new Fraction(num2, denom2);

            Fraction fractionAttendu = new Fraction(numAttendu, denomAttendu);

            Assert.Equal(fraction1.Moins(fraction2), fractionAttendu);
        }

        [Theory]
        [InlineData(1, 4, -1, 4, -1, 16)]
        [InlineData(0, 3, 1, 3, 0, 3)]
        [InlineData(1, 2, 1, 4, 1, 8)]
        public void Fois_ShouldBeValid(int num1, int denom1, int num2, int denom2, int numAttendu, int denomAttendu)
        {
            Fraction fraction1 = new Fraction(num1, denom1);

            Fraction fraction2 = new Fraction(num2, denom2);

            Fraction fractionAttendu = new Fraction(numAttendu, denomAttendu);

            Assert.Equal(fraction1.Fois(fraction2), fractionAttendu);
        }

        [Theory]
        [InlineData(-1, 4, -4, 1)]
        [InlineData(8, 3, 3, 8)]
        [InlineData(1, 2, 2, 1)]
        public void Inverse_ShouldBeValid(int num1, int denom1, int numAttendu, int denomAttendu)
        {
            Fraction fraction1 = new Fraction(num1, denom1);

            Fraction fractionAttendu = new Fraction(numAttendu, denomAttendu);


            Assert.Equal(fraction1.Inverse(), fractionAttendu);
        }

        [Fact]
        public void Inverse_ShouldNotBeValid()
        {
            Fraction fraction = new Fraction(0, 10);

            Assert.Throws<InvalidOperationException>(() => fraction.Inverse());
        }

        [Theory]
        [InlineData(-1, 4, "-1/4")]
        [InlineData(8, 3, "8/3")]
        [InlineData(0, 2, "0/2")]
        public void ToString_ShouldBeValid(int num, int denom, string chaineAttendue)
        {
            Fraction fraction = new Fraction(num, denom);



            Assert.Equal(fraction.ToString(), chaineAttendue);
        }
    }
}