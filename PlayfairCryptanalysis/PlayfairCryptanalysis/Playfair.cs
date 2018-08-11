using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayfairCryptanalysis
{
    public class Playfair
    {
        const int ALPHABET_LENGTH = 25;
        public char[] playfairArray;
        const int A = 65;       //ASCII values of letters
        const int J = 74;
        const int Z = 90;


        public Playfair(string key)
        {
            this.playfairArray = CreatePlayfairArray(key);
        }

        public static char[] CreatePlayfairArray(string key)
        {
            // NOTE: This assumes input of only letters.

            char[] input = key.ToUpper().ToCharArray();
            char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            char[] result = new char[ALPHABET_LENGTH];
            bool[] isUsed = new bool[ALPHABET_LENGTH];

            int index = 0;
            for (int i = 0; i < input.Length; i++)
            {
                int charValue = (int)input[i];
                // Replace J's with I's
                if (charValue >= J)
                    charValue--;
                // If not used, put in front of result and mark as used
                if(!isUsed[charValue - A])
                {
                    isUsed[charValue - A] = true;
                    result[index++] = input[i];
                }
            }

            if(index < ALPHABET_LENGTH)
            {
                for (int i = 0; i < ALPHABET_LENGTH; i++)
                {
                    if(!isUsed[i])
                    {
                        result[index++] = alphabet[i];
                    }

                }
            }

            return result;
        }

        public int[] SearchArray (char c, char[] array)
        {
            //Row
            for (int i = 0; i < 5; i++)
            {
                //Column
                for (int j = 0; j < 5; j++)
                {
                    if (array[(i * 5) + j] == c)
                        return new int[] { i, j };
                }
            }
            return null;
        }

    }
}
