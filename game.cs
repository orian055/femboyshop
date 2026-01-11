using System;
using System.Threading;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            Menus menu = new Menus();
            Intro intro = new Intro();

            Tut tut = new Tut();

            Console.WriteLine("heyyyyy");
            Thread.Sleep(1000);

            while (true)
            {
                Console.Clear();
                menu.RunMainMenu();

                if (!int.TryParse(Console.ReadLine(), out int choice))
                    continue;

                switch (choice)
                {
                    case 1:
                    {
                        Console.WriteLine("lets get crazy");
                        SaveData data = new SaveData { Money = 100 };
                        SaveSystem.Save(data);

                        RunGame(data, rnd, intro);
                        break;
                    }

                    case 2:
                    {
                        if (!SaveSystem.SaveExits())
                        {
                            Console.WriteLine("No save file found...");
                            Thread.Sleep(1500);
                            break;
                        }

                        SaveData data = SaveSystem.Load();
                        RunGame(data, rnd, intro);
                        break;
                    }

                    case 3:
                    {
                        Console.WriteLine("are you sure? 1 - yes | 2 - no");
                        if (!int.TryParse(Console.ReadLine(), out int sure))
                        {
                            Console.WriteLine("1 - yes | 2 - no");
                            Thread.Sleep(1200);
                            break;
                        }

                        if (sure == 1)
                        {
                            Console.WriteLine("A Fresh start, Good luck traveler.");
                            SaveSystem.DeleteSave();
                        }
                        else if (sure == 2)
                        {
                            Console.WriteLine("Im glad");
                        }

                        Thread.Sleep(1200);
                        break; // ✅ this fixes the fall-through error
                    }
                    case 4:
                    {
                        tut.runTut();
                        break;
                    }
                    case 5:
                    {
                        Console.WriteLine("oof, ill miss you mate");
                        Environment.Exit(0);
                        break;
                    }

                    default:
                        Console.WriteLine("Pick 1-5.");
                        Thread.Sleep(1200);
                        break;
                }
            }
        }
        
        // ✅ You were missing this
        static void RunGame(SaveData data, Random rnd, Intro intro)
        {
            // New shop each run = new random stock each time you start/continue
            Shop shop = new Shop(rnd);

            Console.Clear();
            Console.WriteLine($"Money: {data.Money}$");
            Thread.Sleep(1200);

            intro.runIntro();
            Thread.Sleep(800);

            shop.RunShop();

            // if cart empty, nothing to buy
            if (shop.Cart.Count == 0)
            {
                Console.WriteLine("store owner: you added nothing.");
                Thread.Sleep(1500);
                return;
            }

            // total price
            int total = 0;
            foreach (var entry in shop.Cart)
                total += entry.Value.Price * entry.Value.Quantity;

            Console.WriteLine($"\nstore owner: total is {total}$");
            Console.WriteLine($"you: i have {data.Money}$");
            Thread.Sleep(1200);

            if (data.Money < total)
            {
                Console.WriteLine("store owner: BROKE. come back when you got money.");
                Thread.Sleep(1500);
                return;
            }

            // pay
            data.Money -= total;

            // move cart -> inventory (save items by ID)
            foreach (var entry in shop.Cart)
            {
                int id = entry.Key;
                int qty = entry.Value.Quantity;

                if (data.Inventory.ContainsKey(id))
                    data.Inventory[id] += qty;
                else
                    data.Inventory[id] = qty;
            }

            SaveSystem.Save(data);

            Console.WriteLine($"store owner: deal. money left: {data.Money}$");
            Console.WriteLine("store owner: saved.");
            Thread.Sleep(1500);
        }
    }
}

