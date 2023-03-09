namespace AssemblyCacheExplorer
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblAssemblyFolderCLR2 = new System.Windows.Forms.Label();
            this.lblAssemblyFolderCLR4 = new System.Windows.Forms.Label();
            this.txtAssemblyFolderCLR2 = new System.Windows.Forms.TextBox();
            this.txtAssemblyFolderCLR4 = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.chkBackupAssemblies = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(242, 236);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(323, 236);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblAssemblyFolderCLR2
            // 
            this.lblAssemblyFolderCLR2.AutoSize = true;
            this.lblAssemblyFolderCLR2.Location = new System.Drawing.Point(12, 9);
            this.lblAssemblyFolderCLR2.Name = "lblAssemblyFolderCLR2";
            this.lblAssemblyFolderCLR2.Size = new System.Drawing.Size(116, 13);
            this.lblAssemblyFolderCLR2.TabIndex = 2;
            this.lblAssemblyFolderCLR2.Text = "CLR2 Assembly Folder:";
            // 
            // lblAssemblyFolderCLR4
            // 
            this.lblAssemblyFolderCLR4.AutoSize = true;
            this.lblAssemblyFolderCLR4.Location = new System.Drawing.Point(12, 60);
            this.lblAssemblyFolderCLR4.Name = "lblAssemblyFolderCLR4";
            this.lblAssemblyFolderCLR4.Size = new System.Drawing.Size(116, 13);
            this.lblAssemblyFolderCLR4.TabIndex = 3;
            this.lblAssemblyFolderCLR4.Text = "CLR4 Assembly Folder:";
            // 
            // txtAssemblyFolderCLR2
            // 
            this.txtAssemblyFolderCLR2.Location = new System.Drawing.Point(12, 25);
            this.txtAssemblyFolderCLR2.Name = "txtAssemblyFolderCLR2";
            this.txtAssemblyFolderCLR2.Size = new System.Drawing.Size(376, 20);
            this.txtAssemblyFolderCLR2.TabIndex = 4;
            // 
            // txtAssemblyFolderCLR4
            // 
            this.txtAssemblyFolderCLR4.Location = new System.Drawing.Point(12, 76);
            this.txtAssemblyFolderCLR4.Name = "txtAssemblyFolderCLR4";
            this.txtAssemblyFolderCLR4.Size = new System.Drawing.Size(376, 20);
            this.txtAssemblyFolderCLR4.TabIndex = 5;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(12, 236);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnRestoreDefaults_Click);
            // 
            // chkBackupAssemblies
            // 
            this.chkBackupAssemblies.AutoSize = true;
            this.chkBackupAssemblies.Location = new System.Drawing.Point(12, 122);
            this.chkBackupAssemblies.Name = "chkBackupAssemblies";
            this.chkBackupAssemblies.Size = new System.Drawing.Size(295, 17);
            this.chkBackupAssemblies.TabIndex = 7;
            this.chkBackupAssemblies.Text = "Backup assemblies during Install and Uninstall operations";
            this.chkBackupAssemblies.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 271);
            this.Controls.Add(this.chkBackupAssemblies);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.txtAssemblyFolderCLR4);
            this.Controls.Add(this.txtAssemblyFolderCLR2);
            this.Controls.Add(this.lblAssemblyFolderCLR4);
            this.Controls.Add(this.lblAssemblyFolderCLR2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblAssemblyFolderCLR2;
        private System.Windows.Forms.Label lblAssemblyFolderCLR4;
        private System.Windows.Forms.TextBox txtAssemblyFolderCLR2;
        private System.Windows.Forms.TextBox txtAssemblyFolderCLR4;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.CheckBox chkBackupAssemblies;
    }
}