using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaLibrairie
{
    public class Fraction
    {
        private int _numerateur;
        private int _denominateur;

        public Fraction(int numerateur, int denominateur)
        {
            if (denominateur == 0) throw new ArgumentException("Le dénominateur ne peut pas être 0.");

            _numerateur = numerateur;
            _denominateur = denominateur;
        }

        public Fraction Plus(Fraction f)
        {
            int num = _numerateur * f._denominateur + f._numerateur * _denominateur;
            int denom = _denominateur * f._denominateur;
            return new Fraction(num, denom);
        }

        public Fraction Moins(Fraction f)
        {
            int num = _numerateur * f._denominateur - f._numerateur * _denominateur;
            int denom = _denominateur * f._denominateur;
            return new Fraction(num, denom);
        }

        public Fraction Fois(Fraction f)
        {
            int num = _numerateur * f._numerateur;
            int denom = _denominateur * f._denominateur;
            return new Fraction(num, denom);
        }

        public bool EstZero()
        {
            return _numerateur == 0;
        }

        public Fraction Inverse()
        {
            if (EstZero()) throw new InvalidOperationException("La fraction ne doit pas égaler à zéro.");

            int num = _denominateur;
            int denom = _numerateur;
            return new Fraction(num, denom);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (!(obj is Fraction)) return false;

            Fraction other = (Fraction)obj;

            return _numerateur * other._denominateur == other._numerateur * _denominateur;
        }

        public override string ToString()
        {
            return $"{_numerateur}/{_denominateur}";
        }

        public int Numerateur { get { return _numerateur; } }
        public int Denominateur { get { return _denominateur; } }
    }
}
