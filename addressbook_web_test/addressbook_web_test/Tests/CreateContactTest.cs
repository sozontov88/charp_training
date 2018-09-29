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
            UserData newContact = new UserData("first", "second");
            newContact.Lastname = "123";
            newContact.Email = "asdfg@asd";
            newContact.Email2 = "asdfzzg@asd";
            newContact.Email3 = "asdfzxcg@asd";
            newContact.Phone2 = "asdfg@asd";
            newContact.Home = "12123(23)";
            newContact.Work = "23234(123)";
            List<UserData> oldName = app.Contacts.GetAllName();
            app.Contacts.Create(newContact);

            Assert.AreEqual(oldName.Count + 1, app.Contacts.GetNameCount());

            List<UserData> newName = app.Contacts.GetAllName();
            oldName.Add(newContact);
            oldName.Sort();
            newName.Sort();
            Assert.AreEqual(oldName, newName);
        }

        [Test]
        public void TestContactInformation()
        {
            UserData fromTable = app.Contacts.GetContactInformationFromTable(0);
            UserData fromForm = app.Contacts.GetContactInformation(0);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.Allphone, fromForm.Allphone);
            Assert.AreEqual(fromTable.Allemails, fromForm.Allemails);
        }
        [Test]
        public void TestContactCount()
        {
          Console.Out.WriteLine(app.Contacts.GetOfNumberOfSearchresult());
        }
    }
}
