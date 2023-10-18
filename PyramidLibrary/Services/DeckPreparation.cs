using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PyramidLibrary.Models;

namespace PyramidLibrary.Services
{
    public static class DeckPreparation
    {
        public static List<Card> CreateDeck()
        {
            int[] numberList = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            string[] suitsList = { "H", "D", "C", "S" };

            List<Card> deck = new List<Card>();
            foreach (int number in numberList)
            {
                foreach (string suit in suitsList)
                {
                    deck.Add(new Card(number, suit));
                }
            }
            return deck;
        }

        public static void Shuffle<T>(List<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static List<IPosition> PopulateDeckPositions(List<Card> deck)
        {
            List < IPosition > deckPos = new List <IPosition>();
            int n = 0;
            foreach (Card card in deck)
            {
                deckPos.Add(new DeckPosition(n,card));
                n++;
            }
            return deckPos;
        }


    }
}
