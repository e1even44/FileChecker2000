namespace FileChecker.Forms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            buttonAddFiles = new Button();
            buttonOpenExplorer = new Button();
            textBoxInitialDirectoryPath = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            buttonScanFiles = new Button();
            dataGridViewScansForFile = new DataGridView();
            dataGridViewAllFiles = new DataGridView();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewScansForFile).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAllFiles).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(buttonAddFiles);
            groupBox1.Controls.Add(buttonOpenExplorer);
            groupBox1.Controls.Add(textBoxInitialDirectoryPath);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(809, 86);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ordner Information:";
            // 
            // buttonAddFiles
            // 
            buttonAddFiles.Enabled = false;
            buttonAddFiles.Location = new Point(673, 39);
            buttonAddFiles.Name = "buttonAddFiles";
            buttonAddFiles.Size = new Size(127, 23);
            buttonAddFiles.TabIndex = 2;
            buttonAddFiles.Text = "Dateien hinzufügen";
            buttonAddFiles.UseVisualStyleBackColor = true;
            buttonAddFiles.Click += buttonAddFiles_Click;
            // 
            // buttonOpenExplorer
            // 
            buttonOpenExplorer.Location = new Point(540, 39);
            buttonOpenExplorer.Name = "buttonOpenExplorer";
            buttonOpenExplorer.Size = new Size(127, 23);
            buttonOpenExplorer.TabIndex = 1;
            buttonOpenExplorer.Text = "Explorer öffnen";
            buttonOpenExplorer.UseVisualStyleBackColor = true;
            buttonOpenExplorer.Click += buttonOpenExplorer_Click;
            // 
            // textBoxInitialDirectoryPath
            // 
            textBoxInitialDirectoryPath.Location = new Point(143, 39);
            textBoxInitialDirectoryPath.Name = "textBoxInitialDirectoryPath";
            textBoxInitialDirectoryPath.ReadOnly = true;
            textBoxInitialDirectoryPath.Size = new Size(391, 23);
            textBoxInitialDirectoryPath.TabIndex = 1;
            textBoxInitialDirectoryPath.TextChanged += textBoxInitialDirectoryPath_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 42);
            label1.Name = "label1";
            label1.Size = new Size(118, 15);
            label1.TabIndex = 0;
            label1.Text = "Initialer Ordner-Pfad:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(buttonScanFiles);
            groupBox2.Controls.Add(dataGridViewScansForFile);
            groupBox2.Controls.Add(dataGridViewAllFiles);
            groupBox2.Location = new Point(12, 104);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1384, 661);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Dateiübersicht:";
            // 
            // buttonScanFiles
            // 
            buttonScanFiles.Location = new Point(682, 632);
            buttonScanFiles.Name = "buttonScanFiles";
            buttonScanFiles.Size = new Size(127, 23);
            buttonScanFiles.TabIndex = 3;
            buttonScanFiles.Text = "Datei scannen";
            buttonScanFiles.UseVisualStyleBackColor = true;
            buttonScanFiles.Click += buttonScanFiles_Click;
            // 
            // dataGridViewScansForFile
            // 
            dataGridViewScansForFile.AllowUserToAddRows = false;
            dataGridViewScansForFile.AllowUserToDeleteRows = false;
            dataGridViewScansForFile.AllowUserToResizeRows = false;
            dataGridViewScansForFile.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewScansForFile.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewScansForFile.Location = new Point(815, 22);
            dataGridViewScansForFile.MultiSelect = false;
            dataGridViewScansForFile.Name = "dataGridViewScansForFile";
            dataGridViewScansForFile.ReadOnly = true;
            dataGridViewScansForFile.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewScansForFile.Size = new Size(563, 604);
            dataGridViewScansForFile.TabIndex = 1;
            // 
            // dataGridViewAllFiles
            // 
            dataGridViewAllFiles.AllowUserToAddRows = false;
            dataGridViewAllFiles.AllowUserToDeleteRows = false;
            dataGridViewAllFiles.AllowUserToOrderColumns = true;
            dataGridViewAllFiles.AllowUserToResizeRows = false;
            dataGridViewAllFiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewAllFiles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAllFiles.Location = new Point(6, 22);
            dataGridViewAllFiles.MultiSelect = false;
            dataGridViewAllFiles.Name = "dataGridViewAllFiles";
            dataGridViewAllFiles.ReadOnly = true;
            dataGridViewAllFiles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewAllFiles.Size = new Size(803, 604);
            dataGridViewAllFiles.TabIndex = 0;
            dataGridViewAllFiles.SelectionChanged += dataGridViewAllFiles_SelectionChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1408, 777);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            MaximumSize = new Size(1424, 816);
            MinimumSize = new Size(1424, 816);
            Name = "MainForm";
            Text = "Dateien";
            Load += MainForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewScansForFile).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAllFiles).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button buttonOpenExplorer;
        private TextBox textBoxInitialDirectoryPath;
        private Label label1;
        private GroupBox groupBox2;
        private DataGridView dataGridViewAllFiles;
        private Button buttonAddFiles;
        private Button buttonScanFiles;
        private DataGridView dataGridViewScansForFile;
    }
}
