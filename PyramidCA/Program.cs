using System.Runtime.CompilerServices;
using PyramidCA;
using PyramidLibrary.Models;
using PyramidLibrary.Models.Decks;
using PyramidLibrary.Solver;


int numberOfPyramidRows = 7;



List<Card> cardList = new();

// Aggiunta manuale di tutte le 40 combinazioni
cardList.Add(new Card(10, "D"));
cardList.Add(new Card(10, "D"));
cardList.Add(new Card(10, "D"));
cardList.Add(new Card(10, "D"));
cardList.Add(new Card(6, "S"));
cardList.Add(new Card(7, "H"));
cardList.Add(new Card(1, "H"));
cardList.Add(new Card(6, "C"));
cardList.Add(new Card(7, "D"));
cardList.Add(new Card(9, "H"));
cardList.Add(new Card(7, "S"));
cardList.Add(new Card(3, "D"));
cardList.Add(new Card(1, "C"));
cardList.Add(new Card(2, "H"));
cardList.Add(new Card(9, "S"));
cardList.Add(new Card(7, "C"));
cardList.Add(new Card(3, "H"));
cardList.Add(new Card(1, "S"));
cardList.Add(new Card(2, "C"));
cardList.Add(new Card(8, "S"));
cardList.Add(new Card(2, "S"));
cardList.Add(new Card(10, "H"));

//cardList.Add(new Card(3, "C"));
//cardList.Add(new Card(9, "C"));
//cardList.Add(new Card(3, "S"));
//cardList.Add(new Card(6, "H"));
//cardList.Add(new Card(6, "D"));
//cardList.Add(new Card(8, "C"));
//cardList.Add(new Card(8, "H"));
//cardList.Add(new Card(4, "H"));
//cardList.Add(new Card(4, "D"));
//cardList.Add(new Card(4, "S"));
//cardList.Add(new Card(5, "H"));
//cardList.Add(new Card(5, "D"));
//cardList.Add(new Card(8, "D"));
//cardList.Add(new Card(5, "C"));
//cardList.Add(new Card(5, "S"));
//cardList.Add(new Card(4, "C"));
//cardList.Add(new Card(10, "C"));
//cardList.Add(new Card(10, "S"));

cardList.Add(new Card(3, "C"));
cardList.Add(new Card(9, "F"));
cardList.Add(new Card(3, "S"));

cardList.Add(new Card(6, "X"));
cardList.Add(new Card(6, "Y"));
cardList.Add(new Card(8, "A"));
cardList.Add(new Card(8, "B"));
cardList.Add(new Card(4, "P"));
cardList.Add(new Card(1, "Q"));
cardList.Add(new Card(2, "M"));

cardList.Add(new Card(4, "G"));
cardList.Add(new Card(4, "H"));
cardList.Add(new Card(4, "I"));
cardList.Add(new Card(4, "J"));
cardList.Add(new Card(2, "K"));
cardList.Add(new Card(8, "L"));
cardList.Add(new Card(7, "N"));
cardList.Add(new Card(3, "O"));

//CustomDeck deck = new(cardList);

Deck deck = new Deck();

List<Card> initialCards = deck.Cards.ToList();

Board board = new(numberOfPyramidRows, deck);


Solver solver = new Solver(board, numberOfPyramidRows, initialCards);
Presentation.PresentBoard(solver.Board);
Presentation.PresentCardList(solver.Board.AvailablePyramidCards, "available pyramid cards");
Presentation.PresentAvailableMoves(solver.Board.AvailableMoves);
Presentation.PresentCardList(solver.Board.Deck.Cards, "deck cards");
Presentation.PresentCardList(solver.Board.DiscardDeck.Cards, "discarded cards");

bool solvable = solver.Solve(out List<int>path);

Console.WriteLine(solvable);

foreach (int i in path)
{
    Console.Write(i + ", ");
}

Player player = new(board);

Presentation.PresentBoard(player.Board);
Presentation.PresentCardList(player.Board.AvailablePyramidCards, "available pyramid cards");
Presentation.PresentAvailableMoves(player.Board.AvailableMoves);
Presentation.PresentCardList(player.Board.Deck.Cards, "deck cards");
Presentation.PresentCardList(player.Board.DiscardDeck.Cards, "discarded cards");

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

