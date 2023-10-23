namespace PyramidLibrary.Models;

public class FullDeck : IDeck
{

    public List<IPosition> Positions { get; set; }

    public FullDeck()
    {
        List<Card> cards = CreateCards();
        Shuffle(cards);
        Positions = new();
        AssignPositions(cards);
    }

    private void AssignPositions(List<Card> cards)
    {
        int i = 0;
        foreach (Card card in cards)
        {
            Positions.Add(new DeckPosition(i, card));
            i++;
        }
    }

    private List<Card> CreateCards()
    {
        int[] numberList = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        string[] suitsList = { "H", "D", "C", "S" };

        List<Card> deck = new List<Card>();
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
}
