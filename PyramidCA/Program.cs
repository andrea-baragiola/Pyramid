
using System.Collections.Generic;
using System.Numerics;
using PyramidCA;
using PyramidLibrary.Models;
using PyramidLibrary.Services;


Player player = new();

Presentation.PresentBoard(player.Board);

Presentation.PresentAvailableBoardPositions(player.Board.AvailableBoardPositions);

Presentation.PresentAvailableMoves(player.Board.AvailableMoves);

Console.WriteLine();


while (player.isWinner == false && player.isLooser == false)
{
    player.ExecuteMove(0);

    Presentation.PresentBoard(player.Board);

    player.Board.GetAvailableBoardPositions();
    player.Board.GetAvailableMoves();

    Presentation.PresentAvailableBoardPositions(player.Board.AvailableBoardPositions);

    Presentation.PresentAvailableMoves(player.Board.AvailableMoves);

    Presentation.PresentAvailableDescardedDeckPositions(player.Board.DiscardedCardsDeck.Positions);

    player.CheckWinLoss();
}

if (player.isWinner)
{
    Console.WriteLine("YOU WON");
}
else
{
    Console.WriteLine("YOU LOST");
}



//// iniziare while loop
///

// 

// fare elenco carte disponibili
//player.DoMove(board.AvailableMoves[0]);

//board.GetAvailableBoardPositions();
//board.GetAvailableMoves();

//player.DoMove(board.AvailableMoves[0]);


//// fare elenco mosse disponibili
//List<(IPosition, IPosition)> availableBoardMoves = AvailableMoves.GetAvailableBoardMoves(board, availableBoardPositions);

//List<(IPosition, IPosition)> availableDeckMoves = AvailableMoves.GetAvailableDeckMoves(board, inHandDeck, availableBoardPositions);

// PRESENTATION
//Presentation.PresentAvailableBoardPositions(availableBoardPositions);



//Presentation.PresentAvailableDeckMoves(availableDeckMoves);





// fare prima mossa
// cambiare gli status delle carte nel board



