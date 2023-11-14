using PyramidCA;
using PyramidLibrary.Models;
using PyramidLibrary.Models.Decks;
using PyramidLibrary.Solver;


int numberOfPyramidRows = 3;

Deck deck = new Deck();

List<Card> initialCards = deck.Cards.ToList();

Board board = new(numberOfPyramidRows, deck);


//Solver solver = new Solver(board, numberOfPyramidRows, initialCards);
//Presentation.PresentBoard(solver.Board);
//Presentation.PresentCardList(solver.Board.AvailablePyramidCards, "available pyramid cards");
//Presentation.PresentAvailableMoves(solver.Board.AvailableMoves);
//Presentation.PresentCardList(solver.Board.Deck.Cards, "deck cards");
//Presentation.PresentCardList(solver.Board.DiscardDeck.Cards, "discarded cards");

//bool solvable = solver.Solve(out List<int>path);

//Console.WriteLine(solvable);

//foreach (int i in path)
//{
//    Console.Write(i + ", ");
//}

Player player = new(board);

Presentation.PresentBoard(player.Board);
Presentation.PresentCardList(player.Board.AvailablePyramidCards, "available pyramid cards");
Presentation.PresentAvailableMoves(player.Board.AvailableMoves);
Presentation.PresentCardList(player.Board.Deck.Cards, "deck cards");
Presentation.PresentCardList(player.Board.DiscardDeck.Cards, "discarded cards");

while (player.IsWinner == false && player.IsLooser == false)
{
    int choice = Presentation.AskWhichMove(player.Board.AvailableMoves);

    player.DoMove(player.Board.AvailableMoves[choice]);

    player.Board.CreateAllAvailableMoves();
    Presentation.PresentBoard(player.Board);
    Presentation.PresentCardList(player.Board.AvailablePyramidCards, "available pyramid cards");
    Presentation.PresentAvailableMoves(player.Board.AvailableMoves);
    Presentation.PresentCardList(player.Board.Deck.Cards, "deck cards");
    Presentation.PresentCardList(player.Board.DiscardDeck.Cards, "discarded cards");

    player.CheckWinLoss();
}

if (player.IsWinner)
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

