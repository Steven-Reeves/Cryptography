using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayfairCryptanalysis
{
    class AnnealingAlgorithm
    {
        string cipherKey = "";
        Random rand;
        AnnealingAlgorithm(string key)
        {
            cipherKey = key;
            rand = new Random();
        }

        string RandomSwap(string key)
        {
            var newKey = key.ToCharArray();
            var index1 = rand.Next(24);
            var index2 = index1;
            while (index2 == index1)
            {
                index2 = rand.Next(24);
            }

            var temp = newKey[index1];
            newKey[index1] = newKey[index2];
            newKey[index2] = temp;

            return newKey.ToString();
        }
    }
}
