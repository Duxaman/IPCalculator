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
            this.AddressTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.NetsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.NetsBtnPanel = new System.Windows.Forms.Panel();
            this.ClearTreeBtn = new System.Windows.Forms.Button();
            this.DivideBtn = new System.Windows.Forms.Button();
            this.DeleteSegmentBtn = new System.Windows.Forms.Button();
            this.AddSegmentBtn = new System.Windows.Forms.Button();
            this.NetsGrid = new System.Windows.Forms.DataGridView();
            this.ColorPicker = new System.Windows.Forms.ColorDialog();
            this.SaveNetTreeDialog = new System.Windows.Forms.SaveFileDialog();
            this.OpenNetTreeDialog = new System.Windows.Forms.OpenFileDialog();
            this.HostAm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeleteColiumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.IdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BroadcastAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubnetMask = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalHosts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Occupied = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Free = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.Size = new System.Drawing.Size(1024, 24);
            this.MainMenuStrip.TabIndex = 0;
            this.MainMenuStrip.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenNetTreeToolStripMenuItem,
            this.SaveNetTreeToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileToolStripMenuItem.Text = "File";
            // 
            // OpenNetTreeToolStripMenuItem
            // 
            this.OpenNetTreeToolStripMenuItem.Name = "OpenNetTreeToolStripMenuItem";
            this.OpenNetTreeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.OpenNetTreeToolStripMenuItem.Text = "Open net tree";
            this.OpenNetTreeToolStripMenuItem.Click += new System.EventHandler(this.OpenNetTreeToolStripMenuItem_Click);
            // 
            // SaveNetTreeToolStripMenuItem
            // 
            this.SaveNetTreeToolStripMenuItem.Name = "SaveNetTreeToolStripMenuItem";
            this.SaveNetTreeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.SaveNetTreeToolStripMenuItem.Text = "Save net tree";
            this.SaveNetTreeToolStripMenuItem.Click += new System.EventHandler(this.SaveNetTreeToolStripMenuItem_Click);
            // 
            // MainGrid
            // 
            this.MainGrid.ColumnCount = 2;
            this.MainGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.28586F));
            this.MainGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.71415F));
            this.MainGrid.Controls.Add(this.RightPanel, 1, 0);
            this.MainGrid.Controls.Add(this.LeftPanel, 0, 0);
            this.MainGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainGrid.Location = new System.Drawing.Point(0, 24);
            this.MainGrid.Name = "MainGrid";
            this.MainGrid.RowCount = 1;
            this.MainGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainGrid.Size = new System.Drawing.Size(1024, 597);
            this.MainGrid.TabIndex = 1;
            // 
            // RightPanel
            // 
            this.RightPanel.ColumnCount = 1;
            this.RightPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RightPanel.Controls.Add(this.NetTreeView, 0, 0);
            this.RightPanel.Controls.Add(this.NetListDataGridView, 0, 1);
            this.RightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightPanel.Location = new System.Drawing.Point(210, 3);
            this.RightPanel.Name = "RightPanel";
            this.RightPanel.RowCount = 2;
            this.RightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.53846F));
            this.RightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.46154F));
            this.RightPanel.Size = new System.Drawing.Size(811, 591);
            this.RightPanel.TabIndex = 0;
            // 
            // NetTreeView
            // 
            this.NetTreeView.BackColor = System.Drawing.Color.WhiteSmoke;
            this.NetTreeView.ContextMenuStrip = this.TreeViewContextMenu;
            this.NetTreeView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NetTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NetTreeView.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.NetTreeView.FullRowSelect = true;
            this.NetTreeView.HideSelection = false;
            this.NetTreeView.HotTracking = true;
            this.NetTreeView.Location = new System.Drawing.Point(3, 3);
            this.NetTreeView.Name = "NetTreeView";
            this.NetTreeView.Size = new System.Drawing.Size(805, 357);
            this.NetTreeView.TabIndex = 0;
            this.NetTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.NetTreeView_NodeMouseClick);
            // 
            // TreeViewContextMenu
            // 
            this.TreeViewContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AggregateMenuItem,
            this.ClearMenuItem});
            this.TreeViewContextMenu.Name = "TreeViewContextMenu";
            this.TreeViewContextMenu.Size = new System.Drawing.Size(181, 70);
            // 
            // AggregateMenuItem
            // 
            this.AggregateMenuItem.Name = "AggregateMenuItem";
            this.AggregateMenuItem.Size = new System.Drawing.Size(180, 22);
            this.AggregateMenuItem.Text = "Aggregate node";
            this.AggregateMenuItem.Click += new System.EventHandler(this.AggregateMenuItem_Click);
            // 
            // ClearMenuItem
            // 
            this.ClearMenuItem.Name = "ClearMenuItem";
            this.ClearMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ClearMenuItem.Text = "Clear node";
            this.ClearMenuItem.Click += new System.EventHandler(this.ClearMenuItem_Click);
            // 
            // NetListDataGridView
            // 
            this.NetListDataGridView.AllowUserToAddRows = false;
            this.NetListDataGridView.AllowUserToDeleteRows = false;
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
            this.NetListDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NetListDataGridView.Location = new System.Drawing.Point(3, 366);
            this.NetListDataGridView.Name = "NetListDataGridView";
            this.NetListDataGridView.RowHeadersVisible = false;
            this.NetListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.NetListDataGridView.Size = new System.Drawing.Size(805, 222);
            this.NetListDataGridView.TabIndex = 1;
            // 
            // LeftPanel
            // 
            this.LeftPanel.ColumnCount = 1;
            this.LeftPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LeftPanel.Controls.Add(this.RootAddressBox, 0, 0);
            this.LeftPanel.Controls.Add(this.InfoBox, 0, 1);
            this.LeftPanel.Controls.Add(this.NetsPanel, 0, 2);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftPanel.Location = new System.Drawing.Point(3, 3);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.RowCount = 3;
            this.LeftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.LeftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 315F));
            this.LeftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LeftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.LeftPanel.Size = new System.Drawing.Size(201, 591);
            this.LeftPanel.TabIndex = 1;
            // 
            // RootAddressBox
            // 
            this.RootAddressBox.Controls.Add(this.InfoBtn);
            this.RootAddressBox.Controls.Add(this.AddressBox);
            this.RootAddressBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RootAddressBox.Location = new System.Drawing.Point(3, 3);
            this.RootAddressBox.Name = "RootAddressBox";
            this.RootAddressBox.Size = new System.Drawing.Size(195, 74);
            this.RootAddressBox.TabIndex = 0;
            this.RootAddressBox.TabStop = false;
            this.RootAddressBox.Text = "Subnet";
            // 
            // InfoBtn
            // 
            this.InfoBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InfoBtn.Font = new System.Drawing.Font("Arial", 8.25F);
            this.InfoBtn.Location = new System.Drawing.Point(39, 45);
            this.InfoBtn.Name = "InfoBtn";
            this.InfoBtn.Size = new System.Drawing.Size(108, 23);
            this.InfoBtn.TabIndex = 1;
            this.InfoBtn.Text = "Info";
            this.InfoBtn.UseVisualStyleBackColor = true;
            this.InfoBtn.Click += new System.EventHandler(this.InfoBtn_Click);
            // 
            // AddressBox
            // 
            this.AddressBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddressBox.Location = new System.Drawing.Point(6, 19);
            this.AddressBox.Name = "AddressBox";
            this.AddressBox.Size = new System.Drawing.Size(181, 20);
            this.AddressBox.TabIndex = 0;
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
            this.InfoBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InfoBox.Location = new System.Drawing.Point(3, 83);
            this.InfoBox.Name = "InfoBox";
            this.InfoBox.Size = new System.Drawing.Size(195, 309);
            this.InfoBox.TabIndex = 1;
            this.InfoBox.TabStop = false;
            this.InfoBox.Text = "Information";
            // 
            // TotalHostBox
            // 
            this.TotalHostBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalHostBox.Location = new System.Drawing.Point(6, 280);
            this.TotalHostBox.Name = "TotalHostBox";
            this.TotalHostBox.Size = new System.Drawing.Size(181, 20);
            this.TotalHostBox.TabIndex = 13;
            // 
            // ReverseMaskTextBox
            // 
            this.ReverseMaskTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReverseMaskTextBox.Location = new System.Drawing.Point(6, 235);
            this.ReverseMaskTextBox.Name = "ReverseMaskTextBox";
            this.ReverseMaskTextBox.Size = new System.Drawing.Size(181, 20);
            this.ReverseMaskTextBox.TabIndex = 12;
            // 
            // SubnetMaskTextBox
            // 
            this.SubnetMaskTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SubnetMaskTextBox.Location = new System.Drawing.Point(6, 195);
            this.SubnetMaskTextBox.Name = "SubnetMaskTextBox";
            this.SubnetMaskTextBox.Size = new System.Drawing.Size(181, 20);
            this.SubnetMaskTextBox.TabIndex = 11;
            // 
            // BroadcastTextBox
            // 
            this.BroadcastTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BroadcastTextBox.Location = new System.Drawing.Point(6, 155);
            this.BroadcastTextBox.Name = "BroadcastTextBox";
            this.BroadcastTextBox.Size = new System.Drawing.Size(181, 20);
            this.BroadcastTextBox.TabIndex = 10;
            // 
            // EndAddressBox
            // 
            this.EndAddressBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EndAddressBox.Location = new System.Drawing.Point(6, 112);
            this.EndAddressBox.Name = "EndAddressBox";
            this.EndAddressBox.Size = new System.Drawing.Size(181, 20);
            this.EndAddressBox.TabIndex = 9;
            // 
            // StartAddressBox
            // 
            this.StartAddressBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StartAddressBox.Location = new System.Drawing.Point(6, 72);
            this.StartAddressBox.Name = "StartAddressBox";
            this.StartAddressBox.Size = new System.Drawing.Size(181, 20);
            this.StartAddressBox.TabIndex = 8;
            // 
            // AddressTextBox
            // 
            this.AddressTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddressTextBox.Location = new System.Drawing.Point(6, 33);
            this.AddressTextBox.Name = "AddressTextBox";
            this.AddressTextBox.Size = new System.Drawing.Size(181, 20);
            this.AddressTextBox.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(3, 263);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 14);
            this.label7.TabIndex = 6;
            this.label7.Text = "Total hosts";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(3, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 14);
            this.label6.TabIndex = 5;
            this.label6.Text = "Wildcard";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(3, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 14);
            this.label5.TabIndex = 4;
            this.label5.Text = "Subnet mask";
            // 
            // label4
            // 
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(3, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Broadcast address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(6, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "EndAddress";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "StartAddress";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Address";
            // 
            // NetsPanel
            // 
            this.NetsPanel.ColumnCount = 1;
            this.NetsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.NetsPanel.Controls.Add(this.NetsBtnPanel, 0, 0);
            this.NetsPanel.Controls.Add(this.NetsGrid, 0, 1);
            this.NetsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NetsPanel.Location = new System.Drawing.Point(3, 398);
            this.NetsPanel.Name = "NetsPanel";
            this.NetsPanel.RowCount = 2;
            this.NetsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.NetsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.NetsPanel.Size = new System.Drawing.Size(195, 190);
            this.NetsPanel.TabIndex = 2;
            // 
            // NetsBtnPanel
            // 
            this.NetsBtnPanel.Controls.Add(this.ClearTreeBtn);
            this.NetsBtnPanel.Controls.Add(this.DivideBtn);
            this.NetsBtnPanel.Controls.Add(this.DeleteSegmentBtn);
            this.NetsBtnPanel.Controls.Add(this.AddSegmentBtn);
            this.NetsBtnPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NetsBtnPanel.Location = new System.Drawing.Point(3, 3);
            this.NetsBtnPanel.Name = "NetsBtnPanel";
            this.NetsBtnPanel.Size = new System.Drawing.Size(189, 24);
            this.NetsBtnPanel.TabIndex = 0;
            // 
            // ClearTreeBtn
            // 
            this.ClearTreeBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.ClearTreeBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ClearTreeBtn.Location = new System.Drawing.Point(106, 0);
            this.ClearTreeBtn.Name = "ClearTreeBtn";
            this.ClearTreeBtn.Size = new System.Drawing.Size(82, 24);
            this.ClearTreeBtn.TabIndex = 10;
            this.ClearTreeBtn.Text = "Clear";
            this.ClearTreeBtn.UseVisualStyleBackColor = true;
            this.ClearTreeBtn.Click += new System.EventHandler(this.ClearBtnClick);
            // 
            // DivideBtn
            // 
            this.DivideBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.DivideBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DivideBtn.Location = new System.Drawing.Point(48, 0);
            this.DivideBtn.Name = "DivideBtn";
            this.DivideBtn.Size = new System.Drawing.Size(58, 24);
            this.DivideBtn.TabIndex = 9;
            this.DivideBtn.Text = "DIvide";
            this.DivideBtn.UseVisualStyleBackColor = true;
            this.DivideBtn.Click += new System.EventHandler(this.DivideBtn_Click);
            // 
            // DeleteSegmentBtn
            // 
            this.DeleteSegmentBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.DeleteSegmentBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DeleteSegmentBtn.Location = new System.Drawing.Point(24, 0);
            this.DeleteSegmentBtn.Name = "DeleteSegmentBtn";
            this.DeleteSegmentBtn.Size = new System.Drawing.Size(24, 24);
            this.DeleteSegmentBtn.TabIndex = 8;
            this.DeleteSegmentBtn.Text = "-";
            this.DeleteSegmentBtn.UseVisualStyleBackColor = true;
            this.DeleteSegmentBtn.Click += new System.EventHandler(this.DeleteSegmentBtn_Click);
            // 
            // AddSegmentBtn
            // 
            this.AddSegmentBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddSegmentBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AddSegmentBtn.Location = new System.Drawing.Point(0, 0);
            this.AddSegmentBtn.Name = "AddSegmentBtn";
            this.AddSegmentBtn.Size = new System.Drawing.Size(24, 24);
            this.AddSegmentBtn.TabIndex = 7;
            this.AddSegmentBtn.Text = "+";
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
            this.NetsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NetsGrid.Location = new System.Drawing.Point(3, 33);
            this.NetsGrid.MultiSelect = false;
            this.NetsGrid.Name = "NetsGrid";
            this.NetsGrid.RowHeadersVisible = false;
            this.NetsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.NetsGrid.Size = new System.Drawing.Size(189, 154);
            this.NetsGrid.TabIndex = 1;
            this.NetsGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.NetsGrid_CellClick);
            this.NetsGrid.SelectionChanged += new System.EventHandler(this.NetsGrid_SelectionChanged);
            // 
            // SaveNetTreeDialog
            // 
            this.SaveNetTreeDialog.DefaultExt = "json";
            this.SaveNetTreeDialog.Filter = "JSON files | *.json";
            this.SaveNetTreeDialog.Title = "Сохранить дерево сетей";
            // 
            // OpenNetTreeDialog
            // 
            this.OpenNetTreeDialog.DefaultExt = "json";
            this.OpenNetTreeDialog.Filter = "JSON Files | *.json";
            this.OpenNetTreeDialog.Title = "Открыть дерево сетей";
            // 
            // HostAm
            // 
            this.HostAm.Frozen = true;
            this.HostAm.HeaderText = "Host amount";
            this.HostAm.Name = "HostAm";
            this.HostAm.Width = 92;
            // 
            // Color
            // 
            this.Color.Frozen = true;
            this.Color.HeaderText = "Color";
            this.Color.Name = "Color";
            this.Color.ReadOnly = true;
            this.Color.Width = 57;
            // 
            // DeleteColiumn
            // 
            this.DeleteColiumn.Frozen = true;
            this.DeleteColiumn.HeaderText = "";
            this.DeleteColiumn.Image = global::IPCalculator.Properties.Resources.navigate_cross;
            this.DeleteColiumn.Name = "DeleteColiumn";
            this.DeleteColiumn.ReadOnly = true;
            this.DeleteColiumn.Width = 5;
            // 
            // IdColumn
            // 
            this.IdColumn.Frozen = true;
            this.IdColumn.HeaderText = "#";
            this.IdColumn.Name = "IdColumn";
            this.IdColumn.ReadOnly = true;
            this.IdColumn.Width = 38;
            // 
            // Address
            // 
            this.Address.Frozen = true;
            this.Address.HeaderText = "Net address";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            this.Address.Width = 83;
            // 
            // StartAddress
            // 
            this.StartAddress.Frozen = true;
            this.StartAddress.HeaderText = "Start address";
            this.StartAddress.Name = "StartAddress";
            this.StartAddress.ReadOnly = true;
            this.StartAddress.Width = 83;
            // 
            // EndAddress
            // 
            this.EndAddress.Frozen = true;
            this.EndAddress.HeaderText = "End Address";
            this.EndAddress.Name = "EndAddress";
            this.EndAddress.ReadOnly = true;
            this.EndAddress.Width = 83;
            // 
            // BroadcastAddress
            // 
            this.BroadcastAddress.Frozen = true;
            this.BroadcastAddress.HeaderText = "Broadcast address";
            this.BroadcastAddress.Name = "BroadcastAddress";
            this.BroadcastAddress.ReadOnly = true;
            this.BroadcastAddress.Width = 123;
            // 
            // SubnetMask
            // 
            this.SubnetMask.Frozen = true;
            this.SubnetMask.HeaderText = "Subnet mask";
            this.SubnetMask.Name = "SubnetMask";
            this.SubnetMask.ReadOnly = true;
            this.SubnetMask.Width = 113;
            // 
            // TotalHosts
            // 
            this.TotalHosts.Frozen = true;
            this.TotalHosts.HeaderText = "Total hosts";
            this.TotalHosts.Name = "TotalHosts";
            this.TotalHosts.ReadOnly = true;
            this.TotalHosts.Width = 89;
            // 
            // Occupied
            // 
            this.Occupied.Frozen = true;
            this.Occupied.HeaderText = "Occupied";
            this.Occupied.Name = "Occupied";
            this.Occupied.ReadOnly = true;
            this.Occupied.Width = 66;
            // 
            // Free
            // 
            this.Free.Frozen = true;
            this.Free.HeaderText = "Free";
            this.Free.Name = "Free";
            this.Free.ReadOnly = true;
            this.Free.Width = 80;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 621);
            this.Controls.Add(this.MainGrid);
            this.Controls.Add(this.MainMenuStrip);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1040, 660);
            this.Name = "MainForm";
            this.Text = "IP calculator";
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

