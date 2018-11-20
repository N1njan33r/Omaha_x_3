using System;
using System.IO;

namespace POS
{
    class Products
    {
        // Properties - Name, Category, Desc, Price
        public Products()
        {

        }
        public Products(string value)
        {

        }

        static string filePath = @"C:\Users\Public\Documents\OmahaGames\productlist.csv";
        // string clientDetails = clientNameTextBox.Text + "," + mIDTextBox.Text + "," + billToTextBox.Text;
        public static void CreateList()
        {
            FileInfo fileInfo = new FileInfo(filePath);

            if (!fileInfo.Exists)
                Directory.CreateDirectory(fileInfo.Directory.FullName);
            if (!File.Exists(filePath))
            {
                string clientHeader = "Product Name" + "," + "Category" + "," + "Description" + "," + "Price" + Environment.NewLine;
                File.WriteAllText(filePath, clientHeader);
            }
        }
    }
}
