namespace PyramidLibrary.Models;

public class OneToFourtyDeck : Deck
{

    public OneToFourtyDeck()
    {

        List<Card> cardList = new();
        foreach (int number in Enumerable.Range(1, 40))
        {
            cardList.Add(new Card(number, "A"));
        }
        Cards = cardList;
    }   
    
}

