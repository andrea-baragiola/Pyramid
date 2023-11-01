using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyramidLibrary.Models
{
    public class Board
    {
        public int Id { get; }
        public Pyramid Pyramid { get; }
        public IDeck Deck { get; }
        public DiscardDeck DiscardDeck { get; }

        public List<SinglePyramidMove> AvailableSinglePyramidMoves { get; set; }
        public List<PyramidPyramidMove> AvailablePyramidPyramidMoves { get; set; }
        public List<DeckPyramidMove> AvailableDeckPyramidMoves { get; set; }

        private List<Position> AvailableBoardPositions { get; set; } = new();

        public Board(int numberOfRows, IDeck deck)
        {
            Deck = deck;
            Pyramid = new Pyramid(Deck, numberOfRows);
            DiscardDeck = new DiscardDeck();
            GetAvailableBoardPositions();
            GetAvailableDeckPyramidMoves();
            GetAvailablePyramidPyramidMoves();
        }

        public void GetAvailableBoardPositions()
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

                if (Pyramid.CardRows[row1][index1].Number == 10)
                {
                    AvailableSinglePyramidMoves.Add(new SinglePyramidMove(row1, index1));
                    continue;
                }
                for (int k = i + 1; k < AvailableBoardPositions.Count; k++)
                {
                    int row2 = AvailableBoardPositions[k].Row;
                    int index2 = AvailableBoardPositions[k].Index;

                    if (Pyramid.CardRows[row1][index1].Number == 10 - Pyramid.CardRows[row2][index2].Number)
                    {
                        AvailablePyramidPyramidMoves.Add(new PyramidPyramidMove(row1, index1, row2, index2));
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

                for (int k = 0; k < Deck.Cards.Count; k++)
                {
                    if (Pyramid.CardRows[row][index].Number == 10 - Deck.Cards[k].Number)
                    {
                        AvailableDeckPyramidMoves.Add(new DeckPyramidMove(k, row, index));
                    }
                }
            }
        }

    }
}
