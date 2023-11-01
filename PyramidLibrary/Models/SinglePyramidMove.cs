using PyramidLibrary.CustomExceptions;

namespace PyramidLibrary.Models;

public class SinglePyramidMove : IMove
{
    public Card Card { get; }
    public SinglePyramidMove(Card card)
    {
        Card = card;
    }

    public bool Execute(Board board)
    {
        if (Card.Number != 13)
        {
            throw new InvalidMoveOperation();
        }

        if (!board.Pyramid.CanDrow(Card))
        {
            throw new InvalidDrowOperation();
        }

        board.Pyramid.Drow(Card);
        board.DiscardDeck.Discard(Card);

        return true;

    }
}
