using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;
using RSA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA.Tests
{
    [TestClass()]
    public class RSAKitTests
    {
        RSAKit kit;
        [TestInitialize()]
        public void Test_Init()
        {
            kit = new RSAKit();
        }

        [TestMethod()]
        public void GenerateKeysTest()
        {
            var keySet = kit.GenerateKeys();

            Assert.IsTrue(kit.E > 10000);
            Assert.IsTrue(kit.P > 10000);
            Assert.IsTrue(kit.Q > 10000);
        }

        [TestMethod()]
        public void Create_nTest()
        {
            kit.P = 3;
            kit.Q = 5;

            Assert.AreEqual(15, kit.Create_n());
        }

        [TestMethod()]
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
        }

        [TestMethod()]
        public void Gcd_invTest()
        {
            BigInteger expected = new BigInteger(23);
            kit.E = BigInteger.Parse("7");
            kit.P = BigInteger.Parse("17");
            kit.Q = BigInteger.Parse("11");
            BigInteger result = kit.Gcd_inv();
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void Gcd_inv_RTest()
        {
            BigInteger expected = new BigInteger(23);
            kit.E = 7;
            kit.P = 17;
            kit.Q = 11;
            kit.N = kit.Create_n();
            BigInteger result = kit.Gcd_inv_R();
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void PhiTestA()
        {
            BigInteger expected = new BigInteger(12);
            kit.P = 4;
            kit.Q = 5;

            Assert.AreEqual(expected, kit.Phi());
        }

        [TestMethod()]
        public void PhiTestB()
        {
            BigInteger expected = new BigInteger(60);
            kit.P = 7;
            kit.Q = 11;

            Assert.AreEqual(expected, kit.Phi());
        }

        [TestMethod()]
        public void Create_nTestA()
        {
            BigInteger expected = new BigInteger(77);
            kit.P = 7;
            kit.Q = 11;

            Assert.AreEqual(expected, kit.Create_n());
        }

        [TestMethod()]
        public void Create_nTestB()
        {
            BigInteger expected = new BigInteger(35);
            kit.P = 7;
            kit.Q = 5;

            Assert.AreEqual(expected, kit.Create_n());
        }

        [TestMethod()]
        public void GcdTest()
        {
            BigInteger expected = new BigInteger(1);
            kit.E = BigInteger.Parse("7");
            kit.P = BigInteger.Parse("17");
            kit.Q = BigInteger.Parse("11");
            BigInteger result = kit.Gcd();
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void EncryptTest()
        {
            BigInteger expected = new BigInteger(128);
            BigInteger input = new BigInteger(2);
            kit.E = BigInteger.Parse("7");
            kit.P = BigInteger.Parse("17");
            kit.Q = BigInteger.Parse("11");
            kit.N = kit.Create_n();
            BigInteger result = kit.Encrypt(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void DecryptTest()
        {
            BigInteger expected = new BigInteger(2);
            BigInteger input = new BigInteger(128);
            kit.E = BigInteger.Parse("7");
            kit.P = BigInteger.Parse("17");
            kit.Q = BigInteger.Parse("11");
            kit.N = kit.Create_n();
            kit.D = kit.Gcd_inv_R();
            BigInteger result = kit.Decrypt(input);
            Assert.AreEqual(expected, result);
        }
    }
}