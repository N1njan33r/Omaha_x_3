using System;
using System.Collections.Generic;
using System.Linq;

namespace POS
{
    class Menu
    {
	
        static bool sortByName;
        public static void MenuPrompt()
        {
            Console.WriteLine("Please select an option:" + Environment.NewLine + "1 - View games by Name" + Environment.NewLine + "2 - View games by Category");
            SortSelection();
        }

        static int gamePage;
        static void SortSelection()
        {
            int i = 1;
            Console.Write("Selection: ");
            ConsoleKeyInfo userInput = Console.ReadKey();
            Console.WriteLine();
            if (!(userInput.KeyChar.Equals('1') | userInput.KeyChar.Equals('2')))
            {
                Console.WriteLine("Invalid selection. Please try again..." + Environment.NewLine);
                SortSelection();
            }
            else if (userInput.KeyChar.Equals('1'))
            {
                Console.Clear();
                Console.WriteLine("Select a game: ");
                foreach (var game in Products.Games)
                {
                    Console.WriteLine(i.ToString() + " - " + game.Name);
                    i++;
                }
                sortByName = true;
                GameSelection();
            }
            else if (userInput.KeyChar.Equals('2'))
            {
                string _category = "";
                Console.Clear();
                Console.WriteLine("Select a category: ");
                foreach (var game in Products.Games)
                {
                    if (game.Category.Equals(_category))
                        continue;
                    Console.WriteLine(i.ToString() + " - " + game.Category);
                    _category = game.Category;
                    i++;
                }

                CategorySelection();
            }
        }

        static string _selectedCategory;
        static void CategorySelection()
        {
            int i = 1;
            Console.Write("Selection: ");
            ConsoleKeyInfo userInput = Console.ReadKey();
            Console.WriteLine();
            if (!(userInput.KeyChar.Equals('1') | userInput.KeyChar.Equals('2') | userInput.KeyChar.Equals('3') | userInput.KeyChar.Equals('4')))
            {
                Console.WriteLine("Invalid selection. Please try again..." + Environment.NewLine);
                CategorySelection();
            }
            else if (userInput.KeyChar.Equals('1'))
            {
                Console.Clear();
                Console.WriteLine("Select a game: ");
                foreach (var action in Products.Games)
                {
                    if (action.Category.Equals("Action"))
                    {
                        Console.WriteLine(i.ToString() + " - " + action.Name);
                        i++;
                    }
                }
                _selectedCategory = "Action";
            }
            else if (userInput.KeyChar.Equals('2'))
            {
                Console.Clear();
                Console.WriteLine("Select a game: ");
                foreach (var sports in Products.Games)
                {
                    if (sports.Category.Equals("Sports"))
                    {
                        Console.WriteLine(i.ToString() + " - " + sports.Name);
                        i++;
                    }
                }
                _selectedCategory = "Sports";
            }
            else if (userInput.KeyChar.Equals('3'))
            {
                Console.Clear();
                Console.WriteLine("Select a game: ");
                foreach (var adventure in Products.Games)
                {
                    if (adventure.Category.Equals("Adventure"))
                    {
                        Console.WriteLine(i.ToString() + " - " + adventure.Name);
                        i++;
                    }
                }
                _selectedCategory = "Adventure";
            }
            else if (userInput.KeyChar.Equals('4'))
            {
                Console.Clear();
                Console.WriteLine("Select a game: ");
                foreach (var fighting in Products.Games)
                {
                    if (fighting.Category.Equals("Fighting"))
                    {
                        Console.WriteLine(i.ToString() + " - " + fighting.Name);
                        i++;
                    }
                }
                _selectedCategory = "Fighting";
            }
            sortByName = false;
            GameSelection();
        }

        public static Game _selectedGame;
        static void GameSelection()
        {
            Console.Write("Selection: ");
            ConsoleKeyInfo userInput = Console.ReadKey();
            Console.WriteLine();
            if (sortByName)
            {
                if (userInput.KeyChar.Equals('.'))
                {
                    Console.WriteLine("===UNDER CONSTRUCTION===");
                    GameSelection();
                }
                else if (int.TryParse(userInput.KeyChar.ToString(), out int number))
                {
                    if (number > 0 && number <= 9)
                    {
                        Console.Clear();
                        Game[] game = Products.Games.ToArray();
                        _selectedGame = game[number - 1];
                        Console.WriteLine(Environment.NewLine + _selectedGame.Name + "\t" + "$" + _selectedGame.Price.ToString() + @"/ea.");
                        Console.WriteLine("==========================================================================");
                        Console.WriteLine("Description: " + _selectedGame.Description);
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection. Please try again..." + Environment.NewLine);
                        GameSelection();
                    }
                }
            }
            if (!sortByName)
            {
                if (int.TryParse(userInput.KeyChar.ToString(), out int number))
                {
                    if (number > 0 && number <= 3)
                    {
                        Console.Clear();
                        if (_selectedCategory == "Sports")
                        {
                            number += 3;
                        }
                        if (_selectedCategory == "Adventure")
                        {
                            number += 6;
                        }
                        if (_selectedCategory == "Fighting")
                        {
                            number += 9;
                        }
                        Game[] game = Products.Games.ToArray();
                        _selectedGame = game[number - 1];
                        Console.WriteLine(Environment.NewLine + _selectedGame.Name + "\t" + "$" + _selectedGame.Price.ToString() + @"/ea.");
                        Console.WriteLine("==========================================================================");
                        Console.WriteLine("Description: " + _selectedGame.Description);
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection. Please try again..." + Environment.NewLine);
                        GameSelection();
                    }
                }
            }

            EnterQty();
        }

        public static double lineTotal;
        static void EnterQty()
        {
            do
            {
                Console.Write(Environment.NewLine + "Enter quantity: ");
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out int result))
                {
                    lineTotal = result * _selectedGame.Price;
                    Console.WriteLine("Qty: " + result + " | $" + lineTotal);
                    var newReceiptItem = new Receipt(_selectedGame.Name, lineTotal);
                    Receipt.AddItemToReceipt(newReceiptItem);
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid selection. Please try again..." + Environment.NewLine);
                    continue;
                }
            } while (true);

            FinalCountdown();
        }

        private static void FinalCountdown()
        {
            Console.Write("Add another item? (y/n): ");
            ConsoleKeyInfo userInput = Console.ReadKey();
            Console.Clear();
            if (!(userInput.KeyChar.Equals('y') | userInput.KeyChar.Equals('n')))
            {
                Console.WriteLine("Invalid input.");
                FinalCountdown();
            }
            else if (userInput.KeyChar.Equals('y'))
                MenuPrompt();
            else if (userInput.KeyChar.Equals('n'))
                Receipt.CreateReceipt();
        }

        // Prompt User Select Menu Items by Categories or List All
        // Select Quant
        // Store line total and name of product in receipt

        public void promptReceipt()
        {
            string addItem = "Some Menu Item"; // Use this as your string a new menu item
            int lineItemTotal = 1; // Put the total of a menu item here
            var newReceiptItem = new Receipt(addItem, lineItemTotal);
            Receipt.AddItemToReceipt(newReceiptItem);  // This will add a ReceiptItem to the Receipt list
        }
    
    }

}
