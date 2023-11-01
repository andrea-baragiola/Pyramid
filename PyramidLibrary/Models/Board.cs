using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyramidLibrary.Models
{
    public class Board : IBoard
    {
        public int Id { get; private set; }
        public Pyramid Pyramid { get; private set; }
        public MainDeck Deck { get; private set; }
        public DiscardDeck DiscardDeck { get; private set; }

        public Board(int numberOfRows, FullDeck deck)
        {
            Pyramid = new(deck, numberOfRows);
            Deck = new MainDeck(deck);
            DiscardDeck = new();
        }

        public bool Move(IMove move)
        {
            return move.Execute(this);
        }

    }
}
