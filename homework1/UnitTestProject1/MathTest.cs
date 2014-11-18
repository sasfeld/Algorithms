using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms_Euclid;

namespace UnitTestProject1
{
    [TestClass]
    public class MathTest
    {
        [TestMethod]
        public void TestCalculatePrimeNumbers()
        {
            // when input number is given
            int givenNumber = 100;

            // and method is called
            int[] resultPrimeNumbers = ExtendedMath.calculatePrimeNumbers(givenNumber);

            // then expect the following array
            int[] expectedPrimeNumbers = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };

            int i = 0;
            foreach (int expectedPrimeNumber in expectedPrimeNumbers)
            {
                Assert.AreEqual(expectedPrimeNumber, resultPrimeNumbers[i]);
                i++;
            }
        }

        [TestMethod]
        public void TestCalculateMean()
        {
            // when input numbers are given
            long[] inputNumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // and method is called
            double resultMean = ExtendedMath.calculateMean(inputNumbers);

            // then expect
            Assert.AreEqual(5, resultMean);
        }

        [TestMethod]
        public void TestCalculateStandardDeviation()
        {
            // when input numbers are given
            long[] inputNumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // and method is called
            double resultDeviation = ExtendedMath.calculateStandardDeviation(inputNumbers);

            // then expect
            Assert.AreEqual(2.582, Math.Round(resultDeviation, 3));
        }

        [TestMethod]
        public void TestPrimeFactorization()
        {
            // when prime factors for 18 are calculated, expect 2, 3, 3
            int[] expectedPrimeFactors = { 2, 3, 3 };
            assertPrimeFactors(18, expectedPrimeFactors );

            // when prime factors for 24 are calculated, expect 2, 2, 2, 3 
            int[] expectedPrimeFactorsFor18 = { 2, 2, 2, 3 };
            assertPrimeFactors(24, expectedPrimeFactorsFor18);
        }

        protected void assertPrimeFactors(int number, int[] expectedPrimeFactors)
        {
            long[] resultPrimeFactors = ExtendedMath.calculatePrimeFactors(number);

            int i = 0;
            foreach (int expectedPrimeFactor in expectedPrimeFactors)
            {
                Assert.AreEqual(expectedPrimeFactor, resultPrimeFactors[i]);
                i++;
            }
        }
    }
}
