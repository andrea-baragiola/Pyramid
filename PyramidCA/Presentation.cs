using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PyramidLibrary.Models;

namespace PyramidCA
{
    public static class Presentation
    {
        public static void PresentBoard(Board board)
        {
            Console.WriteLine("Board");
            int counter = board.PyramidOfCards.Count();

            foreach (List<IPosition> listOfposition in board.PyramidOfCards)
            {
                for (int i = 0; i < counter; i++)
                {
                    Console.Write("  ");
                }

                foreach (IPosition position in listOfposition)
                {
                    if (position.Card == null)
                    {
                        Console.Write("  " + ", ");
                    }
                    else
                    {
                        Console.Write(position.Card.Name + "  ");
                    }
                }
                Console.WriteLine();
                counter--;

            }
            Console.WriteLine();
            Console.WriteLine();
        }
        public static void PresentAvailableBoardPositions(List<IPosition> availableBoardPositions)
        {
            Console.WriteLine("AvailableBoardPositions");
            foreach (IPosition position in availableBoardPositions)
            {
                Console.Write(position.Card.Name + ", ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void PresentAvailableBoardMoves(List<(IPosition, IPosition)> availableBoardMoves)
        {
            Console.WriteLine("AvailableBoardMoves");
            foreach ((IPosition, IPosition) move in availableBoardMoves)
            {
                if (move.Item2 == null)
                {
                    Console.WriteLine(move.Item1.Card.Name);
                }
                else
                {
                    Console.WriteLine(move.Item1.Card.Name + " + " + move.Item2.Card.Name);
                }
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void PresentAvailableDeckMoves(List<(IPosition, IPosition)> availableDeckMoves)
        {
            Console.WriteLine("AvailableDeckMoves");
            foreach ((IPosition, IPosition) move in availableDeckMoves)
            {
                Console.WriteLine(move.Item1.Card.Name + " + " + move.Item2.Card.Name);
            }
            Console.WriteLine();
        }
    }
}
