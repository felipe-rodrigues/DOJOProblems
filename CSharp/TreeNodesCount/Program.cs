using System;

namespace TreeNodesCount
{
    class Program
    {
        static void Main(string[] args)
        {

            Node root = new Node() { Value = 10};

            root.Left = new Node() { Value = 5 };
            root.Rigth = new Node() { Value = 12 };

            var rootRight = root.Rigth;
            var rootLeft = root.Left;
            rootLeft.Left = new Node() { Value = 4 };

            var left2 = rootLeft.Left;

            left2.Left = new Node() { Value = 3 };


            rootRight.Left = new Node() { Value = 5 };
            rootRight.Rigth = new Node() { Value = 7 };

            var deepest = Deepest(root);
            Console.WriteLine($"The tree contains {countNodes(root)} nodes");
            Console.WriteLine($"The deepest element is {deepest.Value} and His count is {deepest.Count}");
        }


        static int countNodes(Node root)
        {
            if (root == null)
            {
                return 0;
            }
            else
            {
                return  1  + countNodes(root.Left) + countNodes(root.Rigth);
            }
        }

        static Node Deepest(Node node)
        {

            if(node != null  &&  node.Rigth == null && node.Left == null)
            {
                return node;
            }
            else
            {

                if(node.Left == null) 
                {
                    return Increment(Deepest(node.Rigth));
                }
                else if(node.Rigth == null)
                {
                    return Increment(Deepest(node.Left));
                }
                else
                {
                    var left = Increment(Deepest(node.Left));
                    var right = Increment(Deepest(node.Rigth));

                    if (left.Count > right.Count) 
                    {
                        return left;
                    }
                    else
                    {
                        return right;
                    }
                }
            }
        }

        static Node Increment(Node node)
        {
            node.Count++;

            return node;
        }
    }


    public class Node
    {
        public dynamic Value { get; set; }
        public Node Rigth { get; set; }
        public Node Left { get; set; }
        public int? Count { get; set; }

        public Node()
        {
            Count = 0;
        }
    }
}
