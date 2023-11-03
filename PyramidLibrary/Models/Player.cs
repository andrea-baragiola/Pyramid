using PyramidLibrary.Models.Decks;
using PyramidLibrary.Models.Moves;

namespace PyramidLibrary.Models;

public class Player
{
    public Board Board { get; }
    public bool isWinner { get; private set; } = false;
    public bool isLooser { get; private set; } = false;


    public Player(int numberOfPyramidRows)
    {
        Board = new(numberOfPyramidRows, new Deck());
    }

    public void DoDeckPyramidMove(DeckPyramidMove move)
    {
        Board.Deck.RemoveCard(move.DeckCardIndex);
        Board.Pyramid.RemoveCard(move.PyramidCard);
        Board.DiscardDeck.ReceiveCard(move.DeckCard);
        Board.DiscardDeck.ReceiveCard(move.PyramidCard);
    }

    public void DoPyramidPyramidMove(PyramidPyramidMove move)
    {
        Board.Pyramid.RemoveCard(move.Card1);
        Board.Pyramid.RemoveCard(move.Card2);
        Board.DiscardDeck.ReceiveCard(move.Card1);
        Board.DiscardDeck.ReceiveCard(move.Card2);
    }

    public void DoSinglePyramidMove(SinglePyramidMove move)
    {
        Board.Pyramid.RemoveCard(move.Card);
        Board.DiscardDeck.ReceiveCard(move.Card);
    }

    public void CheckWinLoss()
    {
        if (Board.AvailableMoves.Count == 0)
        {
            if (Board.Pyramid.CardRows[0][0] == null)
            {
                isWinner = true;
            }
            else
            {
                isLooser = true;
            }
        }
    }
}
