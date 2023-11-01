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
        Card cardFromDeck = Board.Deck.GiveCard(move.DeckCardIndex);
        Card cardFromPyramid = Board.Pyramid.GiveCard(move.PyramidCardRow, move.PyramidCardIndex);
        Board.DiscardDeck.ReceiveCard(cardFromDeck);
        Board.DiscardDeck.ReceiveCard(cardFromPyramid);
    }

    public void DoPyramidPyramidMove(PyramidPyramidMove move)
    {

        Card cardFromPyramid1 = Board.Pyramid.GiveCard(move.PyramidCardRow1, move.PyramidCardIndex1);
        Card cardFromPyramid2 = Board.Pyramid.GiveCard(move.PyramidCardRow2, move.PyramidCardIndex2);
        Board.DiscardDeck.ReceiveCard(cardFromPyramid1);
        Board.DiscardDeck.ReceiveCard(cardFromPyramid2);
    }

    public void DoSinglePyramidMove(SinglePyramidMove move)
    {
        Card cardFromPyramid = Board.Pyramid.GiveCard(move.PyramidCardRow, move.PyramidCardIndex);
        Board.DiscardDeck.ReceiveCard(cardFromPyramid);
    }

    public void CheckWinLoss()
    {
        if (Board.AvailableDeckPyramidMoves.Count == 0 && Board.AvailablePyramidPyramidMoves.Count == 0)
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
