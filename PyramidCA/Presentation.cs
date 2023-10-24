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

        public static void PresentDescardedDeckPositions(List<IPosition> availableDiscardedPositions)
        {
            Console.WriteLine("DiscardedCards");
            foreach (IPosition position in availableDiscardedPositions)
            {
                Console.Write(position.Card.Name + ", ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void PresentAvailableMoves(List<Move> availableBoardMoves)
        {
            Console.WriteLine("AvailableMoves");
            int moveIndex = 0;
            foreach (Move move in availableBoardMoves)
            {
                if (move.Cohordinates.Item2 == null)
                {
                    Console.WriteLine($"n.{moveIndex}: {move.Cohordinates.Item1.Card.Name}");
                }
                else
                {
                    Console.WriteLine($"n.{moveIndex}: {move.Cohordinates.Item1.Card.Name} + {move.Cohordinates.Item2.Card.Name}");
                }
                moveIndex++;
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

        public static int AskWhichMove(List<Move> moveList)
        {
            Console.Write($"Which move do you want to perform? (between n.0 and n.{moveList.Count - 1}) : ");
            return int.Parse(Console.ReadLine());
        }
    }
}
