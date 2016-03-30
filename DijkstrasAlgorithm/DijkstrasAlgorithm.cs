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

        public IList<int> GetShortestPath(int start, int end)
        {
            var d = new int[AdjacencyMatrix.GetLength(0)];
            var visited = new bool[d.Length];
            for (int i = 0; i < d.Length; i++)
            {
                if (i != start - 1)
                {
                    d[i] = int.MaxValue;
                }
                else
                {
                    d[i] = 0;
                }
            }
            while(true) {
                int from = 0, zfrom = int.MaxValue;
                for (int i = 0; i < d.Length; i++)
                {
                    if (zfrom > d[i] && !visited[i])
                    {
                        from = i;
                        zfrom = d[i];
                    }
                }
                if (zfrom == int.MaxValue)
                    break;
                visited[from] = true;
                for (int j = 0; j < d.Length; j++)
                {
                    if (AdjacencyMatrix[from, j] != 0)
                    {
                        if (!visited[j] && d[j] > d[from] + AdjacencyMatrix[from, j])
                            d[j] = d[from] + AdjacencyMatrix[from, j];
                    }
                }
            }
            return new List<int> {d[end - 1]};
        }
    }
}
