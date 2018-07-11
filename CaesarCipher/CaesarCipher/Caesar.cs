using System;

namespace CaesarCipher
{
    public class Caesar
    {

        public Caesar()
        {
            // Just in case we need member variables
        }

        public char Cipher (char ch, int inKey)
        {
            // If not a letter, just return it.
            if(!char.IsLetter(ch))
            {
                return ch;
            }

            // Check for uppercase and use key to change.
            char offset = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + inKey) - offset) % 26) + offset);
        }

        public string Encrypt(string input, int inKey)
        {
            if (inKey < 0 || inKey > 26)
                inKey = NormalizeKey(inKey);

            string output = "";

            foreach(char c in input)
            {
                output += Cipher(c, inKey);
            }
           
            return output.ToUpper();
        }

        public string Decrypt(string input, int inKey)
        {
            if (inKey < 0 || inKey > 26)
                inKey = NormalizeKey(inKey);

            // Just use Decrypt with a negative key
            string output = Encrypt(input, 26 - inKey);

            return output.ToLower();
        }

        // Quick fix for key > 26 or key < 0 (Note: Key < 0 not working)
        public int NormalizeKey( int origKey)
        {
            int normKey = origKey;

            while (normKey < 0)
                normKey += 26;

            normKey %= 26;

            return normKey;
        }

    }
}
