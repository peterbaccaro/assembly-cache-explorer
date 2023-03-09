using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using AssemblyCacheHelper.DTO;

namespace AssemblyCacheExplorer
{
    public partial class AssemblyProperties : Form
    {
        public NetAssembly NetAssemblyProperties { get; set; }

        public AssemblyProperties()
        {
            InitializeComponent();
        }

        private void AssemblyProperties_Load(object sender, EventArgs e)
        {
            string imageRuntimeVersion = AssemblyCacheHelper.NetAssemblies.GetImageRuntimeVersion(NetAssemblyProperties.AssemblyFilename);

            lblAssemblyNameValue.Text = NetAssemblyProperties.AssemblyName;
            lblAssemblyVersionValue.Text = NetAssemblyProperties.AssemblyVersion;
            lblCultureValue.Text = NetAssemblyProperties.Culture;
            lblPublicKeyTokenValue.Text = NetAssemblyProperties.PublicKeyToken;
            lblProcesorArchitectureValue.Text = NetAssemblyProperties.ProcessorArchitecture;
            lblRuntimeVersionValue.Text = (imageRuntimeVersion != "") ? String.Format("{0} ({1})", NetAssemblyProperties.RuntimeVersion, imageRuntimeVersion) : NetAssemblyProperties.RuntimeVersion;
            lblModifiedDateValue.Text = NetAssemblyProperties.ModifiedDate;
            lblFileSizeValue.Text = NetAssemblyProperties.FileSize;
            lblAssemblyFilenameValue.Text = Path.GetFileName(NetAssemblyProperties.AssemblyFilename);
            lblFileVersionValue.Text = NetAssemblyProperties.FileVersion;
            lblFileDescriptionValue.Text = NetAssemblyProperties.FileDescription;
            lblCompanyValue.Text = NetAssemblyProperties.Company;
            lblProductNameValue.Text = NetAssemblyProperties.ProductName;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
