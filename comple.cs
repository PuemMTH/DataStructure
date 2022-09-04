using System;
namespace Tree_1
{
    class Program
    {
        class Node
        {
            public int data { get; set; }
            public Node LeftNode { get; set; }
            public Node RightNode { get; set; }
        }
        class BinaryTree
        {
            public Node Root { get; set; }
            public void Insert(int Value)
            {
                Node Parent = null;
                Node tmp = this.Root;
                while (tmp != null)
                {
                    Parent = tmp;
                    if (Value < tmp.data)
                    {
                        tmp = tmp.LeftNode;
                    }
                    else if (Value > tmp.data)
                    {
                        tmp = tmp.RightNode;
                    }
                    else
                        return;
                }
                Node newNode = new Node();
                newNode.data = Value;
                newNode.RightNode = null;
                newNode.LeftNode = null;

                if (this.Root == null)
                {
                    this.Root = newNode;
                }
                else
                {
                    if (newNode.data > Parent.data)
                        Parent.RightNode = newNode;
                    else
                        Parent.LeftNode = newNode;
                }
                return;
            }
            public void PrintTree(Node Parent, String indent, bool last)
            {
                Console.WriteLine(indent + "+- " + Parent.data);
                indent += last ? "  " : "|  ";
                if (Parent.LeftNode != null && Parent.RightNode != null)
                {
                    PrintTree(Parent.LeftNode, indent, false);
                    PrintTree(Parent.RightNode, indent, true);
                }
                else if (Parent.LeftNode != null) { PrintTree(Parent.LeftNode, indent, true); }
                else if (Parent.RightNode != null) { PrintTree(Parent.RightNode, indent, true); }
            }

            public Node tmp_node { get; set; }
            public Node tmp_delete { get; set; }
            public String LineSpace = "";

            public void Search(int Value)
            {
                Node Parent = null;
                Node tmp = this.Root;
                while (tmp != null)
                {
                    Parent = tmp;
                    if (Parent.data.Equals(Value))
                    {
                        LineSpace += "F";
                        tmp_node = Parent;
                        return;
                    }
                    else if (Value < tmp.data)
                    {
                        LineSpace += "L";
                        tmp = tmp.LeftNode;
                    }
                    else if (Value > tmp.data)
                    {
                        LineSpace += "R";
                        tmp = tmp.RightNode;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            

            public Node Remove(int key)
            {
                Node parent = null;
                Node pointer = this.Root;
                while (pointer != null && pointer.data != key)
                {
                    parent = pointer;
                    if (key < pointer.data) {
                        pointer = pointer.LeftNode;
                    }
                    else {
                        pointer = pointer.RightNode;
                    }
                }
                if (pointer == null) return this.Root;
                if (pointer.LeftNode == null && pointer.RightNode == null)
                {
                    if (pointer != this.Root)
                    {
                        if (parent.LeftNode == pointer) {
                            parent.LeftNode = null;
                        }
                        else {
                            parent.RightNode = null;
                        }
                    }
                    else {
                        this.Root = null;
                    }
                }
                else if (pointer.LeftNode != null && pointer.RightNode != null)
                {
                    Node successor = getMinimumKey(pointer.RightNode);
                    int val = successor.data;
                    Remove(successor.data);
                    pointer.data = val;
                }
                else {
                    Node child = (pointer.LeftNode != null)? pointer.LeftNode: pointer.RightNode;
                    if (pointer != this.Root)
                    {
                        if (pointer == parent.LeftNode){
                            parent.LeftNode = child;
                        }
                        else {
                            parent.RightNode = child;
                        }
                    }
                    else {
                        this.Root = child;
                    }
                }
                return this.Root;
            }
    
            public Node getMinimumKey(Node pointer)
            {
                while (pointer.LeftNode != null) {
                    pointer = pointer.LeftNode;
                }
                return pointer;
            }

        }

       static void Main(string[] args)
        {
            BinaryTree BT = new BinaryTree();
            int[] keys = { 50, 20, 70, 30, 110, 10, 15, 60, 90, 150 };
            foreach (int i in keys){
                BT.Insert(i);
            }
            BT.PrintTree(BT.Root, "Remov    ", true);
            BT.Remove(10);
            BT.PrintTree(BT.Root, "After    ", true);
        }
    }
}