using System;
using System.Collections.Generic;

namespace POS
{
    class Menu
    {

        public static void MenuPrompt()
        {

            // ask user for item to buy X

            // validate input
            // foreach over games to see if user entered input matches game title
                // if user entered input matches game title get out of foreach loop
                // if user entereed input doesn't match, how do i know?

            // ask for quantity

            // validate input

            // see menu? choose another to buy?  complete purchase?




            List<Game> listOfGames = ItemDatabase.CreateGamesMenu();
            Game matchedGame;          //loop to game menu
            while (true)
            {
                bool matchFound = false;
                Console.WriteLine("Please enter the games that you would like to purchase:");
                Console.WriteLine("=============================");

                var gameTitleChosenByUSer = Console.ReadLine();
                Console.WriteLine("===============");



                foreach (var game in listOfGames)  //right now we call the list by gaming.
                {
                   // Console.WriteLine(game.Title);
                    if (string.Equals(gameTitleChosenByUSer, game.Title))
                    {
                        matchFound = true;
                        Console.WriteLine(game.Title + game.Price);
                        break;
                    }
                    
                }
                
            }
        }
        

        //making the product list
        class ItemDatabase
        {
            public static List<Game> CreateGamesMenu()
            {
                List<Game> gameslist = new List<Game>
                {
                    new Game("Diablo","$10.00"),
                    new Game("SOCOM", "$20.00"),
                    new Game("Red Dead Redemtion","$30.00"),
                    new Game("A","$30.00"),
                };
                return gameslist;

                

            }
        }
        
        /*
         * Prompt User Select Menu Items by Categories or List All
         * Select Quant
         * Store line total and name of product in recetipt
         */

        public void promptReciept()
        {
            string addItem = "Some Menue Item"; ///Use this as your string a new menu item
            int lineItemTotal = 1 ; /// put the total of a menu item here
            var newRecieptItem = new Reciept(addItem,lineItemTotal);          
            Reciept.AddITemToReciept(newRecieptItem);  //this will add a RecieptItem to the Reciept list
            
        }
        
    }

}
