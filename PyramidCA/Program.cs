﻿using PyramidCA;
using PyramidLibrary.Models;
using PyramidLibrary.Models.Moves;

int numberOfPyramidRows = 7;
Player player = new(numberOfPyramidRows);
List<IMove> moves;

Presentation.PresentBoard(player.Board);
Presentation.PresentAvailablePyramidCards(player.Board.AvailablePyramidCards);
Presentation.PresentAvailableMoves(player.Board.AvailableMoves);



//Presentation.PresentAvailableBoardPositions(player.Board.AvailableBoardPositions);
//Presentation.PresentAvailableMoves(player.Board.AvailableMoves);
//Console.WriteLine();


while (player.isWinner == false && player.isLooser == false)
{
    int choice = Presentation.AskWhichMove(player.Board.AvailableMoves);

    if (player.Board.AvailableMoves[choice] is DeckPyramidMove deckPyramidMove)
    {
        player.DoDeckPyramidMove(deckPyramidMove);
    }
    else if (player.Board.AvailableMoves[choice] is PyramidPyramidMove pyramidPyramidMove)
    {
        player.DoPyramidPyramidMove(pyramidPyramidMove);
    }
    else if (player.Board.AvailableMoves[choice] is SinglePyramidMove singlePyramidMove)
    {
        player.DoSinglePyramidMove(singlePyramidMove);
    }


    player.Board.GetAllAvailableMoves();
    Presentation.PresentBoard(player.Board);
    Presentation.PresentAvailablePyramidCards(player.Board.AvailablePyramidCards);
    Presentation.PresentAvailableMoves(player.Board.AvailableMoves);

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


