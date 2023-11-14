using PyramidLibrary.Models.Decks;
using PyramidLibrary.Models.Moves;

namespace PyramidLibrary.Models
{
    public class Board
    {
        public Pyramid Pyramid { get; }
        public IDeck Deck { get; }
        public IDeck DiscardDeck { get; }
        public List<Card> AvailablePyramidCards { get; set; } = new();
        public List<IMove> AvailableMoves => availableSinglePyramidMoves
                .Cast<IMove>()
                .Concat(availablePyramidPyramidMoves.Cast<IMove>())
                .Concat(availableDeckPyramidMoves.Cast<IMove>())
                .ToList();

        private List<SinglePyramidMove> availableSinglePyramidMoves = new();
        private List<PyramidPyramidMove> availablePyramidPyramidMoves = new();
        private List<DeckPyramidMove> availableDeckPyramidMoves = new();

        public Board(int numberOfRows, IDeck deck)
        {
            Deck = deck;
            Pyramid = new Pyramid(Deck, numberOfRows);
            DiscardDeck = new DiscardDeck();
            GetAllAvailableMoves();
        }

        // TODO:EDAR GetXXX e non ritorna nulla? Se fai qualcosa chiamato Get fai in modo che torni qualcosa.
        // forse in questo caso sono tutti Generate o Crete
        public void GetAllAvailableMoves()
        {
            GetAvailableCards();
            GetAvailableDeckPyramidMoves();
            GetAvailablePyramidMoves();
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

        private void GetAvailablePyramidMoves()
        {
            availablePyramidPyramidMoves.Clear();
            availableSinglePyramidMoves.Clear();
            for (int i = 0; i < AvailablePyramidCards.Count; i++)
            {
                Card card1 = AvailablePyramidCards[i];

                if (card1.Number == 10)
                {
                    availableSinglePyramidMoves.Add(new SinglePyramidMove(card1));
                    continue;
                }
                for (int k = i + 1; k < AvailablePyramidCards.Count; k++)
                {
                    Card card2 = AvailablePyramidCards[k];

                    if (card1.Number == 10 - card2.Number)
                    {
                        availablePyramidPyramidMoves.Add(new PyramidPyramidMove(card1, card2));
                    }
                }
            }
        }

        private void GetAvailableDeckPyramidMoves()
        {
            availableDeckPyramidMoves.Clear();
            for (int i = 0; i < AvailablePyramidCards.Count; i++)
            {
                Card pyramidCard = AvailablePyramidCards[i];

                for (int k = 0; k < Deck.Cards.Count; k++)
                {
                    Card deckCard = Deck.Cards[k];
                    if (pyramidCard.Number == 10 - deckCard.Number)
                    {
                        availableDeckPyramidMoves.Add(new DeckPyramidMove(deckCard, pyramidCard, k));
                    }
                }
            }
        }

    }
}
