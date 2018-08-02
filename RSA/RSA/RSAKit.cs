using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Numerics;

namespace RSA
{
    public class RSAKit
    {
        BigInteger P = 0, Q = 0, E = 0;

        public void GenerateArbitraryKeys()
        {
            var inFile = Directory.GetCurrentDirectory() + "primes.txt";
            var logFile = File.ReadAllLines(inFile);
            var primeList = new List<string>(logFile);



        }

        public void GenerateKeys()
        {
            // Generate all keys here

        }

        public BigInteger Create_e()
        {
            // Generate e here
            return 0;
        }

        public BigInteger Create_n()
        {
            return P * Q;
        }

        public BigInteger Phi()
        {
            // Generate n here
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
            return 0;
        }

        public BigInteger Encrypt(BigInteger input)
        {
            return 0;
        }

        public BigInteger Decrypt(BigInteger input)
        {
            return 0;
        }

        private BigInteger Big_mod(BigInteger mod_base, BigInteger mod_exp, BigInteger mod_num)
        {
            // Cool mod logic
            return 0;
            // Dammit Phong! We're still doing it (maybe)
        }

    }
}
