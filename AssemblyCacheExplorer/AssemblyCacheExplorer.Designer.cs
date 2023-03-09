namespace AssemblyCacheExplorer
{
    partial class AssemblyCacheExplorer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssemblyCacheExplorer));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripInstallButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripUninstallButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripExportAssemblyButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripRefreshButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBackupFolderButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSettingsButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripFilterLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripFilterTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripRuntimeVersionLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripRuntimeVersionComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripAboutButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.lvAssemblyCache = new System.Windows.Forms.ListView();
            this.colAssemblyName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPublicKeyToken = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRuntimeVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFileVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colModifiedDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuUninstall = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.statusStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripProgressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 416);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(914, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.AutoSize = false;
            this.toolStripStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(170, 17);
            this.toolStripStatusLabel.Text = "0 Assemblies, 0 Selected";
            this.toolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar.Visible = false;
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripInstallButton,
            this.toolStripUninstallButton,
            this.toolStripExportAssemblyButton,
            this.toolStripSeparator2,
            this.toolStripRefreshButton,
            this.toolStripSeparator6,
            this.toolStripBackupFolderButton,
            this.toolStripSeparator8,
            this.toolStripSettingsButton,
            this.toolStripSeparator3,
            this.toolStripFilterLabel,
            this.toolStripFilterTextBox,
            this.toolStripSeparator4,
            this.toolStripRuntimeVersionLabel,
            this.toolStripRuntimeVersionComboBox,
            this.toolStripSeparator5,
            this.toolStripAboutButton,
            this.toolStripSeparator7});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(914, 31);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripInstallButton
            // 
            this.toolStripInstallButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripInstallButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripInstallButton.Image")));
            this.toolStripInstallButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripInstallButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripInstallButton.Name = "toolStripInstallButton";
            this.toolStripInstallButton.Size = new System.Drawing.Size(36, 28);
            this.toolStripInstallButton.Text = "Install Assembly";
            this.toolStripInstallButton.Click += new System.EventHandler(this.toolStripInstallButton_Click);
            // 
            // toolStripUninstallButton
            // 
            this.toolStripUninstallButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripUninstallButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripUninstallButton.Image")));
            this.toolStripUninstallButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripUninstallButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripUninstallButton.Name = "toolStripUninstallButton";
            this.toolStripUninstallButton.Size = new System.Drawing.Size(36, 28);
            this.toolStripUninstallButton.Text = "Uninstall Assembly";
            this.toolStripUninstallButton.Click += new System.EventHandler(this.toolStripUninstallButton_Click);
            // 
            // toolStripExportAssemblyButton
            // 
            this.toolStripExportAssemblyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripExportAssemblyButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripExportAssemblyButton.Image")));
            this.toolStripExportAssemblyButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripExportAssemblyButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripExportAssemblyButton.Name = "toolStripExportAssemblyButton";
            this.toolStripExportAssemblyButton.Size = new System.Drawing.Size(36, 28);
            this.toolStripExportAssemblyButton.Text = "Export Assembly";
            this.toolStripExportAssemblyButton.ToolTipText = "Export Assembly";
            this.toolStripExportAssemblyButton.Click += new System.EventHandler(this.toolStripExportAssemblyButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripRefreshButton
            // 
            this.toolStripRefreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripRefreshButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripRefreshButton.Image")));
            this.toolStripRefreshButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripRefreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRefreshButton.Name = "toolStripRefreshButton";
            this.toolStripRefreshButton.Size = new System.Drawing.Size(36, 28);
            this.toolStripRefreshButton.Text = "Refresh";
            this.toolStripRefreshButton.Click += new System.EventHandler(this.toolStripRefreshButton_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripBackupFolderButton
            // 
            this.toolStripBackupFolderButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBackupFolderButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBackupFolderButton.Image")));
            this.toolStripBackupFolderButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBackupFolderButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBackupFolderButton.Name = "toolStripBackupFolderButton";
            this.toolStripBackupFolderButton.Size = new System.Drawing.Size(36, 28);
            this.toolStripBackupFolderButton.ToolTipText = "Show Backup Folder";
            this.toolStripBackupFolderButton.Click += new System.EventHandler(this.toolStripBackupFolderButton_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripSettingsButton
            // 
            this.toolStripSettingsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSettingsButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSettingsButton.Image")));
            this.toolStripSettingsButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripSettingsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSettingsButton.Name = "toolStripSettingsButton";
            this.toolStripSettingsButton.Size = new System.Drawing.Size(36, 28);
            this.toolStripSettingsButton.Text = "Settings";
            this.toolStripSettingsButton.Click += new System.EventHandler(this.toolStripSettingsButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripFilterLabel
            // 
            this.toolStripFilterLabel.Name = "toolStripFilterLabel";
            this.toolStripFilterLabel.Size = new System.Drawing.Size(36, 28);
            this.toolStripFilterLabel.Text = "Filter:";
            // 
            // toolStripFilterTextBox
            // 
            this.toolStripFilterTextBox.Name = "toolStripFilterTextBox";
            this.toolStripFilterTextBox.Size = new System.Drawing.Size(200, 31);
            this.toolStripFilterTextBox.TextChanged += new System.EventHandler(this.toolStripFilterTextBox_TextChanged);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripRuntimeVersionLabel
            // 
            this.toolStripRuntimeVersionLabel.Name = "toolStripRuntimeVersionLabel";
            this.toolStripRuntimeVersionLabel.Size = new System.Drawing.Size(97, 28);
            this.toolStripRuntimeVersionLabel.Text = "Runtime Version:";
            // 
            // toolStripRuntimeVersionComboBox
            // 
            this.toolStripRuntimeVersionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripRuntimeVersionComboBox.Items.AddRange(new object[] {
            "*ALL*",
            "CLR 2",
            "CLR 4"});
            this.toolStripRuntimeVersionComboBox.Name = "toolStripRuntimeVersionComboBox";
            this.toolStripRuntimeVersionComboBox.Size = new System.Drawing.Size(121, 31);
            this.toolStripRuntimeVersionComboBox.SelectedIndexChanged += new System.EventHandler(this.toolStripRuntimeVersionComboBox_SelectedIndexChanged);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripAboutButton
            // 
            this.toolStripAboutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripAboutButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripAboutButton.Image")));
            this.toolStripAboutButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripAboutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripAboutButton.Name = "toolStripAboutButton";
            this.toolStripAboutButton.Size = new System.Drawing.Size(36, 28);
            this.toolStripAboutButton.Text = "About";
            this.toolStripAboutButton.Click += new System.EventHandler(this.toolStripAboutButton_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 31);
            // 
            // lvAssemblyCache
            // 
            this.lvAssemblyCache.AllowColumnReorder = true;
            this.lvAssemblyCache.AllowDrop = true;
            this.lvAssemblyCache.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvAssemblyCache.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAssemblyName,
            this.colVersion,
            this.colPublicKeyToken,
            this.colRuntimeVersion,
            this.colFileVersion,
            this.colModifiedDate});
            this.lvAssemblyCache.ContextMenuStrip = this.contextMenuStrip;
            this.lvAssemblyCache.FullRowSelect = true;
            this.lvAssemblyCache.GridLines = true;
            this.lvAssemblyCache.LargeImageList = this.imageList;
            this.lvAssemblyCache.Location = new System.Drawing.Point(0, 28);
            this.lvAssemblyCache.Name = "lvAssemblyCache";
            this.lvAssemblyCache.Size = new System.Drawing.Size(914, 385);
            this.lvAssemblyCache.SmallImageList = this.imageList;
            this.lvAssemblyCache.TabIndex = 3;
            this.lvAssemblyCache.UseCompatibleStateImageBehavior = false;
            this.lvAssemblyCache.View = System.Windows.Forms.View.Details;
            this.lvAssemblyCache.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvAssemblyCache_ColumnClick);
            this.lvAssemblyCache.SelectedIndexChanged += new System.EventHandler(this.lvAssemblyCache_SelectedIndexChanged);
            this.lvAssemblyCache.Click += new System.EventHandler(this.lvAssemblyCache_Click);
            this.lvAssemblyCache.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvAssemblyCache_DragDrop);
            this.lvAssemblyCache.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvAssemblyCache_DragEnter);
            this.lvAssemblyCache.DoubleClick += new System.EventHandler(this.lvAssemblyCache_DoubleClick);
            this.lvAssemblyCache.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lvAssemblyCache_KeyUp);
            // 
            // colAssemblyName
            // 
            this.colAssemblyName.Text = "Assembly Name";
            this.colAssemblyName.Width = 363;
            // 
            // colVersion
            // 
            this.colVersion.Text = "Version";
            this.colVersion.Width = 64;
            // 
            // colPublicKeyToken
            // 
            this.colPublicKeyToken.Text = "Public Key Token";
            this.colPublicKeyToken.Width = 115;
            // 
            // colRuntimeVersion
            // 
            this.colRuntimeVersion.Text = "Runtime Version";
            this.colRuntimeVersion.Width = 98;
            // 
            // colFileVersion
            // 
            this.colFileVersion.Text = "File Version";
            this.colFileVersion.Width = 178;
            // 
            // colModifiedDate
            // 
            this.colModifiedDate.Text = "Modified Date";
            this.colModifiedDate.Width = 166;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuUninstall,
            this.toolStripMenuExport,
            this.toolStripSeparator1,
            this.toolStripMenuProperties});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(128, 76);
            // 
            // toolStripMenuUninstall
            // 
            this.toolStripMenuUninstall.Name = "toolStripMenuUninstall";
            this.toolStripMenuUninstall.Size = new System.Drawing.Size(127, 22);
            this.toolStripMenuUninstall.Text = "Uninstall";
            this.toolStripMenuUninstall.Click += new System.EventHandler(this.toolStripMenuUninstall_Click);
            // 
            // toolStripMenuExport
            // 
            this.toolStripMenuExport.Name = "toolStripMenuExport";
            this.toolStripMenuExport.Size = new System.Drawing.Size(127, 22);
            this.toolStripMenuExport.Text = "Export";
            this.toolStripMenuExport.Click += new System.EventHandler(this.toolStripMenuExport_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(124, 6);
            // 
            // toolStripMenuProperties
            // 
            this.toolStripMenuProperties.Name = "toolStripMenuProperties";
            this.toolStripMenuProperties.Size = new System.Drawing.Size(127, 22);
            this.toolStripMenuProperties.Text = "Properties";
            this.toolStripMenuProperties.Click += new System.EventHandler(this.toolStripMenuProperties_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Assembly.png");
            // 
            // openFileDialog
            // 
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.Title = "Select Assemblies to Install";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // bgWorker
            // 
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker_ProgressChanged);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            // 
            // AssemblyCacheExplorer
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 438);
            this.Controls.Add(this.lvAssemblyCache);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AssemblyCacheExplorer";
            this.Text = "Assembly Cache Explorer";
            this.Activated += new System.EventHandler(this.AssemblyCacheExplorer_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AssemblyCacheExplorer_FormClosing);
            this.Load += new System.EventHandler(this.AssemblyCacheExplorer_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripInstallButton;
        private System.Windows.Forms.ToolStripButton toolStripUninstallButton;
        private System.Windows.Forms.ToolStripButton toolStripRefreshButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripSettingsButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripFilterLabel;
        private System.Windows.Forms.ToolStripTextBox toolStripFilterTextBox;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ListView lvAssemblyCache;
        private System.Windows.Forms.ColumnHeader colAssemblyName;
        private System.Windows.Forms.ColumnHeader colVersion;
        private System.Windows.Forms.ColumnHeader colPublicKeyToken;
        private System.Windows.Forms.ColumnHeader colFileVersion;
        private System.Windows.Forms.ColumnHeader colModifiedDate;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuUninstall;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuProperties;
        private System.Windows.Forms.ColumnHeader colRuntimeVersion;
        private System.Windows.Forms.ToolStripLabel toolStripRuntimeVersionLabel;
        private System.Windows.Forms.ToolStripComboBox toolStripRuntimeVersionComboBox;
        private System.Windows.Forms.ToolStripButton toolStripExportAssemblyButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripAboutButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuExport;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripButton toolStripBackupFolderButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.ComponentModel.BackgroundWorker bgWorker;
    }
}

