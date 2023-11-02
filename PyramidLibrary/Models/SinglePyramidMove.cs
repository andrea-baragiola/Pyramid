namespace PyramidLibrary.Models;

public class SinglePyramidMove : IMove
{
    public Card Card { get; set; }
    public string Description => Card.Name;

    public SinglePyramidMove(Card card)
    {
        Card = card;
    }
}
