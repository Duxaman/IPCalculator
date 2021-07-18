using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPCalculator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void OpenNetTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SaveNetTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void InfoBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Net net = new Net(AddressBox.Text);
                ShowNetInfo(net);
            }
            catch(Exception ex)
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

        }

        private void RedivideBtn_Click(object sender, EventArgs e)
        {

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

            #endregion

            #region TreeView
            #endregion

        }
    }
}
