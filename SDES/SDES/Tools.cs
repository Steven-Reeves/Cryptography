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
        // - Follow Algorithm 

        // Sboxes             ------> Steven

        // function K          ------> Randall 

        // Decrypt              ------> Randall
        // - Follow Algorithm 


    }
}
