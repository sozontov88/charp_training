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

        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;

        }

        private List<GroupData> groupCache = null;
        public List<GroupData> GetAllGroups()
        {
            if(groupCache == null)
            {

            groupCache = new List<GroupData>();
            manager.Navigator.GoToGropsPage();
            ICollection <IWebElement> elements= driver.FindElements(By.CssSelector("span.group"));
            foreach(IWebElement element in elements)
            {
                          
              groupCache.Add(new GroupData(null)
              { Id = element.FindElement(By.TagName("input")).GetAttribute("value")
              });
            }
                string allGroupName = driver.FindElement(By.CssSelector("div#content form")).Text;
                string[] parts = allGroupName.Split('\n');
                int shift = groupCache.Count - parts.Length;
                for(int i =0; i< groupCache.Count; i++)
                {
                    if(i<shift)
                    {
                        groupCache[i].Name = "";
                    }
                    else
                    {
                       groupCache[i].Name = parts[i-shift].Trim();
                    }
                   
                }
               
            }
           return new List<GroupData>( groupCache);
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
            groupCache = null;
            return this;
        }

        public GroupHelper RetutnToGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }
       
        public GroupHelper SelectGroup(int index)
        {
            if (IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")))
            {
             driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            }
          
            return this;
        }
        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
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
            groupCache = null;
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
