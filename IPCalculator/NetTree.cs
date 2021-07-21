using System;
using System.Linq;
using System.Collections.Generic;

namespace IPCalculator
{
    sealed public class NetTree
    {
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
            for (int i = 0; i < NodeToLocate.Mask - Root.Net.Mask; ++i)   //first remaining (needed mask - rootmask) bits is the path to the node in the tree
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

        public NetTree(NetTreeNode rootnode)
        {
            Root = rootnode;
        }

        private void AllocateNode(ref NetTreeNode Node, NetSegment Segment)
        {
            if (Node.Left != null)
            {
                Node.Left.State = State.Leaf;
                Node.Right.State = State.Leaf;
            }
            Node.State = State.Occupied;
            Node.OccupyId = Segment.Id;
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
                    Node.Left.Parent = Node;
                    Node.Right = new NetTreeNode(RightChild);
                    Node.Right.Parent = Node;
                }
                catch (ArgumentException)
                {
                    //cant divide more
                } 
            }
        }

        private void FindSmallestNode(NetTreeNode CurNode, NetSegment Segment, ref bool finished)
        {
            if (!finished)
            {
                if (CurNode.State == State.Free) //if current node is free
                {
                    if (CurNode.Net.HostAm < Segment.HostAm) //if current node does not have enought hosts
                    {
                        if (CurNode.Parent != null)  //if parent exist go back to parent
                        {
                            CurNode = CurNode.Parent;
                            AllocateNode(ref CurNode, Segment);
                            finished = true;              //mark that we should exit all recursion levels
                            return;
                        }
                        else
                        {
                            throw new CannotDistributeNetsException("Невозможно распределить сеть с " + Segment.HostAm + " хостами, наибольший узел может вместить лишь " + CurNode.Net.HostAm + " хостов");
                        }
                    }
                    else
                    {
                        CreateChildren(ref CurNode);
                        if (CurNode.Left != null)
                        {
                            FindSmallestNode(CurNode.Left, Segment, ref finished);
                            FindSmallestNode(CurNode.Right, Segment, ref finished);
                        }
                        else
                        {
                            AllocateNode(ref CurNode, Segment);
                            finished = true;
                            return;
                        }
                    }
                } 
            }

        }

        private void FindNets(NetTreeNode Node, ref List<NetSegment> Segments)
        {
            if(Node.State == State.Occupied)
            {
                NetSegment Net = new NetSegment();
                Net.Id = Node.OccupyId;
                Net.HostAm = Node.Net.HostAm;
                Segments.Add(Net);
            }
            if(Node.Left != null)
            {
                FindNets(Node.Left, ref Segments);
                Node.Left.Parent = null;
                Node.Left = null;
                FindNets(Node.Right, ref Segments);
                Node.Right.Parent = null;
                Node.Right = null;
            }
        }


        /// <summary>
        /// Distributes specified nets from NetSegment array inside provided node
        /// </summary>
        /// <param name="rootnode"></param>
        /// <param name="SegmentsToAllocate"></param>
        public void DistributeNet(NetTreeNode rootnode, NetSegment[] SegmentsToAllocate)
        {
            if (SegmentsToAllocate.Length == 0) throw new CannotDistributeNetsException("Массив сетей пуст");
            NetSegment[] SortedNets = SegmentsToAllocate.OrderByDescending(x => x.HostAm).ToArray();
            for (int i = 0; i < SortedNets.Length; ++i)
            {
                bool finishmark = false;
                FindSmallestNode(rootnode, SortedNets[i], ref finishmark);
            }
        }
        /// <summary>
        /// Removes all children of the specified node and retrieves all found networks
        /// </summary>
        /// <param name="rootnode"></param>
        /// <returns>Netsegment array of the nets, that were previously allocated in this node</returns>
        public NetSegment[] AggregateNode(NetTreeNode node)
        {
            List<NetSegment> Segments = new List<NetSegment>();
            FindNets(node, ref Segments);
            return Segments.ToArray();
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
