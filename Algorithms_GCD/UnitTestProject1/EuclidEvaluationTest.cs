using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms_Euclid;

namespace UnitTestProject1
{
    [TestClass]
    public class EuclidEvaluationTest
    {
        [TestMethod]
        public void TestGenerationOfRandomPairs()
        {
            assertRandomPairs(1000, 10000, 100000);
        }

        protected void assertRandomPairs(int numberPairs, int minimum, int maximum)
        {
            // when evaluation object is created
            EuclidEvaluation evaluation = new EuclidEvaluation();

            // and generate random pairs is called
            evaluation.generateRandomPairs(numberPairs, minimum, maximum);

            HashSet<int[]> generatedPairs = evaluation.getRandomPairs();

            // then make sure that the size matches
            Assert.AreEqual(numberPairs, generatedPairs.Count);

            // and that each generated value has the specified minimum and maximum
            foreach (int[] generatedPair in generatedPairs)
            {
                Assert.IsTrue(generatedPair[0] >= minimum);
                Assert.IsTrue(generatedPair[0] <= maximum);
                Assert.IsTrue(generatedPair[1] >= minimum);
                Assert.IsTrue(generatedPair[1] <= maximum);
            }
        }
    }
}
