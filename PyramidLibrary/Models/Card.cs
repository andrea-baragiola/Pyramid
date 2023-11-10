//namespace PyramidLibrary.Models;

//public class Card
//{
//    public int Number { get; set; }
//    public string Suit { get; set; }
//    public string Name { get; set; }
//    public Card(int number, string suit)
//    {
//        Number = number;
//        Suit = suit;
//        Name = number.ToString() + suit;
//    }
//}

namespace PyramidLibrary.Models;

public record Card(int Number, string Suit, string Name)
{
    public Card(int number, string suit) : this(number, suit, number.ToString() + suit)
    {
    }
}
