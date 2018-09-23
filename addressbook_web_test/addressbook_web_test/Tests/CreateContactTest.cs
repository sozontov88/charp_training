using System;
using System.Collections.Generic;
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
            UserData newContact = new UserData("first","second");
            newContact.Lastname = "123";
            List<UserData> oldName = app.Contacts.GetAllName();
            app.Contacts.Create(newContact);
           
            List<UserData> newName = app.Contacts.GetAllName();
            oldName.Add(newContact);
            oldName.Sort();
            newName.Sort();
            Assert.AreEqual(oldName, newName);
        }

       

      
     }
}
