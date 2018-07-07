using System;
using System.Collections.Generic;



namespace Cryptanalysis
{
    public class Analyzer
    {
        string _cipherText;
        List<Tuple<string, int>> _decryptCandidates; // <plaintext, fitnessScore>
        readonly List<(char, char)> DIGRAPHS = new List<(char, char)>
        {
            ('t', 'h'), ('e', 'r'), ('o', 'n'), ('a', 'n'), ('r', 'e'), ('h', 'e'), ('i', 'n'), ('e', 'd'), ('n', 'd'), ('h', 'a'), ('a', 't'), ('e', 'n'),
            ('e', 's'), ('o', 'f'), ('o', 'r'), ('n', 't'), ('e', 'a'), ('t', 'i'), ('t', 'o'), ('i', 't'), ('s', 't'), ('i', 'o'), ('l', 'e'), ('i', 's'),
            ('o', 'u'), ('a', 'r'), ('a', 's'), ('d', 'e'), ('r', 't'), ('v', 'e'), ('s', 's'), ('e', 'e'), ('t', 't'), ('f', 'f'), ('l', 'l'), ('m', 'm'),
            ('o', 'o'),
        };

        readonly List<string> TRIGRAPHS = new List<string>  //Includes common 3-letter words
        {
            "the", "and", "tha", "ent", "ion", "tio", "for", "nde", "has", "nce", "edt", "tis", "oft", "sth", "men", "are", "but", "not", "you", "all", "any", "can", "had", "her", "was", "one",
            "our", "out", "day", "get", "has", "him", "his", "how", "man", "new", "now", "old", "see", "two", "way", "who", "boy", "did", "its", "let", "put", "say", "she", "too", "use"
        };

        public Analyzer()
        {
            _decryptCandidates = new List<Tuple<string, int>>();
        }

        public Analyzer(string cipherText)
        {
            _decryptCandidates = new List<Tuple<string, int>>();
            _cipherText = cipherText;
        }

        int ScoreText(string plainText)
        {
            var text = plainText.ToCharArray();
            var score = 0;

            foreach(var d in DIGRAPHS)
            {
                for(int i = 0; i < plainText.Length - 1; i++)
                {
                    if(d.Item1 == text[i] && d.Item2 == text[i+1])
                    {
                        score++;
                    }
                }
            }

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

            return score; //final score here
        }

        public void TestScore()
        {
            Random _random = new Random();
            string testEnglish = "thisisablockofnormalenglishtexttocheckonmycaesarciphercryptanalysisithasnospacesorspecialcharactersthequickbrownfoxjumpedoverthelazydogimjustgoingtotypethisonelastsentancespellingisjustalittleimportantinthistesttextfurthermoreitsopponentwillbecheatingbyusingtriplethecharactercountthisstringhastotryandmatchthefitnessscorethisrecievesthisiscurrentlyonlyanalyzingusingdigraphsnevermindiwentandaddedtrigraphsholycowthisissupergoodnowiaddedcommonthreeletterwordsandthescoringisnotevenclose";
            string testGarbage = "";

            var score = ScoreText(testEnglish);
            Console.WriteLine(testEnglish + "\n" + "Score: " + score + "\n\n");

            for(int i = 0; i < testEnglish.Length * 3; i++)
            {
                var num = _random.Next(0, 26);
                char letter = (char)('a' + num);
                testGarbage += letter;
            }

            score = ScoreText(testGarbage);
            Console.WriteLine(testGarbage + "\n" + "Score: " + score + "\n\n");
        }
    }
}
