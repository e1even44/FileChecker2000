using FileChecker.Core.AccessLayers;
using FileChecker.Core.Services;
using FileChecker.Data.Entities;

namespace FileChecker.Forms
{
    public partial class MainForm : Form
    {
        private readonly AppFileAccessLayer _fileAccess = new();
        private readonly ScanAccessLayer _scanAccess = new();

        private AppFile? _selectedFile;

        public MainForm()
        {
            InitializeComponent();
        }

        private void RefreshDataGridViewAllFiles()
        {
            dataGridViewAllFiles.DataSource = null;
            dataGridViewAllFiles.DataSource = _fileAccess.GetAll();

            // if datagridview has at least one file, set selected row to first row of datagridview
            if (dataGridViewAllFiles.Rows.Count > 0)
            {
                dataGridViewAllFiles.Rows[0].Selected = true;
            }
        }

        private void RefreshDataGridViewScansForFile()
        {
            dataGridViewScansForFile.DataSource = null;
            dataGridViewScansForFile.DataSource = _scanAccess.GetScansForFile(_selectedFile);
        }

        /// <summary>
        /// Gets selected row from datagridview, if row count is greater than zero.
        /// </summary>
        /// <returns>Selected row as AppFile if count greater zero, null if count zero.</returns>
        private AppFile? GetSelectedAppFile()
        {
            if (dataGridViewAllFiles.SelectedRows.Count > 0)
            {
                return (AppFile)dataGridViewAllFiles.SelectedRows[0].DataBoundItem;
            }
            return null;
        }

        private void buttonOpenExplorer_Click(object sender, EventArgs e)
        {
            // open folder browser dialog
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Ordner auswählen";
                folderDialog.ShowNewFolderButton = true;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    // show selected folder path in textbox
                    textBoxInitialDirectoryPath.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.CenterScreen;

            RefreshDataGridViewAllFiles(); // get files from database
            _selectedFile = GetSelectedAppFile();
        }

        private void textBoxInitialDirectoryPath_TextChanged(object sender, EventArgs e)
        {
            buttonAddFiles.Enabled = textBoxInitialDirectoryPath.Text.Length > 0 ? true : false; // only enable "add files" button, if a folder has been already selected
        }

        private void buttonAddFiles_Click(object sender, EventArgs e)
        {
            FileService.GetFilesRecursively(textBoxInitialDirectoryPath.Text);
            RefreshDataGridViewAllFiles();
        }

        private void buttonScanFiles_Click(object sender, EventArgs e)
        {
            // create new scan based on selected file
            Scan scan = new Scan
            {
                AppFileId = _selectedFile.AppFileId,
                ScanDate = DateTime.Now,
                CurrentSizeInBytes = FileService.GetCurrentFileSize(_selectedFile.FilePath),
                CurrentChecksum = FileService.GetFileChecksum(_selectedFile.FilePath),
            };
            scan.Status = FileService.GetStatus(_selectedFile, scan.CurrentChecksum);

            // add scan to database
            _scanAccess.Add(scan);

            // update selected file properties
            AppFile appFile = new AppFile
            {
                ParentDirectoryPath = _selectedFile.ParentDirectoryPath,
                FilePath = _selectedFile.FilePath,
                FileSizeInBytes = FileService.GetCurrentFileSize(_selectedFile.FilePath),
                Checksum = FileService.GetFileChecksum(_selectedFile.FilePath),
                Created = _selectedFile.Created,
                LastModified = FileService.GetLastModified(_selectedFile.FilePath),
            };

            // update file in database
            _fileAccess.Update(_selectedFile.AppFileId, appFile);

            // refresh UI
            RefreshDataGridViewScansForFile();
            RefreshDataGridViewAllFiles();
        }

        private void dataGridViewAllFiles_SelectionChanged(object sender, EventArgs e)
        {
            // if selected file is not null and if the file has a scan history,
            // show all scans on scans-datagridview
            // else show nothing
            _selectedFile = GetSelectedAppFile();
            if (_selectedFile != null && _scanAccess.FileHasScans(_selectedFile))
            {
                RefreshDataGridViewScansForFile();
            }
            else
            {
                dataGridViewScansForFile.DataSource = null;
            }
        }
    }
}
