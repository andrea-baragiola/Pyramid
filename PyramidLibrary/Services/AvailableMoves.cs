using PyramidLibrary.Models;

namespace PyramidLibrary.Services;

public static class AvailableMoves
{
    public static List<IPosition> GetAvailableBoardPositions(Board board)
    {
        List<IPosition> availableBoardPositions = new List<IPosition>();

        for (int i = 0; i < board.PyramidOfCards.Count - 1; i++)
        {
            List<IPosition> currentRowPositions = board.PyramidOfCards[i];
            List<IPosition> nextRowPositions = board.PyramidOfCards[i+1];

            for (int k = 0; k < currentRowPositions.Count; k++)
            {
                if (nextRowPositions[k].Card == null && nextRowPositions[k + 1].Card == null)
                {
                    availableBoardPositions.Add(currentRowPositions[k]);
                }
            }
        }
        return availableBoardPositions;
    }

    public static List<(IPosition, IPosition)> GetAvailableBoardMoves(Board board, List<IPosition> availablePositions)
    {
        List<(IPosition, IPosition)> availableMoves = new List<(IPosition, IPosition)>();

        for (int i = 0; i < availablePositions.Count; i++)
        {
            if (availablePositions[i].Card.Number == 10)
            {
                availableMoves.Add((availablePositions[i], null));
                continue;
            }
            for (int k = i + 1; k < availablePositions.Count; k++)
            {

                if (availablePositions[i].Card.Number == 10 - availablePositions[k].Card.Number)
                {
                    availableMoves.Add((availablePositions[i], availablePositions[k]));
                }
            }
        }
        return availableMoves;
    }

    public static List<(IPosition, IPosition)> GetAvailableDeckMoves(Board board, InHandDeck inHandDeck, List<IPosition> availablePositions)
    {
        List<(IPosition, IPosition)> availableMoves = new List<(IPosition, IPosition)>();

        for (int i = 0; i < availablePositions.Count; i++)
        {
            for (int k = 0; k < inHandDeck.DeckPositions.Count; k++)
            {
                if (availablePositions[i].Card.Number == 10 - inHandDeck.DeckPositions[k].Card.Number)
                {
                    availableMoves.Add((availablePositions[i], inHandDeck.DeckPositions[k]));
                }
            }
        }
        return availableMoves;
    }
}
