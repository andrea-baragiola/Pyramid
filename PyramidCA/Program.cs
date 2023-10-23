using PyramidCA;
using PyramidLibrary.Models;

int numberOfPyramidRows = 6;
Player player = new(numberOfPyramidRows);

Presentation.PresentBoard(player.Board);
Presentation.PresentAvailableBoardPositions(player.Board.AvailableBoardPositions);
Presentation.PresentAvailableMoves(player.Board.AvailableMoves);
Console.WriteLine();


while (player.isWinner == false && player.isLooser == false)
{
    player.ExecuteMove(0);
    player.Board.GetAvailableBoardPositions();
    player.Board.GetAvailableMoves();

    Presentation.PresentBoard(player.Board);
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


