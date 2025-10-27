using PolinomialWork;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PolinomialTest
{
    [TestClass]
    public class PolinomialTest
    {
        [TestMethod]
        // Перевіряє коректність додавання двох поліномів однакової розмірності.
        public void Add_SameDegreePolynomials_ReturnsSumPolynomial()
        {
            // Arrange
            var p1 = new Polynomial(1, new double[] { 2, 1 });
            var p2 = new Polynomial(1, new double[] { 1, 3 });
            var expected = new Polynomial(1, new double[] { 3, 4 });

            // Act
            var result = p1.Add(p2);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        // Перевіряє коректність додавання двох поліномів різного степеня.
        public void Add_DifferentDegreePolynomials_ReturnsSumPolynomial()
        {            // Arrange
            var p1 = new Polynomial(2, new double[] { 1, 2, 3 }); 
            var p2 = new Polynomial(1, new double[] { 5, 6 });    
            var expected = new Polynomial(2, new double[] { 6, 8, 3 });

            // Act
            var result = p1.Add(p2);

            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        // Перевіряє коректність віднімання поліномів однакового степеня.
        public void Subtract_SameDegreePolynomials_ReturnsDifferencePolynomial()
        {
            // Arrange
            var p1 = new Polynomial(1, new double[] { 3, 2 }); 
            var p2 = new Polynomial(1, new double[] { 1, 4 }); 
            var expected = new Polynomial(1, new double[] { 2, -2 }); 

            // Act
            var result = p1.Subtract(p2);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        // Перевіряє коректність віднімання поліномів різного степеня.
        public void Subtract_DifferentDegreePolynomials_ReturnsDifferencePolynomial()
        {
            // Arrange
            var p1 = new Polynomial(2, new double[] { 2, 3, 4 }); 
            var p2 = new Polynomial(1, new double[] { 1, 2 });    
            var expected = new Polynomial(2, new double[] { -1, -1, -4 }); 

            // Act
            var result = p2.Subtract(p1);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        // Перевіряє коректність множення двох поліномів однакового степеня.
        public void Multiply_TwoSameDegreePolynomials_ReturnsProductPolynomial()
        {
            // Arrange
            var p1 = new Polynomial(1, new double[] { 1, 1 });
            var p2 = new Polynomial(1, new double[] { 1, 1 });
            var expected = new Polynomial(2, new double[] { 1, 2, 1 }); 

            // Act
            var result = p1.Multiply(p2);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        // Перевіряє коректність множення двох поліномів різного степеня.
        public void Multiply_TwoDifferentDegreePolynomials_ReturnsProductPolynomial()
        {
            // Arrange
            var p1 = new Polynomial(1, new double[] { 1, 1 });
            var p2 = new Polynomial(2, new double[] { 1, 1, 1 });
            var expected = new Polynomial(3, new double[] { 1, 2, 2, 1 });

            // Act
            var result = p1.Multiply(p2);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        // Перевіряє, що множення будь-якого полінома на нульовий поліном повертає нульовий поліном.
        public void Multiply_ByZeroPolynomial_ReturnsZeroPolynomial()
        {
            // Arrange
            var p1 = new Polynomial(1, new double[] { 3, 2 });
            var zero = new Polynomial(0, new double[] { 0 });
            var expected = new Polynomial(0, new double[] { 0 });

            // Act
            var result = p1.Multiply(zero);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        // Перевіряє коректність множення полінома на константу (число).
        public void MultiplyByConstant_MultiplyPolynomialByNumber_ReturnsScaledPolynomial()
        {
            // Arrange
            var p = new Polynomial(2, new double[] { 1, 2, 3 });
            double constant = 2;
            var expected = new Polynomial(2, new double[] { 2, 4, 6 });

            // Act
            var result = p.MultiplyByConstant(constant);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        // Перевіряє коректність додавання константи (числа) до полінома.
        public void AddConstant_AddNumberToPolynomial_ReturnsNewPolynomial()
        {
            // Arrange
            var p = new Polynomial(1, new double[] { 2, 3 }); 
            double constant = 5;
            var expected = new Polynomial(1, new double[] { 7, 3 }); 

            // Act
            var result = p.AddConstant(constant);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        // Перевіряє, що обчислення полінома в точці x=0 повертає його вільний член (коефіцієнт при x^0).
        public void Evaluate_AtZero_ReturnsConstantTerm()
        {
            // Arrange
            var p = new Polynomial(2, new double[] { 2, 3, 4 });

            // Act
            var result = p.Evaluate(0);

            // Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        // Перевіряє, що обчислення полінома в точці x=1 повертає суму всіх його коефіцієнтів.
        public void Evaluate_AtOne_ReturnsSumOfCoefficients()
        {
            // Arrange
            var p = new Polynomial(2, new double[] { 2, 3, 4 });

            // Act
            var result = p.Evaluate(1);

            // Assert
            Assert.AreEqual(9, result);
        }

        [TestMethod]
        // Перевіряє коректність обчислення полінома для від'ємного значення аргументу (x).
        public void Evaluate_AtNegativeX_ReturnsCorrectValue()
        {
            // Arrange
            var p = new Polynomial(2, new double[] { 1, 0, 1 }); 

            // Act
            var result = p.Evaluate(-2);

            // Assert
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        // Перевіряє, що метод Equals повертає true для двох різних об'єктів-поліномів з однаковим вмістом.
        public void Equals_IdenticalPolynomials_ReturnsTrue()
        {
            // Arrange
            var p1 = new Polynomial(2, new double[] { 1, 2, 3 });
            var p2 = new Polynomial(2, new double[] { 1, 2, 3 });

            // Act
            bool result = p1.Equals(p2);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        // Перевіряє, що метод Equals повертає false для поліномів, що відрізняються (коефіцієнтами).
        public void Equals_DifferentPolynomials_ReturnsFalse()
        {
            // Arrange
            var p1 = new Polynomial(1, new double[] { 1, 2 });
            var p2 = new Polynomial(1, new double[] { 1, 3 });

            // Act
            bool result = p1.Equals(p2);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        // Перевіряє, що метод Equals повертає false для поліномів, що відрізняються розмірністю.
        public void Equals_DifferentDegreePolynomials_ReturnsFalse()
        {
            // Arrange
            var p1 = new Polynomial(1, new double[] { 1, 2 });
            var p2 = new Polynomial(2, new double[] { 1, 2, 3 });

            // Act
            bool result = p1.Equals(p2);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        // Перевіряє, що метод ToString коректно форматує поліном у рядок, пропускаючи члени з нульовими коефіцієнтами.
        public void ToString_FormatsPolynomialWithoutZeroCoefficients()
        {
            // Arrange
            var p = new Polynomial(2, new double[] { 2, 3, 0 });

            // Act
            string result = p.ToString();

            // Assert
            Assert.AreEqual("3x + 2", result);
        }

        [TestMethod]
        // Перевіряє, що метод Add кидає виняток ArgumentNullException при спробі додати null в якості аргументу.
        public void Add_WithNullArgument_ThrowsArgumentNullException()
        {
            var p = new Polynomial(1, new double[] { 2, 3 });
            Assert.ThrowsException<ArgumentNullException>(() => p.Add(null));
        }

        [TestMethod]
        // Перевіряє, що метод Subtract кидає виняток ArgumentNullException при спробі додати null в якості аргументу.
        public void Subtract_WithNullArgument_ThrowsArgumentNullException()
        {
            var p = new Polynomial(1, new double[] { 2, 3 });
            Assert.ThrowsException<ArgumentNullException>(() => p.Subtract(null));
        }

        [TestMethod]
        // Перевіряє, що метод Multiply кидає виняток ArgumentNullException при спробі помножити на null.
        public void Multiply_WithNullArgument_ThrowsArgumentNullException()
        {
            var p = new Polynomial(1, new double[] { 1, 2 });
            Assert.ThrowsException<ArgumentNullException>(() => p.Multiply(null));
        }
    }
}
