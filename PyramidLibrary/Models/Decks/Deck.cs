namespace PyramidLibrary.Models.Decks;

public class Deck : IDeck
{

    public List<Card> Cards { get; protected set; }
    //public Dictionary<Card, int> CardLookup { get; set; } = new();

    public Deck()
    {

        List<Card> cards = Shuffle(CreateCards());
        Cards = new();
        foreach (Card card in cards)
        {
            ReceiveCard(card);
        }
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
                Card newCard = new Card(number, suit);
                deck.Add(newCard);

            }
        }
        return deck;
    }
    private List<Card> Shuffle(List<Card> cards)
    {
        Random rng = new Random();
        int n = cards.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Card value = cards[k];
            cards[k] = cards[n];
            cards[n] = value;
        }
        return cards;
    }

    public void ReceiveCard(Card card)
    {
        Cards.Add(card);

    }
    public void RemoveCard(Card card)
    {
        Cards.Remove(card);
    }

    public List<Card> GiveCards(int numberOfCards)
    {
        var output = Cards.Take(numberOfCards).ToList();

        Cards.RemoveRange(0, numberOfCards);

        return output;
    }

    //public List<Card> GiveCards(int numberOfCards)
    //{
    //    var output = Cards.TakeLast(numberOfCards).ToList();

    //    Cards.RemoveRange(Cards.Count - numberOfCards, numberOfCards);

    //    return output;
    //}


}