#pragma warning disable CS0108 // "MainForm.MainMenuStrip" скрывает наследуемый член "Form.MainMenuStrip". Если скрытие было намеренным, используйте ключевое слово new.
        private System.Windows.Forms.MenuStrip MainMenuStrip;
#pragma warning restore CS0108 // "MainForm.MainMenuStrip" скрывает наследуемый член "Form.MainMenuStrip". Если скрытие было намеренным, используйте ключевое слово new.
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
        private System.Windows.Forms.Button ClearTreeBtn;
        private System.Windows.Forms.Button DivideBtn;
        private System.Windows.Forms.Button DeleteSegmentBtn;
        private System.Windows.Forms.Button AddSegmentBtn;
        private System.Windows.Forms.DataGridView NetsGrid;
        private System.Windows.Forms.ContextMenuStrip TreeViewContextMenu;
        private System.Windows.Forms.ToolStripMenuItem AggregateMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClearMenuItem;
        private System.Windows.Forms.ColorDialog ColorPicker;
        private System.Windows.Forms.TextBox AddressTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SaveFileDialog SaveNetTreeDialog;
        private System.Windows.Forms.OpenFileDialog OpenNetTreeDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn HostAm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Color;
        private System.Windows.Forms.DataGridViewImageColumn DeleteColiumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn BroadcastAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubnetMask;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalHosts;
        private System.Windows.Forms.DataGridViewTextBoxColumn Occupied;
        private System.Windows.Forms.DataGridViewTextBoxColumn Free;
    }
}

