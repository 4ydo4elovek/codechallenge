namespace Entities
{
    public class Line
    {
        public int Id { get; set; }

        public int NodeIdFrom { get; set; }

        public int NodeIdTo { get; set; }

        public string NodeIdFromUnique { get; set; }
               
        public string NodeIdToUnique { get; set; }

        public Line()
        { }

        public Line(int nodeIdFrom, int nodeIdTo, int id = 0)
        {
            NodeIdFrom = nodeIdFrom;
            NodeIdTo = nodeIdTo;
            Id = id;
        }
    }
}
