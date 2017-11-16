using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Diagnostics;
using System.Threading;

namespace ReleaseSupport
{
    public partial class MainForm : Form
    {

        Dictionary<string, Customer> _customers = new Dictionary<string, Customer>();
        XmlDocument _xdoc = new XmlDocument();
        string _lastCust;
        Dictionary<Color, string> _colorTable = new Dictionary<Color, string>();


        string _xdocFilename;
        CustomerForm _custForm = new CustomerForm();
        ReleaseComponentForm _compForm = new ReleaseComponentForm();
        private bool _configDirty = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string d = "";
#if DEBUG
            d = "_debug";
#endif
            _xdocFilename = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ReleaseSupport\ReleaseConfig"+d+".xml";
            System.IO.FileInfo config = new System.IO.FileInfo(_xdocFilename);
            if (!config.Exists)
            {
                CreateBaseConfig(config);
            }
            LoadConfig();
            BuildGUI();
            tbxReleaseLabel.Text = "Release_" + DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void CreateBaseConfig(System.IO.FileInfo cfgInfo)
        {
            if (!cfgInfo.Directory.Exists)
                cfgInfo.Directory.Create();
            XmlDocument xdoc = new XmlDocument();
            XmlElement root = xdoc.CreateElement("ReleaseConfig");
            xdoc.AppendChild(root);
            XmlAttribute att = xdoc.CreateAttribute("lastcustomer");
            att.Value = String.Empty;
            root.Attributes.Append(att);
            xdoc.Save(cfgInfo.FullName);
        }

        private void BuildGUI()
        {
            listView1.Items.Clear();
            foreach (Customer customer in _customers.Values)
            {
                ListViewItem cLvi = listView1.Items.Add(customer.Name);
                cLvi.SubItems.Add(customer.Home);
                cLvi.Tag = customer;
                cLvi.Selected = (_lastCust == customer.Name);
            }
        }

        private void LoadConfig()
        {
            _xdoc.Load(_xdocFilename);
            XmlNode config = _xdoc.SelectSingleNode("/ReleaseConfig");
            _lastCust = config.Attributes["lastcustomer"].Value;
            XmlNodeList custs = _xdoc.SelectNodes("/ReleaseConfig/Customer");
            foreach (XmlNode cust in custs)
            {
                Customer customer = new Customer(cust);
                _customers.Add(customer.Name, customer);
            }
        }

        private void SaveConfig()
        {
            XmlNode config = _xdoc.SelectSingleNode("/ReleaseConfig");
            config.Attributes["lastcustomer"].Value = _lastCust;
            _xdoc.Save(_xdocFilename);
            _configDirty = false;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool wasDirty = _configDirty;
            bool itemSelected = (listView1.SelectedItems.Count == 1);
            if (itemSelected)
            {
                listView2.Items.Clear();
                cmdCompEdit.Enabled = cmdCompDelete.Enabled = cmdMakeRelease.Enabled = cbCheckall.Enabled = false;
                Customer customer = listView1.SelectedItems[0].Tag as Customer;
                _lastCust = customer.Name;
                foreach (ReleaseComponent rcomp in customer.ReleaseComponents)
                {
                    ListViewItem rLvi = listView2.Items.Add(rcomp.Name);
                    rLvi.Tag = rcomp;
                    rLvi.Checked = rcomp.Included;
                    rLvi.SubItems.Add(rcomp.RootDir);
                    rLvi.SubItems.Add(rcomp.Filter);
                    rLvi.SubItems.Add(rcomp.Target);
                }
                tbxReleaseLabel.Text = customer.ReleaseFormat;
                cbClean.Checked = customer.CleanFirst;
            }
            else
            {
                listView2.Items.Clear();
            }
            cmdCustEdit.Enabled = cmdCustDelete.Enabled = cmdMakeRelease.Enabled = linkNotes.Enabled = cbCheckall.Enabled = itemSelected;
            cmdCompAdd.Enabled = itemSelected;
            _configDirty = wasDirty;
        }

