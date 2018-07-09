using System;

namespace CaesarCipher
{
    public class Caesar
    {

        public Caesar()
        {
            // Just in case we need member variables
        }

        public string Encrypt(string input, int inKey)
        {
            // Encrypt input here
            return input + " :Encrypted with " + inKey;
        }

        public string Decrypt(string input, int inKey)
        {
            string output = Encrypt(input, (26 - inKey));
            // Decrypt input here
            return output;
        }

    }
}
