using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyramidLibrary.Models
{
    public class Card
    {
        public int Number { get; set; }
        public string Suit { get; set; }
        public string Name { get; set; }
        public Card(int number, string suit)
        {
            Number = number;
            Suit = suit;
            Name = number.ToString() + suit;
        }


    }
}
