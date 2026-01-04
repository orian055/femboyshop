using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Xml.Linq;

namespace Store
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Random rnd = new Random();
            int bswordstock = rnd.Next(0, 10);
            int bbowstock = rnd.Next(0, 10);
            int arrowsstock = rnd.Next(0, 10);
            int shieldstock = rnd.Next(0, 10);
            int coolhatstock = rnd.Next(0, 10);
            int fuckasshatstock = rnd.Next(0, 10);
            int dragonstock = rnd.Next(0, 10);
            int fbowstock = rnd.Next(0, 10);
            int sandwichstock = rnd.Next(0, 10);
            int potionstock = rnd.Next(0, 10);
            int substock = rnd.Next(0, 10);

            Dictionary<string, int> cart = new Dictionary<string, int>();

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


            Thread.Sleep(5000);

            bool shopping = true;
            while (shopping)
            {
                Console.Clear();
                Console.WriteLine($"1. a basic sword - 25$ | {bswordstock} left");
                Console.WriteLine($"2. a basic bow - 30 | {bbowstock} left ");
                Console.WriteLine($"3. 30 arrows - 10 | {arrowsstock} left ");
                Console.WriteLine($"4. a small shield - 15 | {shieldstock} left ");
                Console.WriteLine($"5. a cool fucking hat - 250 | {coolhatstock} left ");
                Console.WriteLine($"6. a hat that is not that cool tbh - 5 | {fuckasshatstock} left ");
                Console.WriteLine($"7. a sick dragon killing sword - 150 | {dragonstock} left ");
                Console.WriteLine($"8. a legendary bow with flames and poison and blah blah blah just buy it idiot - 175 | {fbowstock} left ");
                Console.WriteLine($"9. a nice sandwich - 25 | {sandwichstock} left ");
                Console.WriteLine($"10. op healing potion - 75 | {potionstock} left ");
                Console.WriteLine($"11. a nuclear submarine - 200,000 | {substock} left ");
                Console.WriteLine("0. checkout");
                foreach (var entry in cart)
                {
                    Console.WriteLine($"\nCart: {entry.Key} ");
                }



                Console.WriteLine("\nStop staring at me... enter the item number or 0 to checkout: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int choice))
                {
                    Console.WriteLine("Numbers please. Try again.");
                    continue;  
                }
                switch (choice)
                {
                    case 1:
                        if (bswordstock == 0)
                            Console.WriteLine("out of stock... its the most selled item here");

                        else if (cart.ContainsKey("basic sword"))
                            Console.WriteLine("dual swords would be pretty cool, im NOT letting a loser like you have it");
                        else
                        {
                            cart.Add("basic sword", 25);
                            bswordstock--;
                            Console.WriteLine("Cheap but gets the job done. Rust included.");
                            Console.WriteLine("item added to cart");
                            
                           

                        }
                        Thread.Sleep(5000);
                        break;
                        

                    case 2:
                        if (bbowstock == 0)
                            Console.WriteLine("out of stock... make one yourself, i just tied a shoelace to a stick");

                        else if (cart.ContainsKey("basic bow"))
                            Console.WriteLine("2 basic bows? really?");
                        else
                        {
                            cart.Add("basic bow", 30);
                            bbowstock--;
                            Console.WriteLine("You might lose an eye with this thing.");
                            Console.WriteLine("item added to cart");

                        }
                        Thread.Sleep(5000);
                        break;

                    case 3:
                        if (arrowsstock == 0)
                            Console.WriteLine("out of stock... only 29 left, i sell in 30s");

                        else if (cart.ContainsKey("30 arrows"))
                            Console.WriteLine("30 is enough boy");
                        else
                        {
                            cart.Add("30 arrows", 10);
                            arrowsstock--;
                            Console.WriteLine("Pointy. Straight-ish. Mostly works.");
                            Console.WriteLine("item added to cart");
                          
                        }
                        Thread.Sleep(5000);
                        break;

                    case 4:
                        if (shieldstock == 0)
                            Console.WriteLine("out of stock... some guy needed it to defend himself from a nuclear submarine..");

                        else if (cart.ContainsKey("small shield"))
                            Console.WriteLine("trust me 1 is enough");
                        else
                        {
                            cart.Add("small shield", 15);
                            shieldstock--;
                            Console.WriteLine("Can block an atomic bomb (probably).");
                            Console.WriteLine("item added to cart");

                        }
                        Thread.Sleep(5000);
                        break;

                    case 5:
                        if (coolhatstock == 0)
                            Console.WriteLine("out of stock... you can tell why");

                        else if (cart.ContainsKey("cool hat"))
                            Console.WriteLine("save some swag for the rest of us");
                        else
                        {
                            cart.Add("cool hat", 250);
                            coolhatstock--;
                            Console.WriteLine("Woah you are cool.");
                            Console.WriteLine("item added to cart");
                        
                        }
                        Thread.Sleep(5000);
                        break;

                    case 6:
                        if (fuckasshatstock == 0)
                            Console.WriteLine("out of stock... i just dont order these fucking hats");

                        else if (cart.ContainsKey("hat"))
                            Console.WriteLine("YOU WANTED TWO OF THESE? LMAO YOU STINK");
                        else
                        {
                            cart.Add("hat", 5);
                            fuckasshatstock--;
                            Console.WriteLine("It exists. That’s about it.");
                            Console.WriteLine("item added to cart");

                        }
                        Thread.Sleep(5000);
                        break;

                    case 7:
                        if (dragonstock == 0)
                            Console.WriteLine("out of stock... dragons were making noise outside");

                        else if (cart.ContainsKey("dragon killing sword"))
                            Console.WriteLine("you cant lift two of these, be fr");
                        else
                        {
                            cart.Add("dragon killing sword", 150);
                            dragonstock--;
                            Console.WriteLine("Forged specifically for dragon violence.");
                            Console.WriteLine("item added to cart");
                          
                        }
                        Thread.Sleep(5000);
                        break;

                    case 8:
                        if (fbowstock == 0)
                            Console.WriteLine("out of stock... a cool dude took 11 just before you came in.");

                        else if (cart.ContainsKey("legendary bow"))
                            Console.WriteLine("you already added that");
                        else
                        {
                            cart.Add("legendary bow", 175);
                            fbowstock--;
                            Console.WriteLine("Overkill? Yes. Worth it? Also yes.");
                            Console.WriteLine("item added to cart");
                        
                        }
                        Thread.Sleep(5000);
                        break;

                    case 9:
                        if (sandwichstock == 0)
                            Console.WriteLine("out of stock... i was hungry");

                        else if (cart.ContainsKey("nice sandwich"))
                            Console.WriteLine("you already added that");
                        else
                        {
                            cart.Add("nice sandwich", 25);
                            sandwichstock--;
                            Console.WriteLine("My mom made it. Don’t ask what’s inside.");
                            Console.WriteLine("item added to cart");
                           
                        }
                        Thread.Sleep(5000);
                        break;

                    case 10:
                        if (potionstock == 0)
                            Console.WriteLine("out of stock...");

                        else if (cart.ContainsKey("healing potion"))
                            Console.WriteLine("trust me 1 is enough");
                        else
                        {
                            cart.Add("healing potion", 75);
                            potionstock--;
                            Console.WriteLine("Cures cancer.");
                            Console.WriteLine("item added to cart");
                           
                        }
                        Thread.Sleep(5000);
                        break;

                    case 11:
                        if (substock == 0)
                            Console.WriteLine("out of stock... and its not really legal too");

                        else if (cart.ContainsKey("nuclear submarine"))
                            Console.WriteLine("WHY DO YOU NEED 2 OF THOSE");
                        else
                        {
                            cart.Add("nuclear submarine", 200000);
                            substock--;
                            Console.WriteLine("WHY DO YOU NEED THIS.");
                            Console.WriteLine("item added to cart");
                          
                        }
                        Thread.Sleep(5000);
                        break;

                    case 0:
                        shopping = false;
                        Console.WriteLine("OKAY!");
                        Thread.Sleep(3000);
                        break;

                    default:
                        Console.WriteLine("Are you drunk? ");
                        Thread.Sleep(5000);
                        break;
                }

            }
            Console.Clear();
        Console.WriteLine("\nSo you took:");
            Thread.Sleep(3000);
            if (cart.Count == 0)
            {
                Console.WriteLine("Nothing):");
            }
            else
            {
                foreach (var entry in cart)
                    {
                    Console.WriteLine($"- {entry.Key} | {entry.Value} ");
                }
                Console.WriteLine($"thats {cart.Values.Sum()}$");
                Console.WriteLine("do you want to cancel anything?");
                Console.WriteLine("1 - yes | 2 - no");
                int cancel = 0;
                bool valid1 = false;

                while (!valid1)
                {
                    string canceling = Console.ReadLine();

                    if (int.TryParse(canceling, out cancel) && (cancel == 1 || cancel == 2))
                    {
                        valid1 = true;
                    }
                    else
                    {
                        Console.Clear();
                        string punish = ".......";
                        foreach (char c in punish)
                        {
                            Console.Write(c);
                            Thread.Sleep(200);
                        }
                        Thread.Sleep(5000);
                        Console.WriteLine("\nwhat the actual fuck is wrong with you");
                        Thread.Sleep(5000);
                        Console.WriteLine("i asked you to write 1 for yes. 2 for no.");
                        Thread.Sleep(5000);
                        Console.WriteLine($"yet. you chose to say: {canceling}");
                        Thread.Sleep(5000);
                        Console.WriteLine("carefull now");
                        Thread.Sleep(5000);
                        Console.WriteLine("do you want to cancel? 1 - yes | 2 - no");
                    }
                    }
                    if (cancel == 1)
                    {
                        bool removing = true;
                        while (removing)
                        {
                        foreach (var entry in cart)
                        {
                            Console.WriteLine($"cart: {entry.Key} ");
                        }
                        Console.WriteLine("enter item name to remove or enter bye to exit ");
                            string remove = Console.ReadLine();
                        if (cart.Remove(remove)) 
                                Console.WriteLine("removed");
                            else if (remove == "bye")
                            {
                                removing = false;
                            }
                            else
                                Console.WriteLine("try typing it again");
                        }
                        Console.WriteLine("\nSo you took:");
                        Thread.Sleep(3000);
                        if (cart.Count == 0)
                        {
                            Console.WriteLine("Nothing):");
                            Environment.Exit(0);
                        }
                        else
                        {
                            foreach (var entry in cart)
                            {
                                Console.WriteLine($"- {entry.Key} | {entry.Value} ");
                            }

                            Console.WriteLine($"thats {cart.Values.Sum()}$");
                        }
                    }
                    else if (cancel == 2)
                        Console.WriteLine("yay");

           
                    


                    Console.WriteLine("\nNow pay before we will have a problem");
                    Console.WriteLine("enter credit card info:");
                
                    string scam = Console.ReadLine();
                if (scam == "secret")
                    Console.WriteLine("its on the house <3");

                else
                {
                    bool lover = true;
                    while (lover)
                    {
                        Console.WriteLine("enter phone number:");
                        string love = Console.ReadLine();
                        if (int.TryParse(love, out int number))
                        {
                            Console.WriteLine("ill call you later<3");
                            lover = false;
                        }
                        else
                        {
                            Console.WriteLine("NUMBER!");
                        }
                    }
                }
                    Thread.Sleep(500);
                    string brag = "WORKED ON THIS FOR A WHOLE WEEK RAHHHHH ";
                    foreach (char c in brag)
                    {
                        Console.Write(c);
                        Thread.Sleep(50);
                    }

                

            }

        }
    }
}
