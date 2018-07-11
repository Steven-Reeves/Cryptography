using System;
using System.Collections.Generic;
using CaesarCipher;

namespace Cryptanalysis
{
    public class Analyzer
    {
        Caesar _decrypter = new Caesar();
        public List<DecryptCandidate> _decryptCandidates; // <plaintext, fitnessScore>
        public int _currentDecrypt = 0;
        int _score = 0;
        int _key = 0;

        readonly List<(char, char)> DIGRAPHS = new List<(char, char)>   //Includes common double-letters
        {
            ('t', 'h'), ('e', 'r'), ('o', 'n'), ('a', 'n'), ('r', 'e'), ('h', 'e'), ('i', 'n'), ('e', 'd'), ('n', 'd'), ('h', 'a'), ('a', 't'), ('e', 'n'),
            ('e', 's'), ('o', 'f'), ('o', 'r'), ('n', 't'), ('e', 'a'), ('t', 'i'), ('t', 'o'), ('i', 't'), ('s', 't'), ('i', 'o'), ('l', 'e'), ('i', 's'),
            ('o', 'u'), ('a', 'r'), ('a', 's'), ('d', 'e'), ('r', 't'), ('v', 'e'), ('s', 's'), ('e', 'e'), ('t', 't'), ('f', 'f'), ('l', 'l'), ('m', 'm'),
            ('o', 'o')
        };

        readonly List<string> TRIGRAPHS = new List<string>  //Includes common 3-letter words
        {
            "the", "and", "tha", "ent", "ion", "tio", "for", "nde", "has", "nce", "edt", "tis", "oft", "sth", "men", "are", "but", "not", "you", "all", "any", "can", "had", "her", "was", "one",
            "our", "out", "day", "get", "has", "him", "his", "how", "man", "new", "now", "old", "see", "two", "way", "who", "boy", "did", "its", "let", "put", "say", "she", "too", "use"
        };

        public Analyzer()
        {
            _decryptCandidates = new List<DecryptCandidate>();
        }

        public string Decrypt(string cipherText)
        {
            _decryptCandidates.Clear();
            _score = 0;
            var key = 1;
            var winner = "";

            //Fill list of decrypted candidates
            for (int i = 1; i < 26; i++)
            {
                var possibleDecrypt = _decrypter.Decrypt(cipherText, i);
                _decryptCandidates.Add(new DecryptCandidate(possibleDecrypt, i));
            }

            //Score fitness levels of each candidate
            foreach(var c in _decryptCandidates)
            {
                var score = DigraphScore(c.plainText);
                score += TrigraphScore(c.plainText);
                c.fitness = score;
            }

            //Find highest fitness level
            foreach(var c in _decryptCandidates)
            {
                if(c.fitness > _score)
                {
                    winner = c.plainText;
                    _score = c.fitness;
                    _key = key;
                }

                key++;
            }

            SortPlaintexts();

            //Winner winner chicken dinner!
            return winner;
        }

        public string GetNextDecrypt()
        {
            if (_currentDecrypt < 25)
            {
                _currentDecrypt++;
                return _decryptCandidates[_currentDecrypt].plainText;
            }
            else
            {
                return "No more decryption candidates.";
            }
        }
        int DigraphScore(string plainText)
        {
            var text = plainText.ToCharArray();
            var score = 0;

            foreach (var d in DIGRAPHS)
            {
                for (int i = 0; i < plainText.Length - 1; i++)
                {
                    if (d.Item1 == text[i] && d.Item2 == text[i + 1])
                    {
                        score++;
                    }
                }
            }

            return score;
        }

        int TrigraphScore(string plainText)
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

        void SortPlaintexts()
        {
            var elements = 25;
            int j;
            for (int h = elements / 2; h > 0; h /= 2)
            {
                for (int i = h; i < elements; i++)
                {
                    var temp = _decryptCandidates[i];
                    for (j = i; j >= h && temp.fitness < _decryptCandidates[j - h].fitness;
                        j -= h)
                    {
                        _decryptCandidates[j] = _decryptCandidates[j - h];
                    }
                    _decryptCandidates[j] = temp;
                }
            }
        }

        public void TestScore()
        {
            Random _random = new Random();
            //var testEnglish = "thisisablockofnormalenglishtexttocheckonmycaesarciphercryptanalysisithasnospacesorspecialcharactersthequickbrownfoxjumpedoverthelazydogimjustgoingtotypethisonelastsentancespellingisjustalittleimportantinthistesttextfurthermoreitsopponentwillbecheatingbyusingtriplethecharactercountthisstringhastotryandmatchthefitnessscorethisrecievesthisiscurrentlyonlyanalyzingusingdigraphsnevermindiwentandaddedtrigraphsholycowthisissupergoodnowiaddedcommonthreeletterwordsandthescoringisnotevenclose";
            var testCipherText = _decrypter.Encrypt("Finally, all of you, have unity of mind, sympathy, brotherly love, a tender heart, and a humble mind. Do not repay evil for evil or reviling for reviling, but on the contrary, bless, for to this you were called, that you may obtain a blessing.", _random.Next(1, 25));

            Console.WriteLine(Decrypt(testCipherText) + "\nScore: " + _score + "\nKey: " + _key);
            //var score1 = DigraphScore(testEnglish);
            //Console.WriteLine(testEnglish + "\n" + "Digraph Score: " + score1 + "\n" + "Trigraph Score: " + score2 + "\n\n");

        }
    }
}
