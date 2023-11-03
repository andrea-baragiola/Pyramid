namespace PyramidLibrary.Models.Decks;

public class UnshuffledDeck : Deck
{

    public UnshuffledDeck()
    {

        int[] numberList = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        string[] suitsList = { "H", "D", "C", "S" };

        List<Card> cardList = new();
        foreach (string suit in suitsList)
        {
            foreach (int number in numberList)
            {
                cardList.Add(new Card(number, suit));
            }
        }
        Cards = cardList;
    }

}

