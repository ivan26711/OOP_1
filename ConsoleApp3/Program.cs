using System;
using System.Collections;

public class TreeNode
{
    public string Value { get; set; }
    public List<TreeNode> Children { get; set; }

    public TreeNode(string value)
    {
        Value = value;
        Children = new List<TreeNode>();
    }

    public void AddChild(TreeNode child)
    {
        Children.Add(child);
    }

    public void PrintNodeAndChildrenValues()
    {

        {
           
            Console.WriteLine("Node Name: " + Value);
            Console.WriteLine("\n");
            if (Children.Count == 0)
            {
                return;
            }
            Console.WriteLine("Number of Children: " + Children.Count);

            if (Children.Count > 0)
            {
                Console.WriteLine("Children Names:");
                foreach (var child in Children)
                {
                    Console.WriteLine(child.Value);
                }
                Console.WriteLine("Children's Children:");
                foreach (var child in Children)
                {
                    child.PrintNodeAndChildrenValues();
                }
            }
        }

    }

}

class Program
{
    static void Main()
    {
        TreeNode root = new TreeNode("Root");
        TreeNode child1 = new TreeNode("Child1");
        TreeNode child2 = new TreeNode("Child2");
        TreeNode grandchild1 = new TreeNode("Grandchild1");
        TreeNode grandchild2 = new TreeNode("Grandchild2");

        child1.AddChild(grandchild1);
        child1.AddChild(grandchild2);

        root.AddChild(child1);
        root.AddChild(child2);

        root.PrintNodeAndChildrenValues();
    }
}
