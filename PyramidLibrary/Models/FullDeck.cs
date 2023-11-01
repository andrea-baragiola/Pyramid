namespace PyramidLibrary.Models;

public class FullDeck : IDeck
{

    public IEnumerable<Card> Cards => _cards;

    protected List<Card> _cards;

    public FullDeck()
    {
        _cards = CreateCards();
    }

    private List<Card> CreateCards()
    {
        int[] numberList = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
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

    public void Shuffle()
    {
        Random rng = new Random();
        int n = _cards.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Card value = _cards[k];
            _cards[k] = _cards[n];
            _cards[n] = value;
        }
    }

    public Card DrowCard()
    {
        return DrowCards(1).Single();
    }

    public IEnumerable<Card> DrowCards(int numberOfCards)
    {

        var output = _cards.Take(numberOfCards).ToList();
        _cards.RemoveRange(0, numberOfCards);
        return output;
    }
}

