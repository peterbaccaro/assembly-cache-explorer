using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AssemblyCacheExplorer
{
    public partial class AssemblyGACResults : Form
    {
        public string GACResultsTitle { get; set; }
        public Dictionary<string, string> GACResults { get; set; }

        public AssemblyGACResults()
        {
            InitializeComponent();
        }

        private void AssemblyGACResults_Load(object sender, EventArgs e)
        {
            this.Text = GACResultsTitle;

            lvGACResults.Visible = false;
            lvGACResults.Items.Clear();

            foreach (KeyValuePair<string, string> gacResult in GACResults)
            {
                ListViewItem lvi = new ListViewItem(new string[] { gacResult.Value == "" ? "Success" : "Failed", gacResult.Key });

                if (gacResult.Value == "")
                {
                    lvi.ImageIndex = 0;
                }
                else
                {
                    lvi.ImageIndex = 1;
                    lvi.ToolTipText = gacResult.Value;
                }

                lvGACResults.Items.Add(lvi);
            }
            lvGACResults.Visible = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
