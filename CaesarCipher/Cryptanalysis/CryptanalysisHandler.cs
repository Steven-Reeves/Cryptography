using System;
using System.IO;

namespace Cryptanalysis
{
    public class CryptanalysisHandler
    {
        static Analyzer _analyzer = new Analyzer();
        string _cipherText;
        string _plainText;

        public CryptanalysisHandler()
        {

        }

        public void RunDecrypt()
        {
            GetTextFromFile();

            _plainText = _analyzer.Decrypt(_cipherText);

            UserPicksDecrypt();

            WriteTextToFile(_plainText);
        }

        void UserPicksDecrypt()
        {
            var correct = DoYouAgree();

            while (!correct && _analyzer._currentDecrypt < 26)
            {
                var choice = SeeNextOrListAll();
                if(choice == '1')
                {
                    _plainText = _analyzer.GetNextDecrypt();
                }
                else
                {
                    foreach(var c in _analyzer._decryptCandidates)
                    {
                        Console.WriteLine(c.plainText + "\nKey: " + c.key + "\n");
                    }

                    _plainText = GetTextByKey();
                    break;
                }

                correct = DoYouAgree();
            }
        }

        char SeeNextOrListAll()
        {
            var choice = ' ';
            bool valid = false;

            while (!valid)
            {
                Console.WriteLine("\n--Pick Option 1 or 2--\n(1) See Next.\n(2) See All\nSelection: ");
                var input = Console.ReadLine();

                if (input.Equals("1") || input.Equals("2"))
                {
                    valid = true;
                    choice = input.ToCharArray()[0];
                }
            }

            return choice;
        }

        string GetTextByKey()
        {
            var choice = -1;
            bool valid = false;

            while (!valid)
            {
                Console.WriteLine("\nEnter key value of the correct decrypt (best scored decrypts at bottom): ");
                var input = Console.ReadLine();

                if (int.TryParse(input, out choice))
                {
                    valid = true;
                }
            }

            int i = 0;
            while (choice != _analyzer._decryptCandidates[i].key)
            {
                i++;
                if(i > 26)
                {
                    return "Not Found";
                }
            }

            return _analyzer._decryptCandidates[i].plainText;
        }

        void GetTextFromFile()
        {
            string input = "";
            bool valid = false;

            while (!valid)
            {
                Console.WriteLine("File to load ciphertext from must be in same directory as this .exe\nEnter file name to load: ");
                var InFile = Console.ReadLine();
                try
                {
                    input = System.IO.File.ReadAllText(Directory.GetCurrentDirectory() + "\\" + InFile);
                    valid = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                if (input.Length > 99)
                {
                    _cipherText = input.ToUpper();
                }
                else
                {
                    Console.WriteLine("Ciphertext must be at least 100 characters long.");
                }
            }
        }

        void WriteTextToFile(string plainText)
        {
            File.WriteAllText("output.txt", plainText);
        }

        bool DoYouAgree()
        {
            bool thoughts = false;
            bool valid = false;

            Console.WriteLine("\n" + _plainText);

            while (!valid)
            {
                Console.WriteLine("\nDo you think this is the correct plaintext? (y/n): ");
                var input = Console.ReadLine();

                if(input.Equals("y"))
                {
                    thoughts = true;
                    valid = true;
                }
                else if(input.Equals("n"))
                {
                    thoughts = false;
                    valid = true;
                }
            }

            return thoughts;
        }
    }
}
