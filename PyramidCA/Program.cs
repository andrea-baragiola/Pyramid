using System.Runtime.CompilerServices;
using PyramidCA;
using PyramidLibrary.Models;
using PyramidLibrary.Models.Decks;
using PyramidLibrary.Solver;


int numberOfPyramidRows = 8;
Deck deck = new();
List<Card> initialCards = deck.Cards.ToList();

Board board = new(numberOfPyramidRows, deck);


Solver solver = new Solver(board, numberOfPyramidRows, initialCards);




Presentation.PresentBoard(solver.Board);
Presentation.PresentCardList(solver.Board.AvailablePyramidCards,"available pyramid cards");
Presentation.PresentAvailableMoves(solver.Board.AvailableMoves);
Presentation.PresentCardList(solver.Board.Deck.Cards, "deck cards");
Presentation.PresentCardList(solver.Board.DiscardDeck.Cards, "discarded cards");

Solve(solver);

void Solve(Solver solver)
{


    TreeNode currentNode = solver.Tree.RootNode;
    solver.CreateChildNodes(currentNode);

    while (!solver.isWinner)
    {
        solver.CheckWinLoss();
        if (solver.isLooser == false && solver.isWinner == false)
        {
            solver.ExecuteMove(currentNode, 0);
            solver.Board.GetAllAvailableMoves();

            Presentation.PresentBoard(solver.Board);
            Presentation.PresentCardList(solver.Board.AvailablePyramidCards, "available pyramid cards");
            Presentation.PresentAvailableMoves(solver.Board.AvailableMoves);
            Presentation.PresentCardList(solver.Board.Deck.Cards, "deck cards");
            Presentation.PresentCardList(solver.Board.DiscardDeck.Cards, "discarded cards");

            currentNode = currentNode.Children[0];
            solver.CreateChildNodes(currentNode);

            solver.Path.Push(0);
        }
        else if (solver.isLooser)
        {
            int lastNumber = solver.Path.Pop();
            solver.Path.Push(lastNumber + 1);

            //reset and repeat stack moves changing the last move
            currentNode = solver.Tree.RootNode;
            solver.Board = new(solver._numberOfRows, new CustomDeck(solver._originalCards));

            Presentation.PresentBoard(solver.Board);

            DoAllStackMoves(currentNode, solver);
        }

    }
}

void DoAllStackMoves(TreeNode currentNode, Solver solver)
{
    foreach (int i in solver.Path)
    {
        solver.ExecuteMove(currentNode, i);
        currentNode = currentNode.Children[i];

        Presentation.PresentBoard(solver.Board);



    }
}

//solver.Solve();

Player player = new(board);

while (player.isWinner == false && player.isLooser == false)
{
    int choice = Presentation.AskWhichMove(player.Board.AvailableMoves);

    player.DoMove(player.Board.AvailableMoves[choice]);

    player.Board.GetAllAvailableMoves();
    Presentation.PresentBoard(player.Board);
    Presentation.PresentCardList(player.Board.AvailablePyramidCards, "available pyramid cards");
    Presentation.PresentAvailableMoves(player.Board.AvailableMoves);
    Presentation.PresentCardList(player.Board.Deck.Cards, "deck cards");
    Presentation.PresentCardList(player.Board.DiscardDeck.Cards, "discarded cards");

    player.CheckWinLoss();
}

if (player.isWinner)
{
    Console.WriteLine("  ||=============||");
    Console.WriteLine("  ||   YOU WON   ||");
    Console.WriteLine("  ||=============||");
    Console.WriteLine();
    Console.WriteLine();
}
else
{
    Console.WriteLine("  ||==============||");
    Console.WriteLine("  ||   YOU LOST   ||");
    Console.WriteLine("  ||==============||");
    Console.WriteLine();
    Console.WriteLine();
}

