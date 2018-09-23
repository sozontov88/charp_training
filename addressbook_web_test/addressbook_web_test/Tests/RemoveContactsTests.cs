using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTest
{
    [TestFixture]
    public class RemoveContactsTests: AuthTestBase
    {
        [Test]
        public void RemoveContact()
        {
            List<UserData> oldName = app.Contacts.GetAllName();
            app.Contacts.Remove("0");
          
            List<UserData> newName = app.Contacts.GetAllName();
            oldName.RemoveAt(0);
            Assert.AreEqual(oldName, newName);
            
        }
    }
}
