using PyramidLibrary.CustomExceptions;

namespace PyramidLibrary.Models;

public class PyramidDeckMove : IMove
{
    public Card PyramidCard { get; }
    public Card DeckCard { get; }

    public PyramidDeckMove(Card pyramidCard, Card deckCard)
    {
        PyramidCard = pyramidCard;
        DeckCard = deckCard;
    }

    public bool Execute(Board board)
    {
        if (!board.Pyramid.CanDrow(PyramidCard))
        {
            throw new InvalidDrowOperation();
        }

        if (PyramidCard.Number + DeckCard.Number != 13)
        {
            throw new InvalidMoveOperation();
        }

        board.Pyramid.Drow(PyramidCard);
        board.Deck.DrowCard(DeckCard);
        board.DiscardDeck.Discard(PyramidCard);
        board.DiscardDeck.Discard(DeckCard);

        return true;
    }
}
