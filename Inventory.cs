using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Game
{
   class Inventory
    {
        public void runInv(SaveData data, List<ShopItem> ShopItems)
        {
            

            Console.WriteLine("=== Inventory ===");
            if (data.Inventory.Count == 0)
            {
                Console.WriteLine("you dont have shit man.");
                Thread.Sleep(3000);
                return;
            }
            
            var groups = data.Inventory.GroupBy(id => id);
            foreach (var g in groups)
            {
                int id = g.Key;
                int count = g.Count();

                ShopItem item = ShopItems.First(x => x.id == id);
                Console.WriteLine($"{item.name} x{count}");

                
            }
            Thread.Sleep(3000);
        }
    } 
}