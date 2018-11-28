using System;
using System.Collections.Generic;
using System.Linq;

namespace POS
{
    class Receipt
    {
        //Creating a list to store Menu values
        //
        public string Item { get; set; }
        public int TotalPriceofItem { get; set; }
        public static double Total { get; set; }


        public Receipt(string item, int TotalPriceofItem) { }

        public static List<Receipt> receiptAsList = new List<Receipt>();

        public static void AddItemToReceipt(Receipt lineItem)
        {
            receiptAsList.Add(lineItem);
        }

        public static void CreateReceipt()
        {
            double subTotal = 0;
            for (int i = 0; i < receiptAsList.Count; i++)
            {
                Console.WriteLine($"{receiptAsList[i].Item}    {receiptAsList[i].TotalPriceofItem}");
            }

            for (int i = 0; i < receiptAsList.Count; i++)
            {
                subTotal = receiptAsList[i].TotalPriceofItem + subTotal;
            }

            //string total = (subTotal * 1.06).ToString("###.##");
            Total = (subTotal * 1.06);

            Console.WriteLine($"Tax: 6%");
            Console.WriteLine($"Subtotal: {subTotal}");
            Console.WriteLine($"Total: {Total.ToString("###.##")}");
            
        }
    }
}
