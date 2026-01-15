using System;
using System.Net;

namespace Game
{
    class Explore
    {
        Random rnd;

        Shop shop;
        Village vill;

        
    

        public Explore(Random random)
        {
            rnd = random;
            shop = new Shop(rnd);
        }
        public void RunExplore(SaveData data, Mountains marea, Village vill)
        {
            
            
            Console.Clear();
            Console.WriteLine("=== Explore ===");
            Console.WriteLine("[1] Forest");
            Console.WriteLine("[2] Town");
            Console.WriteLine("[3] Mountains");
            Console.WriteLine("[4] Exit");

            string input = Console.ReadLine();
            int choice = int.Parse(input);
            switch (choice)
            {
                case 1:                 
                        Console.WriteLine("Be carefull!");
                        shop.RunShop(data);
                        break;
                

                case 2:
                    
                        Console.WriteLine("Coming soon!");
                        break;
                    
                case 3:

                        Console.WriteLine("Its a scary place.");
                        marea.runMountains(vill);
                        break;

                case 4:

                        break;

                default:

                         Console.WriteLine("1-4");
                         break;                 
            }

        }
    }
}