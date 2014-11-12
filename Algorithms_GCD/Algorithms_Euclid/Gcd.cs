using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Algorithms_Euclid
{
    public enum EuclidMethod
    {
        SUBTRACTION,
        MODULO,
        RECURSIVE,
        PRIME_FACTORIZATION,
    }

    class Gcd
    {     

        protected EuclidMethod configuredMethod;
        protected int counter;
        protected long time;
        protected long ticks;

        public Gcd(EuclidMethod method)
        {
            this.configuredMethod = method;
        }

        public long gcd(long nominator, long denominator)
        {
            this.reset();
            long gcd;

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            switch (this.configuredMethod)
            {
                case EuclidMethod.MODULO:
                    gcd = gcdModulo(nominator, denominator);
                    break;
                case EuclidMethod.SUBTRACTION:
                    gcd = gcdSubtraction(nominator, denominator);
                    break;
                case EuclidMethod.RECURSIVE:
                    gcd = gcdRecursive(nominator, denominator);
                    break;
                case EuclidMethod.PRIME_FACTORIZATION:
                    gcd = gcdPrimeFactorization(nominator, denominator);
                    break;
                default:
                    throw new InvalidOperationException("The given configured method " + this.configuredMethod + " is not supported.");
            }
            stopWatch.Stop();
            this.time = stopWatch.ElapsedMilliseconds;
            this.ticks = stopWatch.ElapsedTicks;
            stopWatch.Reset();

            return gcd;
        }


        protected void reset() 
        {
            this.counter = 0;
            this.time = 0;
            this.ticks = 0;
        }

        public int getCount()
        {
            return this.counter;
        }

        public long getTime()
        {
            return this.time;
        }

        public long getTicks()
        {
            return this.ticks;
        }

        public long gcdRecursive(long nominator, long denominator)
        {
            this.counter++;
            return (denominator != 0) ? gcdRecursive(denominator, nominator % denominator) : nominator;
        }

        public long gcdModulo(long nominator, long denominator)
        {
            long a = nominator;
            long b = denominator;

            while (b != 0)
            {
                this.counter++;
                long t = b;
                b = a % b;
                a = t;
            }

            return a;
        }

        public long gcdSubtraction(long nominator, long denominator)
        {
            long a = nominator;
            long b = denominator;

            if (a == 0)
            {
                return b;
            }

            while (b != 0)
            {
                this.counter++;
                if (a > b)
                {
                    a = a - b;
                }
                else
                {
                    b = b - a;
                }
            }

            return a;
        }

        public long gcdPrimeFactorization(long nominator, long denominator)
        {
            long a = nominator;
            long b = denominator;

            long[] primeFactorsA = ExtendedMath.calculatePrimeFactors(a);
            this.counter += ExtendedMath.getLatestCount();
            List<long> primeFactorsB = ExtendedMath.calculatePrimeFactorsList(b);
            this.counter += ExtendedMath.getLatestCount();

            long gcd = 1;
            for (int i = 0; i < primeFactorsA.Length; i++)
            {
                this.counter++;
                for (int j = 0; j < primeFactorsB.Count; j++)
                {
                    this.counter++;
                    if (primeFactorsA[i] == primeFactorsB[j])
                    {
                        gcd = gcd * primeFactorsA[i];

                        // remove processed prime factor from B
                        primeFactorsB.Remove(primeFactorsA[i]);
                        break;
                    }
                }
            }

            return gcd;
        }
    }
}
