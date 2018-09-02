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
  public  class NavigationHelper
    {
        private string baseURL;
        private IWebDriver driver;

        public NavigationHelper(IWebDriver driver,string baseURL)
        {
            this.baseURL = baseURL;
            this.driver = driver;
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
