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
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin","secret"));
            app.Navigator.GoToGropsPage();
            GroupData group = new GroupData("first");
            group.Footer = "aaa";
            group.Header = "zzz";
            app.Groups
                .InitGroupCreation()
                .FillGroupForm(group)
                .RetutnToGroupPage();
                
        }
        
    }
}
