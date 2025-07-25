﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    internal class Algorithm
    {
        // input
        public long Multiplier;
        public long Seed;
        public long Increment;
        public long Modulus;
        public long NumIteration;
        // output
        public long NumberCycle;
        public List<long> RandomNumber { get; set; }



        public Algorithm()
        {
            RandomNumber = new List<long>();
        }
        public bool isPowerOf2(long number) // 4 (100)&(011) = (000)
        {
            return (number & (number - 1)) == 0 && number != 0;
        }
        public int isPrime(long number)
        {
            int divisorCount = 0;
            long divisor = 1;

            while (divisor <= number)
            {
                if (number % divisor == 0)
                {
                    divisorCount++;
                }

                divisor++;
            }

            return divisorCount == 2 ? 1 : 0;
        }
        public void calculateNumberCycle(long ind)
        {

            if (ind != -1)
            {
                NumberCycle = ind;
                return;

            }

            long kValue = Modulus - 1;
            bool aval;

            if (isPowerOf2(Modulus) && Increment != 0)
            {
                aval = ((Multiplier - 1) % 4) == 0;
                if ((isPrime(Increment) == 1 || isPrime(Modulus) == 1) && aval)
                {
                    NumberCycle = Modulus;
                    return;
                }
            }
            if (isPowerOf2(Modulus) && Increment == 0)
            {
                aval = ((Multiplier - 5) % 8 == 0) || ((Multiplier - 3) % 8 == 0);
                if (Seed % 2 != 0 && aval)
                {
                    NumberCycle = Modulus / 4;
                    return;
                }
            }
            if (isPrime(Modulus) == 1 && Increment == 0)
            {
                if ((Math.Pow(Multiplier, kValue) - 1) % Modulus == 0)
                {
                    NumberCycle = Modulus - 1;
                    return;
                }
            }

            long initialRandom = RandomNumber[0];
            long cycleCount = NumIteration;
            long nextRandom = (Multiplier * RandomNumber[RandomNumber.Count - 1] + Increment) % Modulus;

            while (initialRandom != nextRandom)
            {
                nextRandom = (Multiplier * nextRandom + Increment) % Modulus;
                cycleCount++;
            }
            NumberCycle = cycleCount;

        }
        public void CreateRandom()
        {
            int i = 0;
            long nextRandom = Seed;
            RandomNumber.Add(nextRandom);
            long ind = -1;
            bool flag = false;
            while (i < (NumIteration - 1))
            {
                nextRandom = (Multiplier * nextRandom + Increment) % Modulus;
                RandomNumber.Add(nextRandom);
                if (RandomNumber[i] == RandomNumber[0] && !flag && i != 0)
                {
                    ind = i;
                    flag = true;
                }
                i++;
            }

            calculateNumberCycle(ind);
        }
    }
}
