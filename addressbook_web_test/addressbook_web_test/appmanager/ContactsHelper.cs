﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
         public void Create(UserData contact)
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

        public int GetNameCount()
        {
            return driver.FindElements(By.XPath("//tr[@name='entry']")).Count;
        }
        private List<UserData>contactCache = null;
        public List<UserData> GetAllName()
        {
            if(contactCache ==null)
            {
                contactCache = new List<UserData>();
                manager.Navigator.GoToHome();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name='entry']"));
              foreach (IWebElement element1 in elements)
            {
                
                IList<IWebElement> cells = element1.FindElements(By.TagName("td"));
                string firstName = cells[2].Text;
                string secondName = cells[1].Text;
                              
                contactCache.Add(new UserData(firstName, secondName) {Id = element1.FindElement(By.Name("selected[]")).GetAttribute("Id")});
            }
            }
                   
            return new List<UserData>(contactCache);
        }
        public UserData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHome();
           IList<IWebElement>cells =driver.FindElements(By.Name("entry"))[index].
                FindElements(By.TagName("td"));
            string lastname = cells[1].Text;
            string firstname = cells[2].Text;
            string address = cells[3].Text;
            string allphones = cells[5].Text;
            string allemails = cells[4].Text;
            return new UserData(firstname, lastname)
            {
                Address = address,
                Allphone = allphones,
                Allemails = allemails
                

            };

        }
        public UserData GetContactInformation(int index)
        {
            manager.Navigator.GoToHome();
            InitContactModification(0);
            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new UserData(firstname, lastname)
            {
                Address = address,
                Home = homePhone,
                Mobile = mobilePhone,
                Work = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };
        }

        public void Edit(UserData contacts,int index)
        {
            manager.Navigator.GoToHome();
            InitContactModification(0);
            AddNewContact(contacts);
            SubmitContactsModification();
            manager.Navigator.GoToHome();
        }
     
       public ContactsHelper AddNewContact(UserData user)
        {
            Type(By.Name("firstname"), user.Firstname);
            Type(By.Name("middlename"),user.Middlename);
            Type(By.Name("lastname"), user.Lastname);
            Type(By.Name("nickname"), user.Nickname);
            Type(By.Name("title"), user.Title);
            Type(By.Name("company"), user.Company);
            Type(By.Name("address"), user.Address);
            Type(By.Name("home"), user.Home);
            Type(By.Name("mobile"), user.Mobile);
            Type(By.Name("work"), user.Work);
            Type(By.Name("fax"), user.Fax);
            Type(By.Name("email"), user.Email);
            Type(By.Name("email2"), user.Email2);
            Type(By.Name("email3"), user.Email3);
            Type(By.Name("homepage"), user.Homepage);
            Type(By.Name("byear"), user.Byear);
            Type(By.Name("address2"), user.Address2);
            Type(By.Name("notes"), user.Notes);
            Type(By.Name("phone2"), user.Phone2);
            return this;
        }

        public ContactsHelper SelectContact(string index)
        {
            if (IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")))
            {
                driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            }

            return this;
        }
        public void InitContactModification(int index)
        {
             contactCache = null;
             driver.FindElements(By.Name("entry"))[index].
             FindElements(By.TagName("td"))[7].
             FindElement(By.TagName("a")).Click(); 
            
        }
        public ContactsHelper SubmitContactsModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }
        public void RemoveContacts()
        {
            driver.FindElement(By.XPath("//*[@id='content']/form[2]/div[2]/input")).Click();
            contactCache = null;
        }
        public ContactsHelper SubmitContacts()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
            return this;
        }
        public bool IsContactPresent(UserData contacts)
        {
                 
            if(IsElementPresent(By.XPath("//*[@id='maintable']/tbody/tr[2]")))
            {
              return driver.FindElement(By.XPath("//tr[@name='entry']/td[3]")).Text == contacts.Firstname;
            }
             return false;
        }
        public int GetOfNumberOfSearchresult()
        {
            manager.Navigator.GoToHome();

           string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
         return  Int32.Parse( m.Value);
        }
       
    }
}

