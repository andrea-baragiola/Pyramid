using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyramidLibrary.Models
{
    public class Board
    {
        public Pyramid Pyramid { get; }
        public IDeck Deck { get; }
        public DiscardDeck DiscardDeck { get; }

        public List<SinglePyramidMove> AvailableSinglePyramidMoves { get; set; } = new();
        public List<PyramidPyramidMove> AvailablePyramidPyramidMoves { get; set; } = new();
        public List<DeckPyramidMove> AvailableDeckPyramidMoves { get; set; } = new();

        private List<Position> AvailableBoardPositions { get; set; } = new();

        public Board(int numberOfRows, IDeck deck)
        {
            Deck = deck;
            Pyramid = new Pyramid(Deck, numberOfRows);
            DiscardDeck = new DiscardDeck();
            GetAllAvailableMoves();
        }

        public void GetAllAvailableMoves()
        {
            GetAvailableBoardPositions();
            GetAvailableDeckPyramidMoves();
            GetAvailablePyramidPyramidMoves();
        }

        private void GetAvailableBoardPositions()
        {

            for (int i = 0; i < Pyramid.CardRows.Count - 1; i++)
            {
                List<Card> currentRow = Pyramid.CardRows[i];
                List<Card> nextRow = Pyramid.CardRows[i + 1];

                for (int k = 0; k < currentRow.Count; k++)
                {
                    if (nextRow[k] == null && nextRow[k + 1] == null && currentRow[k] != null)
                    {
                        AvailableBoardPositions.Add(new Position(i, k));
                    }
                }
            }
            AvailableBoardPositions.Reverse();
        }

        private void GetAvailablePyramidPyramidMoves()
        {
            for (int i = 0; i < AvailableBoardPositions.Count; i++)
            {
                int row1 = AvailableBoardPositions[i].Row;
                int index1 = AvailableBoardPositions[i].Index;
                Card card = Pyramid.CardRows[row1][index1];

                if (card.Number == 10)
                {
                    AvailableSinglePyramidMoves.Add(new SinglePyramidMove(card, row1, index1));
                    continue;
                }
                for (int k = i + 1; k < AvailableBoardPositions.Count; k++)
                {
                    int row2 = AvailableBoardPositions[k].Row;
                    int index2 = AvailableBoardPositions[k].Index;

                    Card card1 = Pyramid.CardRows[row1][index1];
                    Card card2 = Pyramid.CardRows[row2][index2];

                    if (card1.Number == 10 - card2.Number)
                    {
                        AvailablePyramidPyramidMoves.Add(new PyramidPyramidMove(card1, card2, row1, index1, row2, index2));
                    }
                }
            }
        }

        private void GetAvailableDeckPyramidMoves()
        {
            for (int i = 0; i < AvailableBoardPositions.Count; i++)
            {
                int row = AvailableBoardPositions[i].Row;
                int index = AvailableBoardPositions[i].Index;
                Card pyramidCard = Pyramid.CardRows[row][index];

                for (int k = 0; k < Deck.Cards.Count; k++)
                {
                    Card deckCard = Deck.Cards[k];
                    if (pyramidCard.Number == 10 - deckCard.Number)
                    {
                        AvailableDeckPyramidMoves.Add(new DeckPyramidMove(deckCard, pyramidCard, k, row, index));
                    }
                }
            }
        }

    }
}
