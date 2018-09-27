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
    public class ModificationContacts : AuthTestBase
    {

        [Test]
        public void EditContact()
        {
            UserData contact = new UserData("Sanya", "ggf");
            List<UserData> oldName = app.Contacts.GetAllName();
            UserData namebefore = oldName[0];
            //app.Contacts.SelectContact("1");
            app.Contacts.Edit(contact,0);

            Assert.AreEqual(oldName.Count, app.Contacts.GetNameCount());

            List<UserData> newName = app.Contacts.GetAllName();
            oldName[0].Firstname = contact.Firstname;
            oldName[0].Lastname = contact.Lastname;
            oldName.Sort();
            newName.Sort();
            Assert.AreEqual(oldName, newName);

            foreach (UserData user in newName)
            {
                if (user.Id == oldName[0].Id)
                {
                    Assert.AreEqual(user.Firstname, contact.Firstname); 
                    Assert.AreEqual(user.Lastname, contact.Lastname);                         
                }
            }
        }
    }
}

    

