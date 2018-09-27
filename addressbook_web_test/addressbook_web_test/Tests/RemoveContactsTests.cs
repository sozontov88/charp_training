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
           
            Assert.AreEqual(oldName.Count - 1, app.Contacts.GetNameCount());
            List<UserData> newName = app.Contacts.GetAllName();
             UserData toBeRemoved = oldName[0];
            oldName.RemoveAt(0);
            Assert.AreEqual(oldName, newName);
            foreach(UserData user in newName)
            {
                Assert.AreNotEqual(user.Id, toBeRemoved.Id);
            }
            
        }
    }
}
