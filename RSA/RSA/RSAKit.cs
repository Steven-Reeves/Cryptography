using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace RSA
{
    public class RSAKit
    {
        public BigInteger P = new BigInteger(0), Q = new BigInteger(0), E = new BigInteger(0);
        List<string> _integerList = new List<string>();

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
            List<string> returnedPrimes = new List<string>(primes);

            return returnedPrimes;
        }

        public void GeneratePQ()
        {
            List<int> randomIndexes = new List<int>();

            Random rand = new Random();
            int temp = rand.Next(_integerList.Count);

            for (int i = 0; i < 2; i++)
            {
                while (randomIndexes.Contains(temp) || BigInteger.Parse(_integerList[randomIndexes[temp]]) < BigInteger.Parse("40000"))
                    temp = rand.Next(_integerList.Count);

                randomIndexes.Add(temp);
            }

            P = BigInteger.Parse(_integerList[randomIndexes[0]]);
            Q = BigInteger.Parse(_integerList[randomIndexes[1]]);
        }

        public void GenerateKeys()
        {
            GeneratePQ();
            Create_e();

        }

        public BigInteger Create_e()
        {
            BigInteger E;

            Random random = new Random();
            int rand = random.Next(_integerList.Count);
            BigInteger temp = BigInteger.Parse(_integerList[rand]);

            while (temp == P || temp == Q || temp > Phi() || temp < BigInteger.Parse("10000"))
            {
                rand = random.Next(_integerList.Count);
                temp = BigInteger.Parse(_integerList[rand]);
            }

            E = temp;

            return E;
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
            // Generate gcd here
            return 0;
        }

        public BigInteger Gcd_inv()
        {
            // Generate gcd^-1 here
            // This is broken!
            return BigInteger.ModPow(E, Phi(), Create_n());
        }

        public BigInteger Encrypt(BigInteger input)
        {
            return 0;
        }

        public BigInteger Decrypt(BigInteger input)
        {
            return 0;
        }

        public BigInteger Big_mod(BigInteger mod_base, BigInteger mod_exp, BigInteger mod_num)
        {
            BigInteger carry = 1;

            for(BigInteger i = 0; i < mod_exp; i++)
            {
                carry = (carry * mod_base) % mod_num;
            }

            return carry;
            // Dammit Phong! We're still doing it (maybe)
        }
    }
}
