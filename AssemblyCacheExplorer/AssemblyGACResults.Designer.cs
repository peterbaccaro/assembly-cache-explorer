namespace AssemblyCacheExplorer
{
    partial class AssemblyGACResults
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssemblyGACResults));
            this.btnOK = new System.Windows.Forms.Button();
            this.lvGACResults = new System.Windows.Forms.ListView();
            this.col1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(573, 381);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lvGACResults
            // 
            this.lvGACResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col1,
            this.col2});
            this.lvGACResults.GridLines = true;
            this.lvGACResults.LargeImageList = this.imageList;
            this.lvGACResults.Location = new System.Drawing.Point(12, 12);
            this.lvGACResults.MultiSelect = false;
            this.lvGACResults.Name = "lvGACResults";
            this.lvGACResults.ShowItemToolTips = true;
            this.lvGACResults.Size = new System.Drawing.Size(636, 357);
            this.lvGACResults.SmallImageList = this.imageList;
            this.lvGACResults.TabIndex = 1;
            this.lvGACResults.UseCompatibleStateImageBehavior = false;
            this.lvGACResults.View = System.Windows.Forms.View.Details;
            // 
            // col1
            // 
            this.col1.DisplayIndex = 1;
            this.col1.Text = "Result";
            this.col1.Width = 293;
            // 
            // col2
            // 
            this.col2.DisplayIndex = 0;
            this.col2.Text = "Assembly Name";
            this.col2.Width = 451;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Success.png");
            this.imageList.Images.SetKeyName(1, "Error.png");
            // 
            // AssemblyGACResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 416);
            this.Controls.Add(this.lvGACResults);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AssemblyGACResults";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AssemblyGACResults";
            this.Load += new System.EventHandler(this.AssemblyGACResults_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ListView lvGACResults;
        private System.Windows.Forms.ColumnHeader col2;
        private System.Windows.Forms.ColumnHeader col1;
        private System.Windows.Forms.ImageList imageList;
    }
}