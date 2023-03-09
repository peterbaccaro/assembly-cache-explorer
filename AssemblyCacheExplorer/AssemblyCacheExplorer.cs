using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;
using System.Configuration;
using System.Reflection;
using System.IO;
using AssemblyCacheHelper;
using AssemblyCacheHelper.DTO;
using AssemblyCacheExplorer.ListView;

namespace AssemblyCacheExplorer
{
    public partial class AssemblyCacheExplorer : Form
    {
        const string _AssemblyFolderCLR2 = "AssemblyFolderCLR2";
        const string _AssemblyFolderCLR4 = "AssemblyFolderCLR4";
        const string _BackupAssemblies = "BackupAssemblies";

        static bool _appLoaded = false;
        static int _lastPercentComplete = 0;
        static ListViewSorter _lvSorter = new ListViewSorter();

        private List<NetAssembly> _netAssemblyList = new List<NetAssembly>();
        private bool _bgWorkerCompleted = true;
        private bool _closePending = false;
        
        public AssemblyCacheExplorer()
        {
            InitializeComponent();
        }

        private void AssemblyCacheExplorer_Load(object sender, EventArgs e)
        {
            //enable background worker progress reporting and cancellation
            bgWorker.WorkerReportsProgress = true;
            bgWorker.WorkerSupportsCancellation = true;
        }

        private void AssemblyCacheExplorer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_bgWorkerCompleted && !_closePending)
            {
                _closePending = true;
                e.Cancel = true;
                if (bgWorker.IsBusy) bgWorker.CancelAsync();
            }
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            _bgWorkerCompleted = false;
            e.Result = "";

            string assemblyFolderCLR2 = ConfigurationManager.AppSettings[_AssemblyFolderCLR2];
            if (!Directory.Exists(assemblyFolderCLR2)) throw new System.ApplicationException(String.Format("AssemblyFolderCLR2 folder does not exist ({0})", assemblyFolderCLR2));

            string assemblyFolderCLR4 = ConfigurationManager.AppSettings[_AssemblyFolderCLR4];
            if (!Directory.Exists(assemblyFolderCLR4)) throw new System.ApplicationException(String.Format("AssemblyFolderCLR4 folder does not exist ({0})", assemblyFolderCLR4));

            _netAssemblyList.Clear();
            List<NetAssemblyFile> assemblyFileList = new List<NetAssemblyFile>();

            string[] assemblyFiles;
            assemblyFiles = Directory.GetFiles(assemblyFolderCLR2, "*.dll", SearchOption.AllDirectories);
            foreach (string assemblyFileName in assemblyFiles)
                    assemblyFileList.Add(new NetAssemblyFile() { AssemblyFilename = assemblyFileName, RuntimeVersion = "CLR2" });

            assemblyFiles = Directory.GetFiles(assemblyFolderCLR4, "*.dll", SearchOption.AllDirectories);
            foreach (string assemblyFileName in assemblyFiles)
                    assemblyFileList.Add(new NetAssemblyFile() { AssemblyFilename = assemblyFileName, RuntimeVersion = "CLR4" });

            for (int i = 0; i < assemblyFileList.Count(); i++)
            {
                NetAssembly netAssembly = NetAssemblies.GetAssemblyInfo(assemblyFileList[i].AssemblyFilename, assemblyFileList[i].RuntimeVersion);
                _netAssemblyList.Add(netAssembly);

                int percentComplete = Convert.ToInt32(100.00 / assemblyFileList.Count() * (i + 1));

                if (percentComplete != _lastPercentComplete)
                {
                    bgWorker.ReportProgress(percentComplete, "");
                    _lastPercentComplete = percentComplete;
                }
            }
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            SetProgressBar(e.ProgressPercentage);
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _bgWorkerCompleted = true;
            toolStripProgressBar.Visible = false;
            this.Cursor = Cursors.Default;

            RefreshAssemblyCacheView();

            try
            {
                string cache = AssemblyCacheHelper.Serialization.SerializeObject(_netAssemblyList);
                StreamWriter sw = new StreamWriter("NetAssemblyCache.xml");
                sw.WriteLine(cache);
                sw.Close();
            }
            catch
            {
            }

            BeReady();

