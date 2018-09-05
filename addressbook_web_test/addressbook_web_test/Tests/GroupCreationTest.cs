using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTest
{
    [TestFixture]
    public class GroupCreationTest : TestBase
    {
       
        [Test]
        public void GroupCreationTests()
        {
                     
            GroupData group = new GroupData("first");
            group.Footer = "aaa";
            group.Header = "zzz";
            app.Groups.Create(group);
        }
        [Test]
        public void EmptyGroupCreationTests()
        {
            GroupData group = new GroupData("");
            group.Footer = "";
            group.Header = "";
            app.Groups.Create(group);
               

        }
    }
}
