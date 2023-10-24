//using PyramidCA;
//using PyramidLibrary.Models;

//int numberOfPyramidRows = 7;
//Player player = new(numberOfPyramidRows);

//Presentation.PresentBoard(player.Board);
//Presentation.PresentAvailableBoardPositions(player.Board.AvailableBoardPositions);
//Presentation.PresentAvailableMoves(player.Board.AvailableMoves);
//Console.WriteLine();


//while (player.isWinner == false && player.isLooser == false)
//{
//    player.ExecuteMove(Presentation.AskWhichMove(player.Board.AvailableMoves));
//    //player.ExecuteMove(0);
//    player.Board.GetAvailableBoardPositions();
//    player.Board.GetAvailableMoves();

//    Presentation.PresentBoard(player.Board);
//    Presentation.PresentAvailableBoardPositions(player.Board.AvailableBoardPositions);
//    Presentation.PresentDescardedDeckPositions(player.Board.DiscardedCardsDeck.Positions);
//    Presentation.PresentAvailableMoves(player.Board.AvailableMoves);

//    player.CheckWinLoss();
//}

//if (player.isWinner)
//{
//    Console.WriteLine("  ||=============||");
//    Console.WriteLine("  ||   YOU WON   ||");
//    Console.WriteLine("  ||=============||");
//    Console.WriteLine();
//    Console.WriteLine();
//}
//else
//{
//    Console.WriteLine("  ||==============||");
//    Console.WriteLine("  ||   YOU LOST   ||");
//    Console.WriteLine("  ||==============||");
//    Console.WriteLine();
//    Console.WriteLine();
//}


