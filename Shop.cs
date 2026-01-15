using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Game
{
    class Shop
    {
        public List<ShopItem> ShopItems { get; private set; }
        public Dictionary<int, (int Price, int Quantity)> Cart = new Dictionary<int, (int, int)>();

        private Random rnd;

        public Shop(Random random)
        {
            rnd = random;

            ShopItems = new List<ShopItem>()
            {
                new ShopItem(25, "basic sword", rnd, 1, "cheap, but does the job"),
                new ShopItem(30, "basic bow", rnd, 2, "you might lose an eye using this"),
                new ShopItem(10, "30 arrows", rnd, 3, "they work... kinda"),
                new ShopItem(15, "small shied", rnd, 4, "can block an atomic bomb (probably)"),
                new ShopItem(250, "cool hat", rnd, 5, "all the girls will want you"),
                new ShopItem(5, "fuckass hat", rnd, 6, "no girl will want you"),
                new ShopItem(150, "dragon sword", rnd, 7, "it kills dragons. what else do you need in a sword"),
                new ShopItem(175, "sexy bow", rnd, 8, "it has flames and poison and blah blah blah"),
                new ShopItem(25, "nice sandwich", rnd, 9, "my mom made it, its nice"),
                new ShopItem(75, "op healing potion", rnd, 10, "can cure cancer"),
                new ShopItem(200000, "nuclear submarine", rnd, 11, "dont let the goverment catch you"),
                

            };
        }

        public void RunShop(SaveData data)
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
            bool shopping = true;
            while (shopping)
            {
                Console.Clear();
                Console.WriteLine("=== STORE ===");
                
                foreach (ShopItem item in ShopItems)
                {
                    Console.WriteLine($"{item.id}. {item.name} - {item.price}$ | {item.info} | {item.stock} left");
                }

                if (Cart.Count == 0)
                {
                    Console.WriteLine("\ngo ahead and add some items");
                }
                else
                {
                    int totalprice = 0;
                    Console.WriteLine($"\ncart:");

                    foreach (var entry in Cart)
                    {
                        int id = entry.Key;
                        int qty = entry.Value.Quantity;
                        int price = entry.Value.Price;
                        int sum = price * qty;
                        totalprice += sum;

                        ShopItem item = ShopItems.First(i => i.id == id);
                        Console.WriteLine($"{id}. {item.name} x{qty} - {sum}$");
                    }

                    Console.WriteLine($"\ntotal {totalprice}$");
                }

                Console.WriteLine("\nstore owner: Stop staring at me... enter the item number or 0 to checkout: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int choice))
                {
                    Console.WriteLine("store owner: numbers mann");
                    Thread.Sleep(1500);
                    continue;
                }

                if (choice == 0)
                {
                    Console.WriteLine("store owner: checking out");
                    Thread.Sleep(1500);
                    shopping = false;
                    break;
                }

                ShopItem selected = ShopItems.FirstOrDefault(i => i.id == choice);
                if (selected == null)
                {
                    Console.WriteLine("store owner: What? try again");
                    Thread.Sleep(1500);
                    continue;
                }

                if (selected.stock <= 0)
                {
                    Console.WriteLine("store owner: dang it! out of stock");
                    Thread.Sleep(1500);
                    continue;
                }

                if (Cart.ContainsKey(selected.id))
                {
                    Cart[selected.id] = (selected.price, Cart[selected.id].Quantity + 1);
                }
                else
                {
                    Cart.Add(selected.id, (selected.price, 1));
                }

                selected.stock--;

                Console.WriteLine($"store owner: {selected.name} added to cart!");
                Thread.Sleep(1500);
            }

            Console.Clear();
            Console.WriteLine("=== Cart ===");
            foreach (var entry in Cart)
            {
                int id = entry.Key;
                int price = entry.Value.Price;
                int qty = entry.Value.Quantity;
                int sum = price * qty;
                ShopItem item = ShopItems.First(i => i.id == id);
                Console.WriteLine($"-{item.name}. X{qty} | {sum}$");
            }

            Console.WriteLine("Do you want to cancel an item?");
            int cancel = 1;
            bool itemcancel = true;
            while (itemcancel)
            {
                Console.WriteLine("1 - yes | 2 - no");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out cancel) && (cancel == 1|| cancel == 2))
                {
                    Console.WriteLine("1 - yes | 2 - no");
                }
                else
                {
                    itemcancel = false;
                }
                
            }
            if (cancel == 1)
            {
                bool canceling = true;
                while (canceling)
                {
                Console.Clear();
                foreach (var entry in Cart)
                {
                    int ids = entry.Key;
                    int price = entry.Value.Price;
                    int qty = entry.Value.Quantity;
                    int sum = price * qty;
                    ShopItem item = ShopItems.First(i => i.id == ids);
                    Console.WriteLine($"{ids}. -{item.name} X{qty}| {price}$");
                }
                Console.WriteLine("\nEnter the item number to cancel or 0 to exit");
                string cancelid = Console.ReadLine();
                if (!int.TryParse(cancelid, out int id))
                    {
                        Console.WriteLine("Item number.");
                        continue;
                    }
                if (id == 0)
                    {
                        canceling = false;
                    }

                else if (!Cart.ContainsKey(id))
                    {
                        Console.WriteLine("try again");
                        continue;
                    }    
                else
                    {
                        Cart[id] = (Cart[id].Price, Cart[id].Quantity - 1);
                        if (Cart[id].Quantity <= 0)
                        {
                            Cart.Remove(id);
                        }
                    }

                }
            }

            Console.WriteLine("okay, now pay");
            int total = 0;
            foreach (var entry in Cart.Values)
             total += entry.Price * entry.Quantity;

            if (data.Money < total)
            {
                Console.WriteLine($"Store owner: BROKE! you have {data.Money}. you need {total}");
                Console.WriteLine();
                return;
            } 

            data.Money -= total;
            Console.WriteLine($"Store owner: thats {total}. | Money = {data.Money}");

            foreach (var entry in Cart)
            {
                int id = entry.Key;
                int qty = entry.Value.Quantity;

                ShopItem item = ShopItems.First(i => i.id == id);

                for (int i = 0; i < qty; i++)
                {
                    data.Inventory.Add(item.id);
                }
            }
         Cart.Clear();


           

        }
    }
}
