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
    }
}