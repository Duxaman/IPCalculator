using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPCalculator
{
    public enum State
    {
        Free,
        Occupied,
        Leaf
    }

    sealed public class NetTreeNode
    {
        public Net Net { get; private set; }
        public NetTreeNode Left { get; set; }
        public NetTreeNode Right { get; set; }
        public NetTreeNode Parent { get; set; }
        public int OccupyId { get; set; }
        public State State { get; set; }
        public NetTreeNode(Net node)
        {
            Net = node;
            State = State.Free;
            OccupyId = -1;
        }
    }
}
