using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomExplorer
{
    public partial class CustomExplorer : Form
    {
        public CustomExplorer()
        {
            InitializeComponent();
        }

        private void historyFolderButton_Click(object sender, EventArgs e)
        {
            DialogResult result = this.historyFolderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.historyFolderTextBox.Text = this.historyFolderBrowserDialog.SelectedPath;
            }
        }

        private void selectDirectoryButton_Click(object sender, EventArgs e)
        {
            DialogResult result = this.folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.directoryPathTextBox.Text = this.folderBrowserDialog.SelectedPath;
            }
        }

        private async void startButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(historyFolderTextBox.Text))
            {
                MessageBox.Show("Select directory to save history", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (String.IsNullOrEmpty(directoryPathTextBox.Text))
            {
                MessageBox.Show("Select directory to explore", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            startButton.Enabled = false;
            directoryTreeView.Nodes.Clear();

            var tokenSource = new CancellationTokenSource();
            var historyFolder = historyFolderTextBox.Text;
            var directoryPath = directoryPathTextBox.Text;

            var directoryExplorer = new DirectoryExplorer();

            var handlers = new List<ExplorerItemHandler>
            {
                new XmlWriter(historyFolder, Path.GetFileName(directoryPath)),
                new TreeViewWriter(directoryTreeView)
            };
            var tasks = new List<Task>();

            try 
            { 
                foreach (var explorerItemHandler in handlers)
                {
                    directoryExplorer.AddObserver(explorerItemHandler);
                    tasks.Add(Task.Run(() => explorerItemHandler.Handle(tokenSource), tokenSource.Token));
                }

                tasks.Add(Task.Run(() => directoryExplorer.StartExplore(directoryPath, tokenSource), tokenSource.Token));

                await Task.WhenAll(tasks);
            }
            catch
            {
                foreach (var task in tasks.Where(t => t.Exception != null))
                {
                    MessageBox.Show(task.Exception.InnerExceptions.First().Message);
                }
            }
            finally
            {
                tokenSource.Cancel();
            }
            MessageBox.Show("Done");
            startButton.Enabled = true;
        }
    }
}
