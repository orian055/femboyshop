using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Xml.Linq;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Random rnd = new Random();
            
            Shop shop = new Shop(rnd);
            
 
                      
         
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
            string loading = "STORE INCOMING";
            foreach (char c in loading)
            {
                Console.Write(c);
                Thread.Sleep(200);
            }


            Thread.Sleep(3000);
            
            shop.RunShop();
            
            Console.Clear();
            if (shop.Cart.Count == 0)
            {
                Console.WriteLine("store owner: you added nothing. | open store = 1 | exit = 2");
                string fuck = Console.ReadLine();
                if (!int.TryParse(fuck, out int yay))
                Console.WriteLine("store owner: bruh");
                
                else if (yay == 1) 
                {shop.RunShop();}
                

                else if (yay == 2)
                {
                Console.WriteLine("store owner: then get out of my sight");
                Environment.Exit(0);
                }
            }

            Console.WriteLine("IM NOT GETTING PUNCHED IN THE FACE(;");       
        }
    }
}

