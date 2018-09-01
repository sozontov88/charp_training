using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests
{
    class GroupContacts
    {
        private string footer = "";
        private string header = "";
        private string name;

        public GroupContacts(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Header
        {
            get { return header; }
            set { header = value; }
        }
        public string Footer
        {
            get { return footer; }
            set { footer = value; }
        }
    }
}
