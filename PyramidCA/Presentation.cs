using PyramidLibrary.Models;
using PyramidLibrary.Models.Moves;

namespace PyramidCA
{
    public static class Presentation
    {
        public static void PresentBoard(Board board)
        {
            Console.WriteLine("Board");
            int counter = board.Pyramid.CardRows.Count();

            foreach (List<Card> listOfCards in board.Pyramid.CardRows)
            {
                for (int i = 0; i < counter; i++)
                {
                    Console.Write("  ");
                }

                foreach (Card card in listOfCards)
                {
                    if (card == null)
                    {
                        Console.Write("  " + ", ");
                    }
                    else
                    {
                        Console.Write(card.Name + "  ");
                    }
                }
                Console.WriteLine();
                counter--;

            }
            Console.WriteLine();
            Console.WriteLine();
        }
        public static void PresentAvailablePyramidCards(List<Card> availableCards)
        {
            Console.WriteLine("AvailableCards");
            foreach (Card card in availableCards)
            {
                Console.Write(card.Name + ", ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void PresentDescardedCards(List<Card> discardedCards)
        {
            Console.WriteLine("DiscardedCards");
            foreach (Card card in discardedCards)
            {
                Console.Write(card.Name + ", ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void PresentAvailableMoves(List<SinglePyramidMove> singlePyramidMove,
                                                 List<PyramidPyramidMove> pyramidPyramidMoves,
                                                 List<DeckPyramidMove> deckPyramidMoves)
        {
            Console.WriteLine("AvailableSinglePyramidMoves");
            int moveIndex = 0;
            foreach (SinglePyramidMove move in singlePyramidMove)
            {
                Console.WriteLine($"n.{moveIndex}: {move.Card.Name}");
                moveIndex++;
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("AvailablePyramidMoves");
            foreach (PyramidPyramidMove move in pyramidPyramidMoves)
            {
                Console.WriteLine($"n.{moveIndex}: {move.Card1.Name} + {move.Card2.Name}");
                moveIndex++;
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("AvailablePyramidMoves");
            foreach (DeckPyramidMove move in deckPyramidMoves)
            {
                Console.WriteLine($"n.{moveIndex}: {move.PyramidCard.Name} + {move.DeckCard.Name}");
                moveIndex++;
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void PresentAvailableMoves(List<IMove> moves)
        {
            Console.WriteLine("Available Moves");
            int moveIndex = 0;
            foreach (IMove move in moves)
            {
                Console.WriteLine($"n.{moveIndex}:  {move.Description}");
                moveIndex++;
            }
            Console.WriteLine();
            Console.WriteLine();
        }


        public static int AskWhichMove(List<IMove> moveList)
        {
            Console.Write($"Which move do you want to perform? (between n.0 and n.{moveList.Count - 1}) : ");
            return int.Parse(Console.ReadLine());
        }
    }
}
