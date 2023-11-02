namespace PyramidLibrary.Models;

public class Deck : IDeck
{

    public List<Card> Cards { get; protected set; }

    public Deck()
    {
        Cards = CreateCards();
        Shuffle();
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

    private void Shuffle()
    {
        Random rng = new Random();
        int n = Cards.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Card value = Cards[k];
            Cards[k] = Cards[n];
            Cards[n] = value;
        }
    }

    public Card DrowCard()
    {
        return DrowCards(1).Single();
    }

    public IEnumerable<Card> DrowCards(int numberOfCards)
    {

        var output = Cards.Take(numberOfCards).ToList();
        Cards.RemoveRange(0, numberOfCards);
        return output;
    }

    public void GiveCard(int x)
    {
        Card output = Cards[x];
        Cards.RemoveAt(x);
    }


}

