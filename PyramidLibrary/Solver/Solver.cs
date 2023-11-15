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

    public bool Solve(out List<int> winnerPath)
    {
        TreeNode<IMove> currentNode = Tree.RootNode;
        CreateChildNodes(currentNode);

        bool puzzleImpossible = false;
        bool puzzlePossible = false;

        while (puzzleImpossible == false && puzzlePossible == false)
        {
            RestartTheGame();
            currentNode = FollowValidPath();
            CheckWinLoss();

            while (IsGameEnded == false)
            {
                DoMove(currentNode.Children[0].Data);
                currentNode = currentNode.Children[0];
                Board.CreateAllAvailableMoves();
                CreateChildNodes(currentNode);
                Path.Add(0);

                CheckWinLoss();
            }

            if (IsWinner)
            {
                puzzlePossible = true;
            }
            else if (IsLooser)
            {
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
                        puzzleImpossible = true;
                    }
                }
            }
        }

        if (puzzleImpossible)
        {
            winnerPath = Path;
            return false;
        }
        else
        {
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
