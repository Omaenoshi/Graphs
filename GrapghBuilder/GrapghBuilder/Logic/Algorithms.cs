using System.Collections.Generic;

namespace GrapghBuilder.Logic
{
    public static class Algorithms
    {
        public static GraphTopper DFS(GraphSchema graph, GraphTopper startTopper)
        {
            var visited = new List<GraphTopper>();
            var stack = new Stack<GraphTopper>();
            stack.Push(startTopper);

            while (stack.Count > 0)
            {
                var currentTopper = stack.Pop();
                if (visited.Contains(currentTopper))
                    continue;
                
                visited.Add(currentTopper);

                var index = graph.Toppers.IndexOf(currentTopper);
                foreach (var neighbour in graph.Toppers[index].Edges)
                {
                    if (!visited.Contains(neighbour.ConnectedTop))
                        stack.Push(neighbour.ConnectedTop);
                }
            }

            return visited[visited.Count - 1];
        }
    }
}