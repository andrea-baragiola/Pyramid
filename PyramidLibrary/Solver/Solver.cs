using System;
using System.Numerics;
using PyramidLibrary.Models;
using PyramidLibrary.Models.Decks;
using PyramidLibrary.Models.Moves;

namespace PyramidLibrary.Solver
{
    public class Solver : Player
    {
        public Tree Tree { get; set; }
        //public Board initialBoard { get; set; }
        public Stack<int> Path { get; set; }

        public readonly int _numberOfRows;
        public readonly List<Card> _originalCards;

        public Solver(Board board, int numberOfRows, List<Card> initialCards) : base(board)
        {
            _numberOfRows = numberOfRows;
            _originalCards = initialCards;
            Board = board;


            Path = new();
            Tree = new(new VoidMove());
        }

        //public void Solve()
        //{


        //    TreeNode currentNode = Tree.RootNode;
        //    CreateChildNodes(currentNode);

        //    while (true)
        //    {

        //        CheckWinLoss();
        //        if (isLooser == false && isWinner == false)
        //        {
        //            ExecuteMove(currentNode, 0);
        //            Board.GetAllAvailableMoves();
        //            currentNode = currentNode.Children[0];
        //            CreateChildNodes(currentNode);

        //            Path.Push(0);
        //        }
        //        else if (isLooser)
        //        {
        //            int lastNumber = Path.Pop();
        //            Path.Push(lastNumber + 1);

        //            //reset and repeat stack moves changing the last move
        //            currentNode = Tree.RootNode;
        //            Board = new(_numberOfRows, _deck);
        //            DoAllStackMoves(currentNode);
        //        }

        //    }
        //}

        //public void DoAllStackMoves(TreeNode currentNode)
        //{
        //    foreach (int i in Path)
        //    {
        //        ExecuteMove(currentNode, i);
        //        currentNode = currentNode.Children[i];


        //    }
        //}

        public void ExecuteMove(TreeNode node, int index)
        {
            DoMove(node.Children[index].Move);
        }

        public void CreateChildNodes(TreeNode currentNode)
        {
            foreach (IMove availableMove in Board.AvailableMoves)
            {
                currentNode.AddChild(new TreeNode(availableMove));
            }
        }
    }
}
