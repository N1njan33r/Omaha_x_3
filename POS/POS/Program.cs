using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    class Program
    {
        static void Main(string[] args)
        {
            Products.ListProducts();

            Console.WriteLine("Omaha POS System v3.0");
            Menu.MenuPrompt();

            Console.WriteLine("Goodbye!");
            Console.ReadKey();
        }
    }
}
