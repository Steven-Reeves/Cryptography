using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptanalysis;
using CaesarCipher;

namespace MyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string UserChoice;
            int UserKey = 0;
            string InFile;
            string OutFile;

            Console.WriteLine("Welcome! Would you like to encrypt or decrypt your text file?");
            Console.WriteLine("E/D...");
            UserChoice = Console.ReadLine();
            // TODO: Make sure E or D was acutually used. 

            Console.WriteLine("Please enter the Caeser Key...");
            UserKey = Convert.ToInt32(Console.ReadLine());

            // Create new Caesar class with user key
            Caesar caesar = new Caesar();

            Console.WriteLine("Please enter input text file (with .txt)");
            InFile = Console.ReadLine();
            // TODO: Make sure input has no spaces and has .txt at end.

            Console.WriteLine("Please enter output text file (with .txt)");
            OutFile = Console.ReadLine();
            // TODO: Make sure input has no spaces and has .txt at end.

            // Testing stubbed out functions
            Console.WriteLine("Encrypt: " + caesar.Encrypt(InFile, UserKey));
            Console.WriteLine("Decrypt: " + caesar.Decrypt(InFile, UserKey));

            Analyzer analyzer = new Analyzer();
            // Commented out for debugging
            //analyzer.TestScore();

            //"Press any key..."
            Console.ReadKey();
        }

    }
}
