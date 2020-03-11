using System;
using System.Collections.Generic;
using System.Linq;
using DojoProblems.Graphs;

namespace DojoProblemsCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var queries = int.Parse(Console.ReadLine());

            var listGraphs = new List<Graph>();

            for(int cq =0; cq < queries; cq++)
            {
                var nodesAndEdges = Console.ReadLine();

                var numbers = nodesAndEdges.Split(' ');

                var nodes = int.Parse(numbers[0]);
                var edges = int.Parse(numbers[1]);

                var graph = new List<HashSet<int>>();

                for(var n =0; n < nodes; n++)
                {
                    graph.Add(new HashSet<int>());
                }

                for (int i = 0; i < edges; i++)
                {
                    var nodeConnectionsRead = Console.ReadLine();
                    var connections = nodeConnectionsRead.Split(' ');
                    graph.ElementAt(int.Parse(connections[0]) -1).Add(int.Parse(connections[1]) -1);
                   
                }
                var nodeStart = int.Parse(Console.ReadLine()) - 1;

                listGraphs.Add(new Graph(nodes, edges, graph, nodeStart));

            }


            listGraphs.ForEach(graph =>
            {
                var result = ShortestReach(graph, 6);
                for(var c =1; c < result.Length; c++)
                {
                    Console.WriteLine($"{result[c]} ");
                }
                
            });


            var a = Console.ReadKey();

        }

        private static int[] ShortestReach(Graph graph, int fixedDistance)
        {

            var distances = new int[graph.nodes];
            Array.Fill(distances, -1);

            LinkedList<int> toVisit = new LinkedList<int>();
            toVisit.AddLast(graph.start);
            distances[graph.start] = 0;


            while (toVisit.Any())
            {
                var node = toVisit.Last.Value;
                toVisit.RemoveLast();

                foreach (var neighbor in graph.graph.ElementAt(node))
                {
                    if(distances[neighbor] == -1)
                    {
                        distances[neighbor] = distances[node] + fixedDistance;
                        toVisit.AddLast(neighbor);

                    }
                }
            }
            
            return distances;
        }


        private void CalDijkstra()
        {
            Console.WriteLine("Hello World!");

           // var dijkstra = new Dijkstra();

            var input = new int[,]

            {
                { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                { 0, 0, 2, 0, 0, 0, 6, 7, 0 }
            };


           // dijkstra.GetTheDistances(input, 0);
        }
    }
}
