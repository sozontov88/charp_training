using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTest
{
   public class AddingContactToGroupTests:AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<UserData> oldList = group.GetContacts();
            UserData user = UserData.GetAll().Except(oldList).First();
            app.Contacts.AddContactToGroup(user, group);

            List<UserData>newList = group.GetContacts();
            oldList.Add(user);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(newList, oldList);

        }
    }
}
