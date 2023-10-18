
using System.Collections.Generic;
using PyramidLibrary.Models;
using PyramidLibrary.Services;

int[] numberList = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
string[] suitsList = { "H", "D", "C", "S" };




List<Card> deck = Preparation.PopulateDeck(numberList, suitsList);

//shuffle deck
Preparation.Shuffle(deck);

// selezionare carte nella board
List<Card> cardPositionsA, cardPositionsB, cardPositionsC;
Preparation.PickCardsForBoad(deck, out cardPositionsA, out cardPositionsB, out cardPositionsC);

// disporre carte nella board

Board board = new Board();

board.RowA = Preparation.PopulatePositions("A", new int[] { 0 }, BoardPositionStatus.Blocked, cardPositionsA);
board.RowB = Preparation.PopulatePositions("B", new int[] { -1, 1 }, BoardPositionStatus.Blocked, cardPositionsB);
board.RowC = Preparation.PopulatePositions("C", new int[] { -2, 0, 2,3,4,5,6,7,8,9 }, BoardPositionStatus.Available, cardPositionsC);
board.RowD = Preparation.PopulatePositions("C", new int[] { -3, -1, 1, 3 }, BoardPositionStatus.Empty, new List<Card> { null, null, null, null });

board.AllPositions = board.RowA.Concat(board.RowB).Concat(board.RowC).Concat(board.RowD).ToList();

// inizializzare mazzo scarti
List<Card> descardedCards = new List<Card>();



//// iniziare while loop
///
// fare elenco carte disponibili
List<BoardPosition> availableBoardPositions = new List<BoardPosition>();
foreach (BoardPosition position in board.AllPositions)
{
    if (position.Status == BoardPositionStatus.Available)
    {
        availableBoardPositions.Add(position);
    }
}

List<(BoardPosition, BoardPosition)> availableBoardMoves = GameDesign.GetAvailableBoadMoves(board, availableBoardPositions);

foreach (BoardPosition position in availableBoardPositions)
{
    Console.Write(position.Card.Name + ", ");
}
Console.WriteLine();
Console.WriteLine();

foreach ((BoardPosition,BoardPosition) move in availableBoardMoves)
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

// fare elenco mosse disponibili
// fare prima mossa
// cambiare gli status delle carte nel board



