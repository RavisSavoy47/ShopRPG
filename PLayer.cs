using System;
using System.Collections.Generic;
using System.Text;

namespace ShopRPG
{
    class Player
    {
        private int _gold;
        private Item[] _inventory;

        public Item[] Inventory
        {
            get
            {
                return _inventory;
            }
        }

        public int Gold
        {
            get
            {
                return _gold;
            }
        }

        public Player()
        {
            _gold = 1000;

            _inventory = new Item[4];
        }

        public bool Buy(Item item, int inventoryIndex)
        {
            if(_gold >= item.Cost)
            {
                _gold -= item.Cost;

                _inventory[inventoryIndex] = item;
                return true;
            }

            return false;
        }

        public string[] GetItemNames()
        {
            string[] itemNames = new string[_inventory.Length];

            for (int i = 0; i < _inventory.Length; i++)
            {
                itemNames[i] = _inventory[i].Name;
            }

            return itemNames;
        }
    }
}
