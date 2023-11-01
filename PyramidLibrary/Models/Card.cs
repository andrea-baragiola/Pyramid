namespace PyramidLibrary.Models;

public record Card
{
    public int Number { get; set; }
    public string Suit { get; set; }
    public string Name => Number.ToString() + Suit;
    public Card(int number, string suit)
    {
        Number = number;
        Suit = suit;
    }
}