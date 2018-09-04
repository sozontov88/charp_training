﻿using System;
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
        protected ApplicationManager app;
        private bool acceptNextAlert = true;
     
        [SetUp]
        public void SetupTest()
        {
            app = new ApplicationManager();
           
          
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }
      
        }
}
