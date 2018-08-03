using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        [TestInitialize()]
        public void Test_Init()
        {

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
        public void Gcd_invTest()
        {
            RSAKit kit = new RSAKit();
            kit.E = BigInteger.Parse("7");
            kit.P = BigInteger.Parse("17");
            kit.Q = BigInteger.Parse("11");
            Assert.AreEqual("23", kit.Gcd_inv().ToString());
        }
    }
}