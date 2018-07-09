using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
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
            string input = "";
            string output = "";
            string OutFile;
            Caesar caesar = new Caesar();

            Console.WriteLine("Welcome! Would you like to encrypt or decrypt your text file?");
            Console.WriteLine("E/D...");
            UserChoice = Console.ReadLine();
            // TODO: Make sure E or D was acutually used. 

            Console.WriteLine("Please enter the Caeser Key...");
            UserKey = Convert.ToInt32(Console.ReadLine());

            // TODO: "Would be nice" Loop here until we get a valid input
            Console.WriteLine("Please enter input text file (with .txt)");
            InFile = Console.ReadLine();         
            try
            {
                input = System.IO.File.ReadAllText( Directory.GetCurrentDirectory() + "\\" + InFile);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Please enter output text file (with .txt)");
            OutFile = Console.ReadLine();

            if (UserChoice[0] == 'E')
            {
                output = caesar.Encrypt(input, UserKey);
                try
                {
                    System.IO.File.WriteAllText(Directory.GetCurrentDirectory() + "\\" + OutFile, output);
                    Console.WriteLine(InFile + " encrypted and stored in " + OutFile);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            if (UserChoice[0] == 'D')
            {
                output = caesar.Decrypt(input, UserKey);
                try
                {
                    System.IO.File.WriteAllText(Directory.GetCurrentDirectory() + "\\" + OutFile, output);
                    Console.WriteLine(InFile + " decrypted and stored in " + OutFile);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Analyzer analyzer = new Analyzer();
            // Commented out for debugging
            //analyzer.TestScore();

            //"Press any key..."
            Console.ReadKey();
        }

    }
}
