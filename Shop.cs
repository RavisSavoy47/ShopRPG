﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ShopRPG
{
    class Shop
    {
        private int _gold;
        private Item[] _inventory;

        public Shop(Item[] items)
        {
            _gold = 1000;

            _inventory = items;
        }

        public bool Sell(Player player, int itemIndex)
        {
            Item itemYouWant = _inventory[itemIndex];

            if (_gold >= itemYouWant.Cost)
            {
                return true;
            }
            else
            {
                Console.WriteLine("You can't afford this item.");
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

        public bool Load(StreamReader reader)
        {
            if (!int.TryParse(reader.ReadLine(), out _gold))
                return false;

            return true;
        }
    }
}
