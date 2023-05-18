namespace CustomExplorer
{
    partial class CustomExplorer
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
            this.startButton = new System.Windows.Forms.Button();
            this.directoryTreeView = new System.Windows.Forms.TreeView();
            this.directoryStructureLabel = new System.Windows.Forms.Label();
            this.historyFolderButton = new System.Windows.Forms.Button();
            this.historyFolderTextBox = new System.Windows.Forms.TextBox();
            this.directoryPathTextBox = new System.Windows.Forms.TextBox();
            this.selectDirectoryButton = new System.Windows.Forms.Button();
            this.historyFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(12, 100);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(257, 66);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // directoryTreeView
            // 
            this.directoryTreeView.Location = new System.Drawing.Point(12, 201);
            this.directoryTreeView.Name = "directoryTreeView";
            this.directoryTreeView.Size = new System.Drawing.Size(257, 251);
            this.directoryTreeView.TabIndex = 2;
            // 
            // directoryStructureLabel
            // 
            this.directoryStructureLabel.AutoSize = true;
            this.directoryStructureLabel.Location = new System.Drawing.Point(12, 182);
            this.directoryStructureLabel.Name = "directoryStructureLabel";
            this.directoryStructureLabel.Size = new System.Drawing.Size(93, 13);
            this.directoryStructureLabel.TabIndex = 3;
            this.directoryStructureLabel.Text = "Directory structure";
            // 
            // historyFolderButton
            // 
            this.historyFolderButton.Location = new System.Drawing.Point(154, 16);
            this.historyFolderButton.Name = "historyFolderButton";
            this.historyFolderButton.Size = new System.Drawing.Size(115, 33);
            this.historyFolderButton.TabIndex = 5;
            this.historyFolderButton.Text = "Select history folder";
            this.historyFolderButton.UseVisualStyleBackColor = true;
            this.historyFolderButton.Click += new System.EventHandler(this.historyFolderButton_Click);
            // 
            // historyFolderTextBox
            // 
            this.historyFolderTextBox.Location = new System.Drawing.Point(12, 23);
            this.historyFolderTextBox.Name = "historyFolderTextBox";
            this.historyFolderTextBox.ReadOnly = true;
            this.historyFolderTextBox.Size = new System.Drawing.Size(127, 20);
            this.historyFolderTextBox.TabIndex = 6;
            // 
            // directoryPathTextBox
            // 
            this.directoryPathTextBox.Location = new System.Drawing.Point(12, 68);
            this.directoryPathTextBox.Name = "directoryPathTextBox";
            this.directoryPathTextBox.ReadOnly = true;
            this.directoryPathTextBox.Size = new System.Drawing.Size(127, 20);
            this.directoryPathTextBox.TabIndex = 8;
            // 
            // selectDirectoryButton
            // 
            this.selectDirectoryButton.Location = new System.Drawing.Point(154, 61);
            this.selectDirectoryButton.Name = "selectDirectoryButton";
            this.selectDirectoryButton.Size = new System.Drawing.Size(115, 33);
            this.selectDirectoryButton.TabIndex = 7;
            this.selectDirectoryButton.Text = "Select directory";
            this.selectDirectoryButton.UseVisualStyleBackColor = true;
            this.selectDirectoryButton.Click += new System.EventHandler(this.selectDirectoryButton_Click);
            // 
            // CustomExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 465);
            this.Controls.Add(this.directoryPathTextBox);
            this.Controls.Add(this.selectDirectoryButton);
            this.Controls.Add(this.historyFolderTextBox);
            this.Controls.Add(this.historyFolderButton);
            this.Controls.Add(this.directoryStructureLabel);
            this.Controls.Add(this.directoryTreeView);
            this.Controls.Add(this.startButton);
            this.Name = "CustomExplorer";
            this.Text = "CustomExplorer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TreeView directoryTreeView;
        private System.Windows.Forms.Label directoryStructureLabel;
        private System.Windows.Forms.Button historyFolderButton;
        private System.Windows.Forms.TextBox historyFolderTextBox;
        private System.Windows.Forms.TextBox directoryPathTextBox;
        private System.Windows.Forms.Button selectDirectoryButton;
        private System.Windows.Forms.FolderBrowserDialog historyFolderBrowserDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}

