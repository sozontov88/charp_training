using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTest
{
    [TestFixture]
    public class CreateGroupTest : TestBase
    {
       

        [Test]
        public void TheUntitledTest()
        {
            OpenHomePage();
            Login(new AccountData("admin","secret"));
            GoToGropsPage();
            InitGroupCreation();
            GroupData group = new GroupData("first");
            group.Footer = "aaa";
            group.Header = "zzz";
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupPage();
        }
        
    }
}
