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
        public static IEnumerable<GroupData> RandomGroupProvider()
        {
            List<GroupData> group = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                group.Add(new GroupData(GenereteRandomString(30))
                {
                    Header = GenereteRandomString(100),
                    Footer = GenereteRandomString(100)
                });
            }
            return group;
        }

      

        [Test, TestCaseSource("RandomGroupProvider")]
        public void GroupCreationTests(GroupData group)
        {
                     
            
            List<GroupData>oldGroups= app.Groups.GetAllGroups();
            app.Groups.Create(group);
           

            Assert.AreEqual(oldGroups.Count+1, app.Groups.GetGroupCount());
            List<GroupData> newGroups = app.Groups.GetAllGroups();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups ,newGroups);

        }
     
    }
}
