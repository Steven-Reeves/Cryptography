using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SDES
{
    class Program
    {
        static void Main(string[] args)
        {
            BitArray userKey = new BitArray(10);
            BitArray key_1 = new BitArray(8);
            BitArray key_2 = new BitArray(8);
            BitArray userText = new BitArray(8);
            Tools tools = new Tools();
            BitArrayPair keys = new BitArrayPair();
            // BitArray cihoertext = new BitArray(8);
            string UserChoice = "";
            bool exit = false;
            bool validInput = false;
            string validCharacters = "eEdDqQ";

            // Loop to allow user to replay
            while(!exit)
            {
                Console.WriteLine("Welcome!");
                Console.WriteLine("Enter Q or q at anytime to quit");

                // Encrypt or Decrypt
                validInput = false;
                while (!validInput)
                {
                    Console.WriteLine("Would you like to encrypt or decrypt your 8 bit input?");
                    Console.WriteLine("E/D.......");
                    UserChoice = Console.ReadLine();
                    if (validCharacters.Contains(UserChoice[0]))
                    {
                        validInput = true;
                        if (UserChoice[0] == 'Q' || UserChoice[0] == 'q')
                        {
                            exit = true;
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter correct input...");
                    }
                }

                // Get user plain/ciphertext
                validInput = false;
                while (!validInput && !exit)
                {
                    if (UserChoice[0] == 'e' || UserChoice[0] == 'E')
                        Console.WriteLine("Please enter your 8 bit plaintext for encryption:");
                    else
                        Console.WriteLine("Please enter your 8 bit ciphertext for decryption:");

                    string userTextString = Console.ReadLine();
                    userText = new BitArray(userTextString.Select(c => c == '1').ToArray());
                    if (userText.Length == 8)
                    {
                        validInput = true;
                        Console.WriteLine("Your eight bit text: " + tools.BitArrayToString(userText));
                    }
                    else
                    {
                        if (userTextString[0] == 'Q' || userTextString[0] == 'q')
                        {
                            exit = true;
                            break;
                        }
                        Console.WriteLine("Please enter exactly 8 bits (only 1 or 0) for the text...");
                    }
                }

                // Get 10 bit key
                validInput = false;
                while (!validInput && !exit)
                {
                    Console.WriteLine("Please enter a 10 Bit Key");
                    string userKeyString = Console.ReadLine();
                    userKey = new BitArray(userKeyString.Select(c => c == '1').ToArray());
                    if (userKey.Length == 10)
                    {
                        validInput = true;
                        Console.WriteLine("Your ten bit key: " + tools.BitArrayToString(userKey));
                    }
                    else
                    {
                        if (userKeyString[0] == 'Q' || userKeyString[0] == 'q')
                        {
                            exit = true;
                            break;
                        }
                        Console.WriteLine("Please enter exactly 10 bits (only 1 or 0) for the key...");
                    }
                }

                // Output Keys and plain/ciphertext here
                if (!exit)
                {
                    // Generate Keys here
                    Console.WriteLine("Your 8 bit keys are listed below...");
                    keys = tools.GenerateKeys(userKey);
                    Console.WriteLine("Key 1: " + tools.BitArrayToString(keys.firstItem));
                    Console.WriteLine("Key 2: " + tools.BitArrayToString(keys.secondItem));
                    // TODO: Encrypt or decrypt and output bit array
                }

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
                        Console.WriteLine("Please enter correct input...");
                    }
                }

            }
            Console.WriteLine("Exiting!");
            Console.ReadKey();
        }
    }
}
