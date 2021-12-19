using System;
using System.Collections.Generic;
using System.IO;

namespace GrapghBuilder.Logic
{
    internal class GraphSchema
    {
        public static List<GraphTopper> currentGraph = new List<GraphTopper>();

        public void GraphParse(string path)
        {
            var schema = File.ReadAllLines(path);

            for (var i = 0; i < schema.Length; i++)
            {
                var row = schema[i].Split(';');
                if (i == 0)
                {
                    CreateTopper(row);
                    continue;
                }
                for (var j = 1; j < row.Length; j++)
                {
                    if (row[j] != "0")
                    {
                        var weight = int.Parse(row[j]);
                        currentGraph[i - 1].Edges.Add(new GraphEdge(weight, currentGraph[j - 1]));
                    }
                }
            }
        }

        private void CreateTopper(string[] toppers)
        {
            foreach (var topper in toppers)
            {
                if (topper!=" ")
                    currentGraph.Add(new GraphTopper(topper, new List<GraphEdge>(), null));
            }
        }
    }
}
