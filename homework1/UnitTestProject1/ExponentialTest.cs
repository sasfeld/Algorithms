using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework1;

namespace Homework1_Test
{
    [TestClass]
    public class ExponentialTest
    {
        protected Exponential exponential = new Exponential();        

        [TestMethod]
        public void TestRunAlgorithm()
        {
            runAllAlgorithms(2, 4, 16);
            runAllAlgorithms(3, 6, 729);
            runAllAlgorithms(5, 5, 3125);
            runAllAlgorithms(7, 9, 40353607);
        }

        protected void runAllAlgorithms(long givenX, long givenN, double expectedResult)
        {
            double result1 = this.runFunc1(givenX, givenN);
            long time1 = exponential.getLastMeasuredCpuTime();
            Console.Write("time1 is " + time1 );

            Assert.AreEqual(expectedResult, result1);

            double result2 = this.runFunc2(givenX, givenN);
            Assert.AreEqual(expectedResult, result2);
            long time2 = exponential.getLastMeasuredCpuTime();
            Console.Write("time2 is " + time1);

            double result3 = this.runFunc3(givenX, givenN);
            Assert.AreEqual(expectedResult, result3);
            long time3 = exponential.getLastMeasuredCpuTime();
            Console.Write("time3 is " + time1);
        }

        protected double runFunc1(long x, long n)
        {
            exponential.setAlgorithmToUse(ExponentialAlgorithm.SIMPLE_ITERATIVE_EXPONENTIATION);

            return exponential.runAlgorithm(x, n);
        }

        protected double runFunc2(long x, long n)
        {
            exponential.setAlgorithmToUse(ExponentialAlgorithm.SIMPLE_RECURSIVE_EXPONENTIATION);

            return exponential.runAlgorithm(x, n);
        }

        protected double runFunc3(long x, long n)
        {
            exponential.setAlgorithmToUse(ExponentialAlgorithm.IMPROVED_RECURSIVE_EXPONTENTIATION);

            return exponential.runAlgorithm(x, n);
        }
    }
}
