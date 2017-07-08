namespace ReleaseSupport
{
    partial class Form1
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.hCustomer = new System.Windows.Forms.ColumnHeader();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cmdCustAdd = new System.Windows.Forms.Button();
            this.cmdCustDelete = new System.Windows.Forms.Button();
            this.cmdCustEdit = new System.Windows.Forms.Button();
            this.cmdCompAdd = new System.Windows.Forms.Button();
            this.cmdCompDelete = new System.Windows.Forms.Button();
            this.cmdCompEdit = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.hComponent = new System.Windows.Forms.ColumnHeader();
            this.hSourceRoot = new System.Windows.Forms.ColumnHeader();
            this.hFilter = new System.Windows.Forms.ColumnHeader();
            this.hTargetDir = new System.Windows.Forms.ColumnHeader();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tbxLog = new System.Windows.Forms.TextBox();
            this.hRootdir = new System.Windows.Forms.ColumnHeader();
            this.linkNotes = new System.Windows.Forms.LinkLabel();
            this.cmdMakeRelease = new System.Windows.Forms.Button();
            this.tbxReleaseLabel = new System.Windows.Forms.TextBox();
            this.cmdSaveConfig = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hCustomer,
            this.hRootdir});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(298, 155);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // hCustomer
            // 
            this.hCustomer.Text = "Customer";
            this.hCustomer.Width = 98;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.linkNotes);
            this.splitContainer1.Panel1.Controls.Add(this.cmdCustAdd);
            this.splitContainer1.Panel1.Controls.Add(this.cmdCustDelete);
            this.splitContainer1.Panel1.Controls.Add(this.cmdCustEdit);
            this.splitContainer1.Panel1.Controls.Add(this.listView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.cmdCompAdd);
            this.splitContainer1.Panel2.Controls.Add(this.cmdCompDelete);
            this.splitContainer1.Panel2.Controls.Add(this.cmdCompEdit);
            this.splitContainer1.Panel2.Controls.Add(this.listView2);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(906, 196);
            this.splitContainer1.SplitterDistance = 301;
            this.splitContainer1.TabIndex = 1;
            // 
            // cmdCustAdd
            // 
            this.cmdCustAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdCustAdd.Location = new System.Drawing.Point(3, 163);
            this.cmdCustAdd.Name = "cmdCustAdd";
            this.cmdCustAdd.Size = new System.Drawing.Size(64, 30);
            this.cmdCustAdd.TabIndex = 1;
            this.cmdCustAdd.Text = "Add...";
            this.cmdCustAdd.UseVisualStyleBackColor = true;
            this.cmdCustAdd.Click += new System.EventHandler(this.cmdCustAdd_Click);
            // 
            // cmdCustDelete
            // 
            this.cmdCustDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdCustDelete.Location = new System.Drawing.Point(143, 163);
            this.cmdCustDelete.Name = "cmdCustDelete";
            this.cmdCustDelete.Size = new System.Drawing.Size(64, 30);
            this.cmdCustDelete.TabIndex = 1;
            this.cmdCustDelete.Text = "Delete";
            this.cmdCustDelete.UseVisualStyleBackColor = true;
            this.cmdCustDelete.Click += new System.EventHandler(this.cmdCustDelete_Click);
            // 
            // cmdCustEdit
            // 
            this.cmdCustEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdCustEdit.Location = new System.Drawing.Point(73, 163);
            this.cmdCustEdit.Name = "cmdCustEdit";
            this.cmdCustEdit.Size = new System.Drawing.Size(64, 30);
            this.cmdCustEdit.TabIndex = 1;
            this.cmdCustEdit.Text = "Edit...";
            this.cmdCustEdit.UseVisualStyleBackColor = true;
            this.cmdCustEdit.Click += new System.EventHandler(this.cmdCustEdit_Click);
            // 
            // cmdCompAdd
            // 
            this.cmdCompAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdCompAdd.Location = new System.Drawing.Point(3, 163);
            this.cmdCompAdd.Name = "cmdCompAdd";
            this.cmdCompAdd.Size = new System.Drawing.Size(64, 30);
            this.cmdCompAdd.TabIndex = 4;
            this.cmdCompAdd.Text = "Add...";
            this.cmdCompAdd.UseVisualStyleBackColor = true;
            this.cmdCompAdd.Click += new System.EventHandler(this.cmdCompAdd_Click);
            // 
            // cmdCompDelete
            // 
            this.cmdCompDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdCompDelete.Location = new System.Drawing.Point(143, 163);
            this.cmdCompDelete.Name = "cmdCompDelete";
            this.cmdCompDelete.Size = new System.Drawing.Size(64, 30);
            this.cmdCompDelete.TabIndex = 3;
            this.cmdCompDelete.Text = "Delete";
            this.cmdCompDelete.UseVisualStyleBackColor = true;
            this.cmdCompDelete.Click += new System.EventHandler(this.cmdCompDelete_Click);
            // 
            // cmdCompEdit
            // 
            this.cmdCompEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdCompEdit.Location = new System.Drawing.Point(73, 163);
            this.cmdCompEdit.Name = "cmdCompEdit";
            this.cmdCompEdit.Size = new System.Drawing.Size(64, 30);
            this.cmdCompEdit.TabIndex = 2;
            this.cmdCompEdit.Text = "Edit...";
            this.cmdCompEdit.UseVisualStyleBackColor = true;
            this.cmdCompEdit.Click += new System.EventHandler(this.cmdCompEdit_Click);
            // 
            // listView2
            // 
            this.listView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView2.CheckBoxes = true;
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hComponent,
            this.hSourceRoot,
            this.hFilter,
            this.hTargetDir});
            this.listView2.Location = new System.Drawing.Point(3, 3);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(595, 155);
            this.listView2.TabIndex = 1;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.OnItemChecked);
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // hComponent
            // 
            this.hComponent.Text = "Component";
            this.hComponent.Width = 108;
            // 
            // hSourceRoot
            // 
            this.hSourceRoot.Text = "SourceRoot";
            this.hSourceRoot.Width = 342;
            // 
            // hFilter
            // 
            this.hFilter.Text = "Filter";
            // 
            // hTargetDir
            // 
            this.hTargetDir.Text = "TargetDir";
            this.hTargetDir.Width = 74;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(2, 4);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tbxReleaseLabel);
            this.splitContainer2.Panel2.Controls.Add(this.cmdSaveConfig);
            this.splitContainer2.Panel2.Controls.Add(this.cmdMakeRelease);
            this.splitContainer2.Panel2.Controls.Add(this.tbxLog);
            this.splitContainer2.Size = new System.Drawing.Size(909, 405);
            this.splitContainer2.SplitterDistance = 202;
            this.splitContainer2.TabIndex = 2;
            // 
            // tbxLog
            // 
            this.tbxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxLog.Location = new System.Drawing.Point(155, 26);
            this.tbxLog.Multiline = true;
            this.tbxLog.Name = "tbxLog";
            this.tbxLog.ReadOnly = true;
            this.tbxLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbxLog.Size = new System.Drawing.Size(754, 170);
            this.tbxLog.TabIndex = 0;
            this.tbxLog.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnLogKeyUp);
            // 
            // hRootdir
            // 
            this.hRootdir.Text = "RootDir";
            this.hRootdir.Width = 190;
            // 
            // linkNotes
            // 
            this.linkNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkNotes.AutoSize = true;
            this.linkNotes.Location = new System.Drawing.Point(213, 172);
            this.linkNotes.Name = "linkNotes";
            this.linkNotes.Size = new System.Drawing.Size(77, 13);
            this.linkNotes.TabIndex = 5;
            this.linkNotes.TabStop = true;
            this.linkNotes.Text = "Release Notes";
            this.linkNotes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkNotes_LinkClicked);
            // 
            // cmdMakeRelease
            // 
            this.cmdMakeRelease.Location = new System.Drawing.Point(6, 52);
            this.cmdMakeRelease.Name = "cmdMakeRelease";
            this.cmdMakeRelease.Size = new System.Drawing.Size(143, 29);
            this.cmdMakeRelease.TabIndex = 1;
            this.cmdMakeRelease.Text = "Make Release";
            this.cmdMakeRelease.UseVisualStyleBackColor = true;
            this.cmdMakeRelease.Click += new System.EventHandler(this.cmdMakeRelease_Click);
            // 
            // tbxReleaseLabel
            // 
            this.tbxReleaseLabel.Location = new System.Drawing.Point(6, 26);
            this.tbxReleaseLabel.Name = "tbxReleaseLabel";
            this.tbxReleaseLabel.Size = new System.Drawing.Size(140, 20);
            this.tbxReleaseLabel.TabIndex = 2;
            // 
            // cmdSaveConfig
            // 
            this.cmdSaveConfig.Location = new System.Drawing.Point(6, 155);
            this.cmdSaveConfig.Name = "cmdSaveConfig";
            this.cmdSaveConfig.Size = new System.Drawing.Size(143, 29);
            this.cmdSaveConfig.TabIndex = 1;
            this.cmdSaveConfig.Text = "Save Config";
            this.cmdSaveConfig.UseVisualStyleBackColor = true;
            this.cmdSaveConfig.Click += new System.EventHandler(this.cmdSaveConfig_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 412);
            this.Controls.Add(this.splitContainer2);
            this.Name = "Form1";
            this.Text = "Release Support";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.TextBox tbxLog;
        private System.Windows.Forms.Button cmdCustAdd;
        private System.Windows.Forms.Button cmdCustDelete;
        private System.Windows.Forms.Button cmdCustEdit;
        private System.Windows.Forms.Button cmdCompAdd;
        private System.Windows.Forms.Button cmdCompDelete;
        private System.Windows.Forms.Button cmdCompEdit;
        private System.Windows.Forms.ColumnHeader hCustomer;
        private System.Windows.Forms.ColumnHeader hComponent;
        private System.Windows.Forms.ColumnHeader hSourceRoot;
        private System.Windows.Forms.ColumnHeader hFilter;
        private System.Windows.Forms.ColumnHeader hTargetDir;
        private System.Windows.Forms.ColumnHeader hRootdir;
        private System.Windows.Forms.LinkLabel linkNotes;
        private System.Windows.Forms.TextBox tbxReleaseLabel;
        private System.Windows.Forms.Button cmdMakeRelease;
        private System.Windows.Forms.Button cmdSaveConfig;
    }
}

