using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
{
    /// <summary>
    /// A simple Math facade.
    /// </summary>
    public class ExtendedMath
    {
        protected static int count = 0;

        public static int[] calculatePrimeNumbers(long largestNumber)
        {
            // calculate non-prime numbers
            HashSet<int> nonPrimeNumbers = new HashSet<int>();

            for (int m = 2; m <= System.Math.Sqrt(largestNumber); m++)
            {
                for (int n = 2; m * n <= largestNumber; n++)
                {
                    nonPrimeNumbers.Add(n * m);
                }
            }

            HashSet<int> primeNumbers = new HashSet<int>();
            // now get primes by checking numbers that are not contained in the nonPrimeNumbers
            for (int i = 2; i <= largestNumber; i++)
            {
                if (!nonPrimeNumbers.Contains(i))
                {
                    primeNumbers.Add(i);
                }
            }

            return primeNumbers.ToArray();
        }

        public static long[] calculatePrimeFactors(long number)
        {
            return calculatePrimeFactorsList(number).ToArray();
        }

        public static List<long> calculatePrimeFactorsList(long number)
        {
            long n = number;
            List<long> primeFactors = new List<long>();

            for (int i = 2; i <= number / i; i++)
            {
                count++;
                while (n % i == 0)
                {
                    count++;
                    primeFactors.Add(i);

                    n = n / i;
                }
            }

            if (n > 1)
            {
                primeFactors.Add(n);
            }

            return primeFactors;
        }

        public static int getLatestCount()
        {
            int latestCount = count;
            count = 0;
            return latestCount;
        }

        /// <summary>
        /// Calculate the (arithmetic) mean of the given numbers.
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static double calculateMean(long[] numbers)
        {
            double count = numbers.Length;

            double sum = 0;
            foreach (long number in numbers)
            {
                sum += number;
            }

            return sum / count;
        }

        /// <summary>
        /// Calculate the standard deviation of the given numbers.
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static double calculateStandardDeviation(long[] numbers)
        {
            double count = numbers.Length;
            double mean = calculateMean(numbers);

            double varianceSum = 0;
            foreach (int number in numbers)
            {
                varianceSum += Math.Pow((number - mean), 2);
            }

            return Math.Sqrt(varianceSum / count);
        }
    }
}
