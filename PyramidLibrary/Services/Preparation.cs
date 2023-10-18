using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PyramidLibrary.Models;

namespace PyramidLibrary.Services
{
    public static class Preparation
    {
        public static List<BoardPosition> PopulatePositions(string row, int[] shifts, BoardPositionStatus status, List<Card> cardPositions)
        {
            List<BoardPosition> boardPositions = new List<BoardPosition>();
            foreach (int shift in shifts)
            {
                boardPositions.Add(new BoardPosition(row, shift, status, cardPositions[0]));
                cardPositions.RemoveAt(0);
            }
            return boardPositions;
        }

        public static List<Card> PopulateDeck(int[] numberList, string[] suits)
        {
            List<Card> deck = new List<Card>();
            foreach (int number in numberList)
            {
                foreach (string suit in suits)
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

        public static void PickCardsForBoad(List<Card> deck, out List<Card> cardPositionsA, out List<Card> cardPositionsB, out List<Card> cardPositionsC)
        {
            cardPositionsA = deck.GetRange(0, 1);
            deck.RemoveRange(0, 1);
            cardPositionsB = deck.GetRange(0, 2);
            deck.RemoveRange(0, 2);
            cardPositionsC = deck.GetRange(0, 10);
            deck.RemoveRange(0, 3);
        }
    }
}
