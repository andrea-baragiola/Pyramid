namespace PyramidLibrary.Models;

public class CustomDeck : Deck
{

    public CustomDeck()
    {

        List<Card> cardList = new();
        foreach (int number in Enumerable.Range(1, 40))
        {
            cardList.Add(new Card(number, "A"));
        }
        _cards = cardList;
    }   
    
}

