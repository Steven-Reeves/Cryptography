using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace PlayfairCryptanalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            bool validInput = false;
            string ciphertext;
            string plaintext;
            string key;
            string inFile;
            string UserChoice = "";

            while (!exit)
            {
                Console.WriteLine("Welcome!\n\n");

                // Get user ciphertext
                validInput = false;
                while (!validInput && !exit)
                {
                    Console.WriteLine("Enter your ciphertext below:\n");
                    string userTextString = Console.ReadLine();
                    if (userTextString.Length > 0 && Regex.Matches(userTextString, @"[A-Za-z ]").Count == userTextString.Length)
                    {
                        validInput = true;
                        ciphertext = userTextString;
                        Console.WriteLine("Ciphertext entered: " + userTextString);
                    }
                    else
                    {
                        if (userTextString[0] == 'Q' || userTextString[0] == 'q')
                        {
                            exit = true;
                            break;
                        }
                        Console.WriteLine("Please enter only letters and spaces...\n");
                    }
                }

                //get input from file
                /*
                validInput = false;
                while (!validInput && !exit)
                {
                    Console.WriteLine("Please enter input text file (with .txt)\n");
                    inFile = Console.ReadLine();
                    try
                    {
                        ciphertext = System.IO.File.ReadAllText(Directory.GetCurrentDirectory() + "\\" + inFile);
                        validInput = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message + "\n");
                        validInput = false;
                    }
                }
                */
                Console.WriteLine("Plaintext and key are below...\n");
                // get plaintext and key from algorithm
                Console.WriteLine("PLAINTEXT HERE");
                Console.WriteLine("KEY HERE\n");

                // Ask user if they want to quit
                validInput = false;
                while (!validInput && !exit)
                {
                    Console.WriteLine("Would you like to exit?");
                    Console.WriteLine("Y/N.......");
                    UserChoice = Console.ReadLine();
                    if (UserChoice[0] == 'Y' || UserChoice[0] == 'y')
                    {
                        validInput = true;
                        exit = true;
                        break;
                    }
                    if (UserChoice[0] == 'N' || UserChoice[0] == 'n')
                        validInput = true;
                    else
                    {
                        Console.WriteLine("Please enter correct input.../n");
                    }
                }
            }
            Console.WriteLine("Exiting!");
            Console.ReadKey();
        }
    }
}
