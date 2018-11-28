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
            Console.WriteLine("Omaha POS System v3.0" + Environment.NewLine + "Please select an option:");
            Console.WriteLine("1 - View games by Name" + Environment.NewLine + "2 - View games by Category");
            SortSelection();
        }

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
                if (int.TryParse(userInput.KeyChar.ToString(), out int number))
                {
                    if (number > 0 && number <= Products.Games.Count)
                    {
                        Game[] game = Products.Games.ToArray();
                        _selectedGame = game[number - 1];
                        Console.WriteLine(Environment.NewLine + _selectedGame.Name + "\t" + "$" + _selectedGame.Price.ToString() + @"/ea.");
                        Console.WriteLine("==========================================================================");
                        Console.WriteLine("Description: " + _selectedGame.Description);
                    }
                }
            }
            if (!sortByName)
            {
                if (int.TryParse(userInput.KeyChar.ToString(), out int number))
                {
                    if (number > 0 && number <= 3)
                    {
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
                }
            }

            EnterQty();
        }

        public static double lineTotal;
        static void EnterQty()
        {
            Console.Write(Environment.NewLine + Environment.NewLine + "Enter quantity: ");
            string userInput = Console.ReadLine();
            if (int.TryParse(userInput, out int result))
            {
                lineTotal = result * _selectedGame.Price;
            }
            Console.WriteLine("Qty: " + result + " | $" + lineTotal);
        }

        // Prompt User Select Menu Items by Categories or List All
        // Select Quant
        // Store line total and name of product in receipt

        public void promptReceipt()
        {
            string addItem = "Some Menu Item"; ///Use this as your string a new menu item
            int lineItemTotal = 1 ; /// put the total of a menu item here
            var newReceiptItem = new Receipt(addItem,lineItemTotal);          
            Receipt.AddItemToReceipt(newReceiptItem);  //this will add a ReceiptItem to the Receipt list            
        }        
    }
}
