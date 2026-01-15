using System.Collections.Generic;

namespace Game
{
    class SaveData
    {
        public int Money { get; set;} = 0;

        // itemid -> quantity
        public List<int> Inventory { get; set;} = new List<int>();
    }
}