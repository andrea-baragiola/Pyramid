using PyramidLibrary.Models.Moves;

namespace PyramidLibrary.Solver
{
    public class Tree
    {
        public TreeNode RootNode { get; set; }

        public Tree(IMove rootMove)
        {
            RootNode = new TreeNode(rootMove);
        }
    }
}
