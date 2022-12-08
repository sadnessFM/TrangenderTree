// ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract

namespace TrangenderTree;

public class TransTree
{
    internal Node Root { get; set; }

    public void Add(int value)
    {
        Node before = null;
        Node after = Root;

        while (after != null)
        {
            before = after;
            if (value < after.Data)
                after = after.LeftNode;
            else if (value > after.Data) //Is new node in right tree?
                after = after.RightNode;
            else
                //Exist same value
                return;
        }

        Node newNode = new()
        {
            Data = value
        };

        if (Root == null)
            Root = newNode;
        else
        {
            if (before != null && value < before.Data)
                before.LeftNode = newNode;
            else if (before != null) before.RightNode = newNode;
        }
    }

    public Node Find(int value) => Find(value, Root);

    public void Remove(int value) => Root = Remove(Root, value);

    private Node Remove(Node parent, int key)
    {
        if (parent == null) return parent ?? throw new ArgumentNullException(nameof(parent));

        if (key < parent.Data)
            parent.LeftNode = Remove(parent.LeftNode, key);
        else if (key > parent.Data)
            parent.RightNode = Remove(parent.RightNode, key);

        else
        {
            if (parent.LeftNode == null)
                return parent.RightNode;
            if (parent.RightNode == null)
                return parent.LeftNode;
            
            parent.Data = MinValue(parent.RightNode);
            
            parent.RightNode = Remove(parent.RightNode, parent.Data);
        }

        return parent;
    }

    private int MinValue(Node node)
    {
        int minv = node.Data;

        while (node.LeftNode != null)
        {
            minv = node.LeftNode.Data;
            node = node.LeftNode;
        }

        return minv;
    }

    private Node Find(int value, Node parent) =>
        (parent == null 
            ? null 
            : value == parent.Data 
                ? parent 
                : Find(value, value < parent.Data 
                    ? parent.LeftNode 
                    : parent.RightNode)) 
        ?? throw new InvalidOperationException();

    public int GetTreeDepth() => GetTreeDepth(Root);

    private int GetTreeDepth(Node parent) => parent == null 
        ? 0 
        : Math.Max(GetTreeDepth(parent.LeftNode), GetTreeDepth(parent.RightNode)) + 1;

    public void TraversePreOrder(Node parent)
    {
        if (parent == null) return;
        Console.Write(parent.Data + " ");
        TraversePreOrder(parent.LeftNode);
        TraversePreOrder(parent.RightNode);
    }

    public void TraverseInOrder(Node parent)
    {
        if (parent == null) return;
        TraverseInOrder(parent.LeftNode);
        Console.Write(parent.Data + " ");
        TraverseInOrder(parent.RightNode);
    }

    public void TraversePostOrder(Node parent)
    {
        if (parent == null) return;
        TraversePostOrder(parent.LeftNode);
        TraversePostOrder(parent.RightNode);
        Console.Write(parent.Data + " ");
    }
}