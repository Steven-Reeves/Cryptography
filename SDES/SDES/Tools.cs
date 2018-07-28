using System.Collections;
using System;

namespace SDES
{
    public class Tools
    {
        public BitArrayPair GenerateKeys(BitArray inputKey)
        {
            var keyPair = new BitArrayPair();
            keyPair.firstItem = new BitArray(8);
            keyPair.secondItem = new BitArray(8);

            var workingKey = PermuteTen(inputKey);

            var splitKey = SplitBitArray(workingKey);
            splitKey.firstItem = Shift(splitKey.firstItem, -1);
            splitKey.secondItem = Shift(splitKey.secondItem, -1);

            workingKey = JoinBitArrays(splitKey);

            workingKey = PermuteEight(workingKey); //Key 1
            keyPair.firstItem = workingKey;

            splitKey.firstItem = Shift(splitKey.firstItem, -2);
            splitKey.secondItem = Shift(splitKey.secondItem, -2);

            workingKey = JoinBitArrays(splitKey);

            workingKey = PermuteEight(workingKey); //Key 2
            keyPair.secondItem = workingKey;

            return keyPair;
        }

        public BitArray PermuteTen(BitArray input)
        {
            int[] p10Scramble = { 6, 2, 0, 4, 1, 9, 3, 8, 7, 5 };
            BitArray output = new BitArray(10);

            for (int i = 0; i < 10; i++)
            {
                output[p10Scramble[i]] = input[i];
            }

            return output;
        }

        public BitArray Shift(BitArray input, int shiftCount) //positive shifts right, negative shifts left
        {
            int count = input.Count;
            BitArray output = new BitArray(count);

            while (shiftCount < 0)
            {
                shiftCount += count;
            }

            for (int i = 0; i < count; i++)
            {
                output[(i + shiftCount) % count] = input[i];
            }

            return output;
        }

        public BitArray PermuteEight(BitArray input)
        {
            int[] p8Scramble = { 1, 3, 5, 0, 2, 4, 7, 6 };
            BitArray output = new BitArray(8);

            for (int i = 2; i < 10; i++)
            {
                output[p8Scramble[i - 2]] = input[i];
            }

            return output;
        }

        public BitArrayPair SplitBitArray(BitArray input)
        {
            BitArrayPair splitArrays = new BitArrayPair();
            int midway = input.Count / 2;
            splitArrays.firstItem = new BitArray(midway);
            splitArrays.secondItem = new BitArray(midway);

            for (int i = 0; i < midway; i++)
            {
                splitArrays.firstItem[i] = input[i];
            }

            for (int i = midway; i < input.Count; i++)
            {
                splitArrays.secondItem[i - midway] = input[i];
            }

            return splitArrays;
        }

        public BitArray JoinBitArrays(BitArrayPair input)
        {
            BitArray output = new BitArray(input.firstItem.Count + input.secondItem.Count);

            for (int i = 0; i < input.firstItem.Count; i++)
            {
                output[i] = input.firstItem[i];
            }

            for (int i = 0; i < input.secondItem.Count; i++)
            {
                output[i + input.firstItem.Count] = input.secondItem[i];
            }

            return output;
        }

        public string BitArrayToString(BitArray input)
        {
            string output = "";
            for(int i = 0; i < input.Count; i++)
            {
                if (input[i])
                    output += "1";
                else
                    output += "0";
            }

            return output;
        }

        public BitArray Encrypt(BitArray plainText, BitArray key)
        {
            BitArrayPair keyPair = GenerateKeys(key);

            BitArrayPair splitBitArray = SplitBitArray(PermuteEightEncrypt(plainText));             //do not overwrite this
            BitArray xorTemp = EncryptExpand(splitBitArray.secondItem).Xor(keyPair.firstItem);

            BitArrayPair splitXoredArray = SplitBitArray(xorTemp);
            BitArrayPair sBoxArrays = new BitArrayPair();

            sBoxArrays.firstItem = SBoxes(splitXoredArray.firstItem, new char[,] {      {'1', '0', '3', '2'},
                                                                                        {'3', '2', '1', '0'},
                                                                                        {'0', '2', '1', '3'},
                                                                                        {'3', '1', '3', '2'}});

            sBoxArrays.secondItem = SBoxes(splitXoredArray.secondItem, new char[,] {    {'0', '1', '2', '3'},
                                                                                        {'2', '0', '1', '3'},
                                                                                        {'3', '0', '1', '0'},
                                                                                        {'2', '1', '0', '3'}});

            BitArray temp = new BitArray(splitBitArray.firstItem);


            BitArray firstHalfOfEncrypt = temp.Xor(EncryptPermuteFour(JoinBitArrays(sBoxArrays)));

            xorTemp = EncryptExpand(firstHalfOfEncrypt).Xor(keyPair.secondItem);
            splitXoredArray = SplitBitArray(xorTemp);

            sBoxArrays.firstItem = SBoxes(splitXoredArray.firstItem, new char[,] {      {'1', '0', '3', '2'},
                                                                                        {'3', '2', '1', '0'},
                                                                                        {'0', '2', '1', '3'},
                                                                                        {'3', '1', '3', '2'}});

            sBoxArrays.secondItem = SBoxes(splitXoredArray.secondItem, new char[,] {    {'0', '1', '2', '3'},
                                                                                        {'2', '0', '1', '3'},
                                                                                        {'3', '0', '1', '0'},
                                                                                        {'2', '1', '0', '3'}});

            BitArray secondHalfOfEncrypt = splitBitArray.secondItem.Xor(EncryptPermuteFour(JoinBitArrays(sBoxArrays)));
            BitArrayPair bothHalves = new BitArrayPair();
            bothHalves.firstItem = secondHalfOfEncrypt;
            bothHalves.secondItem = firstHalfOfEncrypt;

            BitArray encryptedOutput = PermuteEightEncryptInverted(JoinBitArrays(bothHalves));

            return encryptedOutput;
        }

