
using System.Collections.Generic;
using PyramidCA;
using PyramidLibrary.Models;
using PyramidLibrary.Services;


List<Card> deck = DeckPreparation.CreateDeck();
DeckPreparation.Shuffle(deck);

Board board = new Board();

board.ListOfListPositions = BoardPreparation.PopulateBoard(deck);







// disporre carte nella in hand deck

InHandDeck inHandDeck = new InHandDeck();
inHandDeck.DeckPositions = DeckPreparation.PopulateDeckPositions(deck);

// inizializzare mazzo scarti
List<Card> descardedCards = new List<Card>();

//// iniziare while loop

// fare elenco carte disponibili
List<IPosition> availableBoardPositions = AvailableMoves.GetAvailableBoardPositions(board);

// fare elenco mosse disponibili
List<(IPosition, IPosition)> availableBoardMoves = AvailableMoves.GetAvailableBoardMoves(board, availableBoardPositions);

List<(IPosition, IPosition)> availableDeckMoves = AvailableMoves.GetAvailableDeckMoves(board, inHandDeck, availableBoardPositions);

// PRESENTATION
//Presentation.PresentAvailableBoardPositions(availableBoardPositions);

Presentation.PresentBoard(board);

Presentation.PresentAvailableBoardMoves(availableBoardMoves);

Presentation.PresentAvailableDeckMoves(availableDeckMoves);





// fare prima mossa
// cambiare gli status delle carte nel board



