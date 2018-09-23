using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTest
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
      
        [Test]
        public void GroupRemovalTest()
        {
            List<GroupData> oldGroups = app.Groups.GetAllGroups();
            app.Groups.Remove(0);
            List<GroupData> newGroups = app.Groups.GetAllGroups();
            oldGroups.RemoveAt(0);
           
            Assert.AreEqual(oldGroups, newGroups);
        }

     }
}
