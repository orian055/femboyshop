using System;

namespace Game
{
    class Mountains
    {
        public void runMountains(Village vill)
        {
            Console.WriteLine("you arrive at the mountains...");
            Console.WriteLine("there are dragons flying around");
            
            
            Console.Clear();
            Console.WriteLine("=== Mountains ===");
            Console.WriteLine("[1] Village");
            Console.WriteLine("[2] Warrior's path");
            Console.WriteLine("[3] Mountain top (final boss)");
            Console.WriteLine("[4] Go back");

            string input = Console.ReadLine();
            int choice = int.Parse(input);
            switch (choice)
            {
                case 1:                 
                        Console.WriteLine("You spot a villag with some people inside");
                        vill.runVillage();
                        break;
                

                case 2:
                    
                        Console.WriteLine("Its a gate leading to some stairs");
                        break;
                    
                case 3:

                        Console.WriteLine("The dragon can be seen sitting there, waiting for opponent");
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
