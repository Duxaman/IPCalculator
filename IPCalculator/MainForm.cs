using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

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
                    ParseNetTree(NetTree.Root);   //update Tree and summary
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
                        NetTree.DistributeNet(NetTree.LocateNode(new Net(NetTreeView.SelectedNode.Text)), SegmentsToAllocate);
                    }
                    else
                    {
                        if (NetTree == null)   //if tree does not exist
                        {
                            NetTree = new NetTree(new Net(AddressBox.Text)); // create new tree and new root
                        }
                        NetTree.DistributeNet(NetTree.Root, SegmentsToAllocate);
                    }
                    //if operation successful, add new segments to allocated
                    for (int i = 0; i < SegmentsToAllocate.Length; ++i)
                    {
                        Segments.Add(SegmentsToAllocate[i].Id, SegmentsToAllocate[i]);
                    }
                    ParseNetTree(NetTree.Root); //update UI controls
                }
                catch (CannotDistributeNetsException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        private void ClearBtnClick(object sender, EventArgs e)
        {
            NetTree = null;     //clear tree
            ClearUI();
            Segments.Clear();   //clear allocated net info
        }

        private void ClearUI()
        {
            NetTreeView.Nodes.Clear(); //clear view
            NetListDataGridView.Rows.Clear();  //clear summary table
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
                AddNetSummary(NodeToParse.OccupyId, NodeToParse.Net);   //add node info to summary
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

        private void ParseNetTree(NetTreeNode Root)
        {
            ClearUI();
            TreeNode Node = new TreeNode(Root.Net.ToString());  //create treeview root
            NetTreeView.Nodes.Add(Node);
            ParseNodeState(ref Node, Root);   //parse node state
            AttachSubNodes(ref Node, Root);   //recursively attach subnodes
            NetTreeView.ExpandAll();
        }

        private void AttachSubNodes(ref TreeNode Node, NetTreeNode NodeToAdd)
        {
            if (NodeToAdd.Left != null)
            {
                AddNode(ref Node, NodeToAdd.Left);
            }
            if (NodeToAdd.Right != null)
            {
                AddNode(ref Node, NodeToAdd.Right);
            }
        }

        private void AddNode(ref TreeNode Parent, NetTreeNode NodeToAdd)
        {
            TreeNode Node = new TreeNode(NodeToAdd.Net.ToString());
            ParseNodeState(ref Node, NodeToAdd);
            AttachSubNodes(ref Node, NodeToAdd);
            Parent.Nodes.Add(Node);
        }

        private void NetTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ShowNetInfo(new Net(e.Node.Text));
        }


        #endregion

        #region SummaryTable
        /// <summary>
        /// Adds information about the net into the summary table
        /// </summary>
        /// <param name="netid">Id of the net</param>
        /// <param name="net">Net to add</param>
        private void AddNetSummary(int netid, Net net)
        {
            NetListDataGridView.RowCount += 1;
            int index = NetListDataGridView.RowCount - 1;
            NetListDataGridView.Rows[index].Cells[0].Value = netid;
            NetListDataGridView.Rows[index].Cells[1].Value = net.Address.ToString();
            NetListDataGridView.Rows[index].Cells[2].Value = net.StartAddress.ToString();
            NetListDataGridView.Rows[index].Cells[3].Value = net.EndAddress.ToString();
            NetListDataGridView.Rows[index].Cells[4].Value = net.BroadcastAddress.ToString();
            NetListDataGridView.Rows[index].Cells[5].Value = net.FullMask.ToString();
            NetListDataGridView.Rows[index].Cells[6].Value = net.HostAm.ToString();
            NetListDataGridView.Rows[index].Cells[7].Value = Segments[netid].HostAm;
            NetListDataGridView.Rows[index].Cells[8].Value = net.HostAm - Segments[netid].HostAm;
            NetListDataGridView.Sort(NetListDataGridView.Columns[0], System.ComponentModel.ListSortDirection.Ascending); // sort all summary by netid
        }

        #endregion

        #endregion

        #region Treeview Context menu

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
            ParseNetTree(NetTree.Root);
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





        #endregion

        #endregion


    }
}
