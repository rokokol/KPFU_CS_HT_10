using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            void First()
            {
                
            }

            void Second()
            {
                Console.WriteLine("Creates 3 studs and checks their hobbies");
                void EatDumplings(Object human, EventArgs dumplings) { }
                
                void DoMath(Object human, EventArgs math) { }
                
                void Chill(Object human, EventArgs action) { }
                
                void Programming(Object human, EventArgs tasks) { }
                
                void Read(Object human, EventArgs book) { }

                Human[] humans =
                {
                    new Human("Ilya"),
                    new Human("Gosha"),
                    new Human("Diana")
                };
                
                void ChechHobby(EventHandler evnt)
                {
                    foreach (var VARIABLE in humans)
                    {
                        if (VARIABLE.likedEvents.GetInvocationList().Contains(evnt))
                        {
                            Console.WriteLine($"{VARIABLE.Name} likes it!");
                        }
                    }
                }
                
                humans[0].likedEvents += EatDumplings;
                humans[0].likedEvents += Programming;
                humans[0].likedEvents += DoMath;

                humans[1].likedEvents += Chill;
                humans[1].likedEvents += Programming;
                humans[1].likedEvents += DoMath;

                humans[2].likedEvents += EatDumplings;
                humans[2].likedEvents += Read;
                humans[2].likedEvents += Chill;

                bool run = true;
                while (run)
                {
                    Console.WriteLine("Input action to check its enjoyers or \"exit\" to stop");
                    Console.WriteLine("(Tip: eat dumplings, chill, do math, programming, read)");
                    Console.Write("> ");
                    string respond = Console.ReadLine();
                    switch (respond.ToLower())
                    {
                        case "eat dumplings": ChechHobby(EatDumplings); break;
                        case "chill": ChechHobby(Chill); break;
                        case "read": ChechHobby(Read); break;
                        case "do math": ChechHobby(DoMath); break;
                        case "programming": ChechHobby(Programming); break;
                        case "exit": run = false; break;
                        default: Console.WriteLine("Unexpected input. Please, try again:"); break;
                    }
                }
            }

            bool temp = true;
            while (temp)
            {
                Console.WriteLine("Input 1 or 2 to check tasks or \"exit\" to stop");
                Console.Write("> ");
                string respond = Console.ReadLine();
                switch (respond.ToLower())
                {
                    case "1": First(); break;
                    case "2": Second(); break;
                    case "exit": temp = false; break;
                    default: Console.WriteLine("Unexpected input. Please, try again:"); break;
                }
            }
        }
    }
}