            if (_closePending) 
                this.Close();
        }

        private void ReloadAssemblyCacheView()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                toolStripProgressBar.Visible = true;
                SetProgressBar(0);

                BeBusy();
                bgWorker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void SetProgressBar(int percentage)
        {
            toolStripProgressBar.Value = percentage;
            toolStripStatusLabel.Text = String.Format("Loading Assemblies {0}%", toolStripProgressBar.Value);
            statusStrip.Refresh();
        }

        private void toolStripRuntimeVersionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_bgWorkerCompleted && !_closePending)
            {
                RefreshAssemblyCacheView();
            }
        }

        private void RefreshAssemblyCacheView()
        {
            try
            {
                lvAssemblyCache.ListViewItemSorter = null;

                lvAssemblyCache.Visible = false;
                lvAssemblyCache.Items.Clear();

                List<NetAssembly> netAssemblyListFiltered = (from assembly in _netAssemblyList
                                                             where (toolStripRuntimeVersionComboBox.SelectedIndex == 0) || 
                                                                   (toolStripRuntimeVersionComboBox.SelectedIndex == 1 && assembly.RuntimeVersion == "CLR2") ||
                                                                   (toolStripRuntimeVersionComboBox.SelectedIndex == 2 && assembly.RuntimeVersion == "CLR4")
                                                             select assembly).ToList<NetAssembly>();

                PopulateAssemblyCacheView(netAssemblyListFiltered);
            }
            finally
            {
                lvAssemblyCache.Visible = true;
            }
        }

        private void PopulateAssemblyCacheView(List<NetAssembly> netAssemblyList)
        {
            var netAssemblyListFiltered = (from assembly in netAssemblyList
                                           where assembly.AssemblyName.ToLower().Contains(toolStripFilterTextBox.Text.ToLower())
                                           select assembly);

            foreach (NetAssembly netAssembly in netAssemblyListFiltered)
            {
                ListViewItem lvi = new ListViewItem(new string[] { netAssembly.AssemblyName, netAssembly.AssemblyVersion, netAssembly.PublicKeyToken, netAssembly.RuntimeVersion, netAssembly.FileVersion, netAssembly.ModifiedDate });
                lvi.Tag = netAssembly;
                lvi.ImageIndex = 0;
                lvAssemblyCache.Items.Add(lvi);
            }

            toolStripStatusLabel.Text = String.Format("{0} Assemblies, {1} Selected", lvAssemblyCache.Items.Count, lvAssemblyCache.SelectedItems.Count);
        }

        private void AssemblyCacheExplorer_Activated(object sender, EventArgs e)
        {
            if (!_appLoaded)
            {
                this.Refresh();
                toolStripRuntimeVersionComboBox.SelectedIndex = 0;
                ReloadAssemblyCacheView();
                _appLoaded = true;
            }
        }

        private void toolStripRefreshButton_Click(object sender, EventArgs e)
        {
            if (_bgWorkerCompleted && !_closePending)
            {
                ReloadAssemblyCacheView();
            }
        }

        private void toolStripBackupFolderButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (_bgWorkerCompleted && !_closePending)
                {
                    string appFolderFullPath = Path.GetDirectoryName(Application.ExecutablePath);
                    string backupFolderFullPath = Path.Combine(appFolderFullPath, "Backup");

                    Process process = new Process();
                    if (Directory.Exists(backupFolderFullPath))
                    {
                        process.StartInfo.FileName = "explorer.exe";
                        process.StartInfo.Arguments = backupFolderFullPath;
                        process.StartInfo.UseShellExecute = false;
                        process.StartInfo.CreateNoWindow = true;
                        process.StartInfo.RedirectStandardOutput = true;
                        process.Start();
                    }
                    else
                    {
                        MessageBox.Show("Backup folder deos not exist.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lvAssemblyCache_Click(object sender, EventArgs e)
        {
            if (_bgWorkerCompleted && !_closePending)
            {
                toolStripStatusLabel.Text = String.Format("{0} Assemblies, {1} Selected", lvAssemblyCache.Items.Count, lvAssemblyCache.SelectedItems.Count);
            }
        }

        private void lvAssemblyCache_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_bgWorkerCompleted && !_closePending)
            {
                toolStripStatusLabel.Text = String.Format("{0} Assemblies, {1} Selected", lvAssemblyCache.Items.Count, lvAssemblyCache.SelectedItems.Count);
            }
        }

        private void toolStripFilterTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_bgWorkerCompleted && !_closePending)
            {
                this.Cursor = Cursors.WaitCursor;

                RefreshAssemblyCacheView();

                this.Cursor = Cursors.Default;
            }
        }

        #region InstallAssemblies

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            string unmanagedAssemblies = "";

            foreach (string fileFullPath in openFileDialog.FileNames)
            {
                try
                {
                    AssemblyName asmname = AssemblyName.GetAssemblyName(fileFullPath);
                }
                catch
                {
                    unmanagedAssemblies = unmanagedAssemblies + fileFullPath + "\n";
                }
            }

            if (unmanagedAssemblies != "")
            {
                MessageBox.Show("The following modules were expected to contain an assembly manifest: \n\n" + unmanagedAssemblies, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void toolStripInstallButton_Click(object sender, EventArgs e)
        {
            if (_bgWorkerCompleted && !_closePending)
            {
                openFileDialog.AddExtension = true;
                openFileDialog.FileName = "";
                openFileDialog.DefaultExt = ".dll";
                openFileDialog.CheckFileExists = true;
                openFileDialog.Filter = "DLL files|*.dll";

                DialogResult dialogResult = openFileDialog.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    List<string> assembliesToInstall = new List<string>();

                    foreach (string fileFullPath in openFileDialog.FileNames)
                    {
                        assembliesToInstall.Add(fileFullPath);
                    }

                    if (assembliesToInstall.Count > 0)
                        InstallAssemblies(assembliesToInstall);
                }
            }
        }

        private void lvAssemblyCache_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void lvAssemblyCache_DragDrop(object sender, DragEventArgs e)
        {
            if (_bgWorkerCompleted && !_closePending)
            {
                Array files = (Array)e.Data.GetData(DataFormats.FileDrop);

                if (files != null)
                {
                    List<string> assembliesToInstall = new List<string>();

                    foreach (string fileFullPath in files)
                    {
                        assembliesToInstall.Add(fileFullPath);
                    }

                    InstallAssemblies(assembliesToInstall);
                }
            }
        }

        private void InstallAssemblies(List<string> assembliesToInstall)
        {
            bool backupAssemblies = Convert.ToBoolean(ConfigurationManager.AppSettings[_BackupAssemblies] ?? "True");
            if (backupAssemblies)
            {
                List<string> assembliesToBackup = new List<string>();
                foreach (string assemblyFullPath in assembliesToInstall)
                {
                    NetAssembly netAssembly = NetAssemblies.GetAssemblyInfo(assemblyFullPath, "");
                    var netAssemblyFileName = (from assembly in _netAssemblyList
                                               where (assembly.AssemblyName == netAssembly.AssemblyName) &&
                                                     (assembly.AssemblyVersion == netAssembly.AssemblyVersion)
                                               select assembly.AssemblyFilename).FirstOrDefault();

                    if (netAssemblyFileName != null) assembliesToBackup.Add(netAssemblyFileName);
                }
                if (assembliesToBackup.Count > 0) BackupAssemblies(assembliesToBackup, "InstallAssemblies");
            }

            Dictionary<string, string> results = new Dictionary<string, string>();
            foreach (string assemblyFullPath in assembliesToInstall)
            {
                string gacUtilFullPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"GACUtil\gacutil.exe");
                string result = GACUtil.AssemblyInstall(gacUtilFullPath, assemblyFullPath, false);
                results.Add(Path.GetFileName(assemblyFullPath), result);
            }

            Application.DoEvents();

            AssemblyGACResults frmAssemblyGACResults = new AssemblyGACResults();
            frmAssemblyGACResults.GACResultsTitle = "Install Assembly Summary";
            frmAssemblyGACResults.GACResults = results;
            frmAssemblyGACResults.ShowDialog();

            ReloadAssemblyCacheView();
        }

        #endregion

        #region AssemblyProperties

        private void lvAssemblyCache_DoubleClick(object sender, EventArgs e)
        {
            if (_bgWorkerCompleted && !_closePending)
            {
                ShowAssemblyProperties();
            }
        }

        private void toolStripMenuProperties_Click(object sender, EventArgs e)
        {
            if (_bgWorkerCompleted && !_closePending)
            {
                ShowAssemblyProperties();
            }
        }

        private void ShowAssemblyProperties()
        {
            List<NetAssembly> netAssemblyList = new List<NetAssembly>();

            if (lvAssemblyCache.SelectedItems.Count == 0)
            {
                MessageBox.Show("No Assembly Selected", "Assembly Properties", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (lvAssemblyCache.SelectedItems.Count > 1)
            {
                MessageBox.Show("Multiple Assemblies Selected", "Assembly Properties", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                AssemblyProperties frmAssemblyProperties = new AssemblyProperties();
                frmAssemblyProperties.NetAssemblyProperties = (NetAssembly)lvAssemblyCache.SelectedItems[0].Tag;
                frmAssemblyProperties.ShowDialog();
            }
        }

        #endregion

        #region UninstallAssembly

        private void toolStripUninstallButton_Click(object sender, EventArgs e)
        {
            if (_bgWorkerCompleted && !_closePending)
            {
                UninstallAssemblies();
            }
        }

        private void toolStripMenuUninstall_Click(object sender, EventArgs e)
        {
            if (_bgWorkerCompleted && !_closePending)
            {
                UninstallAssemblies();
            }
        }

        private void UninstallAssemblies()
        {
            if (lvAssemblyCache.SelectedItems.Count == 0)
            {
                MessageBox.Show("No Assemblies Selected", "Uninstall Assembly", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string message;
                if (lvAssemblyCache.SelectedItems.Count == 1)
                    message = String.Format("Are you sure you want to uninstall '{0}' ?", ((NetAssembly)lvAssemblyCache.SelectedItems[0].Tag).AssemblyName);
                else
                    message = String.Format("Are you sure you want to uninstall these {0} items ?", lvAssemblyCache.SelectedItems.Count);

                DialogResult dialogResult = MessageBox.Show(message, "Confirm Assembly Uninstall", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    bool backupAssemblies = Convert.ToBoolean(ConfigurationManager.AppSettings[_BackupAssemblies] ?? "True");
                    if (backupAssemblies)
                    {
                        List<string> assembliesToBackup = new List<string>();
                        for (int i = 0; i < lvAssemblyCache.SelectedItems.Count; i++)
                        {
                            NetAssembly assembly = (NetAssembly)lvAssemblyCache.SelectedItems[i].Tag;
                            assembliesToBackup.Add(assembly.AssemblyFilename);
                        }
                        if (assembliesToBackup.Count > 0) BackupAssemblies(assembliesToBackup, "UninstallAssemblies");
                    }

                    Dictionary<string, string> results = new Dictionary<string, string>();
                    for (int i = 0; i < lvAssemblyCache.SelectedItems.Count; i++)
                    {
                        NetAssembly asm = (NetAssembly)lvAssemblyCache.SelectedItems[i].Tag;
                        string gacUtilFullPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"GACUtil\gacutil.exe");

                        string result = GACUtil.AssemblyUninstall(gacUtilFullPath, asm.AssemblyFullName.Replace(" ", ""), false);

                        results.Add(asm.AssemblyFullName, result);
                    }

                    ReloadAssemblyCacheView();

                    AssemblyGACResults frmAssemblyGACResults = new AssemblyGACResults();
                    frmAssemblyGACResults.GACResultsTitle = "Uninstall Assembly Summary";
                    frmAssemblyGACResults.GACResults = results;
                    frmAssemblyGACResults.ShowDialog();
                }
            }
        }

        private void BackupAssemblies(List<string> assembliesToBackup, string operation)
        {
            string appFolderFullPath = Path.GetDirectoryName(Application.ExecutablePath);
            string backupFolderFullPath = Path.Combine(appFolderFullPath, "Backup");
            string backupSubFolderFullPath = Path.Combine(backupFolderFullPath, DateTime.Now.ToString("yyyy-MM-dd_HHmm!ss_") + operation);

            if (!Directory.Exists(backupFolderFullPath)) Directory.CreateDirectory(backupFolderFullPath);
            if (!Directory.Exists(backupSubFolderFullPath)) Directory.CreateDirectory(backupSubFolderFullPath);

            foreach (string assemblyToBackup in assembliesToBackup)
            {
                string destinationFullPath = Path.Combine(backupSubFolderFullPath, Path.GetFileName(assemblyToBackup));
                int suffix = 1;
                while(File.Exists(destinationFullPath))
                {
                    destinationFullPath = destinationFullPath + suffix.ToString();
                    suffix++;
                }

                File.Copy(assemblyToBackup, destinationFullPath);
            }
        }

        #endregion

        #region Export Assembly

        private void toolStripExportAssemblyButton_Click(object sender, EventArgs e)
        {
            if (_bgWorkerCompleted && !_closePending)
            {
                ExportAssemblies();
            }
        }

        private void toolStripMenuExport_Click(object sender, EventArgs e)
        {
            if (_bgWorkerCompleted && !_closePending)
            {
                ExportAssemblies();
            }
        }
        
        private void ExportAssemblies()
        {
            try
            {
                if (lvAssemblyCache.SelectedItems.Count == 0)
                {
                    MessageBox.Show("No Assemblies Selected", "Export Assembly", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    folderBrowserDialog.Description = "Select Export Folder";
                    DialogResult folderBrowserDialogResult = folderBrowserDialog.ShowDialog();

                    if (folderBrowserDialogResult == DialogResult.OK)
                    {
                        string destinationFolder = folderBrowserDialog.SelectedPath;

                        List<string> assembliesToExport = new List<string>();
                        for (int i = 0; i < lvAssemblyCache.SelectedItems.Count; i++)
                        {
                            NetAssembly asm = (NetAssembly)lvAssemblyCache.SelectedItems[i].Tag;
                            assembliesToExport.Add(asm.AssemblyFilename);
                        }

                        if (!Directory.Exists(destinationFolder))
                        {
                            MessageBox.Show(String.Format("Destination folder does not exist./n/n'{0}'.", destinationFolder), "Export Assemblies", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        foreach (string assemblyFullPath in assembliesToExport)
                        {
                            string assemblyFileName = Path.GetFileName(assemblyFullPath);
                            string exportAssemblyFullPath = Path.Combine(destinationFolder, assemblyFileName);

                            if (File.Exists(exportAssemblyFullPath))
                            {
                                DialogResult dialogResult = MessageBox.Show(String.Format("Assembly '{0}' already exists, overwrite ?", assemblyFileName), "Export Assemblies", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (dialogResult == DialogResult.Yes)
                                {
                                    try
                                    {
                                        File.Delete(exportAssemblyFullPath);
                                        File.Copy(assemblyFullPath, exportAssemblyFullPath);
                                    }
                                    catch (Exception ex)
                                    {
                                        string msg = String.Format("Assembly '{0}' could not be overwritten./n/nError:/n{1}", assemblyFileName, ex.Message);
                                        MessageBox.Show(msg, "Export Assemblies", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }

                                }
                            }
                            else
                            {
                                File.Copy(assemblyFullPath, exportAssemblyFullPath);
                            }
                        }

                        MessageBox.Show("Assembly Export completed successfully.", "Export Assembly", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Export Assemblies failed./n/nError:/n{0}", ex.Message), "Export Assemblies", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void lvAssemblyCache_KeyUp(object sender, KeyEventArgs e)
        {
            if (_bgWorkerCompleted && !_closePending)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    UninstallAssemblies();
                }
                else if (e.KeyCode == Keys.F5)
                {
                    ReloadAssemblyCacheView();
                }
            }
        }

        private void toolStripSettingsButton_Click(object sender, EventArgs e)
        {
            if (_bgWorkerCompleted && !_closePending)
            {
                Settings frmSettings = new Settings();
                frmSettings.ShowDialog();
            }
        }

        private void toolStripAboutButton_Click(object sender, EventArgs e)
        {
            if (_bgWorkerCompleted && !_closePending)
            {
                About frmAbout = new About();
                frmAbout.ShowDialog();
            }
        }

        private void lvAssemblyCache_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (_bgWorkerCompleted && !_closePending)
            {
                lvAssemblyCache.ListViewItemSorter = _lvSorter;

                if (_lvSorter.LastSortColumn == e.Column)
                {
                    if (lvAssemblyCache.Sorting == SortOrder.Ascending)
                        lvAssemblyCache.Sorting = SortOrder.Descending;
                    else
                        lvAssemblyCache.Sorting = SortOrder.Ascending;
                }
                else
                {
                    lvAssemblyCache.Sorting = SortOrder.Descending;
                }
                _lvSorter.Column = e.Column;

                lvAssemblyCache.Sort();
            }
        }

        private void BeBusy()
        {
            toolStripInstallButton.Enabled = false;
            toolStripUninstallButton.Enabled = false;
            toolStripExportAssemblyButton.Enabled = false;
            toolStripRefreshButton.Enabled = false;
            toolStripBackupFolderButton.Enabled = false;
            toolStripSettingsButton.Enabled = false;
            toolStripFilterTextBox.Enabled = false;
            toolStripRuntimeVersionComboBox.Enabled = false;
            toolStripAboutButton.Enabled = false;

            contextMenuStrip.Enabled = false;
        }

        private void BeReady()
        {
            toolStripInstallButton.Enabled = true;
            toolStripUninstallButton.Enabled = true;
            toolStripExportAssemblyButton.Enabled = true;
            toolStripRefreshButton.Enabled = true;
            toolStripBackupFolderButton.Enabled = true;
            toolStripSettingsButton.Enabled = true;
            toolStripFilterTextBox.Enabled = true;
            toolStripRuntimeVersionComboBox.Enabled = true;
            toolStripAboutButton.Enabled = true;

            contextMenuStrip.Enabled = true;
        }
   }
}
