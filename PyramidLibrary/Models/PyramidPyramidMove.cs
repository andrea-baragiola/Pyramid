namespace PyramidLibrary.Models;

public class PyramidPyramidMove
{

    public Card Card1 { get; set; }
    public Card Card2 { get; set; }
    public PyramidPyramidMove(Card card1, Card card2)
    {
        Card1 = card1;
        Card2 = card2;


    }
}
