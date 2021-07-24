using IPCalculator;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class NetTreeTests
    {
        private struct DistributeTestCase
        {
            public Net RootNet;
            public NetSegment[] InputSegments;
            public NetSegment[] ExpectedSegments;
        }
        private static Dictionary<string, DistributeTestCase> DistributeCases;
        [SetUp]
        public void CreateTestSets()
        {
            DistributeCases = new Dictionary<string, DistributeTestCase>();
            DistributeTestCase NotEnoughtPlaceCase = new DistributeTestCase();
            NotEnoughtPlaceCase.RootNet = new Net("192.168.4.0/29");
            NotEnoughtPlaceCase.InputSegments = new NetSegment[6];
            for (int i = 0; i < 6; ++i)
            {
                NotEnoughtPlaceCase.InputSegments[i] = new NetSegment();
                NotEnoughtPlaceCase.InputSegments[i].Id = i;
                NotEnoughtPlaceCase.InputSegments[i].HostAm = 1;
            }
            DistributeCases["DistributeNotEnoughtPlaceTooManyNets"] = NotEnoughtPlaceCase;
            //******************************************************************************
            DistributeTestCase NotEnoughtPlaceCase1 = new DistributeTestCase();
            NotEnoughtPlaceCase1.RootNet = new Net("192.168.4.0/16");
            NotEnoughtPlaceCase1.InputSegments = new NetSegment[1];
            NotEnoughtPlaceCase1.InputSegments[0] = new NetSegment();
            NotEnoughtPlaceCase1.InputSegments[0].Id = 0;
            NotEnoughtPlaceCase1.InputSegments[0].HostAm = 80000;
            DistributeCases["DistributeNotEnoughtPlaceTooManyHosts"] = NotEnoughtPlaceCase1;
            //******************************************************************************
            DistributeTestCase MultipleSmallNets = new DistributeTestCase();
            MultipleSmallNets.RootNet = new Net("192.168.0.0/27");
            MultipleSmallNets.InputSegments = new NetSegment[8];
            MultipleSmallNets.ExpectedSegments = new NetSegment[8];
            for (int i = 0; i < 8; ++i)
            {
                MultipleSmallNets.InputSegments[i] = new NetSegment();
                MultipleSmallNets.InputSegments[i].Id = i;
                MultipleSmallNets.InputSegments[i].HostAm = 1;
                MultipleSmallNets.InputSegments[i].Color = System.Drawing.Color.Yellow;
                MultipleSmallNets.ExpectedSegments[i] = new NetSegment();
                MultipleSmallNets.ExpectedSegments[i].Id = i;
                MultipleSmallNets.ExpectedSegments[i].HostAm = 1;
                MultipleSmallNets.ExpectedSegments[i].Color = System.Drawing.Color.Yellow;
            }
            MultipleSmallNets.ExpectedSegments[0].AssignedNet = new Net("192.168.0.0/30");
            MultipleSmallNets.ExpectedSegments[1].AssignedNet = new Net("192.168.0.4/30");
            MultipleSmallNets.ExpectedSegments[2].AssignedNet = new Net("192.168.0.8/30");
            MultipleSmallNets.ExpectedSegments[3].AssignedNet = new Net("192.168.0.12/30");
            MultipleSmallNets.ExpectedSegments[4].AssignedNet = new Net("192.168.0.16/30");
            MultipleSmallNets.ExpectedSegments[5].AssignedNet = new Net("192.168.0.20/30");
            MultipleSmallNets.ExpectedSegments[6].AssignedNet = new Net("192.168.0.24/30");
            MultipleSmallNets.ExpectedSegments[7].AssignedNet = new Net("192.168.0.28/30");
            DistributeCases["MultipleSmallNets"] = MultipleSmallNets;
            //******************************************************************************
            DistributeTestCase JustSetOfNets = new DistributeTestCase();
            JustSetOfNets.RootNet = new Net("192.168.2.0/23");
            JustSetOfNets.InputSegments = new NetSegment[6];
            JustSetOfNets.ExpectedSegments = new NetSegment[6];
            int hostam = 6;
            for (int i = 0; i < 6; ++i)
            {
                JustSetOfNets.InputSegments[i] = new NetSegment();
                JustSetOfNets.InputSegments[i].Id = i;
                JustSetOfNets.InputSegments[i].HostAm = hostam;
                JustSetOfNets.InputSegments[i].Color = System.Drawing.Color.Yellow;
                JustSetOfNets.ExpectedSegments[i] = new NetSegment();
                JustSetOfNets.ExpectedSegments[i].Id = i;
                JustSetOfNets.ExpectedSegments[i].HostAm = hostam;
                JustSetOfNets.ExpectedSegments[i].Color = System.Drawing.Color.Yellow;
                hostam *= 2;
            }
            JustSetOfNets.ExpectedSegments[0].AssignedNet = new Net("192.168.3.240/29");
            JustSetOfNets.ExpectedSegments[1].AssignedNet = new Net("192.168.3.224/28");
            JustSetOfNets.ExpectedSegments[2].AssignedNet = new Net("192.168.3.192/27");
            JustSetOfNets.ExpectedSegments[3].AssignedNet = new Net("192.168.3.128/26");
            JustSetOfNets.ExpectedSegments[4].AssignedNet = new Net("192.168.3.0/25");
            JustSetOfNets.ExpectedSegments[5].AssignedNet = new Net("192.168.2.0/24");
            DistributeCases["JustSetOfNets"] = JustSetOfNets;
            //******************************************************************************
            DistributeTestCase TwoDifferentNets = new DistributeTestCase();
            TwoDifferentNets.RootNet = new Net("192.168.0.0/23");
            TwoDifferentNets.InputSegments = new NetSegment[2];
            TwoDifferentNets.ExpectedSegments = new NetSegment[2];
            TwoDifferentNets.InputSegments[0] = new NetSegment();
            TwoDifferentNets.InputSegments[0].Id = 0;
            TwoDifferentNets.InputSegments[0].HostAm = 254;
            TwoDifferentNets.InputSegments[0].Color = System.Drawing.Color.Yellow;
            TwoDifferentNets.ExpectedSegments[0] = new NetSegment();
            TwoDifferentNets.ExpectedSegments[0].Id = 0;
            TwoDifferentNets.ExpectedSegments[0].HostAm = 254;
            TwoDifferentNets.ExpectedSegments[0].Color = System.Drawing.Color.Yellow;
            TwoDifferentNets.InputSegments[1] = new NetSegment();
            TwoDifferentNets.InputSegments[1].Id = 1;
            TwoDifferentNets.InputSegments[1].HostAm = 1;
            TwoDifferentNets.InputSegments[1].Color = System.Drawing.Color.Yellow;
            TwoDifferentNets.ExpectedSegments[1] = new NetSegment();
            TwoDifferentNets.ExpectedSegments[1].Id = 1;
            TwoDifferentNets.ExpectedSegments[1].HostAm = 1;
            TwoDifferentNets.ExpectedSegments[1].Color = System.Drawing.Color.Yellow;
            TwoDifferentNets.ExpectedSegments[0].AssignedNet = new Net("192.168.0.0/24");
            TwoDifferentNets.ExpectedSegments[1].AssignedNet = new Net("192.168.1.0/30");
            DistributeCases["TwoDifferentNets"] = TwoDifferentNets;
        }

        private bool SegmentsArrayHasTheSameElements(NetSegment[] actual, NetSegment[] reference)
        {
            actual.OrderBy(x => x.Id);
            reference.OrderBy(x => x.Id);
            for(int i = 0; i < actual.Length; ++i)
            {
                if (!actual[i].AssignedNet.Equals(reference[i].AssignedNet)) return false;
                if (actual[i].Color != reference[i].Color) return false;
                if (actual[i].HostAm != reference[i].HostAm) return false;
                if (actual[i].Id != reference[i].Id) return false;
            }
            return true;
        }

        private NetTreeNode CreateTestTree()
        {
            NetTreeNode TestRoot = new NetTreeNode(new Net("192.168.4.16/28"));
            NetTreeNode TestRootLeft = new NetTreeNode(new Net("192.168.4.16/29"));
            NetTreeNode TestRootRight = new NetTreeNode(new Net("192.168.4.24/29"));
            NetTreeNode BottomLeft = new NetTreeNode(new Net("192.168.4.16/30"));
            NetTreeNode BottomRight = new NetTreeNode(new Net("192.168.4.20/30"));
            BottomLeft.State = State.Leaf;
            BottomRight.State = State.Leaf;
            TestRootLeft.State = State.Occupied;
            TestRootLeft.OccupyId = 0;
            TestRootLeft.Left = BottomLeft;
            TestRootLeft.Right = BottomRight;
            TestRoot.Left = TestRootLeft;
            TestRoot.Right = TestRootRight;
            return TestRoot;
        }

        [Test]
        [TestCase("192.168.4.16/28")]
        [TestCase("192.168.4.16/29")]
        [TestCase("192.168.4.16/30")]
        [TestCase("192.168.4.20/30")]
        [TestCase("192.168.4.24/29")]
        public void LocateNodeReturnsCorrectNode(string testcase)
        {
            try
            {
                NetTree TestTree = new NetTree(CreateTestTree());
                NetTreeNode node = TestTree.LocateNode(new Net(testcase));
                if (!node.Net.Equals(new Net(testcase)))
                {
                    Assert.Fail();
                }
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [Test]
        [TestCase("192.168.4.16/25")]
        [TestCase("192.168.4.24/30")]
        [TestCase("192.134.4.24/10")]
        public void LocateNodeThrowsNodeNotFoundExceptionWhenNodeNotFound(string testcase)
        {
            try
            {
                NetTree TestTree = new NetTree(CreateTestTree());
                NetTreeNode node = TestTree.LocateNode(new Net(testcase));
                Assert.Fail();

            }
            catch (NodeNotFoundException)
            { }
            catch (System.Exception)
            {
                Assert.Fail();
            }
        }

        [Test]
        [TestCase("MultipleSmallNets")]
        [TestCase("JustSetOfNets")]
        [TestCase("TwoDifferentNets")]
        public void DistributeNetReturnsCorrectSegments(string testcase)
        {
            DistributeTestCase Case = DistributeCases[testcase];
            try
            {
                NetTree TestTree = new NetTree(Case.RootNet);
                TestTree.DistributeNet(TestTree.Root, ref Case.InputSegments);
                if(!SegmentsArrayHasTheSameElements(Case.InputSegments, Case.ExpectedSegments))
                {
                    Assert.Fail();
                }
            }
            catch (System.Exception)
            {
                Assert.Fail();
            }
        }
        [Test]
        [TestCase("DistributeNotEnoughtPlaceTooManyNets")]
        [TestCase("DistributeNotEnoughtPlaceTooManyHosts")]
        public void DistributeNetThrowsExceptionWhenThereIsNoPlaceForNetworks(string testcase)
        {
            DistributeTestCase Case = DistributeCases[testcase];
            try
            {
                NetTree TestTree = new NetTree(Case.RootNet);
                TestTree.DistributeNet(TestTree.Root, ref Case.InputSegments);
                Assert.Fail();
            }
            catch (CannotDistributeNetsException) { }
            catch (System.Exception)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void DistributeNetThrowsExceptionWhenSegmentArrayIsEmpty()
        {
            NetSegment[] netSegments = new NetSegment[] { };
            try
            {
                NetTree TestTree = new NetTree(new Net("192.168.13.44/12"));
                TestTree.DistributeNet(TestTree.Root, ref netSegments);
                Assert.Fail();
            }
            catch (CannotDistributeNetsException)
            {

            }
            catch (System.Exception)
            {
                Assert.Fail();
            }

        }

        [Test]
        public void AggregateNodeThrowsExceptionWhenTryAggregatingLeaf()
        {
            NetTreeNode Root = CreateTestTree();
            try
            {
                NetTree netTree = new NetTree(Root);
                netTree.AggregateNode(netTree.LocateNode(new Net("192.168.4.20/30")));
                Assert.Fail();
            }
            catch(CannotAggregateNetsException)
            {
            }
            catch(Exception)
            {
                Assert.Fail();
            }
        }
        [Test]
        public void AggregateNodeReturnCorrectSegmentsWhenNodeIsOccupied()
        {
            NetTreeNode Root = CreateTestTree();
            try
            {
                NetTree netTree = new NetTree(Root);
                NetSegment[] Segments =  netTree.AggregateNode(netTree.LocateNode(new Net("192.168.4.16/29")));
                if(Segments.Length == 1)
                {
                    if (Segments[0].HostAm != 6) Assert.Fail();
                    if (Segments[0].Id != 0) Assert.Fail();
                }
                else Assert.Fail();
                
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }
    }

}