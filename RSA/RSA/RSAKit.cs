using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace RSA
{
    public class RSAKit
    {
        int P = 0, Q = 0, E = 0;

        public void GenerateKeys()
        {
            // Generate all keys here

        }

        public int Create_e()
        {
            // Generate e here
            return 0;
        }

        public int Create_n()
        {
            // Generate n here
            return P * Q;
        }

        public int Phi()
        {
            // Generate n here
            return (P-1) * (Q-1);
        }

        public int Gcd()
        {
            // Generate gcd here
            return 0;
        }

        public int Gcd_inv()
        {
            // Generate gcd^-1 here
            return 0;
        }

        public int Encrypt(int input)
        {
            return 0;
        }

        public int Decrypt(int input)
        {
            return 0;
        }

        private int Big_mod(int mod_base, int mod_exp, int mod_num)
        {
            // Cool mod logic
            return 0;
            // Dammit Phong! We're still doing it (maybe)
        }

    }
}
