using System;
using System.Collections;
using System.Collections.Generic;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    public class GraphNode<T>
    {
        public T Name { get; set; }

        bool Visited;

        public GraphNode(T name)
        {
            Name = name;
            Visited = false;
        }
    }

    public class Graph<T> //: IEnumerable<T>
    {
        // Fields
        public List<GraphNode<T>> nodeList;

        internal Dictionary<GraphNode<T>, List<T>> adjList;

        public int Count { get; internal set; }

        // Constructors
        public Graph()
        {
            Count = 0;

            nodeList = new List<GraphNode<T>>();

            adjList = new Dictionary<GraphNode<T>, List<T>>();
        }

        // Add Vertex by label
        public void AddNode(T name)
        {
            GraphNode<T> newNode = new GraphNode<T>(name);
            adjList.Add(newNode, new List<T>());
            nodeList[Count] = newNode;
            Count++;
        }

        //Add vertext using Node.
        public void AddNode(GraphNode<T> newNode)
        {
            nodeList.Add(newNode);
            Count++;
        }

        // Remove Vertex
        public void RemoveVertex(T node)
        {
            //...
        }

        // Add Edge
        public void AddEdge(GraphNode<T> fromNode, T toNode)
        {
            if (adjList.ContainsKey(fromNode))
            {
                adjList[fromNode].Add(toNode);
            }
            else
            {
                throw new Exception("That vertex does not exist in graph in Adjacency List.");
            }
        }

        // Remove Edge

        // Print Verticies

        // Print Edges

        //DFS

        //BFS
    }