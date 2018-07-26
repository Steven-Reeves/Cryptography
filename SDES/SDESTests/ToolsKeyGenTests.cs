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
        public void ShiftTwoTestA()
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

        [TestMethod()]
        public void ShiftNegativeTestA()
        {
            inputArray = new BitArray(5);
            inputArray.Set(0, true);
            inputArray.Set(1, false);
            inputArray.Set(2, true);
            inputArray.Set(3, false);
            inputArray.Set(4, false);

            outputArray = testTools.Shift(inputArray, -1);

            Assert.AreEqual(false, outputArray[0]);
            Assert.AreEqual(true, outputArray[1]);
            Assert.AreEqual(false, outputArray[2]);
            Assert.AreEqual(false, outputArray[3]);
            Assert.AreEqual(true, outputArray[4]);
        }

        [TestMethod()]
        public void SplitTest()
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

            var splitArray = testTools.SplitBitArray(inputArray);

            Assert.AreEqual(true, splitArray.firstItem[0]);
            Assert.AreEqual(true, splitArray.firstItem[1]);
            Assert.AreEqual(true, splitArray.firstItem[2]);
            Assert.AreEqual(true, splitArray.firstItem[3]);
            Assert.AreEqual(true, splitArray.firstItem[4]);

            Assert.AreEqual(false, splitArray.secondItem[0]);
            Assert.AreEqual(false, splitArray.secondItem[1]);
            Assert.AreEqual(false, splitArray.secondItem[2]);
            Assert.AreEqual(false, splitArray.secondItem[3]);
            Assert.AreEqual(false, splitArray.secondItem[4]);
        }

        [TestMethod()]
        public void JoinTest()
        {
            var splitArrays = new BitArrayPair();
            splitArrays.firstItem = new BitArray(5);
            splitArrays.secondItem = new BitArray(5);

            splitArrays.firstItem.Set(0, true);
            splitArrays.firstItem.Set(1, true);
            splitArrays.firstItem.Set(2, true);
            splitArrays.firstItem.Set(3, true);
            splitArrays.firstItem.Set(4, true);

            splitArrays.secondItem.Set(0, false);
            splitArrays.secondItem.Set(1, false);
            splitArrays.secondItem.Set(2, false);
            splitArrays.secondItem.Set(3, false);
            splitArrays.secondItem.Set(4, false);

            var joinedArray = testTools.JoinBitArrays(splitArrays);

            Assert.AreEqual(true, joinedArray[0]);
            Assert.AreEqual(true, joinedArray[1]);
            Assert.AreEqual(true, joinedArray[2]);
            Assert.AreEqual(true, joinedArray[3]);
            Assert.AreEqual(true, joinedArray[4]);
            Assert.AreEqual(false, joinedArray[5]);
            Assert.AreEqual(false, joinedArray[6]);
            Assert.AreEqual(false, joinedArray[7]);
            Assert.AreEqual(false, joinedArray[8]);
            Assert.AreEqual(false, joinedArray[9]);
        }

        [TestMethod()]
        public void GenerateKeysTestA()
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

            var keys = testTools.GenerateKeys(inputArray);

            Assert.AreEqual(true, keys.firstItem[0]);
            Assert.AreEqual(true, keys.firstItem[1]);
            Assert.AreEqual(true, keys.firstItem[2]);
            Assert.AreEqual(false, keys.firstItem[3]);
            Assert.AreEqual(false, keys.firstItem[4]);
            Assert.AreEqual(true, keys.firstItem[5]);
            Assert.AreEqual(false, keys.firstItem[6]);
            Assert.AreEqual(false, keys.firstItem[7]);

            Assert.AreEqual(false, keys.secondItem[0]);
            Assert.AreEqual(true, keys.secondItem[1]);
            Assert.AreEqual(false, keys.secondItem[2]);
            Assert.AreEqual(true, keys.secondItem[3]);
            Assert.AreEqual(false, keys.secondItem[4]);
            Assert.AreEqual(false, keys.secondItem[5]);
            Assert.AreEqual(true, keys.secondItem[6]);
            Assert.AreEqual(true, keys.secondItem[7]);
        }

        [TestMethod()]
        public void GenerateKeysTestB()
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

            var keys = testTools.GenerateKeys(inputArray);

            Assert.AreEqual(true, keys.firstItem[0]);
            Assert.AreEqual(false, keys.firstItem[1]);
            Assert.AreEqual(false, keys.firstItem[2]);
            Assert.AreEqual(true, keys.firstItem[3]);
            Assert.AreEqual(false, keys.firstItem[4]);
            Assert.AreEqual(true, keys.firstItem[5]);
            Assert.AreEqual(false, keys.firstItem[6]);
            Assert.AreEqual(false, keys.firstItem[7]);

            Assert.AreEqual(false, keys.secondItem[0]);
            Assert.AreEqual(true, keys.secondItem[1]);
            Assert.AreEqual(false, keys.secondItem[2]);
            Assert.AreEqual(true, keys.secondItem[3]);
            Assert.AreEqual(false, keys.secondItem[4]);
            Assert.AreEqual(true, keys.secondItem[5]);
            Assert.AreEqual(false, keys.secondItem[6]);
            Assert.AreEqual(true, keys.secondItem[7]);
        }
    }
}