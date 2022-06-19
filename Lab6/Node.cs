namespace Lab6
{
    public class Node
    {
        public int Data;
        public Node LeftNode;
        public Node RightNode;

        public Node(int value)
        {
            Data = value;
            LeftNode = null;
            RightNode = null;
        }
    }
}