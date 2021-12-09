namespace GrapghBuilder.Logic
{
    class GraphEdge
    {
        public int Weight { get; set; }
        public GraphTopper ConnectedTop { get; set; }

        public GraphEdge(int weight, GraphTopper cnTop)
        {
            Weight = weight;
            ConnectedTop = cnTop;
        }
    }
}
