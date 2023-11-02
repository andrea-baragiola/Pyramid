namespace PyramidLibrary.Models
{
    public interface IDeck
    {
        List<Card> Cards { get; }

        Card DrowCard();
        void GiveCard(int x);

        IEnumerable<Card> DrowCards(int numberOfCards);
    }
}