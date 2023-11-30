using BankTools;
using BuildingMaster;
using System;
using System.Globalization;
using System.Threading;

namespace Tymakov
{
    internal class Program
    {
        /// <summary>
        /// Writes "> " in start of the line.
        /// </summary>
        static void Offer()
        {
            Console.Write("> ");
        }

        /// <summary>
        /// Writes a number of the task.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="number">Number of the task.</param>
        static void Message(string message, int number)
        {
            Console.WriteLine("\nLet's check problem #{0}\nThis program {1}\nPress any to continue...", number, message);
            Offer();
            Console.ReadKey();
        }

        /// <summary>
        /// Reads the input int. If input incorrect it ass user to try again.
        /// </summary>
        /// <returns>The input int.</returns>
        /// <param name="positiveFlag">If set to <c>true</c> input must be positive.</param>
        /// <param name="nonZero">If set to <c>true</c> input must not be zero.</param>
        static int ReadInt(bool positiveFlag, bool nonZero)
        {
            int result = 1;
            bool term = true;
            while (term)
            {
                Offer();
                bool convert = int.TryParse(Console.ReadLine(), out result);
                bool positive = (result >= 0) || !positiveFlag;
                bool noZero = (result != 0) || !nonZero;
                if (convert && positive && noZero)
                {
                    term = false;
                }
                else if (!positive)
                {
                    Console.WriteLine("The input must be positive. Please, try again:");
                }
                else
                {
                    Console.WriteLine("Incorrect input. Please, try again:");
                }
            }
            return result;
        }

        static void Main(string[] args)
        {
            #region Lab
            void Lab11_1()
            {
                Message("tests AccountType fabric", 1);
                AccountTypeFabric fabric = new AccountTypeFabric();
                Console.WriteLine("Create first account with 1000 rub:");
                ulong first = fabric.CreateAccount(1000);
                Console.WriteLine(fabric.GetAccount(first));
                Console.WriteLine("Move it to the trash:");
                fabric.RemoveAccount(first);
            }
            #endregion

            #region HT
            void HT11_1()
            {
                Message("tests Creator", 1);
                Console.WriteLine("Creating a building:");
                uint first = Creator.Create(100, 10, 2, 1);
                Console.WriteLine(Creator.GetBuilding(first));
                Console.WriteLine("Remove first:");
                Creator.RemoveBuilding(first);
            }
            #endregion

            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("ru");
            bool run = true;
            while (run)
            {
                Console.WriteLine();
                Console.WriteLine("||===========================<\\\\>===========================||");
                Console.WriteLine("Please, input \"HT\", if you want to check the HT solutions  or type \"exit\" to stop");
                Offer();
                string respond = Console.ReadLine().ToLower().Trim();
                if (respond.Equals("exit"))
                {
                    run = false;
                    continue;
                }
                Console.WriteLine("Please, input a number of a task:");
                Console.WriteLine("(example: 11_1)");
                Offer();
                string number = Console.ReadLine();
                if (respond.Equals("ht") || respond.Equals("нт")) // and russian-letters case
                {
                    switch (number)
                    {
                        case "11_1": HT11_1(); break;
                        // case "11_2": HT11_2(); break;
                        default: Console.WriteLine("This is not a command or a number of task"); break;
                    }
                }
                else
                {
                    switch (number)
                    {
                        case "11_1": Lab11_1(); break;
                        // case 3: Lab3(); break;
                        // case 4: Lab4(); break;
                        default: Console.WriteLine("This is not a command or a number of task"); break;
                    }
                }
            }

            Console.WriteLine("Please, press any key to continue...");
            Console.ReadKey();
        }
    }
}
