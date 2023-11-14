using PyramidLibrary.Models.Moves;

namespace PyramidLibrary.Solver
{
    // TODO:EDAR usa i generics Tree<T>
    public class Tree
    {
        public TreeNode RootNode { get; set; }

        public Tree(IMove rootMove)
        {
            RootNode = new TreeNode(rootMove);
        }

        public TreeNode GetNodeByPath(List<int> path)
        {
            TreeNode currentNode = RootNode;

            foreach (int index in path)
            {
                currentNode = currentNode.Children[index];
            }

            return currentNode;
        }

        public bool PathIsValid(List<int> path)
        {
            TreeNode currentNode = RootNode;

            foreach (int index in path)
            {
                if (index < 0 || index >= currentNode.Children.Count)
                {
                    return false;
                }

                currentNode = currentNode.Children[index];
            }

            return true;
        }
    }
}
