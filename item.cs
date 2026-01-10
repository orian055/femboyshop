using System;

namespace Game
{
    class Item
    {
      public int Price;
      public string Name;
      public int Stock;
      public int Id;
      public string Info;
    public Item(int price, string name,Random rnd, int id, string info)
        {
            Price = price;
            Name = name;
            Id = id;
            Stock = rnd.Next(0,10);
            Info = info;
        }
    }
}