using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_Euclid
{
    public class Evaluation
    {
        /// <summary>
        /// Container object which keeps the evaluation data for a single evaluated GCD algorithm.
        /// </summary>
        public class MethodEvaluationData {
            protected SortedDictionary<int, long> timesInMilliseconds;
            protected SortedDictionary<int, long> ticks;
            protected SortedDictionary<int, long> deviations;
            protected SortedDictionary<int, int> numbersOfSteps;
            public double allTicksMean { get; set; }

            public double allTicksDeviation { get; set; }

            public int numberLoops { get; set; }

            public MethodEvaluationData(int numberOfEvaluations)
            {
                this.setNumbersOfSteps(new SortedDictionary<int, int>());
                this.setTimesInMilliseconds(new SortedDictionary<int, long>());
                this.setTicks(new SortedDictionary<int, long>());
                this.setDeviations(new SortedDictionary<int, long>());
            }

            public void setTimeInMilliseconds(int numberOfEvaluation, long time)
            {
                this.timesInMilliseconds[numberOfEvaluation] = time;
            }

            public void setTicks(int numberOfEvaluation, long tick)
            {
                this.ticks[numberOfEvaluation] = tick;
            }

            public void setNumbersOfSteps(int numberOfEvaluation, int steps)
            {
                this.numbersOfSteps[numberOfEvaluation] = steps;
            }

            public void setTimesInMilliseconds(SortedDictionary<int, long> times)
            {
                this.timesInMilliseconds = times;
            }

            public void setTicks(SortedDictionary<int, long> ticks)
            {
                this.ticks = ticks;
            }

            public void setDeviations(SortedDictionary<int, long> deviations)
            {
                this.deviations = deviations;
            }

            public void setDeviations(int numberOfEvaluation, int deviation)
            {
                this.deviations[numberOfEvaluation] = deviation;
            }

            public void setNumbersOfSteps(SortedDictionary<int, int> steps)
            {
                this.numbersOfSteps = steps;
            }

            public SortedDictionary<int, long> getTimesInMilliseconds()
            {
                return this.timesInMilliseconds;
            }

            public SortedDictionary<int, long> getTicks()
            {
                return this.ticks;
            }

            public SortedDictionary<int, long> getDeviations()
            {
                return this.deviations;
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
            /// Get a histogram of the computing time.
            /// 
            /// Therefore, return an array with key = computing time and value = count of the computing time.
            /// </summary>
            /// <returns></returns>
            public SortedDictionary<long, int> getComputingTimeHistogram()
            {
                SortedDictionary<long, int> computingTimeHistogram = new SortedDictionary<long, int>();

                foreach (int evaluationNumber in this.getTimesInMilliseconds().Keys)
                {
                    long computingTime = this.getTimesInMilliseconds()[evaluationNumber];

                    // increase count if entry for number of steps exists
                    if (computingTimeHistogram.ContainsKey(computingTime))
                    {
                        computingTimeHistogram[computingTime]++;
                    }
                    else
                    {
                        // otherwise set count to 1
                        computingTimeHistogram[computingTime] = 1;
                    }
                }

                return computingTimeHistogram;
            }

            /// <summary>
            /// Get a histogram of the CPU ticks.
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

                return ticksHistogram;
            }

            public void calculateMeanAndDeviation()
            {
                long[] allTicks = new long[this.getTicks().Count];

                int i = 0;
                foreach (int evaluationNumber in this.getTicks().Keys)
                {
                    long ticks = this.getTicks()[evaluationNumber];

                    allTicks[i] = ticks;

                    i++;
                }

                this.allTicksMean = ExtendedMath.calculateMean(allTicks);
                this.allTicksDeviation = ExtendedMath.calculateStandardDeviation(allTicks);
            }

        }

        protected HashSet<int[]> randomPairs;

        protected System.Windows.Forms.RichTextBox infoTextBox;

        public double overallStandardDeviation { get; set; }
        public double overallMean { get; set; }

        public Evaluation()
        {
            this.initialize();
        }

        protected void initialize()
        {
                  
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
            }
        }

        /// <summary>
        /// Get the previously generated random pairs.
        /// 
        /// If none were generated, an exception will be thrown to ensure that multiple GCD methods use the same random pairs.
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
    }
}
