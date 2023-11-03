using System.Numerics;
using PyramidLibrary.Models.Decks;
using PyramidLibrary.Models.Moves;

namespace PyramidLibrary.Models
{
    public class Board
    {
        public Pyramid Pyramid { get; }
        public IDeck Deck { get; }
        public DiscardDeck DiscardDeck { get; }
        public List<IMove> AvailableMoves => AvailableSinglePyramidMoves
                .Cast<IMove>()
                .Concat(AvailablePyramidPyramidMoves.Cast<IMove>())
                .Concat(AvailableDeckPyramidMoves.Cast<IMove>())
                .ToList();

        public List<SinglePyramidMove> AvailableSinglePyramidMoves { get; set; } = new();
        public List<PyramidPyramidMove> AvailablePyramidPyramidMoves { get; set; } = new();
        public List<DeckPyramidMove> AvailableDeckPyramidMoves { get; set; } = new();

        public List<Card> AvailablePyramidCards { get; set; } = new();

        public Board(int numberOfRows, IDeck deck)
        {
            Deck = deck;
            Pyramid = new Pyramid(Deck, numberOfRows);
            DiscardDeck = new DiscardDeck();
            GetAllAvailableMoves();
        }

        public void GetAllAvailableMoves()
        {
            GetAvailableCards();
            GetAvailableDeckPyramidMoves();
            GetAvailablePyramidPyramidMoves();
        }

        private void GetAvailableCards()
        {
            AvailablePyramidCards.Clear();
            for (int i = 0; i < Pyramid.CardRows.Count - 1; i++)
            {
                List<Card> currentRow = Pyramid.CardRows[i];
                List<Card> nextRow = Pyramid.CardRows[i + 1];

                for (int k = 0; k < currentRow.Count; k++)
                {
                    if (nextRow[k] == null && nextRow[k + 1] == null && currentRow[k] != null)
                    {
                        AvailablePyramidCards.Add(Pyramid.CardRows[i][k]);
                    }
                }
            }
            AvailablePyramidCards.Reverse();
        }

        private void GetAvailablePyramidPyramidMoves()
        {
            AvailablePyramidPyramidMoves.Clear();
            AvailableSinglePyramidMoves.Clear();
            for (int i = 0; i < AvailablePyramidCards.Count; i++)
            {
                Card card1 = AvailablePyramidCards[i];

                if (card1.Number == 10)
                {
                    AvailableSinglePyramidMoves.Add(new SinglePyramidMove(card1));
                    continue;
                }
                for (int k = i + 1; k < AvailablePyramidCards.Count; k++)
                {
                    Card card2 = AvailablePyramidCards[k];

                    if (card1.Number == 10 - card2.Number)
                    {
                        AvailablePyramidPyramidMoves.Add(new PyramidPyramidMove(card1, card2));
                    }
                }
            }
        }

        private void GetAvailableDeckPyramidMoves()
        {
            AvailableDeckPyramidMoves.Clear();
            for (int i = 0; i < AvailablePyramidCards.Count; i++)
            {
                Card pyramidCard = AvailablePyramidCards[i];

                for (int k = 0; k < Deck.Cards.Count; k++)
                {
                    Card deckCard = Deck.Cards[k];
                    if (pyramidCard.Number == 10 - deckCard.Number)
                    {
                        AvailableDeckPyramidMoves.Add(new DeckPyramidMove(deckCard, pyramidCard, k));
                    }
                }
            }
        }

    }
}
