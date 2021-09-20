using System;
using System.Collections.Generic;
using System.Text;

namespace ShopRPG
{

    class Game
    {
        private Shop _shop;
        private PLayer _player;
        private bool _gameOver = false;
        private int _currentScene = 0;
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

        }

        public void Start()
        {

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

        }


        void DisplayOpeningScene()
        {
            int choice = GetInput("Welcome to the RPG Shop Simulator!" + "What would you like to do?", "Start Shopping", "Load Inventory");

            if (choice == 0)
            {

            }
        }

        void GetShopMenuOptions()
        {

        }

        void DisplayShopMenu()
        {

        }
    }    
}
            
