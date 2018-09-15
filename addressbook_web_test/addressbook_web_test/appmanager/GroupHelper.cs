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
   public class GroupHelper : HelperBase
    {
      
        public GroupHelper(ApplicationManager manager):base(manager)
        {
            
        }

        public GroupHelper Remove(int p)
        {
            manager.Navigator.GoToGropsPage();
            SelectGroup(p);
            RemoveGroup();
            RetutnToGroupPage();
            return this;
        }

        public GroupHelper Modify(int p, GroupData group)
        {
            manager.Navigator.GoToGropsPage();
            SelectGroup(p);
            InitGroupModification();
            FillGroupForm(group);
            SubmitGroupModification();
            RetutnToGroupPage();
            return this;
        }

     

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGropsPage();
            InitGroupCreation();
            FillGroupForm(group);
            Submit();
            RetutnToGroupPage();
            return this;
        }
        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }
        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"),group.Footer);
            return this;
        }

        public GroupHelper Submit()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper RetutnToGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }
       
        public GroupHelper SelectGroup(int index)
        {
            if (IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + index + "]")))
            {
             driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            }
          
            return this;
        }
        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }
        public GroupHelper GoToGroupPage()
        {
            driver.FindElement(By.LinkText("GROUPS")).Click();
            return this;
        }
        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }
        public bool IsGroupExist(GroupData group)
        {
           if( IsElementPresent(By.XPath("//span[@class='group']")))
            {
              return driver.FindElement(By.XPath("//span[@class='group']")).Text
                      == group.Name;
            }
            return false;

        }
      
    }
}
