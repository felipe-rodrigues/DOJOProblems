using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ContactList
{
    public class Program
    {
        static void Main(string[] args)
        {

            string[] lines = File.ReadAllLines("test_case/teste_case_4.txt");

            var q = Convert.ToInt32(lines[0]);
            string[][] queries = new string[q][];
            for (int queriesRowItr = 1; queriesRowItr <= q; queriesRowItr++)
            {
                var line = lines[queriesRowItr];
                queries[queriesRowItr - 1] = line.Split(' ');
            }

            var initial = DateTime.Now;
            int[] result = solution2(queries);
            var completed = DateTime.Now;

            Console.WriteLine(string.Join("\n", result));
            Console.WriteLine($"Time taken was { (completed - initial).TotalSeconds}");
        }


        static int[] contacts(string[][] queries)
        {
            int rows = queries.GetUpperBound(0) - queries.GetLowerBound(0) + 1;

            var contacts = new List<string>();
            var result = new List<int>();

            for (var i = 0; i < rows; i++)
            {
                try
                {
                    var function = queries[i][0];
                    var value = queries[i][1];

                    if (function == "add")
                    {
                        contacts.Add(value);
                    }
                    else if (function == "find")
                    {
                        var count = contacts.Where(c => c.StartsWith(value)).Count();
                        result.Add(count);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"The index was {i}");
                }

            }

            return result.ToArray();
        }


        public static int[] solution2(string[][] queries)
        {
            int rows = queries.GetUpperBound(0) - queries.GetLowerBound(0) + 1;

            Node tree = new Node();

            List<int> result = new List<int>();

            for (var i = 0; i < rows; i++)
            {
                
                var function = queries[i][0];
                var value = queries[i][1];

                if (function == "add")
                {
                    tree.insert(tree, value);
                }
                else if (function == "find")
                {
                    Node currentNode = tree;

                    foreach (var item in value)
                    {
                        int index = item - 'a';
                        currentNode = currentNode.Children[index];

                        if(currentNode == null)
                        {
                            break;
                        }
                    }

                    result.Add(currentNode == null ? 0 : currentNode.Count );

                }
               
            }

            return result.ToArray();
        }
    }
}
