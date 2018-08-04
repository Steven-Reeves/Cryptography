using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace RSA
{
    public class RSAKit
    {
        public BigInteger P = new BigInteger(0), Q = new BigInteger(0), E = new BigInteger(0), D = new BigInteger(0), N = new BigInteger(0);
        List<string> _integerList = new List<string>();
        private Random random = new Random();

        public RSAKit()
        {
            _integerList = GetPrimesFromFile("\\primes.txt");
        }
        public List<string> GetPrimesFromFile(string filename)
        {
            var inFile = Directory.GetCurrentDirectory() + filename;
            var logFile = File.ReadAllText(inFile);

            var punctuation = logFile.Where(Char.IsPunctuation).Distinct().ToArray();   //parsing pulled from stackoverflow,
            var primes = logFile.Split().Select(x => x.Trim(punctuation));              //SUPER COOL
            primes = primes.Where(x => x.Count() > 0);
            List<string> returnedPrimes = new List<string>(primes);

            return returnedPrimes;
        }

        public void GeneratePQ()
        {
            List<int> randomIndexes = new List<int>();
            
            int temp = random.Next(_integerList.Count);

            for (int i = 0; i < 2; i++)
            {
                while (randomIndexes.Contains(temp) || BigInteger.Parse(_integerList[temp]) < BigInteger.Parse("40000"))
                    temp = random.Next(_integerList.Count);

                randomIndexes.Add(temp);
            }

            P = BigInteger.Parse(_integerList[randomIndexes[0]]);
            Q = BigInteger.Parse(_integerList[randomIndexes[1]]);
        }

        public void GenerateKeys()
        {
            GeneratePQ();
            Create_e();
            N = Create_n();
            D = Gcd_inv_R();
        }

        public void Create_e()
        {
            int rand = random.Next(_integerList.Count);
            BigInteger temp = BigInteger.Parse(_integerList[rand]);

            while (temp == P || temp == Q || temp > Phi() || temp < BigInteger.Parse("10000"))
            {
                rand = random.Next(_integerList.Count);
                temp = BigInteger.Parse(_integerList[rand]);
            }

            E = temp;
        }

        public BigInteger Create_n()
        {
            return P * Q;
        }

        public BigInteger Phi()
        {
            return (P-1) * (Q-1);
        }

        public BigInteger Gcd()
        {            
            return BigInteger.GreatestCommonDivisor(E, Phi());
        }

        public BigInteger Gcd_inv()
        {
            // GCD inverse is just inverse modulus
            BigInteger i = Phi(), v = 0, d = 1, a = E;
            while (a > 0)
            {
                BigInteger t = i / a, x = a;
                a = i % x;
                i = x;
                x = d;
                d = v - t * x;
                v = x;
            }
            v %= Phi();

            if (v < 0)
                v = (v + Phi()) % Phi();

            return v;
        }

        public BigInteger Gcd_inv_R()
        {
            int k = 1;
            BigInteger n = Create_n();

            while (BigInteger.Pow(E, k) % n != 1)
                k++;

            BigInteger d = BigInteger.Pow(E, k - 1) % n;

            return d;
        }

        public BigInteger Encrypt(BigInteger input)
        {
            return Big_mod(input, E, N);
        }

        public BigInteger Decrypt(BigInteger input)
        {
            return Big_mod(input, D, N);
        }

        public BigInteger Big_mod(BigInteger mod_base, BigInteger mod_exp, BigInteger mod_num)
        {
            BigInteger carry = 1;

            for(BigInteger i = 0; i < mod_exp; i++)
            {
                carry = (carry * mod_base) % mod_num;
            }

            return carry;           
        }
    }
}
