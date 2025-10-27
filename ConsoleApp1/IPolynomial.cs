

namespace PolinomialWork
{
    public interface IPolynomial
    {
        int Degree { get; }
        double[] Coefficients { get; }
        IPolynomial Add(IPolynomial other);
        IPolynomial Subtract(IPolynomial other);
        IPolynomial AddConstant(double constant);
        IPolynomial MultiplyByConstant(double constant);
        IPolynomial Multiply(IPolynomial other);
        double Evaluate(double x);
    }
}
