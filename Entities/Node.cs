using System;
using System.Collections.Generic;

namespace Entities
{
    [Serializable]
    public class Node
    {
        public int Id { get; set; }

        public string Label { get; set; }

        public IList<Line> Lines { get; set; }

        public Node()
        {
            Lines = new List<Line>();
        }

        public Node(string label, IList<Line> ids = null, int id = 0)
        {
            Label = label;
            Lines = ids ?? new List<Line>();
            Id = id;
        }
    }
}
