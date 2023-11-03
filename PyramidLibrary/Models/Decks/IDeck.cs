namespace PyramidLibrary.Models.Decks
{
    public interface IDeck
    {
        List<Card> Cards { get; }

        Card DrowCard();
        void RemoveCard(int x);

        IEnumerable<Card> DrowCards(int numberOfCards);
    }
}