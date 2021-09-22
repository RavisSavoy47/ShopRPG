using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ShopRPG
{
    public struct Item
    {
        public string Name;
        public int Cost;
    }

    class Game
    {

        private Shop _shop;
        private Player _player;
        private bool _gameOver;
        private int _currentScene;
        private Item[] _ShopInventory;
        public void Run()
        {
            Start();

            while (!_gameOver)
            {
                Update();
            }

            End();
        }

        public void InitializeItems()
        {
            Item copySmash = new Item { Name = "A copy of Smash", Cost = 33};
            Item shotGun = new Item { Name = "ShotGun", Cost = 36};

            Item theFlops = new Item { Name = "Fresh Flops", Cost = 900};
            Item trueDrip = new Item { Name = "The Drip", Cost = 1000};

            _ShopInventory = new Item[] { copySmash, shotGun, theFlops, trueDrip };
        }

        public void Start()
        {
            _gameOver = false;
            _currentScene = 0;
            InitializeItems();

        }

        public void Update()
        {
            DisplayCurrentScene();
        }

        public void End()
        {

        }

        int GetInput(string description, params string[] options)
        {
            string input = "";
            int inputReceived = -1;

            while (inputReceived == -1)
            {
                //Print options
                Console.WriteLine(description);
                for (int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine((i + 1) + ". " + " " + options[i]);
                }
                Console.Write("> ");

                //Get input from player
                input = Console.ReadLine();

                //If the player typed an int...
                if (int.TryParse(input, out inputReceived))
                {
                    //...decrement the input and check if it's within the bounds of the array
                    inputReceived--;
                    if (inputReceived < 0 || inputReceived >= options.Length)
                    {
                        //Set input received to be the default value
                        inputReceived = -1;
                        //Display error message
                        Console.WriteLine("Invalid Input");
                        Console.ReadKey(true);
                    }
                    Console.Clear();
                }
                //If the player didn't type an int
                else
                {
                    //set inpurt recieved to be default value
                    inputReceived = -1;
                    Console.WriteLine("Invalid Input Bro!");
                    Console.ReadKey(true);
                    Console.Clear();
                }


            }
            return inputReceived;
        }

        public void Save()
        {

        }

        public void Load()
        {

        }

      
        void DisplayCurrentScene()
        {
            switch (_currentScene)
            {
                case 0:
                    DisplayOpeningScene();
                    break;
                case 1:
                    GetShopMenuOptions();
                    break;
                case 2:
                    DisplayShopMenu();
                    break;

                    Console.WriteLine("Invaild scene index");
                    break;
            }
        }


        void DisplayOpeningScene()
        {
            int choice = GetInput("Welcome to the RPG Shop Simulator!" + "What would you like to do?", "Start Shopping", "Load Inventory");

            switch (choice)
            {
                case 0:
                    _currentScene = 2;
                    break;
                case 1:
                    if (Load())
                    {
                        Console.WriteLine("Load Successful");
                        Console.ReadKey(true);
                        Console.Clear();
                        _currentScene = 3;
                    }
                    else
                    {
                        Console.WriteLine("Load Failed.");
                        Console.ReadKey(true);
                        Console.Clear();
                    }

            }
        }

        private string[] GetShopMenuOptions()
        {
            string[] itemName = new string[_ShopInventory.Length + 2];

            //Copy the values from the old array into the new array
            for (int i = 0; i < _ShopInventory.Length; i++)
            {
                itemName[i] = _ShopInventory[i].Name;
            }

            itemName[_ShopInventory.Length - 1] = "Save";
            itemName[_ShopInventory.Length] = "Exit";

            return itemName;
        }

        public void PrintInventory(Item[] inventory)
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + inventory[i].Name + inventory[i].Cost);
            }
        }

        void DisplayShopMenu()
        {
            Console.WriteLine("Welcome! Please selct an item.");
            PrintInventory(_ShopInventory);

            int input = Console.ReadKey().KeyChar;

            int itemIndex = -1;
            switch (input)
            {
                case '1':
                    {
                        itemIndex = 0;
                        break;
                    }
                case '2':
                    {
                        itemIndex = 1;
                        break;
                    }
                case '3':
                    {
                        itemIndex = 2;
                        break;
                    }
                default:
                    {
                        return;
                    }
            }

        }
    }    
}
            
