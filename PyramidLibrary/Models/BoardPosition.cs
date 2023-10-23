namespace PyramidLibrary.Models;

public class BoardPosition : IPosition
{
    public (int, int) Id { get; set; }
    public Card? Card { get; set; }
    public int Row { get; set; }




    public BoardPosition(int inRowIndex, int row, Card? card)
    {
        Id = (row, inRowIndex);
        Row = row;

        Card = card;
    }
}
