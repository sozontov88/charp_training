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
            driver.FindElement(By.LinkText("GROUPS")).Click();
        }
        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL + "addressbook/group.php");
        }

    }
}
