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
    public class ModificationContacts: AuthTestBase
    {
      
            

        [Test]
        public void EditContact()
        {
            UserData contact = new UserData("Sanya","ggf");
            List<UserData> oldName = app.Contacts.GetAllName();
            //app.Contacts.SelectContact("1");
            app.Contacts.Edit(contact,1);
            oldName[0].Firstname = contact.Firstname;
            oldName[0].Lastname = contact.Lastname;

            List<UserData> newName = app.Contacts.GetAllName();
            oldName.Sort();
            newName.Sort();
            Assert.AreEqual(oldName, newName);
          
        }
      

     

      
    }
}
