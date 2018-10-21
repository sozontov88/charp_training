using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.CSharp;
using System.Text;
using System.Xml;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace WebAddressbookTest
{
    [TestFixture]
    public class GroupCreationTest : GroupTestBase
    {
        public static IEnumerable<GroupData> RandomGroupProvider()
        {
            List<GroupData> group = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                group.Add(new GroupData(GenereteRandomString(30))
                {
                    Header = GenereteRandomString(100),
                    Footer = GenereteRandomString(100)
                });
            }
            return group;
        }
        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> group = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                group.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });
            }
            return group;
        }
        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(File.ReadAllText(@"groups.json"));
        }

        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {

            return (List<GroupData>)new XmlSerializer(typeof(List<GroupData>)).
                  Deserialize(new StreamReader(@"groups.xml"));
        }
        public static IEnumerable<GroupData> GroupDataFromExcelFile()
        {
            List<GroupData> groups = new List<GroupData>();
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook workbook = app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), @"groups.xlsx"));
            Excel.Worksheet sheet = workbook.ActiveSheet;
            Excel.Range range = sheet.UsedRange;
            for (int i = 0; i < range.Rows.Count; i++)
            {
                groups.Add(new GroupData()
                {
                    Name = range.Cells[i, 1].Value,
                    Header = range.Cells[i, 1].Value,
                    Footer = range.Cells[i, 1].Value


                });
            }
            workbook.Close();
            app.Visible = false;
            app.Quit();
            return groups;
        }



        [Test, TestCaseSource("GroupDataFromCsvFile")]
        public void GroupCreationTests(GroupData group)
        {
            
            List<GroupData> oldGroups = GroupData.GetAll();
            app.Groups.Create(group);


            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());
            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }
        [Test]
        public void TestDbConectivity()
        {
            DateTime start = DateTime.Now;
            List<GroupData> fromUi = app.Groups.GetAllGroups();
            DateTime end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));
            start = DateTime.Now;
            List<GroupData> fromdb = GroupData.GetAll();
         
            end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));
        }
        [Test]
        public void TestDbConect()
        {

         foreach(UserData user in UserData.GetAll())
            {
                System.Console.Out.WriteLine(user.Deprecated);
            }
      
        }
    }
}
