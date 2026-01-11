using System.Collections.Generic;

namespace Game
{
    class SaveData
    {
        public int Money { get; set;} = 0;

        // itemid -> quantity
        public Dictionary<int, int> Inventory { get; set;} = new Dictionary<int, int>();
    }
}