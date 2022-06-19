using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using static Lab6.Functions;

namespace Lab6
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Введіть кількість елементів: ");
            int n = int.Parse(Console.ReadLine());
            BinaryTree tree1 = new BinaryTree();
            int elem;
            for (int i = 0; i < n; i++)
            {
                Console.Write("Введіть цілочисельний елемент дерева: ");
                elem = int.Parse(Console.ReadLine());
                tree1.Insert(ref tree1.Root,elem);
            }
            tree1.print_tree();
            
            Console.Write("Введіть кількість елементів: ");
            n = int.Parse(Console.ReadLine());
            BinaryTree tree2 = new BinaryTree();
            for (int i = 0; i < n; i++)
            {
                Console.Write("Введіть цілочисельний елемент дерева: ");
                elem = int.Parse(Console.ReadLine());
                tree2.Insert(ref tree2.Root,elem);
            }
            tree2.print_tree();
            List<int> unitedElement = new List<int>();
            UnitTree(tree1.Root,unitedElement);
            UnitTree(tree2.Root,unitedElement);
            BinaryTree resultTree = new BinaryTree();
            foreach (var ele in unitedElement)
            {
                resultTree.Insert(ref resultTree.Root,ele);
            }

            Console.WriteLine("Результуюче дерево: ");
            resultTree.print_tree();
            

        }
    }
}