using System;
using System.Collections.Generic;
using System.Text;

namespace DojoProblems.Graphs
{
    public class Graph
    {

        public List<HashSet<int>> graph { get; set; }
        public int nodes { get; set; }
        public int edges { get; set; }
        public int start { get; set; }

        public Graph()
        {

        }

        public Graph(int nodes, int edges, List<HashSet<int>> graph, int start) {

            this.nodes = nodes;
            this.edges = edges;
            this.graph = graph;
            this.start = start;
        }

    }
}
