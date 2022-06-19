using System.Collections.Generic;

namespace Lab6
{
    public static class Functions
    {
        public static void UnitTree(Node node,List<int> result)
        {
            if (node == null)
            {
                return;
            }

            if (!result.Contains(node.Data))
            {
                result.Add(node.Data);
            }
            UnitTree(node.LeftNode,result);
            UnitTree(node.RightNode, result);

        }
    }
}