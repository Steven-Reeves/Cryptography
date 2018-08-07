using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace RSA
{
    public class KeySet
    {
        public BigInteger E, D, N;

        public KeySet(BigInteger e, BigInteger d, BigInteger n)
        {
            E = e;
            D = d;
            N = n;
        }
    }
}
