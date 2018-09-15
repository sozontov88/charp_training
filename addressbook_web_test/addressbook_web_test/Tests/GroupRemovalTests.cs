using System;
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
            app.Groups.Remove(1);
            Assert.IsFalse(app.Groups.IsGroupExist(new GroupData("first")));
        }

     }
}
