namespace PyramidLibrary.Models.Moves;

public class SinglePyramidMove : IMove
{
    public Card Card { get; set; }
    public string Description => Card.Name;

    public SinglePyramidMove(Card card)
    {
        Card = card;
    }
}
