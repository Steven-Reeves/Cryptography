﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        [TestMethod()]
        public void Gcd_invTest()
        {
            RSAKit kit = new RSAKit();
            kit.E = BigInteger.Parse("7");
            kit.P = BigInteger.Parse("17");
            kit.Q = BigInteger.Parse("11");
            Assert.AreEqual("23", kit.Gcd_inv().ToString());
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
    }
}