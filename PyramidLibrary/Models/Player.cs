using PyramidLibrary.Models.Moves;

namespace PyramidLibrary.Models;

public class Player
{
    public Board Board { get; set; }
    public bool IsWinner { get; set; }
    public bool IsLooser { get; set; }
    public bool IsGameEnded => IsWinner || IsLooser;


    public Player(Board board)
    {
        IsWinner = false;
        IsLooser = false;
        Board = board;
    }

    public void DoMove(IMove move)
    {
        // TODO:EDAR questo e' un caso d'uso perfetto per un pattern. Pero' per il momento possiamo fare finta di nulla.
        if (move is DeckPyramidMove deckPyramidMove)
        {
            DoDeckPyramidMove(deckPyramidMove);
        }
        else if (move is PyramidPyramidMove pyramidPyramidMove)
        {
            DoPyramidPyramidMove(pyramidPyramidMove);
        }
        else if (move is SinglePyramidMove singlePyramidMove)
        {
            DoSinglePyramidMove(singlePyramidMove);
        }
    }

    private void DoDeckPyramidMove(DeckPyramidMove move)
    {
        Board.Deck.RemoveCard(move.DeckCard);
        Board.Pyramid.RemoveCard(move.PyramidCard);
        Board.DiscardDeck.ReceiveCard(move.DeckCard);
        Board.DiscardDeck.ReceiveCard(move.PyramidCard);
    }

    private void DoPyramidPyramidMove(PyramidPyramidMove move)
    {
        Board.Pyramid.RemoveCard(move.Card1);
        Board.Pyramid.RemoveCard(move.Card2);
        Board.DiscardDeck.ReceiveCard(move.Card1);
        Board.DiscardDeck.ReceiveCard(move.Card2);
    }

    private void DoSinglePyramidMove(SinglePyramidMove move)
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
                IsWinner = true;
            }
            else
            {
                IsLooser = true;
            }
        }
    }
}
