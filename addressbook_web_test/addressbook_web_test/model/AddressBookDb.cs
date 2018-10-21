using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTest
{
    public class AddressBookDb : LinqToDB.Data.DataConnection
    {
        public AddressBookDb() : base("AddressBook") { }

        public ITable<GroupData>Groups { get { return GetTable<GroupData>(); } }
        public ITable<UserData> User { get { return GetTable<UserData>(); } }

        public ITable<GroupContactReletion> GCR { get { return GetTable<GroupContactReletion>(); } }
    }
}
