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
            // TODO: Check logic here. Big Keys aren't working for decrypt...
            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)(ch + (inKey % 26));
        }

        public string Encrypt(string input, int inKey)
        {
            string output = "";

            foreach(char c in input)
            {
                output += Cipher(c, inKey);
            }
           
            return output.ToUpper();
        }

        public string Decrypt(string input, int inKey)
        {
            // Just use Decrypt with a negative key!
            string output = Encrypt(input, 26 - inKey);

            return output.ToLower();
        }

    }
}