        private void linkNotes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                Customer customer = listView1.SelectedItems[0].Tag as Customer;
                if ((new System.IO.FileInfo(customer.Notes)).Exists)
                {
                    ProcessStartInfo sInfo = new ProcessStartInfo(customer.Notes);
                    Process.Start(sInfo);
                }
                else
                {
                    MessageBox.Show(String.Format("File {0} does not exist.", customer.Notes), "File does not exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmdSaveConfig_Click(object sender, EventArgs e)
        {
            SaveConfig();
        }

        private void cmdCustAdd_Click(object sender, EventArgs e)
        {
            _custForm.Clear();
            _custForm.ReleaseFormat = Customer.DEFAULT_RELEASEFORMAT_VAL;
            if (_custForm.ShowDialog() == DialogResult.OK)
            {
                _configDirty = true;

                XmlElement config = (XmlElement)_xdoc.SelectSingleNode("/ReleaseConfig");
                XmlElement cust = _xdoc.CreateElement("Customer");
                XmlAttribute att = _xdoc.CreateAttribute("name");
                att.Value = _custForm.CustName;
                cust.Attributes.Append(att);
                att = _xdoc.CreateAttribute("home");
                att.Value = _custForm.Home;
                cust.Attributes.Append(att);
                att = _xdoc.CreateAttribute("notes");
                att.Value = _custForm.Notes;
                cust.Attributes.Append(att);
                config.AppendChild(cust);
                _customers.Add(_custForm.CustName, new Customer((XmlNode)cust));

                BuildGUI();
            }

        }

        private void cmdCompEdit_Click(object sender, EventArgs e)
        {
            ReleaseComponent component = listView2.SelectedItems[0].Tag as ReleaseComponent;
            _compForm.CustName = component.Name;
            _compForm.SourceDir = component.RootDir;
            _compForm.Filter = component.Filter;
            _compForm.Deep = component.Deep;
            _compForm.TargetDir = component.Target;
            if (_compForm.ShowDialog() == DialogResult.OK)
            {
                _configDirty = true;
                component.Name = _compForm.CustName;
                component.RootDir = _compForm.SourceDir;
                component.Filter = _compForm.Filter;
                component.Deep = _compForm.Deep;
                component.Target = _compForm.TargetDir;

                BuildGUI();
            }
        }

        private void HandleCustDialog()
        {
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool itemSelected = (listView2.SelectedItems.Count == 1);
            cmdCompDelete.Enabled = itemSelected;
            cmdCompEdit.Enabled = itemSelected;
        }

        private void cmdCompAdd_Click(object sender, EventArgs e)
        {
            _compForm.Clear();
            if (_compForm.ShowDialog() == DialogResult.OK)
            {
                _configDirty = true;

                Customer customer = listView1.SelectedItems[0].Tag as Customer;

                XmlElement comp = _xdoc.CreateElement("ReleaseComponent");
                XmlAttribute att = _xdoc.CreateAttribute("name");
                att.Value = _compForm.CustName;
                comp.Attributes.Append(att);
                att = _xdoc.CreateAttribute("rootdir");
                att.Value = _compForm.SourceDir;
                comp.Attributes.Append(att);
                att = _xdoc.CreateAttribute("filtercsv");
                att.Value = _compForm.Filter;
                comp.Attributes.Append(att);
                att = _xdoc.CreateAttribute("included");
                att.Value = (_compForm.Deep) ? "true" : "false";
                comp.Attributes.Append(att);
                att = _xdoc.CreateAttribute("target");
                att.Value = _compForm.TargetDir;
                comp.Attributes.Append(att);
                att = _xdoc.CreateAttribute("included");
                att.Value = "true";
                comp.Attributes.Append(att);
                customer.AddCompElement((XmlNode)comp);

                BuildGUI();
            }
        }

        private void cmdCustEdit_Click(object sender, EventArgs e)
        {
            Customer customer = listView1.SelectedItems[0].Tag as Customer;
            _custForm.CustName = customer.Name;
            _custForm.Home = customer.Home;
            _custForm.Notes = customer.Notes;
            _custForm.ReleaseFormat = customer.ReleaseFormat;
            string nameBefore = customer.Name;
            if (_custForm.ShowDialog() == DialogResult.OK && (nameBefore == _custForm.Name || !_customers.ContainsKey(_custForm.Name)))
            {
                _configDirty = true;
                customer.Name = _custForm.CustName;
                customer.Home = _custForm.Home;
                customer.Notes = _custForm.Notes;
                customer.ReleaseFormat = _custForm.ReleaseFormat;
                if (customer.Name != nameBefore)
                {
                    _customers.Remove(nameBefore);
                    _customers.Add(customer.Name, customer);
                    _lastCust = customer.Name;
                }
                BuildGUI();
            }
        }

        private void OnItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ListViewItem cLvi = e.Item;
            ReleaseComponent comp = cLvi.Tag as ReleaseComponent;
            if (cLvi.Tag != null)
            {
                _configDirty = true;
                comp.Included = cLvi.Checked;
            }
        }

        private void cmdCompDelete_Click(object sender, EventArgs e)
        {
            _configDirty = true;
            ReleaseComponent comp = listView2.SelectedItems[0].Tag as ReleaseComponent;
            Customer customer = listView1.SelectedItems[0].Tag as Customer;
            customer.DropComp(comp.Name);
            BuildGUI();
        }

        private void cmdCustDelete_Click(object sender, EventArgs e)
        {
            _configDirty = true;
            Customer customer = listView1.SelectedItems[0].Tag as Customer;
            XmlNodeList cnodes = _xdoc.SelectNodes("/ReleaseConfig/Customer");
            XmlNode ctgt = null;
            foreach (XmlNode cust in cnodes)
            {
                if (cust.Attributes["name"].Value == customer.Name)
                {
                    ctgt = cust;
                    break;
                }
            }
            if (ctgt != null)
            {
                _xdoc.SelectSingleNode("/ReleaseConfig").RemoveChild(ctgt);
                _customers.Remove(customer.Name);
                _lastCust = String.Empty;
                listView2.Items.Clear();
            }
            BuildGUI();
        }

        public void InitRichTextBox()
        {
            rtbLog.Clear();
            _colorTable.Clear();
            // string strRtf = @"{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}\r\n\viewkind4\uc1\pard\f0\fs17 \par\r\n}\r\n";
            //_colorTable.Add(Color.Black, @"\cf1 ");
            //AddColor(ref strRtf);
            // rtbLog.Rtf = strRtf;
        }

        public void AddColor(ref string strRTF)
        {
            // Search for colour table info. If it exists (it shouldn't,
            // but we'll check anyway) remove it and replace with our one
            int iCTableStart = strRTF.IndexOf("colortbl ;");

            string colorString = "colortbl;";
            foreach (Color color in _colorTable.Keys)
            {
                colorString += String.Format("\\red{0}\\green{1}\\blue{2};", color.R, color.G, color.B);
            }

            if (iCTableStart != -1) //then colortbl exists
            {
                //find end of colortbl tab by searching
                //forward from the colortbl tab itself
                int iCTableEnd = strRTF.IndexOf('}', iCTableStart);

                //remove the existing colour table
                strRTF = strRTF.Remove(iCTableStart, iCTableEnd - iCTableStart);

                //now insert new colour table at index of old colortbl tag
                strRTF = strRTF.Insert(iCTableStart, colorString);
            }

            //colour table doesn't exist yet, so let's make one
            else
            {
                // find index of start of header
                int iRTFLoc = strRTF.IndexOf("\\rtf");
                // get index of where we'll insert the colour table
                // try finding opening bracket of first property of header first                
                int iInsertLoc = strRTF.IndexOf('{', iRTFLoc);

                // if there is no property, we'll insert colour table
                // just before the end bracket of the header
                if (iInsertLoc == -1) iInsertLoc = strRTF.IndexOf('}', iRTFLoc) - 1;

                // insert the colour table at our chosen location                
                strRTF = strRTF.Insert(iInsertLoc,
                    // CHANGE THIS STRING TO ALTER COLOUR TABLE
                    "{\\"+colorString+"}");
            }
                        
        }

        public void AppendLogline()
        {
            AppendLogline("");
        }
        public void AppendLogline(string line)
        {
            AppendLogtext(line + Environment.NewLine);
            // tbxLog.AppendText(line + Environment.NewLine);
        }
        public void AppendLogtext(string text, Color fcolor)
        {
            // Color curFColor = rtbLog.ForeColor;
            // rtbLog.ForeColor = fcolor;
            AppendLogtext(text);
            // rtbLog.ForeColor = curFColor;
        }



        public delegate void AppendLogtextDelegate(string text);

        public void AppendLogtext(string text)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new AppendLogtextDelegate(AppendLogtext), text);
                return;
            }

