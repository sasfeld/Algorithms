using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
{
    public class Evaluation
    {
        /// <summary>
        /// Container object which keeps the evaluation data for a single evaluated GCD algorithm.
        /// </summary>
        public class MethodEvaluationData {
            protected SortedDictionary<int, long> ticks;
            protected SortedDictionary<int, int> numbersOfSteps;

            public MethodEvaluationData(int numberOfEvaluations)
            {
                this.setNumbersOfSteps(new SortedDictionary<int, int>());
                this.setTicks(new SortedDictionary<int, long>());
            }

            public void setTicks(int numberOfEvaluation, long tick)
            {
                this.ticks[numberOfEvaluation] = tick;
            }

            public void setNumbersOfSteps(int numberOfEvaluation, int steps)
            {
                this.numbersOfSteps[numberOfEvaluation] = steps;
            }        

            public void setTicks(SortedDictionary<int, long> ticks)
            {
                this.ticks = ticks;
            }           

            public void setNumbersOfSteps(SortedDictionary<int, int> steps)
            {
                this.numbersOfSteps = steps;
            }

            public SortedDictionary<int, long> getTicks()
            {
                return this.ticks;
            }          

            public SortedDictionary<int, int> getNumbersOfSteps()
            {
                return this.numbersOfSteps;
            }

            /// <summary>
            /// Get a histogram of the number of steps.
            /// 
            /// Therefore, return an array with key = steps number and value = count of the steps number.
            /// </summary>
            /// <returns></returns>
            public SortedDictionary<int, int> getNumberOfStepsHistogram()
            {
                SortedDictionary<int, int> numberStepsHistogram = new SortedDictionary<int, int>();

                foreach(int evaluationNumber in this.getNumbersOfSteps().Keys)
                {
                    int numberSteps = this.getNumbersOfSteps()[evaluationNumber];

                    // increase count if entry for number of steps exists
                    if (numberStepsHistogram.ContainsKey(numberSteps))
                    {
                        numberStepsHistogram[numberSteps]++;
                    }
                    else
                    {
                        // otherwise set count to 1
                        numberStepsHistogram[numberSteps] = 1;
                    }
                }

                return numberStepsHistogram;
            }
          

            /// <summary>
            /// Get a normalized histogram of the CPU ticks.
            /// 
            /// Therefore, return an array with key = ticks and value = count of the tick values
            /// </summary>
            /// <returns></returns>
            public SortedDictionary<long, int> getTicksHistogram()
            {
                SortedDictionary<long, int> ticksHistogram = new SortedDictionary<long, int>();

                foreach (int evaluationNumber in this.getTicks().Keys)
                {
                    long ticks = this.getTicks()[evaluationNumber];

                    // increase count if entry for number of steps exists
                    if (ticksHistogram.ContainsKey(ticks))
                    {
                        ticksHistogram[ticks]++;
                    }
                    else
                    {
                        // otherwise set count to 1
                        ticksHistogram[ticks] = 1;
                    }
                }

                this.normalizeHistogram(ticksHistogram, ticksHistogram.Count);

                return ticksHistogram;
            }

            /// <summary>
            /// Normalize the given histogram.
            /// </summary>
            /// <param name="histogram"></param>
            /// <param name="numberOfExperiments"></param>
            protected void normalizeHistogram(SortedDictionary<long, int> histogram, int numberOfExperiments)
            {
                foreach (long histoKey in histogram.Keys)
                {
                   //histogram[histoKey] = (int) histogram[histoKey] / numberOfExperiments;
                }
            }

        }

        protected HashSet<int[]> randomPairs;
        protected Dictionary<ExponentialAlgorithm, MethodEvaluationData> evaluationData;
        protected System.Windows.Forms.RichTextBox infoTextBox;
        protected HashSet<ExponentialAlgorithm> algorithms;

        public Evaluation()
        {
            this.initialize();
        }

        protected void initialize()
        {
            this.algorithms = new HashSet<ExponentialAlgorithm>();
            this.algorithms.Add(ExponentialAlgorithm.SIMPLE_ITERATIVE_EXPONENTITATION);
            this.algorithms.Add(ExponentialAlgorithm.SIMPLE_RECURSIVE_EXPONENTITATION);
            this.algorithms.Add(ExponentialAlgorithm.IMPROVED_RECURSIVE_EXPONTENTIATION);
        }

        public HashSet<ExponentialAlgorithm> getMethodsForEvaluation()
        {
            return this.algorithms;
        }

        public Dictionary<ExponentialAlgorithm, MethodEvaluationData>  getEvaluationData()
        {
            return this.evaluationData;
        }


        /// <summary>
        /// 
        /// Generate a fixed number of denominator, nominator pairs which have a random value between the specified minimum and maximum.
        /// 
        /// After calling this method, you can get the generated pairs by getRandomPairs().
        /// 
        /// </summary>
        /// <param name="numberOfPairs">The number of pairs that should be filled.</param>
        /// <param name="minimumValue">The minimum value that each nominator and denominator should at least have.</param>
        /// <param name="maximumValue">The maximum value that each nominator and denominator should have.</param>
        public void generateRandomPairs(int numberOfPairs, int minimumValue, int maximumValue)
        {
            Random randomizer = new Random();
            randomPairs = new HashSet<int[]>();

            for (int i = 0; i < numberOfPairs; i++)
            {
                int denominator = randomizer.Next(minimumValue, maximumValue);
                int nominator = randomizer.Next(minimumValue, maximumValue);

                int[] pair = { denominator, nominator };
                this.randomPairs.Add(pair);

                this.addInfo("Generated pair (" + denominator + "," + nominator + ")");
            }
        }

        /// <summary>
        /// Get the previously generated random pairs.
        /// 
        /// If none were generated, an exception will be thrown.
        /// </summary>
        /// <returns></returns>
        public HashSet<int[]> getRandomPairs()
        {
            if (null == randomPairs)
            {
                throw new InvalidOperationException("You need to call generateRandomPairs() first!");
            }

            return this.randomPairs;
        }       

       

        internal void setInfoTextBox(System.Windows.Forms.RichTextBox richTextBox)
        {
            this.infoTextBox = richTextBox;
        }

        protected void addInfo(String info)
        {
            this.infoTextBox.AppendText(info + "\n");
        }

        protected void reset()
        {
            this.evaluationData = new Dictionary<ExponentialAlgorithm, MethodEvaluationData>();
            foreach (ExponentialAlgorithm algo in this.getMethodsForEvaluation())
            {
                this.evaluationData[algo] = new MethodEvaluationData(this.getRandomPairs().Count);
            }
        }

        public void runEvaluation()
        {
            this.reset();
            this.runForEachAlgorithm();
        }

        protected void runForEachAlgorithm()
        {
            int[][] randomPairs = this.getRandomPairs().ToArray();

            foreach (int[] randomPair in randomPairs)
            {

                foreach (ExponentialAlgorithm algorithm in this.algorithms)
                {
                    Exponential exponential = new Exponential();

                    exponential.setAlgorithmToUse(algorithm);
                    double result = exponential.runAlgorithm(randomPair[0], randomPair[1]);
                    long ticks = exponential.getLastMeasuredCpuTime();

                    int numberOfEvaluation = (randomPair[0] + randomPair[1]);
                    this.evaluationData[algorithm].setTicks(numberOfEvaluation, ticks);

                    this.addInfo("Calculated exponential of " + randomPair[0] + "^" + randomPair[1] + " = " + result);
                }
            }
        }
        
    }
}
