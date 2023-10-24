namespace PyramidLibrary.Models;

public class Player
{
    public Board Board { get; set; }
    public bool isWinner { get; set; } = false;
    public bool isLooser { get; set; } = false;


    public Player(int numberOfPyramidRows)
    {
        Board = new(numberOfPyramidRows);
    }


    public void ExecuteMove(int moveIndex)
    {
        Move move = Board.AvailableMoves[moveIndex];
        if (move.Cohordinates.Item1.Id.Item1 == 999)
        {
            ExecuteDeckMove(move);
        }
        else
        {
            ExecuteBoardMove(move);
        }
    }

    private void ExecuteBoardMove(Move move)
    {
        List<IPosition> boardPositionsToRemove = new() { move.Cohordinates.Item1, move.Cohordinates.Item2 };
        foreach (IPosition boardPositionToRemove in boardPositionsToRemove)
        {
            if (boardPositionToRemove == null)
            {
                continue;
            }
            else
            {
                AddCardToDescardDeck(boardPositionToRemove.Card);
                DeleteCardFromBoard(boardPositionToRemove);
            }
        }
    }

    private void ExecuteDeckMove(Move move)
    {
        IPosition deckPosition = move.Cohordinates.Item1;
        AddCardToDescardDeck(deckPosition.Card);
        DeletePositionFromInHandDeck(deckPosition);

        IPosition boardPositionToRemove = move.Cohordinates.Item2;
        AddCardToDescardDeck(boardPositionToRemove.Card);
        DeleteCardFromBoard(boardPositionToRemove);
    }

    private void DeletePositionFromInHandDeck(IPosition deckPosition)
    {
        for (int i = 0; i < Board.InHandDeck.Positions.Count; i++)
        {
            if (Board.InHandDeck.Positions[i] == deckPosition)
            {
                Board.InHandDeck.Positions.RemoveAt(i); break;
            }
        }
    }

    private void DeleteCardFromBoard(IPosition positionToMove)
    {
        int row = positionToMove.Id.Item1;
        foreach (IPosition boardposition in Board.PyramidOfCards[row])
        {
            if (boardposition == positionToMove)
            {
                boardposition.Card = null; break;
            }
        }
    }

    private void AddCardToDescardDeck(Card card)
    {
        int currentNumberOfCards = Board.DiscardedCardsDeck.Positions.Count;
        Board.DiscardedCardsDeck.Positions.Add(new DeckPosition(currentNumberOfCards, card));
    }

    public void CheckWinLoss()
    {
        if (Board.AvailableMoves.Count == 0)
        {
            if (Board.AvailableBoardPositions.Count == 0)
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
