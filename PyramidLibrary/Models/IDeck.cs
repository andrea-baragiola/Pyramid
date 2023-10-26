namespace PyramidLibrary.Models
{
    public interface IDeck
    {
        IEnumerable<Card> Cards { get; }

        Card DrowCard();

        IEnumerable<Card> DrowCards(int numberOfCards);
    }
}