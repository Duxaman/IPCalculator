using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPCalculator
{
    sealed public class NetTree
    {
        public NetTreeNode Root { get; private set; }

        public NetTreeNode LocateNode(NetTreeNode CurRoot, Net NodeToLocate)
        {
            NetTreeNode CurNode = CurRoot;
            for (int i = 0; i < 4; ++i)
            {
                if(CurNode.Net.Address[i] == NodeToLocate.Address[i])
                {
                    continue;
                }
                else
                {
                    if(CurNode.Net.Address[i] < NodeToLocate.Address[i])
                    {
                        if (CurNode.Right != null)
                        {
                            return LocateNode(CurNode.Right, NodeToLocate); 
                        }
                        else
                        {
                            throw new NodeNotFoundException();
                        }
                    }
                    else
                    {
                        throw new NodeNotFoundException();
                    }
                }
            }
            if(CurNode.Net.Mask < NodeToLocate.Mask)
            {
                if (CurNode.Left != null)
                {
                    return LocateNode(CurNode.Left, NodeToLocate); 
                }
                else
                {
                    throw new NodeNotFoundException();
                }
            }
            else if (CurNode.Net.Mask == NodeToLocate.Mask)
            {
                return CurNode;
            }
            else
            {
                throw new NodeNotFoundException();
            }
        }

        public NetTree(Net RootNet)
        {
            Root = new NetTreeNode(RootNet);
        }

        public NetTree(NetTreeNode rootnode)
        {
            Root = rootnode;
        }

        public void DistributeNet(NetTreeNode rootnode, int[] net)
        { }
        public int[] AggregateNode(NetTreeNode rootnode)
        {

        }

        public void ClearNode(NetTreeNode rootnode)
        {

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
