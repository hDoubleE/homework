using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC395_Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectedGraph myGraph = new DirectedGraph(7);
            myGraph.AddVertex("Cat");//0
            myGraph.AddVertex("Dog");//1
            myGraph.AddVertex("Pig");//2
            myGraph.AddVertex("Fish");//3

            myGraph.AddEdge(1, 0);
            myGraph.AddEdge(2, 1);
            myGraph.AddEdge(3, 2);
            myGraph.AddEdge(0, 3);
            //myGraph.AddEdge(4, 1);

            myGraph.printVertices();
            myGraph.printEdges();

            myGraph.TopSort();

        }
    }
    public class Vertex
    {
        public bool wasVisited;
        public string label;

        public Vertex(string name)
        {
            label = name;
            wasVisited = false;
        }

        
    }
    public class DirectedGraph
    {
        //data
        //G = (V, E)
        public Vertex[] vertices;
        public int[,] adjacencyMatrix;
        int capacity;
        int count; //this is the number of vertices in the graph

        //methods
        public int nextUnvisitedVertex(int vertexIdx)
        {
            for (int col = 0; col < count; col++)
                if (adjacencyMatrix[vertexIdx, col] != 0 && vertices[col].wasVisited == false)
                    return col;
            return -1;
        }
        public void DFS()
        {
            Stack<int> mystack = new Stack<int>();

            vertices[0].wasVisited = true;
            mystack.Push(0);

           while(mystack.Count>0)
            {
                int nextIdx = nextUnvisitedVertex(mystack.Peek());
                if (nextIdx == -1)
                {
                    mystack.Pop();
                }
                else
                {
                    vertices[nextIdx].wasVisited = true;
                    mystack.Push(nextIdx);
                }
            }
        }

        public bool noSuccessors(int i) //returns true if vertex[i] has no succ
        {
            for (int col = 0; col < count; col++)
                if (adjacencyMatrix[i, col] != 0)
                    return false;
            return true;
        }

        public int findVertexNoSuccessor()
        {
            for (int row = 0; row < count; row++)
                if (noSuccessors(row))
                    return row;
            return -1;//ERROR we have a cycle!!!!
        }
        public void TopSort()
        {
            Stack<string> mystack = new Stack<string>();

            while(count>0)   //Repeat Step 1 until all vertices are removed
            {
                //Find a vertex that has no successors.
                int idx = findVertexNoSuccessor();
                if(idx==-1)
                {
                    Console.WriteLine("EPIC FAIL ");
                    return;
                }

                //Add the vertex to a list of vertices.
                mystack.Push(vertices[idx].label);

                //Remove the vertex from the graph.
                RemoveVertex(idx);
            }
            //display the topological sorting
            while(mystack.Count>0)
                Console.WriteLine(mystack.Pop());

        }

        public void AddVertex(string newLabel)
        {
            if(count<capacity)
            {
                Vertex newVertex = new Vertex(newLabel);//create a new vertex
                vertices[count] = newVertex;
                count++;
            }
            else
                Console.WriteLine("ERROR: the vertices array is full!");
        }

        public void RemoveVertex(int i)
        {
            //sanity check
            if(i<0 || i>=count)
            {
                Console.WriteLine("ERROR: the index is out of bounds!");
                return;
            }

            //all the vertices to the right of i get moved to the left one pos
            for (int j = i; j < count - 1; j++)
                vertices[j] = vertices[j + 1];

            //remove row i
            for (int col = 0; col < count; col++)
                for (int row = i; row < count - 1; row++)
                    adjacencyMatrix[row, col] = adjacencyMatrix[row+1,col];
            //remove column i
            for (int row = 0; row < count; row++)
                for (int col = i; col < count - 1; col++)
                    adjacencyMatrix[row, col] = adjacencyMatrix[row, col + 1];
            //decrease count
            count--;

        }
        public void AddEdge(int idxStart, int idxEnd, int weight = 1)
        {
            if(0<= idxStart && idxStart<count &&
                0 <= idxEnd && idxEnd < count)
                adjacencyMatrix[idxStart, idxEnd] = weight;
            else
                Console.WriteLine("ERROR: out of bounds indeces");
        }
        
        public void RemoveEdge(int idxStart, int idxEnd)
        {
            adjacencyMatrix[idxStart, idxEnd] = 0;
        }

        public void printVertices()
        {
            for (int i = 0; i < count; i++)
                Console.Write(vertices[i].label + " ");
            Console.WriteLine();
        }

        public void printEdges()
        {
            for (int row = 0; row < count; row++)
            {
                for (int col = 0; col < count; col++)
                {
                    Console.Write(adjacencyMatrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
        //constructor
        public DirectedGraph(int capacity = 10)
        {
            count = 0;
            this.capacity = capacity;

            //allocate memory
            vertices = new Vertex[capacity];
            adjacencyMatrix = new int[capacity, capacity];
            //set everything to 0 in this matrix
            for(int row = 0; row<capacity;row++)
                for (int col = 0; col < capacity; col++)
                    adjacencyMatrix[row, col] = 0;
        }
    }
}