            text = text.Replace(@"\", @"\\");
            string strRtf = rtbLog.Rtf;

            Color fcolor = Color.Black;
            if (!_colorTable.ContainsKey(fcolor))
            {
                _colorTable.Add(fcolor, String.Format("\\cf{0} ", _colorTable.Count + 1));
                AddColor(ref strRtf);
            }

            int inspos = strRtf.LastIndexOf(@"\par");
            strRtf = strRtf.Insert(inspos, " " + text);
            strRtf = strRtf.Insert(inspos, _colorTable[fcolor]);

            rtbLog.Rtf = strRtf;
            // tbxLog.AppendText(line + Environment.NewLine);
        }
        public delegate void AppendLogColortextDelegate(string text, Color fcolor);

        public void AppendLogline(string line, Color fcolor)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new AppendLogColortextDelegate(AppendLogline), line, fcolor);
                return;
            }
            line = line.Replace(@"\", @"\\");
            string strRtf = rtbLog.Rtf;
            if (!_colorTable.ContainsKey(fcolor))
            {
                _colorTable.Add(fcolor, String.Format("\\cf{0} ", _colorTable.Count+1));
                AddColor(ref strRtf);
            }
            int inspos = strRtf.LastIndexOf(@"\par");
            strRtf = strRtf.Insert(inspos, "\\line ");
            // strRtf = strRtf.Insert(inspos, "\\cf0 ");
            strRtf = strRtf.Insert(inspos, line);
            strRtf = strRtf.Insert(inspos, _colorTable[fcolor]);
            rtbLog.Rtf = strRtf;
        }

        private void cmdMakeRelease_Click(object sender, EventArgs e)
        {
            InitRichTextBox();
            // return;
            Customer customer = listView1.SelectedItems[0].Tag as Customer;

            ParameterizedThreadStart start = new ParameterizedThreadStart(ReleaseEngine.MakeRelease);
            Thread thread = new Thread(start);
            thread.Start(new object[] { 
                this, 
                String.Format(tbxReleaseLabel.Text, DateTime.Now), 
                customer,
                cbClean.Checked 
            });
        }

        private void OnLogKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyData == Keys.A)
            {
            }
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (_configDirty)
            {
                DialogResult dr = MessageBox.Show("Save changes?", "Save changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (dr)
                {
                    case DialogResult.Yes:
                        SaveConfig();
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                    default:
                        break;
                }
            }
        }

        private void cbCheckall_CheckedChanged(object sender, EventArgs e)
        {
            bool chkState = (sender as CheckBox).Checked;
            foreach (ListViewItem lvi in listView2.Items)
            {
                lvi.Checked = chkState;
            }
        }

        private void cbClean_CheckedChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                Customer customer = listView1.SelectedItems[0].Tag as Customer;
                customer.CleanFirst = cbClean.Checked;
            }
        }
    }
}