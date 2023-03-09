using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Configuration;

namespace AssemblyCacheExplorer
{
    public partial class Settings : Form
    {
        const string _AssemblyFolderCLR2 = "AssemblyFolderCLR2";
        const string _AssemblyFolderCLR4 = "AssemblyFolderCLR4";
        const string _BackupAssemblies = "BackupAssemblies";

        private Configuration _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            txtAssemblyFolderCLR2.Text = _config.AppSettings.Settings[_AssemblyFolderCLR2].Value ?? "";
            txtAssemblyFolderCLR4.Text = _config.AppSettings.Settings[_AssemblyFolderCLR4].Value ?? "";
            chkBackupAssemblies.Checked = Convert.ToBoolean(_config.AppSettings.Settings[_BackupAssemblies].Value ?? "True");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                _config.AppSettings.Settings[_AssemblyFolderCLR2].Value = txtAssemblyFolderCLR2.Text;
                _config.AppSettings.Settings[_AssemblyFolderCLR4].Value = txtAssemblyFolderCLR4.Text;
                _config.AppSettings.Settings[_BackupAssemblies].Value = chkBackupAssemblies.Checked.ToString();

                _config.Save(ConfigurationSaveMode.Full);

                ConfigurationManager.RefreshSection("appSettings");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRestoreDefaults_Click(object sender, EventArgs e)
        {
            txtAssemblyFolderCLR2.Text = @"C:\Windows\assembly\GAC_MSIL";
            txtAssemblyFolderCLR4.Text = @"C:\Windows\Microsoft.NET\assembly\GAC_MSIL";
            chkBackupAssemblies.Checked = true;
        }
    }
}
