namespace PyramidLibrary.Models.Decks
{
    public interface IDeck
    {
        List<Card> Cards { get; }
        Dictionary<Card, int> CardLookup { get; set; }
        void RemoveCard(Card card);
        void ReceiveCard(Card card);
    }
}