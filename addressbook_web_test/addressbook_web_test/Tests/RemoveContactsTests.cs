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
            List<UserData> oldName = UserData.GetAll();
            UserData tobeRemoved = oldName[0];

            app.Contacts.Remove(tobeRemoved);
           
            Assert.AreEqual(oldName.Count - 1, app.Contacts.GetNameCount());
            List<UserData> newName = UserData.GetAll();
            
            oldName.RemoveAt(0);
            Assert.AreEqual(oldName, newName);
            foreach(UserData user in newName)
            {
                Assert.AreNotEqual(user.Id, tobeRemoved.Id);
            }
            
        }
    }
}
