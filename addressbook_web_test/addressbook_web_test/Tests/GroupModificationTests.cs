using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTest
{
    [TestFixture]
    public class GroupModificationTests: AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("second");
            newData.Footer = "qqqqq";
            newData.Header = "asd";

            List<GroupData> oldGroups = app.Groups.GetAllGroups();
            app.Groups.Modify(0, newData);

            List<GroupData> newGroups = app.Groups.GetAllGroups();

            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
           

        }

    }
}
