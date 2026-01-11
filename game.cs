using System;
using System.Data.SqlTypes;
using System.Net;
using System.Reflection.Metadata.Ecma335;
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
                        if (SaveSystem.SaveExits())
                            {
                                Console.WriteLine("a save file already exists. rewrite it?  1 - yes | 2 - no");
                                string rewite = Console.ReadLine();
                                if (!int.TryParse(rewite, out int yes))
                                {
                                    Console.WriteLine("1 - yes | 2 - no");
                                    Thread.Sleep(2500);
                                    break;
                                }
                                else if (yes == 1)
                                {
                                    Console.WriteLine("no going back now");
                                    SaveData rewrite = new SaveData { Money = 100};
                                    SaveSystem.Save(rewrite);
                                    RunGame(rewrite, rnd, intro);
                                    break;
                                }
                                else if (yes == 2)
                                {
                                    Console.WriteLine("be carefull");
                                    break;
                                }

                            }
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
                            Thread.Sleep(2500);
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
                            Thread.Sleep(2500);
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

                        Thread.Sleep(2500);
                        break; 
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
                        Thread.Sleep(2500);
                        break;
                }
            }
        }
        
        
        static void RunGame(SaveData data, Random rnd, Intro intro)
        {
           
            Shop shop = new Shop(rnd);

            Console.Clear();
            Console.WriteLine($"Money: {data.Money}$");
            Thread.Sleep(3000);

            intro.runIntro();
            Thread.Sleep(3000);

            shop.RunShop();

            
            if (shop.Cart.Count == 0)
            {
                Console.WriteLine("store owner: you added nothing.");
                Thread.Sleep(3000);
                return;
            }

            
            int total = 0;
            foreach (var entry in shop.Cart)
                total += entry.Value.Price * entry.Value.Quantity;

            Console.WriteLine($"\nstore owner: thats {total}$");
            Console.WriteLine($"you: i have {data.Money}$");
            Thread.Sleep(3000);
            // i plan to add a neogotiation option.
            if (data.Money < total)
            {
                Console.WriteLine("store owner: Get your money up boy");
                Thread.Sleep(3000);
                return;
            }

            
            data.Money -= total;

            
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

            Console.WriteLine("store owner: come back soon!");
            Console.WriteLine($"money left: {data.Money}$");
            Console.WriteLine("(saved.)");
            Thread.Sleep(3000);
        }
    }
}

