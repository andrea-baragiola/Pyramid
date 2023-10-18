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
        public static List<BoardPosition> GetAvailableBoardPositions(Board board)
        {
            List<BoardPosition> availableBoardPositions = new List<BoardPosition>();
            foreach (BoardPosition position in board.AllPositions)
            {
                if (position.Status == BoardPositionStatus.Available)
                {
                    availableBoardPositions.Add(position);
                }
            }
            return availableBoardPositions;
        }

        public static List<(BoardPosition, BoardPosition)> GetAvailableBoadMoves(Board board, List<BoardPosition> availablePositions)
        {
            List<(BoardPosition, BoardPosition)> availableMoves = new List<(BoardPosition, BoardPosition)> ();

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

        public static List<(BoardPosition, int)> GetAvailableDeckMoves()
        {
            throw new NotImplementedException();
        }
    }
}
