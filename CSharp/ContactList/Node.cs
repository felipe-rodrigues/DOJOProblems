using System;
using System.Collections.Generic;
using System.Text;

namespace ContactList
{
    public class Node
    {
        public int Count { get; set; }

        public Node[] Children { get; set; }

        public Node()
        {
            this.Count = 0;
            this.Children = new Node[26];
        }

        public void insert(Node current, string value)
        {

            foreach (var item in value)
            {
                int index = item - 'a';

                if(current.Children[index] == null)
                {
                    current.Children[index] = new Node();
                }
                current.Children[index].Count++;
                current = current.Children[index];
            }
        }
    }
}
