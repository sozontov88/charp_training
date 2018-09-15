using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTest
{
  public  class NavigationHelper : HelperBase
    {
        private string baseURL;
     

        public NavigationHelper(ApplicationManager manager,string baseURL):base(manager)
        {
            this.baseURL = baseURL;
           
        }
        public void GoToGropsPage()
        {
            if (driver.Url == baseURL + "/addressbook/group.php"
                && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("GROUPS")).Click();
        }
        public void OpenHomePage()
        {
            if(driver.Url == baseURL + "/addressbook/"
                &&IsElementPresent(By.ClassName("left")))
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "/addressbook/");
        }
        public void GoToContactsPage()
        {
            driver.FindElement(By.LinkText("ADD_NEW")).Click();
        }
        public void GoToHome()
        {
            driver.FindElement(By.LinkText("HOME")).Click();
        }

    }
}
