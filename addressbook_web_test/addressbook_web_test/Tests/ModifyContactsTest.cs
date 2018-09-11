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
    public class ModificationContacts: AuthTestBase
    {
      
            

        [Test]
        public void EditContact()
        {
            //app.Contacts.SelectContact("1");
            app.Contacts.Edit(1);
          
           
           
        }
      

     

      
    }
}
