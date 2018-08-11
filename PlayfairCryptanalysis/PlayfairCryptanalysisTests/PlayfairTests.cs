using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlayfairCryptanalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayfairCryptanalysis.Tests
{
    [TestClass()]
    public class PlayfairTests
    {
        Playfair playfair;
        [TestInitialize()]
        public void Test_Init()
        {
            playfair = new Playfair("keyword");
        }

        [TestMethod()]
        public void PlayfairTest()
        {
            playfair = new Playfair("keyword");
            string expected = "KEYWORDABCFGHILMNPQSTUVXZ";
            string result = new string(playfair.playfairArray);
            Assert.AreEqual(expected, result);
        }


        [TestMethod()]
        public void PlayfairTest2()
        {
            playfair = new Playfair("thisisaweirdkeyword");
            string expected = "THISAWERDKYOBCFGLMNPQUVXZ";
            string result = new string(playfair.playfairArray);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void SearchArrayTest()
        {
            char A = 'A';
            int[] result = playfair.SearchArray(A, playfair.playfairArray);
            int[] expected = new int[] { 1, 2 };
            Assert.AreEqual(expected[0], result[0]);
            Assert.AreEqual(expected[1], result[1]);
        }

        [TestMethod()]
        public void SearchArrayTest2()
        {
            char X = 'X';
            int[] result = playfair.SearchArray(X, playfair.playfairArray);
            int[] expected = new int[] { 4, 3 };
            Assert.AreEqual(expected[0], result[0]);
            Assert.AreEqual(expected[1], result[1]);
        }

        [TestMethod()]
        public void EncryptTest()
        {
            string expected = "SHBHMUWUUZ";
            string result = playfair.Encrypt("plaintext");
            Assert.AreEqual(expected, result);
        }
    }
}