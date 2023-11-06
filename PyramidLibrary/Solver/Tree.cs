using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PyramidLibrary.Models;

namespace PyramidLibrary.Solver
{
    public class Tree
    {
        public TreeNode RootBoard { get; set; }

        public Tree(Board rootBoard)
        {
            RootBoard = new TreeNode(rootBoard);
        }
    }
}
