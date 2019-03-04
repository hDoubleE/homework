using System;
using System.Collections.Generic;

public class Graph
{
	internal const int MaxNode = 1024;
	private int[][] childNodes;

	public Graph(int[][] childNodes)
	{
		this.childNodes = childNodes;
	}

	public void TraverseBFS(int node)
	{
		bool[] visited = new bool[MaxNode];
		Queue<int> queue = new Queue<int>();
		queue.Enqueue(node);
		visited[node] = true;
		while (queue.Count > 0)
		{
			int currentNode = queue.Dequeue();
			Console.Write("{0} ", currentNode);
			foreach (int childNode in childNodes[currentNode])
			{
				if (!visited[childNode])
				{
					queue.Enqueue(childNode);
					visited[childNode] = true;
				}
			}
		}
	}

	public void TraverseDFS(int node)
	{
		bool[] visited = new bool[MaxNode];
		Stack<int> stack = new Stack<int>();
		stack.Push(node);
		visited[node] = true;
		while (stack.Count > 0)
		{
			int currentNode = stack.Pop();
			Console.Write("{0} ", currentNode);
			foreach (int childNode in childNodes[currentNode])
			{
				if (!visited[childNode])
				{
					stack.Push(childNode);
					visited[childNode] = true;
				}
			}
		}
	}

	public void TraverseDFSRecursive(int node, bool[] visited)
	{
		if (!visited[node])
		{
			visited[node] = true;
			Console.Write("{0} ", node);
			foreach (int childNode in childNodes[node])
			{
				TraverseDFSRecursive(childNode, visited);
			}
		}
	}
}
public class Graph

{

    // Contains the child nodes for each vertex of the graph

    // assuming that the vertices are numbered 0 ... Size-1

    private List<int>[] childNodes;

 

    /// <summary>Constructs an empty graph of given size</summary>

    /// <param name="size">number of vertices</param>

    public Graph(int size)

    {

        this.childNodes = new List<int>[size];

        for (int i = 0; i < size; i++)
        {
            // Adding an empty list of adjacents for each vertex

            this.childNodes[i] = new List<int>();

        }

    }

 

    /// <summary>Constructs a graph by given list of

    /// child nodes (successors) for each vertex</summary>

    /// <param name="childNodes">children for each node</param>

    public Graph(List<int>[] childNodes)

    {

        this.childNodes = childNodes;

    }

 

    /// <summary>

    /// Returns the size of the graph (number of vertices)

    /// </summary>

    public int Size
    {
        get { return this.childNodes.Length; }
    }

 

    /// <summary>Adds new edge from u to v</summary>

    /// <param name="u">the starting vertex</param>

    /// <param name="v">the ending vertex</param>

    public void AddEdge(int u, int v)
    {
        childNodes[u].Add(v);
    }
	/// <summary>Removes the edge from u to v if such exists

    /// </summary>

    /// <param name="u">the starting vertex</param>

    /// <param name="v">the ending vertex</param>

    public void RemoveEdge(int u, int v)
    {

        childNodes[u].Remove(v);
    }

 

    /// <summary>

    /// Checks whether there is an edge between vertex u and v

    /// </summary>

    /// <param name="u">the starting vertex</param>

    /// <param name="v">the ending vertex</param>

    /// <returns>true if there is an edge between

    /// vertex u and vertex v</returns>

    public bool HasEdge(int u, int v)
    {

        bool hasEdge = childNodes[u].Contains(v);

        return hasEdge;
    }

 

    /// <summary>Returns the successors of a given vertex

    /// </summary>

    /// <param name="v">the vertex</param>

    /// <returns>list of all successors of vertex v</returns>

    public IList<int> GetSuccessors(int v)
    {
        return childNodes[v];
    }

}



class GraphExample
{
	static void Main()
	{
		Graph g = new Graph(new int[][] {
			new int[] {3, 6}, // successors of vertice 0
			new int[] {2, 3, 4, 5, 6}, // successors of vertice 1
			new int[] {1, 4, 5}, // successors of vertice 2
			new int[] {0, 1, 5}, // successors of vertice 3
			new int[] {1, 2, 6}, // successors of vertice 4
			new int[] {1, 2, 3}, // successors of vertice 5
			new int[] {0, 1, 4}  // successors of vertice 6
		});

		Console.Write("Breadth-First Search (BFS) traversal: ");
		g.TraverseBFS(0);
		Console.WriteLine();

		Console.Write("Depth-First Search (DFS) traversal (with stack): ");
		g.TraverseDFS(0);
		Console.WriteLine();

		Console.Write("Depth-First Search (DFS) traversal (recursive): ");
		bool[] visited = new bool[Graph.MaxNode];
		g.TraverseDFSRecursive(0, visited);
		Console.WriteLine();
	}
}
