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
            Assert.Fail();
        }

        [TestMethod()]
        public void Create_nTest()
        {
            Assert.Fail();
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
    }
}