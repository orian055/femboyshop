using System;
using System.Threading;

namespace Game
{
    class Work
    {
        public void Runwork(SaveData data, Random rnd)
        {
            Console.Clear();
            Console.WriteLine("=== MONEY ===");
            Console.WriteLine("[1] Scam people (Indian style)");
            Console.WriteLine("[2] Play guitar on the street");
            Console.WriteLine("[3] Post on onlyfans");
            Console.WriteLine("[4] Exit");
            if (!int.TryParse(Console.ReadLine(), out int choice))
               return;
            switch (choice)
            {
                case 1:
                    {
                        DoJob(data, rnd, "You scammed someone, he didnt notice.", 5, 100);
                        break;
                    }
                case 2:
                    {
                        DoJob(data, rnd, "You showed impressive skills, a crowd was cheering.", 5, 100);
                        break;
                    }
                case 3:
                    {
                        DoJob(data, rnd, "You posted some pics, people fell in love.", 5, 100);
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("cya");
                        break;
                    }  
                default:
                    {
                        Console.WriteLine("1-4");
                        break;
                    }    

            }      
        }
        


    private void DoJob(SaveData data, Random rnd, string name, int minPay, int maxPay)
        {
            Console.WriteLine($"\n{name}.");
            Thread.Sleep(800);

            int earned = rnd.Next(minPay, maxPay + 1);
            data.Money += earned;

            Console.WriteLine($"You made {earned}");
            Console.WriteLine($"wallet: {data.Money}");

            Thread.Sleep(1200);
            Console.WriteLine("\nPress Enter...");
            Console.ReadLine();
        }
    }
}

