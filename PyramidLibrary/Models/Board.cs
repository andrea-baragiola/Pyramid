using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyramidLibrary.Models
{
    public class Board
    {
        public int Id { get; private set; }
        public Pyramid Pyramid { get; private set; }
        public IDeck Deck { get; private set; }
        public DiscardDeck DiscardDeck { get; private set; }

        public Board(int numberOfRows, IDeck deck)
        {
            Deck = deck;
            Pyramid = new Pyramid(Deck, numberOfRows);
            DiscardDeck = new DiscardDeck();            
        }
        
    }
}
