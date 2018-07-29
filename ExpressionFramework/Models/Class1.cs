using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpressionFramework.Models
{

    public class Node
    {
        public string name { get; set; }
        public string type { get; set; }
        public bool isList { get; set; }
        public bool isProcessable { get; set; }

        public bool HasChild { get { return ChildNodes != null && ChildNodes.Any(); } }

        public List<Node> ChildNodes { get; set; } 
    }
}