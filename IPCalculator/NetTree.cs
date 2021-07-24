using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace IPCalculator
{
    [JsonObject]
    sealed public class NetTree
    {
        [JsonProperty]
        public NetTreeNode Root { get; private set; }

        /// <summary>
        /// Finds and returns NetTreeNode that contains the specified Net
        /// </summary>
        /// <param name="NodeToLocate">Net that should be inside the tree node</param>
        /// <returns></returns>
        public NetTreeNode LocateNode(Net NodeToLocate)
        {
            NetTreeNode NeededNode = Root;
            UInt32 address = NodeToLocate.Address.RawInt;
            //shift all net part bits
            address <<= Root.Net.Mask;
            int BitsToMove = NodeToLocate.Mask - Root.Net.Mask;
            if (BitsToMove < 0) throw new NodeNotFoundException("Current subtree does not have specified node ");
            for (int i = 0; i < BitsToMove; ++i)   //first remaining (needed mask - rootmask) bits is the path to the node in the tree
            {
                if (address >> 31 == 0)
                {
                    if (NeededNode.Left != null)
                    {
                        NeededNode = NeededNode.Left;
                    }
                    else
                    {
                        throw new NodeNotFoundException();
                    }
                }
                else
                {
                    if (NeededNode.Right != null)
                    {
                        NeededNode = NeededNode.Right;
                    }
                    else
                    {
                        throw new NodeNotFoundException();
                    }
                }
                address <<= 1;
            }
            return NeededNode;
        }

        public NetTree(Net RootNet)
        {
            Root = new NetTreeNode(RootNet);
        }

        [JsonConstructor]
        public NetTree(NetTreeNode Root)
        {
            this.Root = Root;
        }

        private void AllocateNode(ref NetTreeNode Node, ref NetSegment Segment)
        {
            if (Node.Left != null)
            {
                Node.Left.State = State.Leaf;
                Node.Right.State = State.Leaf;
            }
            Node.State = State.Occupied;
            Node.OccupyId = Segment.Id;
            Segment.AssignedNet = Node.Net;
        }

        private void CreateChildren(ref NetTreeNode Node)
        {
            if (Node.Left == null) //if children does not exist
            {
                try
                {
                    Net LeftChild = new Net(Node.Net.Address, Node.Net.Mask + 1);
                    Address RightChildAddress = Address.InvertBit(Node.Net.Address, Node.Net.Mask + 1);
                    Net RightChild = new Net(RightChildAddress, Node.Net.Mask + 1);
                    Node.Left = new NetTreeNode(LeftChild);
                    Node.Right = new NetTreeNode(RightChild);
                }
                catch (ArgumentException)
                {
                    //cant divide more
                }
            }
        }

        /// <summary>
        /// Tries to allocate NetSegment into smallest possible node of NetTree with root CurNode
        /// </summary>
        /// <param name="CurNode">Current Node of the NetTree</param>
        /// <param name="Segment">Segment to Allocate</param>
        /// <param name="finished">Flag signalizing that segment has been allocated</param>
        private void AllocateToSmallestNode(NetTreeNode CurNode, ref NetSegment Segment, ref bool finished)
        {
            if (!finished)
            {
                if (CurNode.State == State.Free) //if current node is free
                {
                    if (CurNode.Net.HostAm < Segment.HostAm) //if in curent have not enought place then there is no place in subnodes eather
                    {
                        throw new CannotDistributeNetsException("Cannot distribute nets in current subtree, hosts required/actual: " + Segment.HostAm + "/" + CurNode.Net.HostAm );
                    }
                    CreateChildren(ref CurNode); //try to create children
                    if (CurNode.Left != null)
                    {
                        //if children exist
                        if (CurNode.Left.State == State.Free)
                        {
                            if (CurNode.Left.Net.HostAm < Segment.HostAm) //if left node does not have enought hosts
                            {
                                AllocateNode(ref CurNode, ref Segment);
                                finished = true;              //mark that we should exit all recursion levels
                                return;
                            }
                        }
                        if (CurNode.Right.State == State.Free)
                        {
                            if (CurNode.Right.Net.HostAm < Segment.HostAm) //if right node does not have enought hosts
                            {
                                AllocateNode(ref CurNode, ref Segment);
                                finished = true;              //mark that we should exit all recursion levels
                                return;
                            }
                        }
                        AllocateToSmallestNode(CurNode.Left, ref Segment, ref finished);
                        AllocateToSmallestNode(CurNode.Right, ref Segment, ref finished);
                    }
                    else
                    {
                        AllocateNode(ref CurNode, ref Segment);
                        finished = true;
                        return;

                    }
                }
            }

        }
        private void FindNets(NetTreeNode Node, ref List<NetSegment> Segments)
        {
            if (Node.State == State.Occupied)
            {
                NetSegment Net = new NetSegment(); //create net segment
                Net.Id = Node.OccupyId;
                Net.HostAm = Node.Net.HostAm;
                Segments.Add(Net);
                Node.State = State.Free;   //free node (in case if its root node)
                Node.OccupyId = -1;
                if (Node.Left != null)
                {
                    Node.Left = null;
                    Node.Right = null;
                }             
            }
            else if (Node.Left != null)  //if node is free
            {
                FindNets(Node.Left, ref Segments); //check left subtree
                Node.Left = null;
                FindNets(Node.Right, ref Segments);//check right subtree
                Node.Right = null;
            }
        }
        /// <summary>
        /// Distributes specified nets from NetSegment array inside provided node
        /// </summary>
        /// <param name="rootnode"></param>
        /// <param name="SegmentsToAllocate"></param>
        public void DistributeNet(NetTreeNode rootnode, ref NetSegment[] SegmentsToAllocate)
        {
            if (SegmentsToAllocate.Length == 0) throw new CannotDistributeNetsException("Net array is empty ");
            NetSegment[] SortedNets = SegmentsToAllocate.OrderByDescending(x => x.HostAm).ToArray();
            for (int i = 0; i < SortedNets.Length; ++i)
            {
                bool finishmark = false;
                AllocateToSmallestNode(rootnode, ref SortedNets[i], ref finishmark);
                if (!finishmark) throw new CannotDistributeNetsException("Current node doesn't have enought place for all nets ");
            }
        }
        /// <summary>
        /// Removes all children of the specified node and retrieves all found networks
        /// </summary>
        /// <param name="rootnode"></param>
        /// <returns>Netsegment array of the nets, that were previously allocated in this node</returns>
        public NetSegment[] AggregateNode(NetTreeNode node)
        {
            if (node.State != State.Leaf)
            {
                List<NetSegment> Segments = new List<NetSegment>();
                FindNets(node, ref Segments);
                return Segments.ToArray();
            }
            else
            {
                throw new CannotAggregateNetsException("Cannot aggregate node that is a leaf ");
            }
        }

    }


    [Serializable]
    public class NodeNotFoundException : Exception
    {
        public NodeNotFoundException() { }
        public NodeNotFoundException(string message) : base(message) { }
        public NodeNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected NodeNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }


    [Serializable]
    public class CannotDistributeNetsException : Exception
    {
        public CannotDistributeNetsException() { }
        public CannotDistributeNetsException(string message) : base(message) { }
        public CannotDistributeNetsException(string message, Exception inner) : base(message, inner) { }
        protected CannotDistributeNetsException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }


    [Serializable]
    public class CannotAggregateNetsException : Exception
    {
        public CannotAggregateNetsException() { }
        public CannotAggregateNetsException(string message) : base(message) { }
        public CannotAggregateNetsException(string message, Exception inner) : base(message, inner) { }
        protected CannotAggregateNetsException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
