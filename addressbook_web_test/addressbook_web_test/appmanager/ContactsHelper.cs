﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTest
{
   public class ContactsHelper: HelperBase
    {
        public ContactsHelper(ApplicationManager manager):base (manager)
        {

        }
         public void Create(GroupContacts contact)
        {
            manager.Navigator.GoToContactsPage();
            AddNewContact(contact);
            SubmitContacts();
            manager.Navigator.GoToHome();
        }
            public void Remove(string i)
        {
            manager.Navigator.GoToHome();
            SelectContact(i);
            RemoveContacts();
            driver.SwitchTo().Alert().Accept();
        }
        public void Edit(GroupContacts contacts,int index)
        {
            manager.Navigator.GoToHome();
            EditContact(index);
            AddNewContact(contacts);
            SubmitContactsModification();
            manager.Navigator.GoToHome();
        }
        public ContactsHelper AddNewContact(GroupContacts contacts)
        {
           
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contacts.Firstname);
            //driver.FindElement(By.Name("middlename")).Clear();
            //driver.FindElement(By.Name("middlename")).SendKeys(contacts.Middlename);
            //driver.FindElement(By.Name("lastname")).Clear();
            //driver.FindElement(By.Name("lastname")).SendKeys(contacts.Lastname);
            //driver.FindElement(By.Name("nickname")).Clear();
            driver.FindElement(By.Name("nickname")).SendKeys(contacts.Nickname);
            driver.FindElement(By.Name("title")).Clear();
            driver.FindElement(By.Name("title")).SendKeys(contacts.Title);
            driver.FindElement(By.Name("company")).Clear();
            driver.FindElement(By.Name("company")).SendKeys(contacts.Company);
            driver.FindElement(By.Name("address")).Clear();
            driver.FindElement(By.Name("address")).SendKeys(contacts.Address);
            driver.FindElement(By.Name("home")).Clear();
            driver.FindElement(By.Name("home")).SendKeys(contacts.Home);
            driver.FindElement(By.Name("mobile")).Clear();
            driver.FindElement(By.Name("mobile")).SendKeys(contacts.Mobile);
            driver.FindElement(By.Name("work")).Clear();
            driver.FindElement(By.Name("work")).SendKeys(contacts.Work);
            driver.FindElement(By.Name("fax")).Clear();
            driver.FindElement(By.Name("fax")).SendKeys(contacts.Fax);
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys(contacts.Email);
            driver.FindElement(By.Name("email2")).Clear();
            driver.FindElement(By.Name("email2")).SendKeys(contacts.Email2);
            driver.FindElement(By.Name("email3")).Clear();
            driver.FindElement(By.Name("email3")).SendKeys(contacts.Email3);
            driver.FindElement(By.Name("homepage")).Clear();
            driver.FindElement(By.Name("homepage")).SendKeys(contacts.Homepage);
            driver.FindElement(By.Name("byear")).Clear();
            driver.FindElement(By.Name("byear")).SendKeys(contacts.Byear);
            driver.FindElement(By.Name("address2")).Clear();
            driver.FindElement(By.Name("address2")).SendKeys(contacts.Address2);
            driver.FindElement(By.Name("phone2")).Clear();
            driver.FindElement(By.Name("phone2")).SendKeys(contacts.Phone2);
            driver.FindElement(By.Name("notes")).Clear();
            driver.FindElement(By.Name("notes")).SendKeys(contacts.Notes);
            // ERROR: Caught exception [Error: Dom locators are not implemented yet!]
            return this;
        }
       
    
        public ContactsHelper SelectContact(string index)
        {
            driver.FindElement(By.XPath("//tr[2]/td/input")).Click();
            return this;
        }
        public ContactsHelper EditContact(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='EDIT'])["+ index + "]")).Click();

            return this;

        }
        public ContactsHelper SubmitContactsModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }
        public void RemoveContacts()
        {
            driver.FindElement(By.XPath("//*[@id='content']/form[2]/div[2]/input")).Click();
        }
        public ContactsHelper SubmitContacts()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }
        public bool IsContactPresent(GroupContacts contacts)
        {
                 
            if(IsElementPresent(By.XPath("//*[@id='maintable']/tbody/tr[2]")))
            {
              return driver.FindElement(By.XPath("//tr[@name='entry']/td[3]")).Text == contacts.Firstname;
            }
             return false;
        }
       
    }
}

