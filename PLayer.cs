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

            _inventory = new Item[0];
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

        public virtual void Save(StreamWriter writer)
        {
            writer.WriteLine(_inventory.Length);
            writer.WriteLine(_gold);

            for (int i = 0; i < _inventory.Length; i++)
            {
                writer.WriteLine(_inventory[i].Name);
            }
        }

        public bool Load(StreamReader reader)
        {
            if (!int.TryParse(reader.ReadLine(), out int inventoryLength))
                return false;

            _inventory = new Item[inventoryLength];


            if (!int.TryParse(reader.ReadLine(), out _gold))
                return false;

            for (int i = 0; i <_inventory.Length; i++)
            {
                _inventory[i].Name = reader.ReadLine();
            }

           

            return true;
        }
    }
}
