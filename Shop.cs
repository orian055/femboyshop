using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Game
{
    class Shop
    {
        public List<Item> Items { get; private set; }
        public Dictionary<int, (int Price, int Quantity)> Cart = new Dictionary<int, (int, int)>();

        private Random rnd;

        // Constructor: build the shop items here
        public Shop(Random random)
        {
            rnd = random;

            Items = new List<Item>()
            {
                new Item(25, "basic sword", rnd, 1, "cheap, but does the job"),
                new Item(30, "basic bow", rnd, 2, "you might lose an eye using this"),
                new Item(10, "30 arrows", rnd, 3, "they work... kinda"),
                new Item(15, "small shied", rnd, 4, "can block an atomic bomb (probably)"),
                new Item(250, "cool hat", rnd, 5, "all the girls would want you"),
                new Item(5, "fuckass hat", rnd, 6, "no girl will want you"),
                new Item(150, "dragon sword", rnd, 7, "it kills dragons. what else do you need in a sword"),
                new Item(175, "sexy bow", rnd, 8, "it has flames and poison and blah blah blah"),
                new Item(25, "nice sandwich", rnd, 9, "my mom made it, its nice"),
                new Item(75, "op healing potion", rnd, 10, "can cure cancer"),
                new Item(200000, "nuclear submarine", rnd, 11, "dont let the goverment catch you"),

            };
        }

        public void RunShop()
        {
            bool shopping = true;
            while (shopping)
            {
                Console.Clear();
                Console.WriteLine("=== STORE ===");
                
                foreach (Item item in Items)
                {
                    Console.WriteLine($"{item.Id}. {item.Name} - {item.Price}$ | {item.Info} | {item.Stock} left");
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
                        int total = price * qty;
                        totalprice += total;

                        Item item = Items.First(i => i.Id == id);
                        Console.WriteLine($"{id}. {item.Name} x{qty} - {total}$");
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

                Item selected = Items.FirstOrDefault(i => i.Id == choice);
                if (selected == null)
                {
                    Console.WriteLine("store owner: What? try again");
                    Thread.Sleep(1500);
                    continue;
                }

                if (selected.Stock <= 0)
                {
                    Console.WriteLine("store owner: dang it! out of stock");
                    Thread.Sleep(1500);
                    continue;
                }

                if (Cart.ContainsKey(selected.Id))
                {
                    Cart[selected.Id] = (selected.Price, Cart[selected.Id].Quantity + 1);
                }
                else
                {
                    Cart.Add(selected.Id, (selected.Price, 1));
                }

                selected.Stock--;

                Console.WriteLine($"store owner: {selected.Name} added to cart!");
                Thread.Sleep(1500);
            }
        }
    }
}
