using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Diagnostics;

namespace ReleaseSupport
{
    public partial class Form1 : Form
    {

        Dictionary<string, Customer> _customers = new Dictionary<string, Customer>();
        XmlDocument _xdoc = new XmlDocument();
        string _lastCust;
        string _xdocFilename = @"C:\Documents and Settings\GBouwman\ProgEnv\VS2005\ReleaseSupport\ReleaseSupport\ReleaseConfig.xml";
        CustomerForm _custForm = new CustomerForm();
        ReleaseComponentForm _compForm = new ReleaseComponentForm();

        public Form1()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadConfig();
            BuildGUI();
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
            tbxReleaseLabel.Text = "Release_" + DateTime.Now.ToString("yyyy-MM-dd");
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
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool itemSelected = (listView1.SelectedItems.Count == 1);
            if (itemSelected)
            {
                listView2.Items.Clear();
                cmdCompEdit.Enabled = cmdCompDelete.Enabled = false;
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
            }
            else
            {
                listView2.Items.Clear();
            }
            cmdCustEdit.Enabled = cmdCustDelete.Enabled = linkNotes.Enabled = itemSelected;
            cmdCompAdd.Enabled = itemSelected;
        }

        private void linkNotes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                Customer customer = listView1.SelectedItems[0].Tag as Customer;
                ProcessStartInfo sInfo = new ProcessStartInfo(customer.Notes);
                Process.Start(sInfo);
            }
        }

        private void cmdSaveConfig_Click(object sender, EventArgs e)
        {
            SaveConfig();
        }

        private void cmdCustAdd_Click(object sender, EventArgs e)
        {
            _custForm.Clear();
            if (_custForm.ShowDialog() == DialogResult.OK)
            {
                XmlElement config = (XmlElement)_xdoc.SelectSingleNode("/ReleaseConfig");
                XmlElement cust = _xdoc.CreateElement("Customer");
                XmlAttribute att = _xdoc.CreateAttribute("name");
                att.Value = _custForm.CustName;
                cust.Attributes.Append(att);
                att = _xdoc.CreateAttribute("home");
                att.Value = _custForm.Home;
                cust.Attributes.Append(att);
                att = _xdoc.CreateAttribute("notes");
                att.Value = @"C:\Documents and Settings\GBouwman\My Documents\Projecten\Tensing Mobile GIS\Releases\Release Notes.doc";
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
            _compForm.TargetDir = component.Target;
            if (_compForm.ShowDialog() == DialogResult.OK)
            {
                component.Name = _compForm.CustName;
                component.RootDir = _compForm.SourceDir;
                component.Filter = _compForm.Filter;
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
            string nameBefore = customer.Name;
            if (_custForm.ShowDialog() == DialogResult.OK && (nameBefore == _custForm.Name || !_customers.ContainsKey(_custForm.Name)))
            {
                customer.Name = _custForm.CustName;
                customer.Home = _custForm.Home;
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
                comp.Included = cLvi.Checked;
        }

        private void cmdCompDelete_Click(object sender, EventArgs e)
        {
            ReleaseComponent comp = listView2.SelectedItems[0].Tag as ReleaseComponent;
            Customer customer = listView1.SelectedItems[0].Tag as Customer;
            customer.DropComp(comp.Name);
            BuildGUI();
        }

        private void cmdCustDelete_Click(object sender, EventArgs e)
        {
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

        public void AppendLogline()
        {
            AppendLogline("");
        }
        public void AppendLogline(string line)
        {
            tbxLog.AppendText(line + Environment.NewLine);
        }

        private void cmdMakeRelease_Click(object sender, EventArgs e)
        {
            tbxLog.Clear();
            Customer customer = listView1.SelectedItems[0].Tag as Customer;
            ReleaseEngine.MakeRelease(this, tbxReleaseLabel.Text, customer);
        }

        private void OnLogKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyData == Keys.A)
            {
                tbxLog.SelectAll();
            }
        }
    }
}