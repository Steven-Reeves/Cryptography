using System;
using System.Collections.Generic;

namespace PlayfairCryptanalysis
{
    public class AnnealingAlgorithm
    {
        string cipherKey = "";
        Random rand;
        //Analyzer

        public AnnealingAlgorithm(string key)
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

        string RandomKey()
        {
            List<char> remainingAlphabet = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            string randomKey = "";

            while (remainingAlphabet.Count > 0)
            {
                var index = rand.Next(remainingAlphabet.Count);
                randomKey += remainingAlphabet[index];
                remainingAlphabet.Remove(remainingAlphabet[index]);
            }

            return randomKey;
        }

        string GenericAnalysis(string cipherText)
        {
            string plainText = "";

            int stopCount = 0;
            var currentKey = RandomKey();
            int currentFitness = 0;
            int parentFitness = 0;           //TODO: get fitness of currentKey

            while (stopCount < 1000)
            {
                stopCount++;

                var moddedKey = RandomSwap(currentKey);
                //plainText = Decrypt(cipherText, currentKey);
                //currentFitness = Analyze(plainText);

                if(currentFitness > parentFitness)
                {
                    currentKey = moddedKey;
                    parentFitness = currentFitness;
                    stopCount = 0;
                }
            }

            //plainText = Decrypt(cipherText, currentKey);

            return plainText;
        }
    }
}
