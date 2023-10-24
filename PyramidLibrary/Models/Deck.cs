namespace PyramidLibrary.Models;

public class Deck : IDeck
{

    public List<Card> Cards { get; set; }

    public Deck()
    {
        Cards = new();
        PopulateDeck();
    }

    private void PopulateDeck()
    {
        List<Card> cardList = CreateCards();
        Shuffle(cardList);
        Cards = cardList;

    }

    private List<Card> CreateCards()
    {
        int[] numberList = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        string[] suitsList = { "H", "D", "C", "S" };

        List<Card> deck = new();
        foreach (int number in numberList)
        {
            foreach (string suit in suitsList)
            {
                deck.Add(new Card(number, suit));
            }
        }
        return deck;
    }

    private void Shuffle<T>(List<T> list)
    {
        Random rng = new Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public Card GiveCard(int x)
    {
        Card output = Cards[x];
        Cards.RemoveAt(x);
        return output;
    }
}

