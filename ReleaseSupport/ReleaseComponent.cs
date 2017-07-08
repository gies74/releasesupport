using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace ReleaseSupport
{
    public class ReleaseComponent
    {
        XmlNode _node;

        public ReleaseComponent(XmlNode node)
        {
            _node = node;
        }

        public string Name { 
            get { return GetAtt("name"); }
            set { SetAtt("name", value);  }
        }
        public string RootDir
        {
            get { return GetAtt("rootdir"); }
            set { SetAtt("rootdir", value); }
        }
        public string Target
        {
            get { return GetAtt("target"); }
            set { SetAtt("target", value); }
        }
        public string Filter
        {
            get { return GetAtt("filtercsv"); }
            set { SetAtt("filtercsv", value); }
        }
        public bool Deep
        {
            get { return GetAtt("deep") == "true"; }
            set { SetAtt("deep", (value) ? "true" : "false"); }
        }
        public bool Included
        {
            get { return GetAtt("included") == "true"; }
            set { SetAtt("included", (value) ? "true" : "false"); }
        }

        private void SetAtt(string attName, string value)
        {
            if (_node.Attributes[attName] == null)
                 _node.Attributes.Append(_node.OwnerDocument.CreateAttribute(attName));
            _node.Attributes[attName].Value = value;
        }
        private string GetAtt(string attName)
        {
            if (_node.Attributes[attName] != null)
                return _node.Attributes[attName].Value;
            return String.Empty;
        }
    }
}
