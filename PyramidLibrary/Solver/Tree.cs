using PyramidLibrary.Models.Moves;

namespace PyramidLibrary.Solver
{
    public class Tree<T>
    {
        public TreeNode<T> RootNode { get; set; }

        public Tree(T root)
        {
            RootNode = new TreeNode<T>(root);
        }

        public TreeNode<T> GetNodeByPath(List<int> path)
        {
            TreeNode<T> currentNode = RootNode;

            foreach (int index in path)
            {
                currentNode = currentNode.Children[index];
            }

            return currentNode;
        }

        public bool PathIsValid(List<int> path)
        {
            TreeNode<T> currentNode = RootNode;

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
