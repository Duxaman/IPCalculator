using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IPCalculator
{
    public enum State
    {
        Free,
        Occupied,
        Leaf
    }

    [JsonObject]
    sealed public class NetTreeNode
    {
        [JsonProperty]
        public Net Net { get; private set; }
        [JsonProperty]
        public NetTreeNode Left { get; set; }
        [JsonProperty]
        public NetTreeNode Right { get; set; }
        [JsonProperty]
        public int OccupyId { get; set; }
        [JsonProperty]
        public State State { get; set; }
        public NetTreeNode(Net node)
        {
            Net = node;
            State = State.Free;
            OccupyId = -1;
        }
    }
}
