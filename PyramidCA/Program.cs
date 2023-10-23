
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



