using BankTools;
using BuildingMaster;
using System;
using Books;
using static Books.Sortings;
using System.Globalization;
using System.Threading;
using MathTools;

namespace Tymakov
{
    internal class Program
    {
        delegate void Test();
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

            void Lab12_1()
            {
                Message("tests overriden operators for AccountType", 2);
                AccountTypeFabric fabric = new AccountTypeFabric();
                ulong first = fabric.CreateAccount(1000);
                ulong second = fabric.CreateAccount(240);
                
                Console.WriteLine("Accounts:");
                Console.WriteLine("\tFirst:");
                Console.WriteLine(fabric.GetAccount(first));
                Console.WriteLine("\tSecond:");
                Console.WriteLine(fabric.GetAccount(second));

                #region Testing

                Console.WriteLine("Checking the not-equal-to operator for different accounts:");
                Console.WriteLine(fabric.GetAccount(first) != fabric.GetAccount(second));
                Console.WriteLine("Checking the not-equal-to operator for same accounts:");
                Console.WriteLine(fabric.GetAccount(first) != fabric.GetAccount(first));
                Console.WriteLine("Checking the equal-to operator for different accounts:");
                Console.WriteLine(fabric.GetAccount(first) != fabric.GetAccount(second));
                Console.WriteLine("Checking the equal-to operator for same accounts:");
                Console.WriteLine(fabric.GetAccount(second) != fabric.GetAccount(second));

                #endregion
            }

            void Lab12_2()
            {
                Message("tests a rational numbers class", 3);
                RationalNumber a = new RationalNumber(6, 4, true);
                RationalNumber b = new RationalNumber(1, 3, false);
                Console.WriteLine($"a: {a}, b: {b}");
                Console.WriteLine($"a + b = {a + b}");
                Console.WriteLine($"a - b = {a - b}");
                Console.WriteLine($"a * b = {a * b}");
                Console.WriteLine($"a / b = {a / b}");
                Console.WriteLine($"a == b is {a == b}");
                Console.WriteLine($"a != b is {a != b}");
                Console.WriteLine($"a > b is {a > b}");
                Console.WriteLine($"a < b is {a < b}");
                Console.WriteLine($"a >= b is {a >= b}");
                Console.WriteLine($"a <= b is {a <= b}");
                Console.WriteLine($"++a is {++a}");
                Console.WriteLine($"--a is {--a}");
                Console.WriteLine($"a++ is {a++}");
                Console.WriteLine($"a-- is {a--}");
                Console.WriteLine($"(int) a is {(int) a}");
                Console.WriteLine($"(float) a is {(float) a}");
                Console.WriteLine($"a % b is {a % b}");
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

            void HT12_1()
            {
                Message("tests a complex numbers class", 2);
                ComplexNumber a = new ComplexNumber(6, 4);
                ComplexNumber b = new ComplexNumber(6, -4);
                Console.WriteLine($"a: {a}, b: {b}");
                Console.WriteLine($"a + b = {a + b}");
                Console.WriteLine($"a - b = {a - b}");
                Console.WriteLine($"a * b = {a * b}");
                Console.WriteLine($"a / b = {a / b}");
                Console.WriteLine($"a == b is {a == b}");
                Console.WriteLine($"a != b is {a != b}");
            }

            void HT12_2()
            {
                Message("testing a class to sort books", 3);
                Bookcase bookcase = new Bookcase(
                    new Book("Aligori", "ZozoRed", "Doli"),
                        new Book("Zebri", "DomModi", "Anton"),
                        new Book("Drestins'", "Alivers", "Zokkie"));
                Console.WriteLine("Books:");
                Console.WriteLine(bookcase);
                Console.WriteLine();
                Console.WriteLine("Sorting by name:");
                Compare comp = NameSort;
                bookcase.Sort(comp);
                Console.WriteLine(bookcase);
                
                Console.WriteLine("Sorting by author:");
                comp -= NameSort;
                comp += AuthorSort;
                bookcase.Sort(comp);
                Console.WriteLine(bookcase);
                
                Console.WriteLine("Sorting by publish house:");
                comp -= AuthorSort;
                comp += PublishHouseSort;
                bookcase.Sort(comp);
                Console.WriteLine(bookcase);
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
                        case "12_1": HT12_1(); break;
                        case "12_2": HT12_2(); break;
                        default: Console.WriteLine("This is not a command or a number of task"); break;
                    }
                }
                else
                {
                    switch (number)
                    {
                        case "11_1": Lab11_1(); break;
                        case "12_1": Lab12_1(); break;
                        case "12_2": Lab12_2(); break;
                        default: Console.WriteLine("This is not a command or a number of task"); break;
                    }
                }
            }

            Console.WriteLine("Please, press any key to continue...");
            Console.ReadKey();
        }
    }
}
