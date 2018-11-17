using System;
using System.Collections.Generic;
using System.Linq;

namespace POS
{
    class Reciept
    {
        //Creating a list to store Menu values
        //
        public string Item { get; set; }
        public int TotalPriceofItem { get; set; }

        public Reciept(string item, int TotalPriceofItem) { }

        public static List<Reciept> recieptAsList = new List<Reciept>();

        public static void AddITemToReciept(Reciept lineItem)
        {
            recieptAsList.Add(lineItem);
        }

        public static void CreateReciept()
        {
            double subTotal = 0;
            for (int i = 0; i < recieptAsList.Count; i++)
            {
                Console.WriteLine($"{recieptAsList[i].Item}    {recieptAsList[i].TotalPriceofItem}");
            }

            for (int i = 0; i < recieptAsList.Count; i++)
            {
                subTotal = recieptAsList[i].TotalPriceofItem + subTotal;
            }

            string total = (subTotal * 1.06).ToString("###.##");

            Console.WriteLine($"Tax: 6%");
            Console.WriteLine($"Subtotal: {subTotal}");
            Console.WriteLine($"Total: {total}");
            

        }
    }
}
