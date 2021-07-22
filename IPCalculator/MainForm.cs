using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace IPCalculator
{
    public partial class MainForm : Form
    {
        private Dictionary<int, NetSegment> Segments; //stores info about currently allocated nets
        private NetTree NetTree;
        public MainForm()
        {
            InitializeComponent();
            Segments = new Dictionary<int, NetSegment>();
        }

        #region Open/Save

        private void OpenNetTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OpenNetTreeDialog.ShowDialog() == DialogResult.OK)
            {
                string JsonText = File.ReadAllText(OpenNetTreeDialog.FileName);
                try
                {
                    dynamic Object = JsonConvert.DeserializeObject<dynamic>(JsonText);  //read allocated segments and tree
                    Segments = Object[0];
                    NetTree = Object[1];
                    CreateTreeView(NetTree.Root);   //update Tree and summary
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveNetTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NetTree != null)
            {
                if (SaveNetTreeDialog.ShowDialog() == DialogResult.OK)
                {
                    //save tree and color info
                    File.WriteAllText(SaveNetTreeDialog.FileName, JsonConvert.SerializeObject(new { Segments, NetTree }));
                }
            }
            else
            {
                MessageBox.Show("Дерево сетей не инициализировано");
            }
        }

        #endregion

        #region NetInfoPanel
        private void InfoBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Net net = new Net(AddressBox.Text);
                ShowNetInfo(net);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Shows information about the net at the info panel
        /// </summary>
        /// <param name="net"></param>
        private void ShowNetInfo(Net net)
        {
            AddressTextBox.Text = net.Address.ToString();
            StartAddressBox.Text = net.StartAddress.ToString();
            EndAddressBox.Text = net.EndAddress.ToString();
            BroadcastTextBox.Text = net.BroadcastAddress.ToString();
            SubnetMaskTextBox.Text = net.FullMask.ToString();
            ReverseMaskTextBox.Text = net.Wildcard.ToString();
            TotalHostBox.Text = net.HostAm.ToString();

        }
        #endregion

        #region DownLeftPanel

        #region NetsGridControl
        private Random rnd = new Random();

        private void NetsGrid_SelectionChanged(object sender, EventArgs e)
        {
            NetsGrid.ClearSelection();
        }

        private void AddSegmentBtn_Click(object sender, EventArgs e)
        {
            NetsGrid.RowCount += 1;
            NetsGrid.Rows[NetsGrid.RowCount - 1].Cells[1].Style.BackColor = System.Drawing.Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
        }

        private void DeleteSegmentBtn_Click(object sender, EventArgs e)
        {
            if (NetsGrid.RowCount > 1)
            {
                NetsGrid.RowCount -= 1;
            }
        }

        private void NetsGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (ColorPicker.ShowDialog() == DialogResult.OK)
                {
                    NetsGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = ColorPicker.Color;
                }
            }
            if (e.ColumnIndex == 2)
            {
                NetsGrid.Rows.RemoveAt(e.RowIndex);
            }
        }

        /// <summary>
        /// Populate NetsGrid with an array of netsegments, ignoring it's indexes
        /// </summary>
        /// <param name="nets"></param>
        private void PopulateNetsGrid(NetSegment[] nets)
        {
            NetsGrid.Rows.Clear();
            if (nets.Length != 0)        //ignore old net id here and just fill as it is
            {
                NetsGrid.RowCount = nets.Length;
                for (int i = 0; i < nets.Length; ++i)
                {
                    NetsGrid.Rows[i].Cells[0].Value = nets[i].HostAm;
                    NetsGrid.Rows[i].Cells[1].Style.BackColor = System.Drawing.Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                }
            }
        }
        #endregion

        #region DivideControlFunctions
        private NetSegment[] GetSegmentsToDistribute()
        {
            NetSegment[] NewSegments = new NetSegment[NetsGrid.RowCount];
            int key = 0;
            for (int i = 0; i < NetsGrid.RowCount; ++i)
            {
                while (Segments.ContainsKey(key)) { key++; }  //if new segments contains already allocated netid, find first free id
                NewSegments[i] = new NetSegment();
                NewSegments[i].Color = NetsGrid.Rows[i].Cells[1].Style.BackColor;
                NewSegments[i].Id = key;
                NewSegments[i].HostAm = Convert.ToInt32(NetsGrid.Rows[i].Cells[0].Value);  //create segments
                key++;
            }
            return NewSegments;

        }

        private void DivideBtn_Click(object sender, EventArgs e)
        {
            if (NetsGrid.RowCount != 0)
            {
                NetSegment[] SegmentsToAllocate = GetSegmentsToDistribute(); //get new segments from grid
                try
                {
                    if (NetTreeView.SelectedNode != null)    //if some node in tree is selected, use it as root
                    {
                        NetTree.DistributeNet(NetTree.LocateNode(new Net(NetTreeView.SelectedNode.Text)), ref SegmentsToAllocate);
                    }
                    else
                    {
                        if (NetTree == null)   //if tree does not exist
                        {
                            NetTree = new NetTree(new Net(AddressBox.Text)); // create new tree and new root
                        }
                        NetTree.DistributeNet(NetTree.Root, ref SegmentsToAllocate);
                    }
                    //if operation successful, add new segments to allocated
                    for (int i = 0; i < SegmentsToAllocate.Length; ++i)
                    {
                        Segments.Add(SegmentsToAllocate[i].Id, SegmentsToAllocate[i]);
                    }
                    CreateTreeView(NetTree.Root); //update tree UI
                    UpdateSummaryTable(); //print all allocated segments to user

                }
                catch (CannotDistributeNetsException ex)
                {
                    ClearData();
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        private void ClearData()
        {
            NetTree = null;     //clear tree
            NetTreeView.Nodes.Clear(); //clear treeview
            Segments.Clear();   //clear allocated net info
            NetListDataGridView.Rows.Clear();
        }

        private void ClearBtnClick(object sender, EventArgs e)
        {
            ClearData();
        }


        #endregion

        #region RightPanel

        #region UI Update Functions

        #region TreeView
        private void ParseNodeState(ref TreeNode Node, NetTreeNode NodeToParse)
        {
            if (NodeToParse.State == State.Occupied)  //if current node is occupied
            {
                Node.BackColor = Segments[NodeToParse.OccupyId].Color;  //set style of the node
            }
            if (NodeToParse.State == State.Leaf)
            {
                Node.BackColor = System.Drawing.Color.Red;
            }
            if (NodeToParse.State == State.Free)
            {
                Node.BackColor = System.Drawing.Color.White;
            }
        }

        private void CreateTreeView(NetTreeNode Root)
        {
            NetTreeView.Nodes.Clear();
            TreeNode Node = new TreeNode(Root.Net.ToString());  //create treeview root
            NetTreeView.Nodes.Add(Node);
            ParseNodeState(ref Node, Root);   //set node style
            AttachSubNodes(ref Node, Root);   //recursively attach subnodes
            NetTreeView.ExpandAll();
        }

        /// <summary>
        /// Creates and attaches TreeViewNode representaions of NetTreeNodeToParse children to TreeViewParent 
        /// </summary>
        /// <param name="TreeViewParent">Treeview parent node</param>
        /// <param name="NetTreeNodeToParse">NetTreeNode which children should be added to the parent</param>
        private void AttachSubNodes(ref TreeNode TreeViewParent, NetTreeNode NetTreeNodeToParse)
        {
            if (NetTreeNodeToParse.Left != null) //if left subtree exists
            {
                TreeNode LeftNode = AddNode(NetTreeNodeToParse.Left);  //create treeview node for left NetTreeNode
                TreeViewParent.Nodes.Add(LeftNode);                    //attach it to parent
                AttachSubNodes(ref LeftNode, NetTreeNodeToParse.Left); //call this function for left subtree
            }
            if (NetTreeNodeToParse.Right != null)
            {
                TreeNode RightNode = AddNode(NetTreeNodeToParse.Right); //the same way for right subtree
                TreeViewParent.Nodes.Add(RightNode);
                AttachSubNodes(ref RightNode, NetTreeNodeToParse.Right);
            }
        }

        /// <summary>
        /// Creates new TreeView node from NetTreeNode
        /// </summary>
        /// <param name="Parent">TreeView parent node</param>
        /// <param name="NodeToAdd">NetTree node from which new TreeView node will be created</param>
        /// <returns></returns>
        private TreeNode AddNode(NetTreeNode NodeToAdd)
        {
            TreeNode Node = new TreeNode(NodeToAdd.Net.ToString());
            ParseNodeState(ref Node, NodeToAdd); //set node style
            return Node;
        }

        #endregion

        #region SummaryTable

        /// <summary>
        /// Update UI to show all members of Segments Dictionary
        /// </summary>
        private void UpdateSummaryTable()
        {
            NetListDataGridView.Rows.Clear();
            int index = 0;
            foreach (KeyValuePair<int, NetSegment> element in Segments)
            {
                NetListDataGridView.RowCount += 1;
                NetListDataGridView.Rows[index].Cells[0].Value = element.Value.Id;
                NetListDataGridView.Rows[index].Cells[0].Style.BackColor = element.Value.Color;
                NetListDataGridView.Rows[index].Cells[1].Value = element.Value.AssignedNet.Address.ToString();
                NetListDataGridView.Rows[index].Cells[2].Value = element.Value.AssignedNet.StartAddress.ToString();
                NetListDataGridView.Rows[index].Cells[3].Value = element.Value.AssignedNet.EndAddress.ToString();
                NetListDataGridView.Rows[index].Cells[4].Value = element.Value.AssignedNet.BroadcastAddress.ToString();
                NetListDataGridView.Rows[index].Cells[5].Value = element.Value.AssignedNet.FullMask.ToString() + " (" + element.Value.AssignedNet.Mask.ToString() + ")";
                NetListDataGridView.Rows[index].Cells[6].Value = element.Value.AssignedNet.HostAm.ToString();
                NetListDataGridView.Rows[index].Cells[7].Value = element.Value.HostAm;
                NetListDataGridView.Rows[index].Cells[8].Value = element.Value.AssignedNet.HostAm - element.Value.HostAm;
                index++;
            }
            NetListDataGridView.Sort(NetListDataGridView.Columns[0], System.ComponentModel.ListSortDirection.Ascending); // sort all summary by netid
            NetListDataGridView.ClearSelection();
        }

        #endregion

        #endregion

        #region Treeview Context menu and Mouse events

        /// <summary>
        /// Aggregates nets from tree node and removes them from UI controls
        /// </summary>
        /// <returns>An array of aggregated nets</returns>
        private NetSegment[] AggregateNodes()
        {
            NetTreeNode Node = NetTree.LocateNode(new Net(NetTreeView.SelectedNode.Text));
            NetSegment[] AggregatedNets = NetTree.AggregateNode(Node);  //get aggregated nodes
            for (int i = 0; i < AggregatedNets.Length; ++i) //for each net
            {
                Segments.Remove(AggregatedNets[i].Id); // delete net from allocated nets
            }
            CreateTreeView(NetTree.Root);
            return AggregatedNets;
        }

        private void AggregateMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PopulateNetsGrid(AggregateNodes());
            }
            catch (CannotAggregateNetsException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NodeNotFoundException)
            {
                MessageBox.Show("Дерево было изменено вне программы и имеет неверный формат", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearMenuItem_Click(object sender, EventArgs e)
        {
            try  //to clear node we just aggregate node and dont populate found nets
            {
                AggregateNodes();
            }
            catch (CannotAggregateNetsException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NodeNotFoundException)
            {
                MessageBox.Show("Дерево было изменено вне программы и имеет неверный формат", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NetTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            NetTreeView.SelectedNode = e.Node;
            ShowNetInfo(new Net(e.Node.Text));
        }





        #endregion

        #endregion


    }
}
