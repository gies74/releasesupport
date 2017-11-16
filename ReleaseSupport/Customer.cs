using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace ReleaseSupport
{
    public class Customer
    {
        XmlNode _node;
        public const string DEFAULT_RELEASEFORMAT_VAL = "Release_{0:yyyy-MM-dd_HH-mm}-00";
        List<ReleaseComponent> _releaseComponents = new List<ReleaseComponent>();

        public List<ReleaseComponent> ReleaseComponents
        {
            get { return _releaseComponents; }
        }

        public void AddCompElement(XmlNode element)
        {
            _node.AppendChild(element);
            LoadConfig();
        }

        public void DropComp(string name)
        {
            XmlNodeList releasecomps = _node.SelectNodes("ReleaseComponent");
            XmlNode rcomp = null;
            foreach (XmlNode node in releasecomps)
            {
                if (node.Attributes["name"].Value == name)
                {
                    rcomp = node;
                    break;
                }
            }
            if (rcomp != null)
            {
                _node.RemoveChild(rcomp);
                LoadConfig();
            }

        }

        public Customer(XmlNode node)
        {
            _node = node;
            LoadConfig();
        }

        public string Name
        {
            get { return GetAtt("name"); }
            set { SetAtt("name",value); }
        }
        public string Home
        {
            get { return GetAtt("home"); }
            set { SetAtt("home", value); }
        }
        public string Notes
        {
            get { return GetAtt("notes"); }
            set { SetAtt("notes", value); }
        }
        public string ReleaseFormat
        {
            get { return GetAtt("releaseFormat"); }
            set { SetAtt("releaseFormat", value); }
        }
        public bool CleanFirst
        {
            get {
                var x = GetAtt("cleanFirst");
                return Boolean.Parse(String.IsNullOrEmpty(x) ? "true" : x);
            }
            set { SetAtt("cleanFirst", value.ToString()); }
        }

        private void SetAtt(string attName, string value)
        {
            if (_node.Attributes[attName] == null)
            {
                XmlAttribute att;
                _node.Attributes.Append(att = _node.OwnerDocument.CreateAttribute(attName));
            }
            _node.Attributes[attName].Value = value;
        }

        private string GetAtt(string attName)
        {
            XmlAttribute att = _node.Attributes[attName];
            if (att == null && attName == "releaseFormat")
                return DEFAULT_RELEASEFORMAT_VAL;
            else if (att == null)
                return "";
            return att.Value;
        }


        public void LoadConfig()
        {
            this.ReleaseComponents.Clear();
            XmlNodeList releasecomps = _node.SelectNodes("ReleaseComponent");
            foreach (XmlNode releasecomp in releasecomps)
            {
                ReleaseComponent releasecomponent = new ReleaseComponent(releasecomp);
                string x = releasecomponent.Name;
                this.ReleaseComponents.Add(releasecomponent);
            }
        }
    }
}
