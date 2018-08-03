using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;
using RSA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace RSA.Tests
{
    [TestClass()]
    public class RSAKitTests
    {
        RSAKit kit;
        [TestInitialize()]
        public void Test_Init()
        {
<<<<<<< HEAD
            kit = new RSAKit();
=======

>>>>>>> 112f7bcb1af96a291fd3d614031110dc82b5b378
        }

        [TestMethod()]
        public void GenerateKeysTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void Create_nTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
<<<<<<< HEAD
        public void Big_modTestA()
        {
            BigInteger testInt = kit.Big_mod(3, 4, 4);
            BigInteger expected = 1;

            Assert.AreEqual(expected, testInt);
        }

        [TestMethod()]
        public void Big_modTestB()
        {
            BigInteger testInt = kit.Big_mod(5, 4, 15);
            BigInteger expected = 10;

            Assert.AreEqual(expected, testInt);
=======
        public void Gcd_invTest()
        {
            RSAKit kit = new RSAKit();
            kit.E = BigInteger.Parse("7");
            kit.P = BigInteger.Parse("17");
            kit.Q = BigInteger.Parse("11");
            Assert.AreEqual("23", kit.Gcd_inv().ToString());
>>>>>>> 112f7bcb1af96a291fd3d614031110dc82b5b378
        }
    }
}