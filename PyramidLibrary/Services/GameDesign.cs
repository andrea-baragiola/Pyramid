using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PyramidLibrary.Models;

namespace PyramidLibrary.Services
{
    public static class GameDesign
    {
        public static List<IPosition> GetAvailableBoardPositions(Board board)
        {
            List<IPosition> availableBoardPositions = new List<IPosition>();

            foreach (List<IPosition> positions in board.ListOfListPositions)
            {
                foreach (BoardPosition position in positions)
                {
                    if (position.Status == BoardPositionStatus.Available)
                    {
                        availableBoardPositions.Add(position);
                    }
                }
            }


            return availableBoardPositions;
        }

        public static List<(IPosition, IPosition)> GetAvailableBoadMoves(Board board, List<IPosition> availablePositions)
        {
            List<(IPosition, IPosition)> availableMoves = new List<(IPosition, IPosition)> ();

            for (int i = 0; i < availablePositions.Count; i++)
            {
                if (availablePositions[i].Card.Number == 10)
                {
                    availableMoves.Add((availablePositions[i], null));
                    continue;
                }

                for (int k = i +1;  k < availablePositions.Count; k++)
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
}
