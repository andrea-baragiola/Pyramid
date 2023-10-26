namespace PyramidLibrary.Models
{
    public interface IBoard
    {
        Deck Deck { get; }
        DiscardDeck DiscardDeck { get; }
        Pyramid Pyramid { get; }
    }
}