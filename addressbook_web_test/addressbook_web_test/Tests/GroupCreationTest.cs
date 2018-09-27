using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTest
{
    [TestFixture]
    public class GroupCreationTest : AuthTestBase
    {
       
        [Test]
        public void GroupCreationTests()
        {
                     
            GroupData group = new GroupData("first");
            group.Footer = "aaa";
            group.Header = "zzz";
            List<GroupData>oldGroups= app.Groups.GetAllGroups();
            app.Groups.Create(group);
           

            Assert.AreEqual(oldGroups.Count+1, app.Groups.GetGroupCount());
            List<GroupData> newGroups = app.Groups.GetAllGroups();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups ,newGroups);

        }
        [Test]
        public void EmptyGroupCreationTests()
        {
            GroupData group = new GroupData("");
            group.Footer = "";
            group.Header = "";
            List<GroupData> oldGroups = app.Groups.GetAllGroups();
            app.Groups.Create(group);
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());
            List<GroupData> newGroups = app.Groups.GetAllGroups();

            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}
