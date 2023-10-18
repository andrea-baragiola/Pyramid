using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyramidLibrary.Models
{
    public class DeckPosition : IPosition
    {
        public (string?, int?) Id { get; set; }
        public Card? Card { get; set; }

        public int? IndexInDeck { get; set; }

        public DeckPosition( int indexInDeck, Card card)
        {
            Id = ("deck", indexInDeck);
            Card = card;
        }
    }
}
