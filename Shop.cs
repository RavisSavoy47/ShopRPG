using System;
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

        /// <summary>
        /// if the player has the amount of gold then they can buy the item
        /// </summary>
        /// <param name="item"></param>
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

        /// <summary>
        /// checks the amount of gold and if it has more then it lets the player buy it
        /// </summary>
        /// <param name="player"></param>
        /// <param name="choice"></param>
        /// <returns></returns>
        public bool Sell(Player player, int choice)
        {
            int itemIndex = choice;
            Item itemYouWant = _inventory[itemIndex];

            if (player.Gold >= itemYouWant.Cost)
            {
                return true;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You can't afford this item.");
                Console.ReadKey(true);
            }
            return false;
        }
        
        /// <summary>
        /// Gives the items it names
        /// </summary>
        /// <returns></returns>
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
