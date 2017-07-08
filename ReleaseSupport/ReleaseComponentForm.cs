using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ReleaseSupport
{
    public partial class ReleaseComponentForm : Form
    {

        bool _targetDirUserOverride = false;

        public ReleaseComponentForm()
        {
            InitializeComponent();
        }

        private void tbxHome_TextChanged(object sender, EventArgs e)
        {
            EnDisButtons();
        }

        private void EnDisButtons()
        {
            cmdOK.Enabled = tbxSourceDir.Text != String.Empty && tbxName.Text.Trim() != String.Empty && tbxTargetDir.Text != String.Empty;
        }

        public string CustName
        {
            get { return tbxName.Text; }
            set { tbxName.Text = value; }
        }
        public string SourceDir
        {
            get { return tbxSourceDir.Text; }
            set { tbxSourceDir.Text = value; }
        }
        public string TargetDir
        {
            get { return tbxTargetDir.Text; }
            set { tbxTargetDir.Text = value; }
        }
        public string Filter
        {
            get { return tbxFilter.Text; }
            set { tbxFilter.Text = value; }
        }
        public bool Deep
        {
            get { return cbxDeep.Checked; }
            set { cbxDeep.Checked = value; }
        }

        private void tbxName_TextChanged(object sender, EventArgs e)
        {
            EnDisButtons();
            if (!_targetDirUserOverride)
            {
                tbxTargetDir.Text = tbxName.Text;
            }
        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            if (tbxSourceDir.Text != String.Empty)
                folderBrowserDialog1.SelectedPath = tbxSourceDir.Text;
            if (folderBrowserDialog1.ShowDialog() != DialogResult.Cancel)
            {
                tbxSourceDir.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        public void Clear()
        {
            _targetDirUserOverride = false;
            tbxName.Clear();
            tbxSourceDir.Clear();
            tbxFilter.Clear();
            tbxTargetDir.Clear();
        }

        private void SetOverrideTrue(object sender, KeyPressEventArgs e)
        {
            _targetDirUserOverride = true;
        }

        private void tbxTargetDir_TextChanged(object sender, EventArgs e)
        {
            if (_targetDirUserOverride)
                EnDisButtons();
        }

    }
}