// ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract

namespace TrangenderTree;

public class TransTree
{
    internal Node Root { get; private set; } = null!;

    public void Add(int value)
    {
        Node before = null!;
        Node after = Root;

        while (after is not null)
        {
            before = after;
            if (value < after.Data)
                after = after.LeftNode;
            else if (value > after.Data) 
                after = after.RightNode;
            else
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

    public Node Find(int value) => Find(Root, value);

    public void Remove(int value) => Root = Remove(Root, value);

    private static Node Remove(Node parent, int key)
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

        return parent ?? throw new ArgumentNullException(nameof(parent));
    }

    private static int MinValue(Node node)
    {
        int minv = node.Data;

        while (node.LeftNode != null)
        {
            minv = node.LeftNode.Data;
            node = node.LeftNode;
        }

        return minv;
    }

    private static Node Find(Node parent, int value) =>
        (parent == null
            ? null
            : value == parent.Data
                ? parent
                : Find(value < parent.Data
                    ? parent.LeftNode
                    : parent.RightNode, 
                    value)) 
        ?? throw new InvalidOperationException();

    private int GetTreeDepth() => GetTreeDepth(Root);

    private static int GetTreeDepth(Node parent) => parent == null 
        ? 0 
        : Math.Max(GetTreeDepth(parent.LeftNode), GetTreeDepth(parent.RightNode)) + 1;

    public void InOrder(Node parent)
    {
        while (true)
        {
            if (parent == null) return;
            InOrder(parent.LeftNode);
            Console.Write(parent.Data + " ");
            parent = parent.RightNode;
        }
    }

    public void PrintTree()
    {
        int depth = GetTreeDepth();
        for (int i = 1; i <= depth; i++)
        {
            PrintGivenLevel(Root, i);
            Console.WriteLine();
        }
    }

    private static void PrintGivenLevel(Node parent, int level)
    {
        while (true)
        {
            if (parent == null) return;
            switch (level)
            {
                case 1:
                    Console.Write(parent.Data + " ");
                    break;
                case > 1:
                    PrintGivenLevel(parent.LeftNode, level - 1);
                    parent = parent.RightNode;
                    level -= 1;
                    continue;
            }

            break;
        }
    }
}