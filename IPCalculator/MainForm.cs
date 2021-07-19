using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace IPCalculator
{
    public partial class MainForm : Form
    {
        private System.Drawing.Color[] Colors; //for saving purposes;
        private NetTree NetTree;
        public MainForm()
        {
            InitializeComponent();
        }

        private void OpenNetTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OpenNetTreeDialog.ShowDialog() == DialogResult.OK)
            {
                string JsonText = File.ReadAllText(OpenNetTreeDialog.FileName);
                try
                {
                    dynamic Object = JsonConvert.DeserializeObject<dynamic>(JsonText);
                    Colors = Object[0];
                    NetTree = Object[1];
                    ParseNetTree(NetTree.Root);
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
                    File.WriteAllText(SaveNetTreeDialog.FileName, JsonConvert.SerializeObject(new { Colors, NetTree }));
                }
            }
            else
            {
                MessageBox.Show("Дерево сетей не инициализировано"); //TODO
            }
        }

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
        #region BtnPanel

        private int[] GetSegmentsToDistribute()
        {
            NetsGrid.Sort(NetsGrid.Columns[0], System.ComponentModel.ListSortDirection.Descending);
            int[] nets = new int[NetsGrid.RowCount];
            Colors = new System.Drawing.Color[NetsGrid.RowCount];
            for (int i = 0; i < NetsGrid.RowCount; ++i)
            {
                nets[i] = Convert.ToInt32(NetsGrid.Rows[i].Cells[0].Value);
                Colors[i] = NetsGrid.Rows[i].Cells[1].Style.BackColor;
            }
            return nets;
        }

        private void AddSegmentBtn_Click(object sender, EventArgs e)
        {
            NetsGrid.RowCount += 1;
        }

        private void DeleteSegmentBtn_Click(object sender, EventArgs e)
        {
            if (NetsGrid.RowCount > 1)
            {
                NetsGrid.RowCount -= 1;
            }
        }

        private void DivideBtn_Click(object sender, EventArgs e)
        {
            if (NetsGrid.RowCount != 0)
            {
                int[] nets = GetSegmentsToDistribute();
                try
                {
                    if (NetTreeView.SelectedNode != null)
                    {
                        NetTree.DistributeNet(NetTree.LocateNode(NetTree.Root, new Net(NetTreeView.SelectedNode.Text)), nets);
                    }
                    else
                    {
                        if (NetTree == null)
                        {
                            NetTree = new NetTree(new Net(AddressTextBox.Text));
                        }
                        NetTree.DistributeNet(NetTree.Root, nets);
                    }
                    ParseNetTree(NetTree.Root);
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

        private void ClearBtnClick(object sender, EventArgs e)
        {
            NetTree = null;
            NetTreeView.Nodes.Clear();
            NetListDataGridView.Rows.Clear();
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
        #endregion

        #region SummaryTable
        private void AddNetSummary(int netid, Net net)
        {

        }
        #endregion

        #region TreeView
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

        private void ParseNodeState(ref TreeNode Node, NetTreeNode NodeToParse)
        {
            if (NodeToParse.State == State.Occupied)
            {
                Node.BackColor = NetsGrid.Rows[NodeToParse.OccupyId].Cells[1].Style.BackColor;
                AddNetSummary(NodeToParse.OccupyId, NodeToParse.Net);
            }
            if (NodeToParse.State == State.Leaf)
            {
                Node.BackColor = System.Drawing.Color.Red;
            }
        }
        private void ParseNetTree(NetTreeNode Root)
        {
            TreeNode Node = new TreeNode(Root.Net.ToString());
            ParseNodeState(ref Node, Root);
            AttachSubNodes(ref Node, Root);
        }

        private void AddNode(ref TreeNode Parent, NetTreeNode NodeToAdd)
        {
            TreeNode Node = new TreeNode(NodeToAdd.Net.ToString());
            ParseNodeState(ref Node, NodeToAdd);
            AttachSubNodes(ref Node, NodeToAdd);
            Parent.Nodes.Add(Node);
        }

        private void PopulateNetsGrid(int[] nets)
        {
            NetsGrid.Rows.Clear();
            if (nets.Length != 0)
            {
                NetsGrid.RowCount = nets.Length;
                for (int i = 0; i < nets.Length; ++i)
                {
                    NetsGrid.Rows[i].Cells[0].Value = nets[i];
                }
            }
        }

        private void AggregateMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                NetTreeNode Node = NetTree.LocateNode(NetTree.Root, new Net(NetTreeView.SelectedNode.Text));
                PopulateNetsGrid(NetTree.AggregateNode(Node));
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
            try
            {
                NetTreeNode Node = NetTree.LocateNode(NetTree.Root, new Net(NetTreeView.SelectedNode.Text));
                NetTree.ClearNode(Node);
            }
            catch (NodeNotFoundException)
            {
                MessageBox.Show("Дерево было изменено вне программы и имеет неверный формат", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion


    }
}
