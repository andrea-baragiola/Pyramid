using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyramidLibrary.Models.Decks
{
    public class CustomDeck : Deck, IDeck
    {
        public CustomDeck(List<Card> oldcards)
        {
            Cards = oldcards;
        }


    }
}
