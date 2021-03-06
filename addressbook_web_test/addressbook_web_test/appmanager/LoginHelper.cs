﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTest
{
   public class LoginHelper : HelperBase
    {
      
        public LoginHelper(ApplicationManager manager) :base(manager)
    {
           
    }
    
        public void Login(AccountData account)
        {    if(IsLogedIn())
            {
                if(IsLogedIn(account))
                {
                    return;
                }
                LogOut();
            }
            
            Type(By.Name("user"), account.Login);
            Type(By.Name("pass"), account.Password);
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        public bool IsLogedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }

        public bool IsLogedIn(AccountData account)
        {
            return IsLogedIn() &&
                GetLoggetUserName() == account.Login;
              
        }
        public string GetLoggetUserName()
        {
            var text = driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text;
            return text.Substring(1, text.Length - 2);
        }
        public void LogOut()
        {
            if ( IsLogedIn())
            {
              driver.FindElement(By.XPath("//*[@id='top']/form/a")).Click();
            }
           
        }
    }
}
