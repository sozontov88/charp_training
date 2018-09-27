using System;
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
               

        public void Edit(UserData contacts,int index = 0)
        {
            manager.Navigator.GoToHome();
            EditContact(index);
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
        public ContactsHelper EditContact(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='EDIT'])["+ (index + 1) + "]")).Click();
            contactCache = null;
            return this;

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
       
    }
}

