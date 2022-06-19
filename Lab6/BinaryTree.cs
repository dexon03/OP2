using System;
using System.Runtime.InteropServices;

namespace Lab6
{
    public class BinaryTree
    {
        public Node Root;

        public BinaryTree()
        {
            Root = null;
        }

        public void Insert(ref Node node,int value)
        {
            if (node == null)
            {
                node = new Node(value);
            }
            else
            {
                if (value < node.Data)
                {
                    Insert(ref node.LeftNode,value);
                }
                else
                {
                    Insert(ref node.RightNode,value); 
                }
            }
        }

        private int Levels(Node node)
        {
            if (node == null) return 0;
            return Math.Max(Levels(node.LeftNode), Levels(node.RightNode)) + 1;
        }

        public void print_tree()
        {
            int lvl = Levels(this.Root);
            for (int i = 0; i < lvl; i++)
            {
                Console.Write($"{i}" + "\t");
            }

            Console.WriteLine();
            for (int i = 0; i < lvl; i++)
            {
                Console.Write("|\t");
            }

            Console.WriteLine("\n");
            print_tree(this.Root,0);
            
        }

        private void print_tree(Node node, int space)
        {
            if (node == null) return;
            print_tree(node.RightNode,++space);
            for (int i = 1; i < space; i++)
            {
                Console.Write("\t");
            }
            Console.WriteLine(node.Data);
            print_tree(node.LeftNode, space);
            
        }
        
        
        
        
        
    }
}