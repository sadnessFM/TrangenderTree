namespace TrangenderTree;

internal class Program
{
    private static void Main()
    {
        #region Initialization

        TransTree binaryTree = new();
        
        //Постройте BST с узлами: 17, 6, 5, 20, 19, 18, 11, 14, 12, 13, 2, 4, 10
        binaryTree.Add(17);
        binaryTree.Add(6);
        binaryTree.Add(5);
        binaryTree.Add(20);
        binaryTree.Add(19);
        binaryTree.Add(18);
        binaryTree.Add(11);
        binaryTree.Add(14);
        binaryTree.Add(12);
        binaryTree.Add(13);
        binaryTree.Add(2);
        binaryTree.Add(4);
        binaryTree.Add(10);

        #endregion
        
        binaryTree.PrintTree();
        Console.WriteLine();
        
        Console.WriteLine("sorted:");
        binaryTree.InOrder(binaryTree.Root);
        Console.WriteLine();
    }
}