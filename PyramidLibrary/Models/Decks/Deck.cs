namespace PyramidLibrary.Models.Decks;

public class Deck : IDeck
{

    public List<Card> Cards { get; protected set; } = new();
    public Dictionary<Card, int> CardLookup { get; set; } = new();

    public Deck()
    {
        CreateCards();
        Shuffle();
    }

    private void CreateCards()
    {
        int[] numberList = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        string[] suitsList = { "H", "D", "C", "S" };

        List<Card> deck = new();
        foreach (int number in numberList)
        {
            foreach (string suit in suitsList)
            {
                Card newCard = new Card(number, suit);
                ReceiveCard(newCard);
            }
        }
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

    public void ReceiveCard(Card card)
    {
        Cards.Add(card);
        CardLookup.Add(card, Cards.Count);
    }
    public void RemoveCard(Card card)
    {
        Cards.RemoveAt(CardLookup[card]);
        CardLookup.Remove(card);
    }

    public List<Card> GiveCards(int numberOfCards)
    {
            var output = Cards.Take(numberOfCards).ToList();
            Cards.RemoveRange(0, numberOfCards);
            return output;
    }


}

