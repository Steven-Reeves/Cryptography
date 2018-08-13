using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayfairCryptanalysis
{
    public class Analyzer
    {
        public int _currentDecrypt = 0;
        int _score = 0;
        int _key = 0;

        readonly List<string> DIGRAPHS = new List<string>   //Includes common double-letters
        {
            "th", "er", "on", "an", "re", "he", "in", "ed", "nd", "ha", "at", "en",
            "es", "of", "or", "nt", "ea", "ti", "to", "it", "st", "io", "le", "is",
            "ou", "ar", "as", "de", "rt", "ve"
        };

        readonly List<string> TRIGRAPHS = new List<string>  //Includes common 3-letter words
        {
            "the", "and", "tha", "ent", "ion", "tio", "for", "nde", "has", "nce", "edt", "tis", "oft", "sth", "men", "are", "but", "not", "you", "all", "any", "can", "had", "her", "was", "one",
            "our", "out", "day", "get", "has", "him", "his", "how", "man", "new", "now", "old", "see", "two", "way", "who", "boy", "did", "its", "let", "put", "say", "she", "too", "use"
        };

        public Analyzer()
        {
            
        }

        public int TrigraphScore(string plainText)
        {
            var text = plainText.ToCharArray();
            var score = 0;

            foreach (var t in TRIGRAPHS)
            {
                var tri = t.ToCharArray();

                for (int i = 0; i < plainText.Length - 2; i++)
                {
                    if (tri[0] == text[i] && tri[1] == text[i + 1] && tri[2] == text[i + 2])
                    {
                        score++;
                    }
                }
            }

            return score;
        }
        
        public void TestScore()
        {
            Random _random = new Random();
            //var testEnglish = "thisisablockofnormalenglishtexttocheckonmycaesarciphercryptanalysisithasnospacesorspecialcharactersthequickbrownfoxjumpedoverthelazydogimjustgoingtotypethisonelastsentancespellingisjustalittleimportantinthistesttextfurthermoreitsopponentwillbecheatingbyusingtriplethecharactercountthisstringhastotryandmatchthefitnessscorethisrecievesthisiscurrentlyonlyanalyzingusingdigraphsnevermindiwentandaddedtrigraphsholycowthisissupergoodnowiaddedcommonthreeletterwordsandthescoringisnotevenclose";
            //var testCipherText = _decrypter.Encrypt("Finally, all of you, have unity of mind, sympathy, brotherly love, a tender heart, and a humble mind. Do not repay evil for evil or reviling for reviling, but on the contrary, bless, for to this you were called, that you may obtain a blessing.", _random.Next(1, 25));

            //Console.WriteLine(Decrypt(testCipherText) + "\nScore: " + _score + "\nKey: " + _key);
            //var score1 = DigraphScore(testEnglish);
            //Console.WriteLine(testEnglish + "\n" + "Digraph Score: " + score1 + "\n" + "Trigraph Score: " + score2 + "\n\n");

        }
    }
}
