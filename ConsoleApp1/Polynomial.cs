using System;
using System.Linq;
using System.Text;

namespace PolinomialWork
{
    public class Polynomial : IPolynomial
    {
        public int Degree { get; private set; }
        public double[] Coefficients { get; private set; }
        public Polynomial()
        {
            Degree = 0;
            Coefficients = new double[] { 0.0 };
        }
        public Polynomial(int degree, double[] coefficients)
        {
            if (degree < 0)
                throw new ArgumentOutOfRangeException(nameof(degree), "Degree must be non-negative.");
            if (coefficients == null || coefficients.Length == 0)
                throw new ArgumentException("Coefficients array must not be null or empty.");
            if (coefficients.Length != degree + 1)
                throw new ArgumentException("Number of coefficients must be equal to degree + 1.", nameof(coefficients));
            
            Degree = degree;
            Coefficients = coefficients;
        }
        public Polynomial(Polynomial other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            Degree = other.Degree;
            Coefficients = (double[])other.Coefficients.Clone();
        }
        public IPolynomial Add(IPolynomial other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            int maxDegree = Math.Max(this.Degree, other.Degree);
            double[] newCoeffs = new double[maxDegree + 1];

            for (int i = 0; i <= maxDegree; i++)
            {
                double thisCoeff = (i <= this.Degree) ? this.Coefficients[i] : 0;
                double otherCoeff = (i <= other.Degree) ? other.Coefficients[i] : 0;

                newCoeffs[i] = thisCoeff + otherCoeff;
            }

            int newActualDegree = maxDegree;
            while (newActualDegree > 0 && newCoeffs[newActualDegree] == 0)
            {
                newActualDegree--;
            }

            if (newActualDegree != maxDegree)
            {
                double[] finalCoeffs = new double[newActualDegree + 1];
                Array.Copy(newCoeffs, finalCoeffs, newActualDegree + 1);
                return new Polynomial(newActualDegree, finalCoeffs);
            }

            return new Polynomial(newActualDegree, newCoeffs);
        }
        public IPolynomial Subtract(IPolynomial other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            int maxDegree = Math.Max(this.Degree, other.Degree);
            double[] newCoeffs = new double[maxDegree + 1];

            for (int i = 0; i <= maxDegree; i++)
            {
                double thisCoeff = (i <= this.Degree) ? this.Coefficients[i] : 0;
                double otherCoeff = (i <= other.Degree) ? other.Coefficients[i] : 0;

                newCoeffs[i] = thisCoeff - otherCoeff;
            }

            int newActualDegree = maxDegree;
            while (newActualDegree > 0 && newCoeffs[newActualDegree] == 0)
            {
                newActualDegree--;
            }

            if (newActualDegree != maxDegree)
            {
                double[] finalCoeffs = new double[newActualDegree + 1];
                Array.Copy(newCoeffs, finalCoeffs, newActualDegree + 1);
                return new Polynomial(newActualDegree, finalCoeffs);
            }

            return new Polynomial(newActualDegree, newCoeffs);
        }
        public IPolynomial AddConstant(double constant)
        {
            double[] newCoeffs = (double[])this.Coefficients.Clone();
            newCoeffs[0] += constant;
            return new Polynomial(this.Degree, newCoeffs);
        }
        public IPolynomial MultiplyByConstant(double constant)
        {
            if (constant == 0)
            {
                return new Polynomial(0, new double[] { 0.0 });
            }

            double[] newCoeffs = new double[this.Degree + 1];
            for (int i = 0; i <= this.Degree; i++)
            {
                newCoeffs[i] = this.Coefficients[i] * constant;
            }

            return new Polynomial(this.Degree, newCoeffs);
        }
        public double Evaluate(double x)
        {
            double result = 0;
            for (int i = this.Degree; i >= 0; i--)
            {
                result = (result * x) + this.Coefficients[i];
            }
            return result;
        }
        public IPolynomial Multiply(IPolynomial other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            int newDegree = this.Degree + other.Degree;
            double[] newCoeffs = new double[newDegree + 1];

            for (int i = 0; i <= this.Degree; i++)
            {
                for (int j = 0; j <= other.Degree; j++)
                {
                    newCoeffs[i + j] += this.Coefficients[i] * other.Coefficients[j];
                }
            }

            int newActualDegree = newDegree;
            while (newActualDegree > 0 && newCoeffs[newActualDegree] == 0)
            {
                newActualDegree--;
            }

            if (newActualDegree != newDegree)
            {
                double[] finalCoeffs = new double[newActualDegree + 1];
                Array.Copy(newCoeffs, finalCoeffs, newActualDegree + 1);
                return new Polynomial(newActualDegree, finalCoeffs);
            }

            return new Polynomial(newDegree, newCoeffs);
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Polynomial))
            {
                return false;
            }

            Polynomial other = (Polynomial)obj;
            return this.Degree == other.Degree &&
                   this.Coefficients.SequenceEqual(other.Coefficients);
        }
        public override int GetHashCode()
        { 
            int hashCode = 17;

            hashCode = hashCode * 23 + Degree.GetHashCode();

            if (Coefficients != null)
            {
                foreach (double coeff in Coefficients)
                {
                    hashCode = hashCode * 23 + coeff.GetHashCode();
                }
            }
            return hashCode;
        }
        public override string ToString()
        {
            if (Degree == 0 && Coefficients[0] == 0)
            {
                return "0";
            }

            StringBuilder sb = new StringBuilder();

            for (int i = Degree; i >= 0; i--)
            {
                double coeff = Coefficients[i];

                if (coeff == 0)
                {
                    continue;
                }

                if (sb.Length > 0) 
                {
                    sb.Append(coeff > 0 ? " + " : " - ");
                    coeff = Math.Abs(coeff); 
                }
                else if (coeff < 0) 
                {
                    sb.Append("-");
                    coeff = Math.Abs(coeff);
                }

                if (coeff != 1 || i == 0)
                {
                    sb.Append(coeff);
                }

                if (i > 0) 
                { 
                    sb.Append("x");
                    if (i > 1)
                    {
                        sb.Append($"^{i}");
                    }
                }
            }

            if (sb.Length == 0)
            {
                return "0";
            }

            return sb.ToString();
        }
    }
}
