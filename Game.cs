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

        private Item _copySmash;
        private Item _shotGun;
        private Item _theFlops;
        private Item _trueDrip;
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
            _copySmash = new Item { Name = "A copy of Smash", Cost = 33};
            _shotGun = new Item { Name = "ShotGun", Cost = 36};
            _theFlops = new Item { Name = "Fresh Flops", Cost = 900};
            _trueDrip = new Item { Name = "The Drip", Cost = 1000};

            _ShopInventory = new Item[] { _copySmash, _shotGun, _theFlops, _trueDrip };
            
        }

        public void Start()
        {
            InitializeItems();
            _gameOver = false;
            _currentScene = 0;
           
            _shop = new Shop(_ShopInventory);
            _player = new Player();
        }

        public void Update()
        {
            DisplayCurrentScene();
            Console.Clear();
        }

        public void End()
        {
            Console.WriteLine("Thanks for shopping!");
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
            bool loadSuccessfull = true;

            //Create a new stream writer
            StreamWriter writer = new StreamWriter("SaveData.txt");
            //...return false
            loadSuccessfull = false;
        
            //Save player 
            _player.Save(writer);

            //Close writer when done saving
            writer.Close();
        }

        public bool Load()
        {
            bool loadSuccessfull = true;

            //If the file exist..
            if (!File.Exists("SaveData.txt"))
                //..return false
                loadSuccessfull = false;

            //Create a new reader to read from the text file
            StreamReader reader = new StreamReader("SaveData.txt");

                _player = new Player();

            if (!_player.Load(reader))
                loadSuccessfull = false;

            //Close the reader once loading is finished
            reader.Close();
            return loadSuccessfull;
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
            //Lets the player start the shop or load a save 
            int choice = GetInput("Welcome to the RPG Shop Simulator!" + "What would you like to do?", "Start Shopping", "Load Inventory");

            if (choice == 0)
            {
                _currentScene = 2;
            }
            else if (choice == 1)
            {
                if (Load())
                {
                    Console.WriteLine("Load Successful");
                    Console.ReadKey(true);
                    Console.Clear();
                    _currentScene = 2;
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

            itemName[_ShopInventory.Length ] = "Save";
            itemName[_ShopInventory.Length +1] = "Exit";

            return itemName;
        }

        void DisplayShopMenu()
        {
            //shows the player gold and inventory
            Console.WriteLine("Your gold: " + _player.Gold);
            Console.WriteLine("Your inventory: ");

            for (int i = 0; i < _player.GetItemNames().Length; i++)
            {
                Console.WriteLine(_player.GetItemNames()[i]);
            }

            //Condenses the code so that all the player input goes through 3 conditions


            int choice = GetInput("\nWelcome! Please selct an item.", GetShopMenuOptions());
            string[] _shopInventory = _shop.GetItemNames();
            if (_shop.Sell(_player, choice))
            {
                Console.WriteLine("You purchased the " + _shopInventory[choice]);

            }
            else if (choice == _shopInventory.Length)
            {
                Save();
                Console.WriteLine("Saved Game");
                Console.ReadKey(true);
                Console.Clear();
                return;
            }
            else if (choice == _shopInventory.Length + 1)
            {
                _gameOver = true;
                return;
            }
            
        }
    }    
}
            
