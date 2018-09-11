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
    public class ApplicationManager
    {
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        protected IWebDriver driver;
        protected string baseURL;
        protected NavigationHelper navigator;
        protected LoginHelper loginHelper;
        protected GroupHelper groupHelper;
        protected ContactsHelper contacts;

        private ApplicationManager()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            options.UseLegacyImplementation = true;
            driver = new FirefoxDriver(options);
            baseURL = "http://localhost";
            contacts = new ContactsHelper(this);
            navigator = new NavigationHelper(this, baseURL);
            loginHelper = new LoginHelper(this);
            groupHelper = new GroupHelper(this);
        }
          ~ ApplicationManager()
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
        public LoginHelper Auth { get { return loginHelper; } }
        public GroupHelper Groups { get { return groupHelper; } }
        public NavigationHelper Navigator { get { return navigator; } }
        public ContactsHelper Contacts { get { return contacts; } }
      
        public IWebDriver Driver
        {
            get { return driver; }
        }
        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigator.OpenHomePage();
                app.Value = newInstance;
               
            }
            return app.Value;
        }

      
    }
}