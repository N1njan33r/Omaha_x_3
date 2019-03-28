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
        public double TotalPriceofItem { get; set; }
        public static double Total { get; set; }
        

        public Receipt(string item, double lineTotal)
        {
            Item = item;
            TotalPriceofItem = lineTotal;
        }

        public static List<Receipt> receiptAsList = new List<Receipt>();

        public static void AddItemToReceipt(Receipt lineItem)
        {
            receiptAsList.Add(lineItem);
        }

        static void PrintLine()
        {
            Console.WriteLine(new string('-', receiptAsList.Capacity));
        }

        public static void CreateReceipt()
        {
            double subTotal = 0;
            for (int i = 0; i < receiptAsList.Count; i++)
            {
                // Console.WriteLine($"{receiptAsList[i].Item}                {receiptAsList[i].TotalPriceofItem,10}");
                Console.WriteLine(string.Format("{0, -39} | {1, -39}", receiptAsList[i].Item, receiptAsList[i].TotalPriceofItem));
            }
            

            for (int i = 0; i < receiptAsList.Count; i++)
            {
                subTotal = receiptAsList[i].TotalPriceofItem + subTotal;
            }

            //string total = (subTotal * 1.06).ToString("###.##");
            double tax = (subTotal / 100) * 6;
            Total = subTotal + tax;

            Console.WriteLine($"\t\t\tSubtotal: \t $" + "{0:0.00}", subTotal);
            Console.WriteLine($"\t\t\t6% MI Tax: \t $" + "{0:0.00}", tax);
            Console.WriteLine($"\t\t\tTotal: \t\t $" + "{0:0.00}", Total);

            Payment payment = new Payment();
            payment.ChoosePayment();

        }
    }
}
