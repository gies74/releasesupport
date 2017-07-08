using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ReleaseSupport
{
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
        }

        private void tbxHome_TextChanged(object sender, EventArgs e)
        {
            EnDisButtons();
        }

        private void EnDisButtons()
        {
            cmdOK.Enabled = tbxHome.Text != String.Empty && tbxName.Text.Trim() != String.Empty;
        }

        public string CustName
        {
            get { return tbxName.Text; }
            set { tbxName.Text = value; }
        }
        public string Home
        {
            get { return tbxHome.Text; }
            set { tbxHome.Text = value; }
        }
        public string Notes
        {
            get { return tbxNotes.Text; }
            set { tbxNotes.Text = value; }
        }
        public string ReleaseFormat
        {
            get { return tbxReleaseFormat.Text; }
            set { tbxReleaseFormat.Text = value; }
        }

        private void tbxName_TextChanged(object sender, EventArgs e)
        {
            EnDisButtons();
        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            if (tbxHome.Text != String.Empty)
                folderBrowserDialog1.SelectedPath = tbxHome.Text;
            if (folderBrowserDialog1.ShowDialog() != DialogResult.Cancel)
            {
                tbxHome.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void cmdBrowseNotes_Click(object sender, EventArgs e)
        {
            if (tbxNotes.Text != String.Empty)
                openFileDialog1.FileName = tbxNotes.Text;
            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                tbxNotes.Text = openFileDialog1.FileName;
            }
        }

        public void Clear()
        {
            tbxHome.Clear();
            tbxName.Clear();
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (!String.IsNullOrEmpty(tbxNotes.Text))
                if (Path.GetExtension(tbxNotes.Text) != ".txt")
                {
                    MessageBox.Show("Release notes must have .txt extension.");
                    e.Cancel = true;
                }
                else
                {
                    FileInfo releaseNotes = new FileInfo(Path.Combine(tbxHome.Text, tbxNotes.Text));
                    if (!releaseNotes.Exists)
                    {
                        using (var sw = new StreamWriter(releaseNotes.FullName))
                        {
                            sw.WriteLine("====================================================");
                            sw.WriteLine("|| R E L E A S E   N O T E S   " + tbxName.Text);
                            sw.WriteLine("====================================================");
                            sw.Close();
                        }
                    }

                }
            
        }
    }
}