using PyramidLibrary.Models;
using PyramidLibrary.Models.Decks;
using PyramidLibrary.Models.Moves;

namespace PyramidLibrary.Solver;

// TODO:EDAR In generale, commenta sempre. Metti i summary sia sulle classi sia sui metodi public
public class Solver : Player
{
    public Tree Tree { get; set; }
    //public Board initialBoard { get; set; }
    public List<int> Path { get; set; }

    private readonly int _numberOfRows;
    private readonly List<Card> _originalCards;

    public Solver(Board board, int numberOfRows, List<Card> initialCards) : base(board)
    {
        _numberOfRows = numberOfRows;
        _originalCards = initialCards;

        // TODO:EDAR fai gia' questa operazione nella classe base
        Board = board;


        Path = new();
        Tree = new(new VoidMove());
    }

    public bool Solve(out List<int> winnerPath)
    {
        TreeNode currentNode = Tree.RootNode;
        CreateChildNodes(currentNode);

        bool puzzleImpossible = false;
        bool puzzlePossible = false;

        while (puzzleImpossible == false && puzzlePossible == false)
        {
            RestartTheGame();
            currentNode = FollowValidPath();
            CheckWinLoss();

            while (isGameEnded == false)
            {
                DoMove(currentNode.Children[0].Move);
                currentNode = currentNode.Children[0];
                Board.GetAllAvailableMoves();
                CreateChildNodes(currentNode);
                Path.Add(0);

                CheckWinLoss();
            }

            if (isWinner)
            {
                // TODO:EDAR non e' necessario avere una variabile per gestire questo caso. Puoi fare return anche da qui.
                puzzlePossible = true;
            }
            else if (isLooser)
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

    private TreeNode FollowValidPath()
    {
        var currentNode = Tree.RootNode;
        for (int i = 0; i < Path.Count; i++)
        {
            DoMove(currentNode.Children[Path[i]].Move);
            currentNode = currentNode.Children[Path[i]];

            if (i == Path.Count - 1)
            {
                Board.GetAllAvailableMoves();
                CreateChildNodes(currentNode);
            }
        }
        return currentNode;
    }

    private void RestartTheGame()
    {
        isWinner = false;
        isLooser = false;
        // TODO:EDAR Capisco la motivazione ma non mi piace. Board lo passi nel costruttore,
        //qui lo stai ridefinendo. E' un po un anti pattern. Pero' per come e' fatto al momento e' difficile da cambiare.
        Board = new(_numberOfRows, new CustomDeck(_originalCards));
    }
    public void CreateChildNodes(TreeNode currentNode)
    {
        foreach (IMove availableMove in Board.AvailableMoves)
        {
            currentNode.AddChild(new TreeNode(availableMove));
        }
    }
}
