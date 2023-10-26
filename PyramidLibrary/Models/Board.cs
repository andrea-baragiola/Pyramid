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
        public Deck Deck { get; private set; }
        public DiscardDeck DiscardDeck { get; private set; }

        public Board(int numberOfRows)
        {
            Pyramid = new(numberOfRows);
            Deck = new Deck();
            DiscardDeck = new();
            FillPyramid(numberOfRows);
        }

        private void FillPyramid(int numberOfRows)
        {
            List<Card> cardsForPyramid = TakeCorrectAmountOfCardsFromDeck(numberOfRows);
            PlaceCardsInPyramid(numberOfRows, cardsForPyramid);
        }

        private List<Card> TakeCorrectAmountOfCardsFromDeck(int numberOfRows)
        {
            List<Card> cards = new();
            int sum = 0;
            for (int i = 0; i < numberOfRows; i++)
            {
                sum = sum + 1 + i;
            }

            for (int i = 0; i < sum; i++)
            {
                cards.Add(Deck.GiveCard(0));
            }
            return cards;
        }

        private void PlaceCardsInPyramid(int numberOfRows, List<Card> cardsForPyramid)
        {

            for (int j = 0; j < numberOfRows; j++)
            {
                int rowIndex = j;
                int cardIndex = 0;
                for (int i = 0; i <= rowIndex; i++)
                {

                    Pyramid.ReceiveCard(cardsForPyramid[0], rowIndex, cardIndex);
                    cardsForPyramid.RemoveAt(0);
                    cardIndex++;
                }
            }
        }
    }
}
