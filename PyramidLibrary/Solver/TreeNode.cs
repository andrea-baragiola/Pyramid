using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PyramidLibrary.Models;
using PyramidLibrary.Models.Moves;

namespace PyramidLibrary.Solver
{
    public class TreeNode
    {
        public Board Board { get; set; }
        public IMove Move { get; set; }
        public List<TreeNode> Children { get; } = new List<TreeNode>();

        public TreeNode(Board board)
        {
            Board = board;
            Move = Board.AvailableMoves[0];
            Board.AvailableMoves.RemoveAt(0);
        }

        public void AddChild(TreeNode childNode)
        {
            Children.Add(childNode);
        }
    }
}
