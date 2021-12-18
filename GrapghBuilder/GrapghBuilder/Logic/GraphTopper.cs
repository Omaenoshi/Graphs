using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace GrapghBuilder.Logic
{
    public class GraphTopper
    {
        public string Name { get; set; }
        public List<GraphEdge> Edges { get; set; }
        public Views.TopElem El { get; set; }

        public GraphTopper(string name, List<GraphEdge> edges, Views.TopElem el)
        {
            Name = name;
            Edges = edges;
            El = el;
        }

    }
}
