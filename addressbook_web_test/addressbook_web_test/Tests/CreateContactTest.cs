using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTest
{
    [TestFixture]
    public class CreateContactTest : AuthTestBase
    {
       

        [Test]
        public void CreateContactTests()
        {
            GroupContacts newContact = new GroupContacts("second");
            newContact.Lastname = "qqqqq";
            newContact.Middlename = "asd";
            app.Contacts.Create(newContact);
            Assert.IsTrue(app.Contacts.IsContactPresent(newContact));
        }

       

      
     }
}
