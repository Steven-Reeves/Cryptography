using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SDES
{
    public class Tools
    {
        public void GenerateKeys(BitArray input)
        {
            var output = new BitArray(10); //TODO: Should be a BitArray pair
            
        }
        // generateKeys (bitArray input)

        public BitArray PermuteTen(BitArray input)
        {
            int[] p10Scramble = { 6, 2, 0, 4, 1, 9, 3, 8, 7, 5 };
            BitArray output = new BitArray(10);

            for(int i = 0; i < 10; i++)
            {
                output[p10Scramble[i]] = input[i];
            }

            return output;
        }
        // Permute10 <--

        public BitArray Shift(BitArray input, int shiftCount)
        {
            int count = input.Count;
            BitArray output = new BitArray(count);

            for(int i = 0; i < count; i++)
            {
                output[(i + shiftCount) % count] = input[i];
            }

            return output;
        }
        // Shift (bitarray input, int shiftCount)

        public BitArray PermuteEight(BitArray input)
        {
            int[] p8Scramble = { 1, 3, 5, 0, 2, 4, 7, 6 };
            BitArray output = new BitArray(8);

            for (int i = 2; i < 10; i++)
            {
                output[p8Scramble[i-2]] = input[i];
            }

            return output;
        }
        // Permute 8

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

            for(int i = midway; i < input.Count; i++)
            {
                splitArrays.secondItem[i - midway] = input[i];
            }

            return splitArrays;
        }
        // split

        public BitArray JoinBitArrays(BitArrayPair input)
        {
            BitArray output = new BitArray(input.firstItem.Count + input.secondItem.Count);

            for(int i = 0; i < input.firstItem.Count; i++)
            {
                output[i] = input.firstItem[i];
            }

            for(int i = 0; i < input.secondItem.Count; i++)
            {
                output[i + input.firstItem.Count] = input.secondItem[i];
            }

            return output;
        }
        // join


    }
}
