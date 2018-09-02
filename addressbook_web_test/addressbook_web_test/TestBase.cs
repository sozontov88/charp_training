using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTest
{
  public  class TestBase
    {
        protected IWebDriver driver;
        protected StringBuilder verificationErrors;

        protected NavigationHelper navigator;

        protected string baseURL;
        private bool acceptNextAlert = true;
        protected LoginHelper loginHelper;
        protected GroupHelper groupHelper;
        [SetUp]
        public void SetupTest()
        {
            FirefoxOptions options = new FirefoxOptions();
            driver = new FirefoxDriver(options);
            baseURL = "http://localhost/";
            verificationErrors = new StringBuilder();
            navigator = new NavigationHelper(driver, baseURL);
            loginHelper = new LoginHelper(driver);
            groupHelper = new GroupHelper(driver);
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
      
     
        protected void LogOut()
        {
            driver.FindElement(By.LinkText("LOGOUT")).Click();
        }

        }
}
