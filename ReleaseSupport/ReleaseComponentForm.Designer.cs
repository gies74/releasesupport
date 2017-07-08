namespace ReleaseSupport
{
    partial class ReleaseComponentForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lblHome = new System.Windows.Forms.Label();
            this.tbxSourceDir = new System.Windows.Forms.TextBox();
            this.cmdBrowse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxFilter = new System.Windows.Forms.TextBox();
            this.tbxTargetDir = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxDeep = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(83, 14);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(133, 20);
            this.tbxName.TabIndex = 1;
            this.tbxName.TextChanged += new System.EventHandler(this.tbxName_TextChanged);
            // 
            // cmdOK
            // 
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Location = new System.Drawing.Point(191, 156);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(74, 29);
            this.cmdOK.TabIndex = 6;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(111, 156);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(74, 29);
            this.cmdCancel.TabIndex = 7;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // lblHome
            // 
            this.lblHome.AutoSize = true;
            this.lblHome.Location = new System.Drawing.Point(15, 48);
            this.lblHome.Name = "lblHome";
            this.lblHome.Size = new System.Drawing.Size(57, 13);
            this.lblHome.TabIndex = 2;
            this.lblHome.Text = "Source Dir";
            // 
            // tbxSourceDir
            // 
            this.tbxSourceDir.Location = new System.Drawing.Point(83, 41);
            this.tbxSourceDir.Name = "tbxSourceDir";
            this.tbxSourceDir.Size = new System.Drawing.Size(133, 20);
            this.tbxSourceDir.TabIndex = 2;
            this.tbxSourceDir.TextChanged += new System.EventHandler(this.tbxHome_TextChanged);
            // 
            // cmdBrowse
            // 
            this.cmdBrowse.Location = new System.Drawing.Point(222, 41);
            this.cmdBrowse.Name = "cmdBrowse";
            this.cmdBrowse.Size = new System.Drawing.Size(27, 19);
            this.cmdBrowse.TabIndex = 3;
            this.cmdBrowse.Text = "...";
            this.cmdBrowse.UseVisualStyleBackColor = true;
            this.cmdBrowse.Click += new System.EventHandler(this.cmdBrowse_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Filter";
            // 
            // tbxFilter
            // 
            this.tbxFilter.Location = new System.Drawing.Point(83, 67);
            this.tbxFilter.Name = "tbxFilter";
            this.tbxFilter.Size = new System.Drawing.Size(133, 20);
            this.tbxFilter.TabIndex = 4;
            this.tbxFilter.TextChanged += new System.EventHandler(this.tbxName_TextChanged);
            // 
            // tbxTargetDir
            // 
            this.tbxTargetDir.Location = new System.Drawing.Point(83, 93);
            this.tbxTargetDir.Name = "tbxTargetDir";
            this.tbxTargetDir.Size = new System.Drawing.Size(133, 20);
            this.tbxTargetDir.TabIndex = 5;
            this.tbxTargetDir.TextChanged += new System.EventHandler(this.tbxTargetDir_TextChanged);
            this.tbxTargetDir.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SetOverrideTrue);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Target Dir";
            // 
            // cbxDeep
            // 
            this.cbxDeep.AutoSize = true;
            this.cbxDeep.Location = new System.Drawing.Point(225, 71);
            this.cbxDeep.Name = "cbxDeep";
            this.cbxDeep.Size = new System.Drawing.Size(50, 17);
            this.cbxDeep.TabIndex = 8;
            this.cbxDeep.Text = "deep";
            this.cbxDeep.UseVisualStyleBackColor = true;
            // 
            // ReleaseComponentForm
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(277, 197);
            this.Controls.Add(this.cbxDeep);
            this.Controls.Add(this.tbxTargetDir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdBrowse);
            this.Controls.Add(this.tbxSourceDir);
            this.Controls.Add(this.lblHome);
            this.Controls.Add(this.tbxFilter);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ReleaseComponentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Release Component";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lblHome;
        private System.Windows.Forms.TextBox tbxSourceDir;
        private System.Windows.Forms.Button cmdBrowse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxFilter;
        private System.Windows.Forms.TextBox tbxTargetDir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbxDeep;
    }
}