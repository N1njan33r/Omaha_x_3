using System;
using System.Collections.Generic;
using System.IO;

namespace POS
{
    class Products
    {
        // Properties - Name, Category, Desc, Price
        
        // string filoPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments), "OmahaGames"); just another way to set directory
        // string clientDetails = clientNameTextBox.Text + "," + mIDTextBox.Text + "," + billToTextBox.Text;

        public void CheckFile(string path)
        {
            FileInfo fileInfo = new FileInfo(path);

            if (!fileInfo.Exists)
                Directory.CreateDirectory(fileInfo.Directory.FullName);
            if (!File.Exists(path))
            {
                string clientHeader = "Product Name" + "," + "Category" + "," + "Description" + "," + "Price" + Environment.NewLine;
                File.WriteAllText(path, clientHeader);
                var productLine = new List<string>();
                productLine.Add("Red Dead Redemption 2" + "," + "Action" + "," + "GTA with cowboys." + "," + "59.99");
                try
                {
                    File.AppendAllLines(path, productLine);
                }
                catch
                {
                    
                }
            }
        }

        public List<Game> ListProducts()
        {
            List<Game> games = new List<Game>();

            string filePath = @"C:\Users\Public\Documents\OmahaGames\productlist.csv";
            CheckFile(filePath);

            string[] linesInFile = File.ReadAllLines(filePath);
            string[] ProductDetails = new string[0];
            for (int i = 0; i < linesInFile.Length; i++)
            {
                string currentLine1 = linesInFile[i];
                ProductDetails = currentLine1.Split(',');

                foreach (var p in ProductDetails)
                {
                    //Game game = new Game();
                    //game.Name = p;
                    //games.Add(game);
                }
            }

            return games;
        }

        public List<Game> GenerateDefaultList()
        {
            var a = new List<Game>();

            // Action (Mario Odyssey, Mega Man 11, Call of Duty: Black Ops 4)
            a.Add(new Game("Super Mario Odyssey", "Action", "Mario and Cappy, a spirit that possesses Mario's hat and allows him to take control of other characters and objects, set on a journey across various worlds to save Princess Peach from his nemesis Bowser.", 59.99));

            // Sports (FIFA 19, Madden NFL 19, NHL 19)
            a.Add(new Game("FIFA 19", "Sports", "FIFA 18 is a 2017 football simulation video game in the FIFA series.", 49.99));

            // Adventure (RDR, Monster Hunter, Farcry 5)
            a.Add(new Game("Red Dead Redemption 2", "Adventure", "GTA with cowboys.", 59.99));

            // Fighting (Dragon Ball FighterZ, Soul Caliber VI, )
            a.Add(new Game("Soul Caliber VI", "Fighting", "Soulcalibur VI serves as a reboot to the series, taking place during the 16th century to revisit the events of the first Soulcalibur game to \"uncover hidden truths\"", 59.99));

            return a;
        }
    }
}
