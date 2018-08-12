using PlayfairCryptanalysis;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        AnnealingAlgorithm testAlgorithm = new AnnealingAlgorithm();

        [TestInitialize]
        public void TestInit()
        {

        }

        [TestMethod]
        public void TestMethod1()
        {
            var translation = testAlgorithm.GenericAnalysis("ZDNBYSXFPCNMDKEPGBPQPLHCPNTYKBTGSPKXEWVKRMRLMKNKTYUOPCKZITNPHZRYUGBSKMEBNMMVAVKNOFSWBMHNKHNXKOGBPLQEIGMY");

            File.WriteAllText("output.txt", translation[0] + "\n" + translation[1]);
        }
    }
}
