using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Numerics;
using System.Text.RegularExpressions;


namespace RSA
{
    class Program
    {
        static void Main(string[] args)
        {
            RSAKit kit = new RSAKit();
            List<KeySet> keyList = new List<KeySet>();
            string UserChoice = "";
            bool exit = false;
            bool validInput = false;
            string validCharacters = "eEdDqGgQq";
            BigInteger input = new BigInteger();
            BigInteger input_N = new BigInteger();
            BigInteger output = new BigInteger();

            // Loop to allow user to replay
            while (!exit)
            {
                Console.WriteLine("Welcome!");
                Console.WriteLine("Enter Q or q at anytime to quit");

                // Encrypt or Decrypt
                validInput = false;
                while (!validInput)
                {
                    Console.WriteLine("Would you like to encrypt, decrypt, or generate keys?");
                    Console.WriteLine("E/D/G.......");
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
                        Console.WriteLine("Please enter correct input...\n");
                    }
                }

                if (!exit && (UserChoice[0] == 'g' || UserChoice[0] == 'G'))
                {
                    keyList.Add(kit.GenerateKeys());
                    Console.WriteLine("Generated Key set 1:");
                    //Console.WriteLine("\t P: " + kit.P.ToString());
                    //Console.WriteLine("\t Q: " + kit.Q.ToString());
                    Console.WriteLine("\t E: " + keyList[0].E.ToString() + "\n");
                    Console.WriteLine("\t D: " + keyList[0].D.ToString() + "\n");
                    Console.WriteLine("\t N: " + keyList[0].N.ToString() + "\n");
                    //kit.GenerateKeys();
                    keyList.Add(kit.GenerateKeys());
                    Console.WriteLine("Generated Key set 2:");
                    //Console.WriteLine("\t P: " + kit.P.ToString());
                    //Console.WriteLine("\t Q: " + kit.Q.ToString());
                    Console.WriteLine("\t E: " + keyList[1].E.ToString() + "\n");
                    Console.WriteLine("\t D: " + keyList[1].D.ToString() + "\n");
                    Console.WriteLine("\t N: " + keyList[1].N.ToString() + "\n");
                    //kit.GenerateKeys();
                    keyList.Add(kit.GenerateKeys());
                    Console.WriteLine("Generated Key set 3:");
                    //Console.WriteLine("\t P: " + kit.P.ToString());
                    //Console.WriteLine("\t Q: " + kit.Q.ToString());
                    Console.WriteLine("\t E: " + keyList[2].E.ToString() + "\n");
                    Console.WriteLine("\t D: " + keyList[2].D.ToString() + "\n");
                    Console.WriteLine("\t N: " + keyList[2].N.ToString() + "\n");
                }

                // Get user plain/ciphertext
                validInput = false;
                while (!validInput && !exit && !(UserChoice[0] == 'g' || UserChoice[0] == 'G'))
                {
                    if (UserChoice[0] == 'e' || UserChoice[0] == 'E')
                        Console.WriteLine("Please enter your number for encryption:");
                    else
                        Console.WriteLine("Please enter your number for decryption:");

                    string userTextString = Console.ReadLine();
                    if (userTextString.Length > 0 && Regex.Matches(userTextString, @"[0-9]").Count == userTextString.Length)
                    {
                        validInput = true;
                        input = BigInteger.Parse(userTextString);
                        Console.WriteLine("Your number is: " + input.ToString());
                    }
                    else
                    {
                        if (userTextString[0] == 'Q' || userTextString[0] == 'q')
                        {
                            exit = true;
                            break;
                        }
                        Console.WriteLine("Please enter a number...\n");
                    }
                }

                // Get and set N
                validInput = false;
                while (!validInput && !exit && !(UserChoice[0] == 'g' || UserChoice[0] == 'G'))
                {
                    Console.WriteLine("Please enter N: ");

                    string userTextString_N = Console.ReadLine();
                    if (userTextString_N.Length > 0 && Regex.Matches(userTextString_N, @"[0-9]").Count == userTextString_N.Length)
                    {
                        validInput = true;
                        input_N = BigInteger.Parse(userTextString_N);
                        Console.WriteLine("N has been set to: " + input_N.ToString());
                        kit.N = input_N;
                    }
                    else
                    {
                        if (userTextString_N[0] == 'Q' || userTextString_N[0] == 'q')
                        {
                            exit = true;
                            break;
                        }
                        Console.WriteLine("Please enter a number...\n");
                    }
                }

                // Output Keys and plain/ciphertext here
                if (!exit && !(UserChoice[0] == 'g' || UserChoice[0] == 'G'))
                {
                    Console.WriteLine("Using Key set 3:");
                    Console.WriteLine("\t E: " + keyList[2].E.ToString() + "\n");
                    Console.WriteLine("\t D: " + keyList[2].D.ToString() + "\n");
                    Console.WriteLine("\t N: " + kit.N.ToString() + "\n");

                    if (UserChoice[0] == 'e' || UserChoice[0] == 'E')
                    {
                        output = kit.Encrypt(input);
                        Console.WriteLine("Your encrypted number: " + output.ToString());
                    }
                    else
                    {
                        output = kit.Decrypt(input);
                        Console.WriteLine("Your decrypted number: " + output.ToString());
                    }
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
                        Console.WriteLine("Please enter correct input.../n");
                    }
                }

            }
            Console.WriteLine("Exiting!");
            Console.ReadKey();
        }
    }
}
