using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace SDES.Tests
{
    [TestClass()]
    public class ToolsKeyGenTests
    {
        Tools testTools;
        BitArray inputArray;
        BitArray outputArray;

        [TestInitialize()]
        public void TestInit()
        {
            testTools = new Tools();
            inputArray = new BitArray(10);
            outputArray = new BitArray(10);
        }

        [TestMethod()]
        public void PermuteTenTestA()
        {
            inputArray.Set(0, true);
            inputArray.Set(1, false);
            inputArray.Set(2, true);
            inputArray.Set(3, false);
            inputArray.Set(4, true);
            inputArray.Set(5, false);
            inputArray.Set(6, true);
            inputArray.Set(7, false);
            inputArray.Set(8, true);
            inputArray.Set(9, false);

            outputArray = testTools.PermuteTen(inputArray);

            Assert.AreEqual(true, outputArray[0]);
            Assert.AreEqual(true, outputArray[1]);
            Assert.AreEqual(false, outputArray[2]);
            Assert.AreEqual(true, outputArray[3]);
            Assert.AreEqual(false, outputArray[4]);
            Assert.AreEqual(false, outputArray[5]);
            Assert.AreEqual(true, outputArray[6]);
            Assert.AreEqual(true, outputArray[7]);
            Assert.AreEqual(false, outputArray[8]);
            Assert.AreEqual(false, outputArray[9]);
        }

        [TestMethod()]
        public void PermuteTenTestB()
        {
            inputArray.Set(0, true);
            inputArray.Set(1, true);
            inputArray.Set(2, true);
            inputArray.Set(3, true);
            inputArray.Set(4, true);
            inputArray.Set(5, false);
            inputArray.Set(6, false);
            inputArray.Set(7, false);
            inputArray.Set(8, false);
            inputArray.Set(9, false);

            outputArray = testTools.PermuteTen(inputArray);

            Assert.AreEqual(true, outputArray[0]);
            Assert.AreEqual(true, outputArray[1]);
            Assert.AreEqual(true, outputArray[2]);
            Assert.AreEqual(false, outputArray[3]);
            Assert.AreEqual(true, outputArray[4]);
            Assert.AreEqual(false, outputArray[5]);
            Assert.AreEqual(true, outputArray[6]);
            Assert.AreEqual(false, outputArray[7]);
            Assert.AreEqual(false, outputArray[8]);
            Assert.AreEqual(false, outputArray[9]);
        }

        [TestMethod()]
        public void PermuteEightTestA()
        {
            inputArray.Set(0, true);
            inputArray.Set(1, true);
            inputArray.Set(2, false);
            inputArray.Set(3, true);
            inputArray.Set(4, true);
            inputArray.Set(5, true);
            inputArray.Set(6, false);
            inputArray.Set(7, false);
            inputArray.Set(8, false);
            inputArray.Set(9, false);

            outputArray = testTools.PermuteEight(inputArray);

            Assert.AreEqual(true, outputArray[0]);
            Assert.AreEqual(false, outputArray[1]);
            Assert.AreEqual(false, outputArray[2]);
            Assert.AreEqual(true, outputArray[3]);
            Assert.AreEqual(false, outputArray[4]);
            Assert.AreEqual(true, outputArray[5]);
            Assert.AreEqual(false, outputArray[6]);
            Assert.AreEqual(false, outputArray[7]);
        }

        [TestMethod()]
        public void PermuteEightTestB()
        {
            inputArray.Set(0, true);
            inputArray.Set(1, false);
            inputArray.Set(2, true);
            inputArray.Set(3, false);
            inputArray.Set(4, true);
            inputArray.Set(5, true);
            inputArray.Set(6, true);
            inputArray.Set(7, false);
            inputArray.Set(8, false);
            inputArray.Set(9, false);

            outputArray = testTools.PermuteEight(inputArray);

            Assert.AreEqual(true, outputArray[0]);
            Assert.AreEqual(true, outputArray[1]);
            Assert.AreEqual(true, outputArray[2]);
            Assert.AreEqual(false, outputArray[3]);
            Assert.AreEqual(false, outputArray[4]);
            Assert.AreEqual(true, outputArray[5]);
            Assert.AreEqual(false, outputArray[6]);
            Assert.AreEqual(false, outputArray[7]);
        }

        [TestMethod()]
        public void ShiftOneTestA()
        {
            inputArray = new BitArray(5);
            inputArray.Set(0, true);
            inputArray.Set(1, false);
            inputArray.Set(2, true);
            inputArray.Set(3, false);
            inputArray.Set(4, false);

            outputArray = testTools.Shift(inputArray, 1);

            Assert.AreEqual(false, outputArray[0]);
            Assert.AreEqual(true, outputArray[1]);
            Assert.AreEqual(false, outputArray[2]);
            Assert.AreEqual(true, outputArray[3]);
            Assert.AreEqual(false, outputArray[4]);
        }

        [TestMethod()]
        public void ShiftOneTestB()
        {
            inputArray = new BitArray(5);
            inputArray.Set(0, true);
            inputArray.Set(1, false);
            inputArray.Set(2, true);
            inputArray.Set(3, false);
            inputArray.Set(4, false);

            outputArray = testTools.Shift(inputArray, 2);

            Assert.AreEqual(false, outputArray[0]);
            Assert.AreEqual(false, outputArray[1]);
            Assert.AreEqual(true, outputArray[2]);
            Assert.AreEqual(false, outputArray[3]);
            Assert.AreEqual(true, outputArray[4]);
        }
    }
}