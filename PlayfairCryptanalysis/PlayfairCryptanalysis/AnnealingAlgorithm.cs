using System;
using System.Collections.Generic;
using static System.Math;

namespace PlayfairCryptanalysis
{
    public class AnnealingAlgorithm
    {
        string cipherKey = "";
        Random rand;
        Analyzer analyzer = new Analyzer();
        Playfair decoder;

        public AnnealingAlgorithm()
        {
            rand = new Random();
            decoder = new Playfair(RandomKey());
        }
        public AnnealingAlgorithm(string key)
        {
            cipherKey = key;
            rand = new Random();
            decoder = new Playfair(RandomKey());
        }

        string RandomSwap(string key, int keyIndex = 24)
        {
            char[] newKey = key.ToCharArray();
            var index1 = rand.Next(keyIndex);
            var index2 = index1;
            while (index2 == index1)
            {
                index2 = rand.Next(24);
            }

            var temp = newKey[index1];
            newKey[index1] = newKey[index2];
            newKey[index2] = temp;

            string returnValue = "";

            foreach(char c in newKey)
            {
                returnValue += c;
            }

            return returnValue;
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

        public string[] GenericAnalysis(string cipherText)
        {
            string plainText = "";

            int stopCount = 0;
            var currentKey = RandomKey();
            string smallKey = currentKey.Substring(0, 5);
            int currentFitness = 0;
            
            plainText = decoder.Decrypt(cipherText, currentKey.Substring(0, 5));
            int parentFitness = analyzer.TrigraphScore(plainText.ToLower());

            while (stopCount < 50000)
            {
                stopCount++;

                var moddedKey = RandomSwap(currentKey, 4);
                plainText = decoder.Decrypt(cipherText, moddedKey.Substring(0, 5));
                currentFitness = analyzer.TrigraphScore(plainText.ToLower());

                if(currentFitness > parentFitness)
                {
                    currentKey = moddedKey;
                    parentFitness = currentFitness;
                    stopCount = 0;
                }
            }

            plainText = decoder.Decrypt(cipherText, currentKey);

            string[] returnStrings = new string[3];
            returnStrings[0] = plainText;
            returnStrings[1] = currentKey.Substring(0, 5);
            returnStrings[2] = currentFitness.ToString();

            return returnStrings;
        }

        public string[] SimulatedAnnealingAnalysis(string cipherText)
        {
            string plainText = "";

            var currentKey = RandomKey();
            int currentFitness = 0;
            int difference = 0;

            plainText = decoder.Decrypt(cipherText, currentKey.Substring(0, 5));
            int parentFitness = analyzer.FullScore(plainText);

            for (double temperature = 1; temperature > 0; temperature -= .005)
            {
                int stopCount = 0;

                while (stopCount < 1000)
                {
                    stopCount++;

                    var moddedKey = RandomSwap(currentKey, 4);
                    plainText = decoder.Decrypt(cipherText, moddedKey.Substring(0, 5)).ToLower();
                    currentFitness = analyzer.FullScore(plainText);
                    difference = currentFitness - parentFitness;

                    if (difference > 0)
                    {
                        currentKey = moddedKey;
                        parentFitness = currentFitness;
                    }
                    else if (difference < 0 && 25 * Pow( 1.71, currentFitness/temperature) < rand.Next(40))
                    {
                        currentKey = moddedKey;
                        parentFitness = currentFitness;
                    }
                }
            }

            plainText = decoder.Decrypt(cipherText, currentKey.Substring(0, 5)).ToLower() + " ";

            string[] returnStrings = new string[3];
            returnStrings[0] = plainText;
            returnStrings[1] = " " + currentKey.Substring(0, 5);
            returnStrings[2] = " " + currentFitness.ToString();

            return returnStrings;
        }
    }
}
