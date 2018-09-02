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
            navigator.OpenHomePage();
            loginHelper.Login(new AccountData("admin","secret"));
            navigator.GoToGropsPage();
            groupHelper.InitGroupCreation();
            GroupData group = new GroupData("first");
            group.Footer = "aaa";
            group.Header = "zzz";
            groupHelper.FillGroupForm(group);
            groupHelper.RetutnToGroupPage();
            LogOut();
        }
        
    }
}
