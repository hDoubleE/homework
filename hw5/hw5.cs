using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create new directed, adjancency list graph.
            DirectedGraphAL dg = new DirectedGraphAL();

            // Create a series of unconnected animal nodes.
            GraphNode bear = new GraphNode("Bear");
            GraphNode wolf = new GraphNode("Wolf");
            GraphNode zebra = new GraphNode("Zebra");
            GraphNode lion = new GraphNode("Lion");
            GraphNode dog = new GraphNode("Dog");
            GraphNode cat = new GraphNode("Cat");
            GraphNode fish = new GraphNode("Fish");
            GraphNode pig = new GraphNode("Pig");

            // Add nodes to graph, no connections yet.
            dg.AddNode(bear);
            dg.AddNode(wolf);
            dg.AddNode(zebra);
            dg.AddNode(lion);
            dg.AddNode(dog);
            dg.AddNode(cat);
            dg.AddNode(fish);
            dg.AddNode(pig);

            // Make connections.
            dg.AddEdge(bear, fish);
            dg.AddEdge(bear, wolf);

            dg.AddEdge(wolf, pig);
            dg.AddEdge(wolf, fish);

            dg.AddEdge(dog, cat);

            dg.AddEdge(cat, fish);

            dg.AddEdge(lion, zebra);
            dg.AddEdge(lion, pig);

            dg.AddEdge(zebra, pig);

            // Print graph.
            dg.PrintNodes();
            dg.PrintEdges();

            // The Upshot: Using a distionary amortizes the runtime of the graph. Accessing a node in the graph is O(1).
            // To iterate edges at that node requires iteration of the associated list, so O(m), where m is the number of edges in that list. 
            // Printing is O(n) because requires iteration of all nodes and edges. Lots of ways to do this with different data structures. 
            // The algorithms are more interesting for runtimes, still working on these.   
        }
    }

    public class GraphNode
    {
        public string Name { get; set; }

        public GraphNode(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class DirectedGraphAL //: IEnumerable<T>
    {
        // Fields
        public List<GraphNode> nodeList;

        public Dictionary<GraphNode, List<GraphNode>> adjList;

        public int Count { get; internal set; }

        // Constructors
        public DirectedGraphAL()
        {
            Count = 0;

            nodeList = new List<GraphNode>();

            adjList = new Dictionary<GraphNode, List<GraphNode>>();
        }

        // Add Vertex by Label
        public void AddNode(string name)
        {
            GraphNode newNode = new GraphNode(name);
            if (adjList.ContainsKey(newNode))
            {
                throw new InvalidOperationException("That vertex already exists in graph");
            }
            adjList.Add(newNode, new List<GraphNode>());
            nodeList[Count] = newNode;
            Count++;
        }

        //Add vertex by Node.
        public void AddNode(GraphNode newNode)
        {
            if (adjList.ContainsKey(newNode))
            {
                throw new InvalidOperationException("That vertex already exists in graph");
            }
            nodeList.Add(newNode);
            adjList.Add(newNode, new List<GraphNode>());
            Count++;
        }

        // Add Edge
        public void AddEdge(GraphNode from, GraphNode to)
        {
            if (adjList.ContainsKey(from))
            {
               adjList[from].Add(to);
            }
            else
            {
                throw new ArgumentException("That vertex does not exist in graph.");
            }
        }

        // Remove Vertex by node.
        public void RemoveNode(GraphNode targetNode)
        {
            if (!nodeList.Contains(targetNode))
            {
                throw new ArgumentException("The vertex does not exist in graph.");
            }
            nodeList.Remove(targetNode);
            adjList.Remove(targetNode);
            Count--;
        }

        // Remove Vertex by label.
        public void RemoveVertex(string name)
        {
            foreach (var i in nodeList)
            {
                if (i.Name == name)
                {
                    nodeList.Remove(i);
                    adjList.Remove(i);
                    Count--;
                    return;
                }
            }
            throw new ArgumentException("The vertex does not exist in graph.");
        }

        // Remove Edge.
        public void RemoveEdge(GraphNode from, GraphNode to)
        {
            if (adjList.ContainsKey(from) && adjList[from].Contains(to))
            {
                adjList[from].Remove(to);
            }
            else
            {
                throw new ArgumentException("The edge does not exist in graph.");
            }
        }

        // Print Verticies
        public void PrintNodes()
        {
            Console.Write("The graph contains: ");
            foreach (var i in nodeList)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }

        // Print Edges
        public void PrintEdges()
        {
            foreach (var i in adjList.Keys)
            {
                Console.Write($"{i} is connected to: ");
                foreach (var j in adjList[i])
                {
                    Console.Write($"{j} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        //DFS

        //BFS

        // Topological Sort

        // 20 extra points Dijkstras
    }
}