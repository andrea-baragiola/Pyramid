using PyramidLibrary.Models.Moves;

namespace PyramidLibrary.Solver;

public class TreeNode
{
    public IMove Move { get; set; }
    public List<TreeNode> Children { get; } = new();

    public TreeNode(IMove move)
    {
        Move = move;
    }

    public void AddChild(TreeNode childNode)
    {
        Children.Add(childNode);
    }
}
