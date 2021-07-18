namespace IPCalculator
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenNetTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveNetTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainGrid = new System.Windows.Forms.TableLayoutPanel();
            this.RightPanel = new System.Windows.Forms.TableLayoutPanel();
            this.NetTreeView = new System.Windows.Forms.TreeView();
            this.TreeViewContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AggregateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NetListDataGridView = new System.Windows.Forms.DataGridView();
            this.IdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BroadcastAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubnetMask = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalHosts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Occupied = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Free = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LeftPanel = new System.Windows.Forms.TableLayoutPanel();
            this.RootAddressBox = new System.Windows.Forms.GroupBox();
            this.InfoBtn = new System.Windows.Forms.Button();
            this.AddressBox = new System.Windows.Forms.TextBox();
            this.InfoBox = new System.Windows.Forms.GroupBox();
            this.TotalHostBox = new System.Windows.Forms.TextBox();
            this.ReverseMaskTextBox = new System.Windows.Forms.TextBox();
            this.SubnetMaskTextBox = new System.Windows.Forms.TextBox();
            this.BroadcastTextBox = new System.Windows.Forms.TextBox();
            this.EndAddressBox = new System.Windows.Forms.TextBox();
            this.StartAddressBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NetsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.NetsBtnPanel = new System.Windows.Forms.Panel();
            this.RedivideBtn = new System.Windows.Forms.Button();
            this.DivideBtn = new System.Windows.Forms.Button();
            this.DeleteSegmentBtn = new System.Windows.Forms.Button();
            this.AddSegmentBtn = new System.Windows.Forms.Button();
            this.NetsGrid = new System.Windows.Forms.DataGridView();
            this.HostAm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeleteColiumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColorPicker = new System.Windows.Forms.ColorDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.AddressTextBox = new System.Windows.Forms.TextBox();
            this.MainMenuStrip.SuspendLayout();
            this.MainGrid.SuspendLayout();
            this.RightPanel.SuspendLayout();
            this.TreeViewContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NetListDataGridView)).BeginInit();
            this.LeftPanel.SuspendLayout();
            this.RootAddressBox.SuspendLayout();
            this.InfoBox.SuspendLayout();
            this.NetsPanel.SuspendLayout();
            this.NetsBtnPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NetsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem});
            resources.ApplyResources(this.MainMenuStrip, "MainMenuStrip");
            this.MainMenuStrip.Name = "MainMenuStrip";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenNetTreeToolStripMenuItem,
            this.SaveNetTreeToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            resources.ApplyResources(this.FileToolStripMenuItem, "FileToolStripMenuItem");
            // 
            // OpenNetTreeToolStripMenuItem
            // 
            this.OpenNetTreeToolStripMenuItem.Name = "OpenNetTreeToolStripMenuItem";
            resources.ApplyResources(this.OpenNetTreeToolStripMenuItem, "OpenNetTreeToolStripMenuItem");
            this.OpenNetTreeToolStripMenuItem.Click += new System.EventHandler(this.OpenNetTreeToolStripMenuItem_Click);
            // 
            // SaveNetTreeToolStripMenuItem
            // 
            this.SaveNetTreeToolStripMenuItem.Name = "SaveNetTreeToolStripMenuItem";
            resources.ApplyResources(this.SaveNetTreeToolStripMenuItem, "SaveNetTreeToolStripMenuItem");
            this.SaveNetTreeToolStripMenuItem.Click += new System.EventHandler(this.SaveNetTreeToolStripMenuItem_Click);
            // 
            // MainGrid
            // 
            resources.ApplyResources(this.MainGrid, "MainGrid");
            this.MainGrid.Controls.Add(this.RightPanel, 1, 0);
            this.MainGrid.Controls.Add(this.LeftPanel, 0, 0);
            this.MainGrid.Name = "MainGrid";
            // 
            // RightPanel
            // 
            resources.ApplyResources(this.RightPanel, "RightPanel");
            this.RightPanel.Controls.Add(this.NetTreeView, 0, 0);
            this.RightPanel.Controls.Add(this.NetListDataGridView, 0, 1);
            this.RightPanel.Name = "RightPanel";
            // 
            // NetTreeView
            // 
            this.NetTreeView.ContextMenuStrip = this.TreeViewContextMenu;
            resources.ApplyResources(this.NetTreeView, "NetTreeView");
            this.NetTreeView.Name = "NetTreeView";
            // 
            // TreeViewContextMenu
            // 
            this.TreeViewContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AggregateMenuItem,
            this.ClearMenuItem});
            this.TreeViewContextMenu.Name = "TreeViewContextMenu";
            resources.ApplyResources(this.TreeViewContextMenu, "TreeViewContextMenu");
            // 
            // AggregateMenuItem
            // 
            this.AggregateMenuItem.Name = "AggregateMenuItem";
            resources.ApplyResources(this.AggregateMenuItem, "AggregateMenuItem");
            // 
            // ClearMenuItem
            // 
            this.ClearMenuItem.Name = "ClearMenuItem";
            resources.ApplyResources(this.ClearMenuItem, "ClearMenuItem");
            // 
            // NetListDataGridView
            // 
            this.NetListDataGridView.AllowUserToAddRows = false;
            this.NetListDataGridView.AllowUserToDeleteRows = false;
            this.NetListDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.NetListDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.NetListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NetListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdColumn,
            this.Address,
            this.StartAddress,
            this.EndAddress,
            this.BroadcastAddress,
            this.SubnetMask,
            this.TotalHosts,
            this.Occupied,
            this.Free});
            resources.ApplyResources(this.NetListDataGridView, "NetListDataGridView");
            this.NetListDataGridView.Name = "NetListDataGridView";
            this.NetListDataGridView.ReadOnly = true;
            this.NetListDataGridView.RowHeadersVisible = false;
            // 
            // IdColumn
            // 
            this.IdColumn.Frozen = true;
            resources.ApplyResources(this.IdColumn, "IdColumn");
            this.IdColumn.Name = "IdColumn";
            this.IdColumn.ReadOnly = true;
            // 
            // Address
            // 
            this.Address.Frozen = true;
            resources.ApplyResources(this.Address, "Address");
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            // 
            // StartAddress
            // 
            this.StartAddress.Frozen = true;
            resources.ApplyResources(this.StartAddress, "StartAddress");
            this.StartAddress.Name = "StartAddress";
            this.StartAddress.ReadOnly = true;
            // 
            // EndAddress
            // 
            this.EndAddress.Frozen = true;
            resources.ApplyResources(this.EndAddress, "EndAddress");
            this.EndAddress.Name = "EndAddress";
            this.EndAddress.ReadOnly = true;
            // 
            // BroadcastAddress
            // 
            this.BroadcastAddress.Frozen = true;
            resources.ApplyResources(this.BroadcastAddress, "BroadcastAddress");
            this.BroadcastAddress.Name = "BroadcastAddress";
            this.BroadcastAddress.ReadOnly = true;
            // 
            // SubnetMask
            // 
            this.SubnetMask.Frozen = true;
            resources.ApplyResources(this.SubnetMask, "SubnetMask");
            this.SubnetMask.Name = "SubnetMask";
            this.SubnetMask.ReadOnly = true;
            // 
            // TotalHosts
            // 
            this.TotalHosts.Frozen = true;
            resources.ApplyResources(this.TotalHosts, "TotalHosts");
            this.TotalHosts.Name = "TotalHosts";
            this.TotalHosts.ReadOnly = true;
            // 
            // Occupied
            // 
            this.Occupied.Frozen = true;
            resources.ApplyResources(this.Occupied, "Occupied");
            this.Occupied.Name = "Occupied";
            this.Occupied.ReadOnly = true;
            // 
            // Free
            // 
            this.Free.Frozen = true;
            resources.ApplyResources(this.Free, "Free");
            this.Free.Name = "Free";
            this.Free.ReadOnly = true;
            // 
            // LeftPanel
            // 
            resources.ApplyResources(this.LeftPanel, "LeftPanel");
            this.LeftPanel.Controls.Add(this.RootAddressBox, 0, 0);
            this.LeftPanel.Controls.Add(this.InfoBox, 0, 1);
            this.LeftPanel.Controls.Add(this.NetsPanel, 0, 2);
            this.LeftPanel.Name = "LeftPanel";
            // 
            // RootAddressBox
            // 
            this.RootAddressBox.Controls.Add(this.InfoBtn);
            this.RootAddressBox.Controls.Add(this.AddressBox);
            resources.ApplyResources(this.RootAddressBox, "RootAddressBox");
            this.RootAddressBox.Name = "RootAddressBox";
            this.RootAddressBox.TabStop = false;
            // 
            // InfoBtn
            // 
            resources.ApplyResources(this.InfoBtn, "InfoBtn");
            this.InfoBtn.Name = "InfoBtn";
            this.InfoBtn.UseVisualStyleBackColor = true;
            this.InfoBtn.Click += new System.EventHandler(this.InfoBtn_Click);
            // 
            // AddressBox
            // 
            resources.ApplyResources(this.AddressBox, "AddressBox");
            this.AddressBox.Name = "AddressBox";
            // 
            // InfoBox
            // 
            this.InfoBox.Controls.Add(this.TotalHostBox);
            this.InfoBox.Controls.Add(this.ReverseMaskTextBox);
            this.InfoBox.Controls.Add(this.SubnetMaskTextBox);
            this.InfoBox.Controls.Add(this.BroadcastTextBox);
            this.InfoBox.Controls.Add(this.EndAddressBox);
            this.InfoBox.Controls.Add(this.StartAddressBox);
            this.InfoBox.Controls.Add(this.AddressTextBox);
            this.InfoBox.Controls.Add(this.label7);
            this.InfoBox.Controls.Add(this.label6);
            this.InfoBox.Controls.Add(this.label5);
            this.InfoBox.Controls.Add(this.label4);
            this.InfoBox.Controls.Add(this.label3);
            this.InfoBox.Controls.Add(this.label2);
            this.InfoBox.Controls.Add(this.label1);
            resources.ApplyResources(this.InfoBox, "InfoBox");
            this.InfoBox.Name = "InfoBox";
            this.InfoBox.TabStop = false;
            // 
            // TotalHostBox
            // 
            resources.ApplyResources(this.TotalHostBox, "TotalHostBox");
            this.TotalHostBox.Name = "TotalHostBox";
            // 
            // ReverseMaskTextBox
            // 
            resources.ApplyResources(this.ReverseMaskTextBox, "ReverseMaskTextBox");
            this.ReverseMaskTextBox.Name = "ReverseMaskTextBox";
            // 
            // SubnetMaskTextBox
            // 
            resources.ApplyResources(this.SubnetMaskTextBox, "SubnetMaskTextBox");
            this.SubnetMaskTextBox.Name = "SubnetMaskTextBox";
            // 
            // BroadcastTextBox
            // 
            resources.ApplyResources(this.BroadcastTextBox, "BroadcastTextBox");
            this.BroadcastTextBox.Name = "BroadcastTextBox";
            // 
            // EndAddressBox
            // 
            resources.ApplyResources(this.EndAddressBox, "EndAddressBox");
            this.EndAddressBox.Name = "EndAddressBox";
            // 
            // StartAddressBox
            // 
            resources.ApplyResources(this.StartAddressBox, "StartAddressBox");
            this.StartAddressBox.Name = "StartAddressBox";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // NetsPanel
            // 
            resources.ApplyResources(this.NetsPanel, "NetsPanel");
            this.NetsPanel.Controls.Add(this.NetsBtnPanel, 0, 0);
            this.NetsPanel.Controls.Add(this.NetsGrid, 0, 1);
            this.NetsPanel.Name = "NetsPanel";
            // 
            // NetsBtnPanel
            // 
            this.NetsBtnPanel.Controls.Add(this.RedivideBtn);
            this.NetsBtnPanel.Controls.Add(this.DivideBtn);
            this.NetsBtnPanel.Controls.Add(this.DeleteSegmentBtn);
            this.NetsBtnPanel.Controls.Add(this.AddSegmentBtn);
            resources.ApplyResources(this.NetsBtnPanel, "NetsBtnPanel");
            this.NetsBtnPanel.Name = "NetsBtnPanel";
            // 
            // RedivideBtn
            // 
            resources.ApplyResources(this.RedivideBtn, "RedivideBtn");
            this.RedivideBtn.Name = "RedivideBtn";
            this.RedivideBtn.UseVisualStyleBackColor = true;
            this.RedivideBtn.Click += new System.EventHandler(this.RedivideBtn_Click);
            // 
            // DivideBtn
            // 
            resources.ApplyResources(this.DivideBtn, "DivideBtn");
            this.DivideBtn.Name = "DivideBtn";
            this.DivideBtn.UseVisualStyleBackColor = true;
            this.DivideBtn.Click += new System.EventHandler(this.DivideBtn_Click);
            // 
            // DeleteSegmentBtn
            // 
            resources.ApplyResources(this.DeleteSegmentBtn, "DeleteSegmentBtn");
            this.DeleteSegmentBtn.Name = "DeleteSegmentBtn";
            this.DeleteSegmentBtn.UseVisualStyleBackColor = true;
            this.DeleteSegmentBtn.Click += new System.EventHandler(this.DeleteSegmentBtn_Click);
            // 
            // AddSegmentBtn
            // 
            resources.ApplyResources(this.AddSegmentBtn, "AddSegmentBtn");
            this.AddSegmentBtn.Name = "AddSegmentBtn";
            this.AddSegmentBtn.UseVisualStyleBackColor = true;
            this.AddSegmentBtn.Click += new System.EventHandler(this.AddSegmentBtn_Click);
            // 
            // NetsGrid
            // 
            this.NetsGrid.AllowUserToAddRows = false;
            this.NetsGrid.AllowUserToDeleteRows = false;
            this.NetsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.NetsGrid.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.NetsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NetsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HostAm,
            this.Color,
            this.DeleteColiumn});
            resources.ApplyResources(this.NetsGrid, "NetsGrid");
            this.NetsGrid.Name = "NetsGrid";
            this.NetsGrid.RowHeadersVisible = false;
            this.NetsGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.NetsGrid_CellClick);
            // 
            // HostAm
            // 
            this.HostAm.Frozen = true;
            resources.ApplyResources(this.HostAm, "HostAm");
            this.HostAm.Name = "HostAm";
            // 
            // Color
            // 
            this.Color.Frozen = true;
            resources.ApplyResources(this.Color, "Color");
            this.Color.Name = "Color";
            this.Color.ReadOnly = true;
            // 
            // DeleteColiumn
            // 
            this.DeleteColiumn.Frozen = true;
            resources.ApplyResources(this.DeleteColiumn, "DeleteColiumn");
            this.DeleteColiumn.Image = global::IPCalculator.Properties.Resources.navigate_cross;
            this.DeleteColiumn.Name = "DeleteColiumn";
            this.DeleteColiumn.ReadOnly = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // AddressTextBox
            // 
            resources.ApplyResources(this.AddressTextBox, "AddressTextBox");
            this.AddressTextBox.Name = "AddressTextBox";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainGrid);
            this.Controls.Add(this.MainMenuStrip);
            this.Name = "MainForm";
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
            this.MainGrid.ResumeLayout(false);
            this.RightPanel.ResumeLayout(false);
            this.TreeViewContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NetListDataGridView)).EndInit();
            this.LeftPanel.ResumeLayout(false);
            this.RootAddressBox.ResumeLayout(false);
            this.RootAddressBox.PerformLayout();
            this.InfoBox.ResumeLayout(false);
            this.InfoBox.PerformLayout();
            this.NetsPanel.ResumeLayout(false);
            this.NetsBtnPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NetsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenNetTreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveNetTreeToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel MainGrid;
        private System.Windows.Forms.TableLayoutPanel RightPanel;
        private System.Windows.Forms.TreeView NetTreeView;
        private System.Windows.Forms.DataGridView NetListDataGridView;
        private System.Windows.Forms.TableLayoutPanel LeftPanel;
        private System.Windows.Forms.GroupBox RootAddressBox;
        private System.Windows.Forms.TextBox AddressBox;
        private System.Windows.Forms.Button InfoBtn;
        private System.Windows.Forms.GroupBox InfoBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox StartAddressBox;
        private System.Windows.Forms.TextBox EndAddressBox;
        private System.Windows.Forms.TextBox BroadcastTextBox;
        private System.Windows.Forms.TextBox SubnetMaskTextBox;
        private System.Windows.Forms.TextBox ReverseMaskTextBox;
        private System.Windows.Forms.TextBox TotalHostBox;
        private System.Windows.Forms.TableLayoutPanel NetsPanel;
        private System.Windows.Forms.Panel NetsBtnPanel;
        private System.Windows.Forms.Button RedivideBtn;
        private System.Windows.Forms.Button DivideBtn;
        private System.Windows.Forms.Button DeleteSegmentBtn;
        private System.Windows.Forms.Button AddSegmentBtn;
        private System.Windows.Forms.DataGridView NetsGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn BroadcastAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubnetMask;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalHosts;
        private System.Windows.Forms.DataGridViewTextBoxColumn Occupied;
        private System.Windows.Forms.DataGridViewTextBoxColumn Free;
        private System.Windows.Forms.ContextMenuStrip TreeViewContextMenu;
        private System.Windows.Forms.ToolStripMenuItem AggregateMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClearMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn HostAm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Color;
        private System.Windows.Forms.DataGridViewImageColumn DeleteColiumn;
        private System.Windows.Forms.ColorDialog ColorPicker;
        private System.Windows.Forms.TextBox AddressTextBox;
        private System.Windows.Forms.Label label1;
    }
}

