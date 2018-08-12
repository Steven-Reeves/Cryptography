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

        public string Encrypt(string plaintext)
        {
            char[] input = CleanString(plaintext, true);
            StringBuilder result = new StringBuilder(input.Length);
            int[] bufferPos = new int[2];
            int[] pos = new int[2];

            for (int i = 0; i < input.Length; i++)
            {
                if((i & 1) ==0)
                {
                    bufferPos = SearchArray(input[i], playfairArray);
                    continue;
                }
                pos = SearchArray(input[i], playfairArray);

                if(bufferPos[0] == pos[0])
                {
                    //Same row!
                    bufferPos[1]++;
                    bufferPos[1] -= ((bufferPos[1] * 7) >> 5) * 5;
                    pos[1]++;
                    pos[1] -= ((pos[1] * 7) >> 5) * 5;

                    if (bufferPos[1] == pos[1])
                    {
                        //Same letters!
                        bufferPos[0]++;
                        bufferPos[0] -= ((bufferPos[0] * 7) >> 5) * 5;
                        pos[0]++;
                        pos[0] -= ((pos[0] * 7) >> 5) * 5;
                        result.Append(playfairArray[(bufferPos[0] * 5) + bufferPos[1]]);
                        result.Append(playfairArray[(pos[0] * 5) + pos[1]]);
                        continue;
                    }
                }
                else if (bufferPos[1] == pos[1])
                {
                    // Same column!
                    bufferPos[0]++;
                    bufferPos[0] -= ((bufferPos[0] * 7) >> 5) * 5;
                    pos[0]++;
                    pos[0] -= ((pos[0] * 7) >> 5) * 5;
                }
                else
                {
                    // Anything else
                    int buffer = bufferPos[1];
                    bufferPos[1] = pos[1];
                    pos[1] = buffer;
                }
                result.Append(playfairArray[(bufferPos[0] * 5) + bufferPos[1]]);
                result.Append(playfairArray[(pos[0] * 5) + pos[1]]);
            }
            return result.ToString();
        }

        private static char[] CleanString(string text, bool forCipher = false)
        {
            char[] input = text.ToUpper().ToCharArray();
            List<char> result = new List<char>(input.Length);
            int pointer = -1;
            for (int i = 0; i < input.Length; i++)
            {
                pointer++;
                // We will remove all other characters
                if ((int)input[i] < A || (int)input[i] > Z)
                {
                    pointer--;
                    continue;
                }
                if (forCipher && pointer > 0 && result[pointer - 1] == input[i])
                {
                    result.Add('X');
                }
                result.Add(input[i]);
            }
            if (forCipher && (result.Count & 1) == 1)
            {
                result.Add('X');
            }
            return result.ToArray();
        }

        public string Decrypt(string ciphertext, string key)
        {
            this.playfairArray = CreatePlayfairArray(key);          
            string result = Decrypt(ciphertext);
            return result;
        }

            public string Decrypt(string ciphertext)
        {
            char[] input = CleanString(ciphertext);
            StringBuilder result = new StringBuilder(input.Length);

            int[] bufferPos = new int[2];
            int[] pos = new int[2];
            for (int i = 0; i < input.Length; i++)
            {
                if ((i & 1) == 0)
                {
                    bufferPos = SearchArray(input[i], playfairArray);
                    continue;
                }
                pos = SearchArray(input[i], playfairArray);
                if (bufferPos[0] == pos[0])
                {
                    // Same row!
                    bufferPos[1] += 9;
                    bufferPos[1] -= ((bufferPos[1] * 7) >> 5) * 5;
                    pos[1] += 9;
                    pos[1] -= ((pos[1] * 7) >> 5) * 5;

                    if (bufferPos[1] == pos[1])
                    {
                        // Last letters are identical... (possible for XX)
                        bufferPos[0] += 9;
                        bufferPos[0] -= ((bufferPos[0] * 7) >> 5) * 5;
                        pos[0] += 9;
                        pos[0] -= ((pos[0] * 7) >> 5) * 5;
                        result.Append(playfairArray[(bufferPos[0] * 5) + bufferPos[1]]);
                        result.Append(playfairArray[(pos[0] * 5) + pos[1]]);
                        continue;
                    }
                }
                else if (bufferPos[1] == pos[1])
                {
                    // Same column!
                    bufferPos[0] += 9;
                    bufferPos[0] -= ((bufferPos[0] * 7) >> 5) * 5;
                    pos[0] += 9;
                    pos[0] -= ((pos[0] * 7) >> 5) * 5;
                }
                else
                {
                    // Anything else!
                    int buffer = bufferPos[1];
                    bufferPos[1] = pos[1];
                    pos[1] = buffer;
                }
                result.Append(playfairArray[(bufferPos[0] * 5) + bufferPos[1]]);
                result.Append(playfairArray[(pos[0] * 5) + pos[1]]);
            }
            return result.ToString();
        }
    }
}
