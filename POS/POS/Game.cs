using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    class Game
    {

        public string Title { get; set; }
        public string Price { get; set; }

        public Game(string title, string price)
        {
            Title = title;
            Price = price;
        }


    }
}
