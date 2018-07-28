using System.Collections;

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


        // Todo: BitArrayToString ----> First come first serve

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

            for (int i = 2; i < 10; i++)
            {
                output[p8Scramble[i - 2]] = input[i];
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

        // Sboxes             ------> Steven
        public BitArray SBoxes(BitArray input, char[,] matrix)
        {
            //  first, fourth  and second and third pairs...
            bool[] firstHalfBool = new bool[] { input[0], input[4] };
            BitArray firstHalf = new BitArray(firstHalfBool);
            bool[] secondHalfBool = new bool[] { input[2], input[3] };
            BitArray secondHalf = new BitArray(secondHalfBool);

            int[] rowColumn = new int[2];
            firstHalf.CopyTo(rowColumn, 0);
            secondHalf.CopyTo(rowColumn, 1);

            int result = (int)char.GetNumericValue(matrix[rowColumn[0], rowColumn[1]]);

            return new BitArray(new[] { result });
        }



        // function K          ------> Randall 

        // Decrypt              ------> Randall
        // - Follow Algorithm 


    }
}
