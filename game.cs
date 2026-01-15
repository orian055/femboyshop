using System;
using System.Data.SqlTypes;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            
            Menus menu = new Menus();

            Tut tut = new Tut();
            Work work = new Work();
            Inventory inv = new Inventory();
            Explore exp = new Explore(rnd);
            Shop shop = new Shop(rnd);
            Mountains marea = new Mountains();
            Village vill = new Village();
            
            

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
                                    RunGame(rewrite, rnd, tut, work, exp, inv, shop, marea, vill);
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

                        RunGame(data, rnd, tut, work, exp, inv, shop, marea, vill);
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
                        RunGame(data, rnd, tut, work, exp, inv, shop, marea,vill);
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
        
        
        static void RunGame(SaveData data, Random rnd, Tut tut, Work work, Explore exp, Inventory inv, Shop shop, Mountains marea, Village vill)
        {
            tut.runTut();
           
           bool playing = true;
           while (playing)
            {
                Console.Clear();
                Console.WriteLine("[1] Train");
                Console.WriteLine("[2] Work");
                Console.WriteLine("[3] Gamble");
                Console.WriteLine("[4] Explore");
                Console.WriteLine("[5] ?");
                Console.WriteLine("[6] Inventory");
                Console.WriteLine("[0] Save & Exit");
                string input = Console.ReadLine();
                int choice = int.Parse(input);
                
                if (input == null)
                {
                    Console.WriteLine("(:");
                    continue;
                }

                switch(choice)
                {
                  case 1:
                    Console.WriteLine("coming off strong");
                    Thread.Sleep(3000);
                    break;
                  case 2: 
                  Console.WriteLine("You dont have a job, lets get creative!");
                  Thread.Sleep(3000);
                  work.Runwork(data, rnd);
                  break;
                  case 3:
                     Console.WriteLine("I Like you");
                     Thread.Sleep(3000);
                     break;
                  case 4: 
                  Console.WriteLine("YAY! where we goin?");
                  exp.RunExplore(data, marea, vill);
                  Thread.Sleep(3000);
                     break;
                  case 5: 
                  Console.WriteLine("Lets do something secret");
                  Thread.Sleep(3000);
                     break;
                  case 6: 
                  Console.WriteLine("check yo pockets");
                  Thread.Sleep(3000);
                  inv.runInv(data, shop.ShopItems);
                     break;
                  case 0:
                  Console.WriteLine("Ill be waiting for you");
                  SaveSystem.Save(data);
                  playing = false;
                  Thread.Sleep(3000);
                     break;
                  default:
                  Console.WriteLine("pick 1-6");
                  Thread.Sleep(3000);
                  break; 
                }
                
            }
            
        }
    }
}

