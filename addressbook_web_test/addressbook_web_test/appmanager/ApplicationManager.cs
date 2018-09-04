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
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;
        protected NavigationHelper navigator;
        protected LoginHelper loginHelper;
        protected GroupHelper groupHelper;
        protected ContactsHelper contacts;

        public ApplicationManager()
        {
            contacts = new ContactsHelper(driver);
            navigator = new NavigationHelper(driver, baseURL);
            loginHelper = new LoginHelper(driver);
            groupHelper = new GroupHelper(driver);
        }
        public LoginHelper Auth { get { return loginHelper; } }
        public GroupHelper Groups { get { return groupHelper; } }
        public NavigationHelper Navigator { get { return navigator; } }
        public ContactsHelper Contacts { get { return contacts; } }

        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
           
        }
    }
}