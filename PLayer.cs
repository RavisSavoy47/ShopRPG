using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

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

        public void Buy(Item item)
        {
            _gold -= item.Cost;

            Item[] GetItem = new Item[_inventory.Length + 1];


            for (int i = 0; i < _inventory.Length; i++)
            {
                GetItem[i] = _inventory[i];
            }

            GetItem[GetItem.Length - 1] = item;

            _inventory = GetItem;

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
