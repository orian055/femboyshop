using System;

namespace Game
{
    class ShopItem
    {
      public int price;
      public string name;
      public int stock;
      public int id;
      public string info;
    public ShopItem(int price, string name,Random rnd, int id, string info)
        {
            this.price = price;
            this.name = name;
            this.id = id;
            this.stock = rnd.Next(0,10);
            this.info = info;
        }
    
    public void ChangePrice(int new_price)
        {
            this.price = new_price;
        }
}
}