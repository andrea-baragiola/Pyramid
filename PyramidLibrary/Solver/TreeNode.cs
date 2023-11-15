using PyramidLibrary.Models.Moves;

namespace PyramidLibrary.Solver;

public class TreeNode<T>
{
    public T Data { get; set; }
    public List<TreeNode<T>> Children { get; } = new();

    public TreeNode(T data)
    {
        Data = data;
    }

    public void AddChild(TreeNode<T> childNode)
    {
        Children.Add(childNode);
    }
}
