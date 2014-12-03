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
        /// Container object which keeps the evaluation data for a single evaluated algorithm.
        /// </summary>
        public class MethodEvaluationData {
            protected SortedDictionary<int, long> ticks;
            protected SortedDictionary<int, int> numbersOfSteps;
            protected int numberOfLoops;

            public MethodEvaluationData(int numberOfEvaluations)
            {
                this.setNumbersOfSteps(new SortedDictionary<int, int>());
                this.setTicks(new SortedDictionary<int, long>());
                this.numberOfLoops = numberOfEvaluations;
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

            public int getNumberLoops()
            {
                return this.numberOfLoops;
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
            /// Hand in an experiment number (i.e. for specified problem size) to get a histogram for the single experiment.
            /// </summary>
            /// <returns></returns>
            public SortedDictionary<long, double> getTicksHistogram(int experimentNumber, int numberOfLoops, bool normalize)
            {
                SortedDictionary<long, double> ticksHistogram = new SortedDictionary<long, double>();

                int maxIndex = numberOfLoops * (experimentNumber + 1);
                for (int evaluationNumber = numberOfLoops * experimentNumber + 1; evaluationNumber <= maxIndex; evaluationNumber++) 
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

                if (normalize)
                {
                    ticksHistogram = this.normalizeHistogram(ticksHistogram, numberOfLoops);
                }

                return ticksHistogram;
            }

            // Get a normalized histogram of the CPU ticks covering all problem sizes.
            /// 
            /// Therefore, return an array with key = ticks and value = count of the tick values
            /// </summary>
            /// <returns></returns>
            public SortedDictionary<long, double> getTicksHistogram(bool normalize)
            {
                SortedDictionary<long, double> ticksHistogram = new SortedDictionary<long, double>();

                foreach (int experimentNumber in this.getTicks().Keys)
                {
                    long ticks = this.getTicks()[experimentNumber];
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

                if (normalize)
                {
                    ticksHistogram = this.normalizeHistogram(ticksHistogram, this.getTicks().Count);
                }

                return ticksHistogram;
            }

            /// <summary>
            /// Normalize the given histogram.
            /// </summary>
            /// <param name="histogram"></param>
            /// <param name="numberOfExperiments"></param>
            protected SortedDictionary<long, double> normalizeHistogram(SortedDictionary<long, double> histogram, double numberOfExperiments)
            {
                SortedDictionary<long, double> normalizedHistogram = new SortedDictionary<long, double>();
                
                foreach (long histoKey in histogram.Keys)
                {
                    // calculate prohability (count divided by number of experiments)
                    normalizedHistogram[histoKey] = (histogram[histoKey] / numberOfExperiments) * 100;
                }

                return normalizedHistogram;
            }

            /// <summary>
            /// Calculate the mean on this algorithm and the given problem size.
            /// 
            /// </summary>
            /// <returns></returns>
            public double calculateMean(int experimentNumber, int numberOfLoops)
            {
                List<long> cpuTimes = new List<long>();

                int maxIndex = numberOfLoops * (experimentNumber + 1);
                for (int evaluationNumber = numberOfLoops * experimentNumber + 1; evaluationNumber <= maxIndex; evaluationNumber++)
                {
                    long ticks = this.getTicks()[evaluationNumber];

                    cpuTimes.Add(ticks);
                }

                double cpuMean = ExtendedMath.calculateMean(cpuTimes.ToArray());

                return cpuMean;
            }

            /// <summary>
            /// Calculate the variance on this algorithm and the given problem size.
            /// 
            /// </summary>
            /// <returns></returns>
            public double calculateVariance(int experimentNumber, int numberOfLoops)
            {
                List<long> cpuTimes = new List<long>();

                int maxIndex = numberOfLoops * (experimentNumber + 1);
                for (int evaluationNumber = numberOfLoops * experimentNumber + 1; evaluationNumber <= maxIndex; evaluationNumber++)
                {
                    long ticks = this.getTicks()[evaluationNumber];

                    cpuTimes.Add(ticks);
                }

                if (experimentNumber == 2)
                {
                    int bla = 0;
                }
                double cpuMean = ExtendedMath.calculateStandardDeviation(cpuTimes.ToArray());

                return cpuMean;
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
            this.algorithms.Add(ExponentialAlgorithm.SIMPLE_ITERATIVE_EXPONENTIATION);
            this.algorithms.Add(ExponentialAlgorithm.SIMPLE_RECURSIVE_EXPONENTIATION);
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

        public void resetPairs()
        {
            this.randomPairs = new HashSet<int[]>();
        }

        /// <summary>
        /// Add a new pair of int values that will be evaluated.
        /// 
        /// Value1 means the basis x, value2 the exponent n.
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        public void addPair(int value1, int value2)
        {
            int[] pair = { value1, value2 };
            this.randomPairs.Add(pair);    
        }

        /// <summary>
        /// Get the previously generated random pairs.
        /// 
        /// If none were generated, an exception will be thrown.
        /// </summary>
        /// <returns></returns>
        public HashSet<int[]> getPairs()
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

        protected void reset(int numberOfLoops)
        {
            this.evaluationData = new Dictionary<ExponentialAlgorithm, MethodEvaluationData>();
            foreach (ExponentialAlgorithm algo in this.getMethodsForEvaluation())
            {
                this.evaluationData[algo] = new MethodEvaluationData(numberOfLoops);
            }
        }

        public void runEvaluation(int numberOfLoops)
        {
            this.reset(numberOfLoops);
            this.runForEachAlgorithm(numberOfLoops);
        }

        protected void runForEachAlgorithm(int numberOfLoops)
        {
            int[][] pairs = this.getPairs().ToArray();

            int outer = 1;
            foreach (int[] pair in pairs)
            {               
              foreach (ExponentialAlgorithm algorithm in this.algorithms)
              {
                 this.addInfo("Evaluating " + algorithm + " for x=" + pair[0] + ", n=" + pair[1] + " " + numberOfLoops + " times");
                 for (int i = 1; i <= numberOfLoops; i++)
                 {
                   Exponential exponential = new Exponential();
                     
                   exponential.setAlgorithmToUse(algorithm);
                   double result = exponential.runAlgorithm(pair[0], pair[1]);
                   long ticks = exponential.getLastMeasuredCpuTime();

                   int numberOfEvaluation = outer * numberOfLoops + i;
                   this.evaluationData[algorithm].setTicks(numberOfEvaluation, ticks);

                   if (1 == i)
                   {
                       this.addInfo("Calculated exponential of " + pair[0] + "^" + pair[1] + " = " + result);
                   }
                        
                  }
               }
               outer += 1;
            }
        }
        
    }
}
