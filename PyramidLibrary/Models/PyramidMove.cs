using PyramidLibrary.CustomExceptions;

namespace PyramidLibrary.Models;

public class PyramidMove : IMove
{
    public Card Card1 { get; }
    public Card Card2 { get; }

    public PyramidMove(Card card1, Card card2)
    {
        Card1 = card1;
        Card2 = card2;
    }

    public bool Execute(Board board)
    {

        if (!board.Pyramid.CanDrow(Card1))
        {
            throw new InvalidDrowOperation();
        }

        if (!board.Pyramid.CanDrow(Card2))
        {
            throw new InvalidDrowOperation();
        }

        if (Card1.Number + Card2.Number != 13)
        {
            throw new InvalidMoveOperation();
        }

        board.Pyramid.Drow(Card1);
        board.Pyramid.Drow(Card2);
        board.DiscardDeck.Discard(Card1);
        board.DiscardDeck.Discard(Card2);

        return true;

    }
}
