using System;
using System.Collections.Generic;
using System.Linq;

namespace Dijkstra
{
    public class Program
    {

        /// <summary> The Algorithm of dijkstra is about
        /// 1) Create a set sptSet (shortest path tree set) that keeps track of vertices included in shortest path tree, i.e., whose minimum distance from source is calculated and finalized. Initially, this set is empty.
        //  2) Assign a distance value to all vertices in the input graph.
        //            Initialize all distance values as INFINITE.Assign distance value as 0 for the source vertex so that it is picked first.
        //  3) While sptSet doesn’t include all vertices
        //      ….a) Pick a vertex u which is not there in sptSet and has minimum distance value.
        //      ….b) Include u to sptSet.
        //      ….c) Update distance value of all adjacent vertices of u.To update the distance values,
        //              iterate through all adjacent vertices.For every adjacent vertex v, if sum of distance value of u(from source) and weight of edge u-v, is less than the distance value of v, then update the distance value of v.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
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


            var src = 0;
            int numOfNodes = 9;

            var distances = new int[numOfNodes];
            Array.Fill(distances, int.MaxValue);


            var sptSet = new List<int>();

            Stack<int> toVisit = new Stack<int>();

            distances[src] = 0;

            toVisit.Push(src);

            while (sptSet.Count < numOfNodes)
            {
                //var current = toVisit.Pop();

                var nodeMinimunNotVisited = GetTheNodeWithMininumDistance(distances, sptSet);

                sptSet.Add(nodeMinimunNotVisited);

                for(int i=0; i < numOfNodes; i++)
                {
                    var edgeWeight = input[nodeMinimunNotVisited, i];
                    var currentDistance = distances[i];
                    var distanceOfNode = distances[nodeMinimunNotVisited];
                    var sumOfDistance =  distanceOfNode+ edgeWeight;
                    //if sum of distance value of u(from source) and weight of edge u-v, is less than the distance value of v, then update the distance value of v.
                    if (edgeWeight != 0  && (sumOfDistance < currentDistance))
                    {
                        distances[i] = distanceOfNode + edgeWeight;
                    }
                }
            }

         

            Console.WriteLine($"The final result is {string.Join(',', distances)}");            

        }


        static int GetTheNodeWithMininumDistance(int[] distances, List<int> sptSet)
        {

            var minValue = int.MaxValue;
            var minIndex = 0;

            for(int i =0; i < distances.Length; i++)
            {
                var currentDistance = distances[i];
                if(!sptSet.Any(x => x == i) && currentDistance < minValue)
                {
                    minValue = distances[i];
                    minIndex = i;
                }
            }

            return minIndex;
        }
    }
}
