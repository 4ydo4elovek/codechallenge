using System.Collections.Generic;

namespace DijkstrasAlgorithm
{
    public class DijkstrasAlgorithm
    {
        public int[,] AdjacencyMatrix;

        public DijkstrasAlgorithm(int[,] adjacencyMatrix)
        {
            AdjacencyMatrix = adjacencyMatrix;
        }

        public IList<int> GetShortestPath(int start, int end, out int length)
        {
            var d = new int[AdjacencyMatrix.GetLength(0)];
            var visited = new bool[d.Length];
            var p = new int[d.Length];
            p[start - 1] = start - 1;
            for (int i = 0; i < d.Length; i++)
            {
                if (i != start - 1)
                {
                    d[i] = int.MaxValue;
                }
            }
            for(;;)
            {
                int from = 0;
                int lFrom = int.MaxValue;
                for (int i = 0; i < d.Length; i++)
                {
                    if (lFrom > d[i] && !visited[i])
                    {
                        from = i;
                        lFrom = d[i];
                    }
                }
                if (lFrom == int.MaxValue)
                    break;
                visited[from] = true;
                for (int j = 0; j < d.Length; j++)
                {
                    if (AdjacencyMatrix[from, j] != 0)
                    {
                        if (!visited[j] && d[j] > d[from] + AdjacencyMatrix[from, j]) {
                            d[j] = d[from] + AdjacencyMatrix[from, j];
                            p[j] = from;
                        }
                    }
                }
            }
            length = d[end - 1];

            var nodes = new List<int>();

            for (int from = end - 1; from != start - 1; from = p[from])
            {
                nodes.Add(from + 1);
            }
            nodes.Add(start);
            nodes.Reverse();
            return nodes;
        }
    }
}
