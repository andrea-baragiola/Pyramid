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
        public IMove Move { get; set; }
        public List<TreeNode> Children { get; } = new List<TreeNode>();

        public TreeNode(IMove move)
        {
            Move = move;
        }

        public void AddChild(TreeNode childNode)
        {
            Children.Add(childNode);
        }
    }
}
