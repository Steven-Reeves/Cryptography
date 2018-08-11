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

    }
}