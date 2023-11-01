namespace PyramidLibrary.Models
{
    public interface IBoard
    {
        MainDeck Deck { get; }
        DiscardDeck DiscardDeck { get; }
        int Id { get; }
        Pyramid Pyramid { get; }
    }
}