        // Encrypt              ------> Steven
        /*
        public BitArray Encrypt (BitArray plaintext, BitArray key1, BitArray key2)
        {
            // - Follow Algorithm 
            BitArray IP = PermuteEight(plaintext);          //Permute eight might be different for encryption?
            BitArrayPair Split_IP = SplitBitArray(IP);
            // FunctionK()                                   // Do we pass the whole pair?
            // Swap?
            // FunctionK()

            return ciphertext;
        }
        */

        public BitArray PermuteEightEncrypt(BitArray input)
        {
            int[] p8Scramble = { 3, 0, 2, 4, 6, 1, 7, 5 };
            BitArray output = new BitArray(8);

            for (int i = 0; i < 8; i++)
            {
                output[p8Scramble[i]] = input[i];
            }

            return output;
        }

        public BitArray PermuteEightEncryptInverted(BitArray input)
        {
            int[] p8Scramble = { 1, 5, 2, 0, 3, 7, 4, 6};
            BitArray output = new BitArray(8);

            for (int i = 0; i < 8; i++)
            {
                output[p8Scramble[i]] = input[i];
            }

            return output;
        }

        public BitArray EncryptExpand(BitArray input)
        {
            int[] p8EncryptScramble = { 3, 0, 1, 2, 1, 2, 3, 0 };
            BitArray output = new BitArray(8);

            for(int i = 0; i < 8; i++)
            {
                output[i] = input[p8EncryptScramble[i]];
            }

            return output;
        }

        public BitArray EncryptPermuteFour(BitArray input)
        {
            int[] p4EncryptScramble = { 3, 0, 2, 1 };
            BitArray output = new BitArray(4);

            for (int i = 0; i < 4; i++)
            {
                output[p4EncryptScramble[i]] = input[i];
            }

            return output;
        }

        public int BitArrayToInt(BitArray input)
        {
            int value = 0;
            int count = 0;
            for (int i = input.Count - 1; i >= 0; i--)
            {
                if (input[i])
                    value += Convert.ToInt16(Math.Pow(2, count));
                count++;
            }

            return value;
        }

        public BitArray BitArrayFromString(string input)
        {
            int i = 0;
            BitArray output = new BitArray(input.Length);

            foreach(char c in input)
            {
                if (c == '1')
                    output[i] = true;
                else
                    output[i] = false;

                i++;
            }

            return output;
        }

        public BitArray BitArrayFromInt(int input)
        {
            string intString = Convert.ToString(input, 2);
            if(intString.Length < 2)
            {
                intString = "0" + intString;
            }

            BitArray output = BitArrayFromString(intString);

            return output;
        }

        // Sboxes             ------> Steven
        public BitArray SBoxes(BitArray input, char[,] matrix)
        {
            //  first, fourth  and second and third pairs...
            bool[] firstHalfBool = new bool[] { input[0], input[3] };
            BitArray firstHalf = new BitArray(firstHalfBool);
            bool[] secondHalfBool = new bool[] { input[1], input[2] };
            BitArray secondHalf = new BitArray(secondHalfBool);

            int rowInt = BitArrayToInt(firstHalf);
            int columnInt = BitArrayToInt(secondHalf);
            //int[] rowColumn = new int[2];
            //string row = BitArrayToString(firstHalf);
            //int.TryParse(row, out rowInt);

            //string column = BitArrayToString(secondHalf);
            //int.TryParse(column, out columnInt);
            //firstHalf.CopyTo(rowColumn, 0);
            //secondHalf.CopyTo(rowColumn, 1);


            //int result = (int)char.GetNumericValue(matrix[rowColumn[0], rowColumn[1]]);
            int result = (int)char.GetNumericValue(matrix[rowInt, columnInt]);

            return BitArrayFromInt(result);
        }



        // function K          ------> Randall 

        // Decrypt              ------> Randall
        // - Follow Algorithm 


    }
}
