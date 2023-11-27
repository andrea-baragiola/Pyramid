using System.Diagnostics;
using PyramidLibrary.Models;
using PyramidLibrary.Models.Decks;
using PyramidLibrary.Models.Moves;

namespace PyramidLibrary.Solver;

public class Solver : Player
{
    public Tree<IMove> Tree { get; set; }
    public List<int> Path { get; set; }

    private readonly int _numberOfRows;
    private readonly Card[] _originalCards;

    public Solver(Board board, int numberOfRows, Card[] initialCards) : base(board)
    {
        _numberOfRows = numberOfRows;
        _originalCards = initialCards;
        Board = board;


        Path = new();
        Tree = new(new VoidMove());
    }

    public bool Solve(out List<int> winnerPath, out TimeSpan timeTaken)
    {
        var timer = new Stopwatch();
        timer.Start();

        TreeNode<IMove> currentNode = Tree.RootNode;
        CreateChildNodes(currentNode);

        bool puzzleImpossible = false;
        bool puzzlePossible = false;

        while (puzzleImpossible == false && puzzlePossible == false)
        {
            Debug.WriteLine("Restarting with a new path");
            foreach (int number in Path)
            {
                Debug.Write($"{number}, ");
            }
            Debug.WriteLine("");

            RestartTheGame();
            currentNode = FollowValidPath();
            CheckWinLoss();

            while (IsGameEnded == false)
            {
                Debug.WriteLine("Game is not ended");

                DoMove(currentNode.Children[0].Data);
                currentNode = currentNode.Children[0];
                Board.CreateAllAvailableMoves();
                CreateChildNodes(currentNode);
                Path.Add(0);

                CheckWinLoss();
            }

            if (IsWinner)
            {
                Debug.WriteLine("Winner!");
                puzzlePossible = true;
            }
            else if (IsLooser)
            {
                Debug.WriteLine("Looser...");

                bool newMovesAreAvailable = false;

                while (newMovesAreAvailable == false && puzzleImpossible == false)
                {

                    if (Path.Count != 0)
                    {
                        Path[Path.Count - 1]++;
                        bool pathIsValid = Tree.PathIsValid(Path);
                        if (pathIsValid)
                        {
                            newMovesAreAvailable = true;
                        }
                        else
                        {
                            Path.RemoveAt(Path.Count - 1);
                        }
                    }
                    else
                    {
                        Debug.WriteLine("Puzzle is impossible");
                        puzzleImpossible = true;
                    }
                }
            }
        }

        timer.Stop();
        timeTaken = timer.Elapsed;

        if (puzzleImpossible)
        {
            Debug.WriteLine("Puzzle is impossible");
            winnerPath = Path;
            return false;
        }
        else
        {
            Debug.WriteLine("Puzzle is possible");
            winnerPath = Path;
            return true;
        }
    }


    private TreeNode<IMove> FollowValidPath()
    {
        var currentNode = Tree.RootNode;
        for (int i = 0; i < Path.Count; i++)
        {
            DoMove(currentNode.Children[Path[i]].Data);
            currentNode = currentNode.Children[Path[i]];

            if (i == Path.Count - 1)
            {
                Board.CreateAllAvailableMoves();
                CreateChildNodes(currentNode);
            }
        }
        return currentNode;
    }

    private void RestartTheGame()
    {
        IsWinner = false;
        IsLooser = false;
        Board = new(_numberOfRows, new CustomDeck(_originalCards));
    }
    public void CreateChildNodes(TreeNode<IMove> currentNode)
    {
        foreach (IMove availableMove in Board.AvailableMoves)
        {
            currentNode.AddChild(new TreeNode<IMove>(availableMove));
        }
    }
}
