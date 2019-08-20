using System;
using System.Linq;
using System.Text;

namespace PolynomialTask
{
    public sealed class Polynomial
    {
        private readonly double[] coefficients;

        /// <summary>
        /// Makes a copy of the array.
        /// </summary>
        /// <param name="coef"></param>
        public Polynomial(params double[] coef)
        {
            if (coef == null)
                throw new ArgumentNullException();
            coefficients = new double[coef.Length];

            coef.CopyTo(coefficients, 0);
        }

        /// <summary>
        /// Makes a string from an array.
        /// </summary>
        /// <returns>String representation of the array.</returns>
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            if (!coefficients[0].Equals(0.0))
                str.Append(coefficients[0]);

            for (int i = 1; i < coefficients.Length; i++)
            {
                if (!coefficients[i].Equals(0.0))
                    str.Append(" + " + coefficients[i] + "x^" + i);
            }

            return str.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Array hash code.</returns>
        public override int GetHashCode()
        {
            int hash = 0;

            for (int i = 0; i < coefficients.Length; i++)
                hash += (coefficients[i] + i).GetHashCode();

            return hash;
        }

        /// <summary>
        /// Compares two polynomials.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException();

            if (!(obj is Polynomial))
                return false;

            return coefficients.SequenceEqual(((Polynomial)obj).coefficients);
        }

        /// <summary>
        /// Overload ==
        /// </summary>
        /// <param name="polynomial1"></param>
        /// <param name="polynomial2"></param>
        /// <returns></returns>
        public static bool operator ==(Polynomial polynomial1, Polynomial polynomial2)
        {
            return polynomial1.Equals(polynomial2);
        }

        /// <summary>
        /// Overload !=
        /// </summary>
        /// <param name="polynomial1"></param>
        /// <param name="polynomial2"></param>
        /// <returns></returns>
        public static bool operator !=(Polynomial polynomial1, Polynomial polynomial2)
        {
            return !polynomial1.Equals(polynomial2);
        }

        /// <summary>
        /// Overload +
        /// </summary>
        /// <param name="polynomial1"></param>
        /// <param name="polynomial2"></param>
        /// <returns></returns>
        public static Polynomial operator +(Polynomial polynomial1, Polynomial polynomial2)
        {
            var max = polynomial1.coefficients.Length > polynomial2.coefficients.Length ?
                polynomial1.coefficients : polynomial2.coefficients;
            var min = polynomial1.coefficients == max ?
                polynomial2.coefficients : polynomial1.coefficients;

            double[] array = new double[max.Length];

            max.CopyTo(array, 0);
            for (int i = 0; i < min.Length; i++)
            {
                array[i] += min[i];
            }
            return new Polynomial(array);
        }

        /// <summary>
        /// Overload -
        /// </summary>
        /// <param name="polynomial1"></param>
        /// <param name="polynomial2"></param>
        /// <returns></returns>
        public static Polynomial operator -(Polynomial polynomial1, Polynomial polynomial2)
        {
            var max = polynomial1.coefficients.Length > polynomial2.coefficients.Length ?
                polynomial1.coefficients : polynomial2.coefficients;
            var min = polynomial1.coefficients == max ?
                polynomial2.coefficients : polynomial1.coefficients;

            double[] array = new double[max.Length];

            max.CopyTo(array, 0);

            for (int i = 0; i < min.Length; i++)
            {
                array[i] -= min[i];
            }
            return new Polynomial(array);
        }

        /// <summary>
        /// Overload *
        /// </summary>
        /// <param name="polynomial1"></param>
        /// <param name="polynomial2"></param>
        /// <returns></returns>
        public static Polynomial operator *(Polynomial polynomial1, Polynomial polynomial2)
        {
            var array = new double[polynomial1.coefficients.Length + polynomial2.coefficients.Length - 1];

            for (int i = 0; i < polynomial1.coefficients.Length; i++)
            {
                for (int j = 0; j < polynomial2.coefficients.Length; j++)
                {
                    array[i + j] += polynomial1.coefficients[i] * polynomial2.coefficients[j];
                }
            }
            return new Polynomial(array);
        }
    }
}