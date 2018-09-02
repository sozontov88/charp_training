using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTest
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
      

        [Test]
        public void GroupRemovalTest()
        {
            OpenHomePage();
            Login(new AccountData("admin","secret"));
            GoToGroupPage();
            SelectGroup(1);
            RemoveGroup();
            RetutnToGroupPage();
           
        }

      

      
    
        

      

           
     }
}
