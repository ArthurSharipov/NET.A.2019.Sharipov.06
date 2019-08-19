using NUnit.Framework;
using PolynomialTask;

namespace Tests
{
    public class PolynomialTests
    {
        [Test]
        public void PolynomialEqualsTests()
        {
            var polynomial1 = new Polynomial(13.37, 23, 65.8, int.MaxValue, double.MaxValue);
            var polynomial2 = new Polynomial(13.37, 23, 65.8, int.MaxValue, double.MaxValue);
            Assert.AreEqual(polynomial1.Equals(polynomial2), true);

            polynomial1 = new Polynomial(double.MaxValue, 58.5, 64.6, 2569853545.56885);
            polynomial1 = new Polynomial(double.MaxValue, 58.5, 64.6, 2569853545.56884);
            Assert.AreEqual(polynomial1.Equals(polynomial2), false);
        }

        [Test]
        [TestCase(new double[] { 13.37, 23, 65.8, int.MaxValue, double.MaxValue }, 
            ExpectedResult = "13,37 + 23x^1 + 65,8x^2 + 2147483647x^3 + 1,79769313486232E+308x^4")]
        [TestCase(new double[] { 13.37, 23, 65.8, int.MinValue, double.MinValue },
            ExpectedResult = "13,37 + 23x^1 + 65,8x^2 + -2147483648x^3 + -1,79769313486232E+308x^4")]
        public string PolynomialToStringTests(double[] coefficients)
        {
            Polynomial polynomial = new Polynomial(coefficients);
            return polynomial.ToString();
        }

        [Test]
        public void PolynomialAddTests()
        {
            var polynomial1 = new Polynomial(13.37, 23, 65.8);
            var polynomial2 = new Polynomial(15, 2, 66);

            Assert.AreEqual(polynomial1 + polynomial2, new Polynomial(28.369999999999997, 25, 131.8));
        }

        [Test]
        public void PolynomialSubtractionTests()
        {
            var polynomial1 = new Polynomial(13.37, 23, 65.8);
            var polynomial2 = new Polynomial(15, 2, 66);

            Assert.AreEqual(polynomial1 - polynomial2, new Polynomial(1.6300000000000008, -21, 0.20000000000000284));
        }

        [Test]
        public void PolynomialMultiplicationTests()
        {
            var polynomial1 = new Polynomial(13.37, 23, 65.8);
            var polynomial2 = new Polynomial(15, 2, 66);

            Assert.AreEqual(polynomial1 * polynomial2, new Polynomial(200.54999999999998, 371.74, 1915.42, 1649.6, 4342.8));
        }
    }
}