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
            app.Groups.Modify(1, newData);
            Assert.IsTrue(app.Groups.IsGroupExist(newData));
        }

    }
}
