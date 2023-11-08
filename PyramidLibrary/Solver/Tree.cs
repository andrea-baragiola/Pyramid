using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PyramidLibrary.Models;
using PyramidLibrary.Models.Moves;

namespace PyramidLibrary.Solver
{
    public class Tree
    {
        public TreeNode RootMove { get; set; }

        public Tree(IMove rootMove)
        {
            RootMove = new TreeNode(rootMove);
        }
    }
}
