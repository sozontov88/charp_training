﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Serialization;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTest
{
    [TestFixture]
    public class CreateContactTest : AuthTestBase
    {
        public static IEnumerable<UserData> RandomContactProvider()
        {
            List<UserData> user = new List<UserData>();
            for(int i = 0; i <5;i++)
            {
                user.Add(new UserData(GenereteRandomString(50), GenereteRandomString(50))
                {
                    Middlename = GenereteRandomString(50),
                    Nickname = GenereteRandomString(50),
                    Email = GenereteRandomString(40),
                    Email2 = GenereteRandomString(40),
                    Email3= GenereteRandomString(40)
                });
            }
            return user;
        }
        public static IEnumerable<UserData> UserDataFromXmlFile()
        {

            return (List<UserData>)new XmlSerializer(typeof(List<UserData>)).
                  Deserialize(new StreamReader(@"contacts.xml"));
        }
        public static IEnumerable<UserData> UserDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<UserData>>(File.ReadAllText(@"contacts.json"));
        }
       

        [Test, TestCaseSource("UserDataFromJsonFile")]
        public void CreateContactTests(UserData user)
        {
          
            List<UserData> oldName = UserData.GetAll();
            app.Contacts.Create(user);

            Assert.AreEqual(oldName.Count + 1, app.Contacts.GetNameCount());

            List<UserData> newName = UserData.GetAll();
            oldName.Add(user);
            oldName.Sort();
            newName.Sort();
            Assert.AreEqual(oldName, newName);
        }

        [Test]
        public void TestContactInformation()
        {
            UserData fromTable = app.Contacts.GetContactInformationFromTable(0);
            UserData fromForm = app.Contacts.GetContactInformation(0);
            UserData fromDeteils = app.Contacts.GetPropertyInformation(0);
           
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.Allphone, fromForm.Allphone);
            Assert.AreEqual(fromTable.Allemails, fromForm.Allemails);
            
            Assert.AreEqual(fromForm.Address, fromDeteils.Address);
            Assert.AreEqual(fromForm.Allphone, fromDeteils.Allphone);
        }
   
    }
}
