using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;

namespace GrapghBuilder.Logic
{
    public class Algorithms
    {
        public static GraphTopper DFS(GraphSchema graph, GraphTopper startTopper, Border cur)
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
                cur.Background = Brushes.Red;
                var index = graph.Toppers.IndexOf(currentTopper);
                foreach (var neighbour in graph.Toppers[index].Edges)
                {
                    if (!visited.Contains(neighbour.ConnectedTop))
                        stack.Push(neighbour.ConnectedTop);
                }
                cur.Background = Brushes.Gray;
            }

            return visited[visited.Count - 1];
        }
    }
}