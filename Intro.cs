using System;
using System.Threading;

namespace Game
{
    class Intro
    {
        public void runIntro()
        {
            Console.WriteLine("skip intro? 1 - yes | 2 - no");

            int intro = 0;
            bool valid = false;

            while (!valid)
            {
                string input = Console.ReadLine();

                if (int.TryParse(input, out intro) && (intro == 1 || intro == 2))
                {
                    valid = true;  
                }
                else
                {
                    Console.WriteLine("1 - YES | 2 - NO");
                }
            }

            
            if (intro == 2)  
            {


                Console.WriteLine("You are traveling in the forest");
                Thread.Sleep(3000);
                Console.WriteLine("suddenly you come across a strange store");
                Thread.Sleep(3000);
                Console.WriteLine("will you go inside? Y/N");
                string start = Console.ReadLine().ToLower();
                    if (start == "y")
                {
                    Console.WriteLine("yay");
                    Thread.Sleep(3000);
                }
                else if (start == "n")
                {
                    Console.WriteLine("the owner kidnappes you to the store anyway");
                    Thread.Sleep(3000);
                }
                else
                {
                    Console.WriteLine("what??? just go inside man");
                    Thread.Sleep(3000);
                }
                Console.WriteLine("you find yourself in the store, its a very comfy place");
                Thread.Sleep(3000);
                Console.WriteLine("Store Owner: HELLO!");
                Thread.Sleep(3000);
                Console.WriteLine("Store Owner: Welcome to my store!");
                Thread.Sleep(3000);
                Console.WriteLine("Store Owner: Here you can buy all sorts of things!");
                Thread.Sleep(3000);
                Console.WriteLine("you: what do you sell here?");
                Thread.Sleep(3000);
                Console.WriteLine("Store Owner: are you a cop?");
                Thread.Sleep(3000);
                Console.WriteLine("you: what? no im not a cop");
                Thread.Sleep(3000);
                Console.WriteLine("Store Owner: ARE YOU SURE?");
                Thread.Sleep(3000);
                Console.WriteLine("you: im NOT a cop man");
                Thread.Sleep(3000);
                Console.WriteLine("Store Owner: then come take a look");
                Thread.Sleep(3000);
            }    
        }
    }
}