using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyramidLibrary.Models.Decks;

//public class CustomDeck : Deck, IDeck
//{
//    public CustomDeck(List<Card> oldcards)
//    {
//        Cards = oldcards;
//    }
//}

public class CustomDeck : Deck, IDeck
{
    public CustomDeck(List<Card> oldCards)
    {
        Cards = oldCards.Select(card => new Card(card.Number, card.Suit, card.Name)).ToList();
    }
}
