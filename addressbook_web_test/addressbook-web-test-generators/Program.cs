using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddressbookTest;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;

namespace addressbook_web_test_generators
{
    class Program
    {
        static void Main(string[] args)
        {
           
            string type = args[0];
            int count = Convert.ToInt32(args[1]);
            string format = args[3];
            string filename = args[2];

            List<UserData> user = new List<UserData>();
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < count; i++)
            {
                              
                groups.Add(new GroupData(TestBase.GenereteRandomString(10))
                {
                    Header = TestBase.GenereteRandomString(20),
                    Footer = TestBase.GenereteRandomString(20)
                });

            }
            for (int i = 0; i < count; i++)
            {
                
                user.Add(new UserData( 
                    TestBase.GenereteRandomString(10),
                    TestBase.GenereteRandomString(10)
                    )
                    {
                        Address = TestBase.GenereteRandomString(10),
                        Address2 = TestBase.GenereteRandomString(10),
                        Email = TestBase.GenereteRandomString(10)
                    });
                }

            
            if (format == "excel")
            {
                WriteGroupsToExcelFile(groups, filename);
            }
            else
            {
                StreamWriter writer = new StreamWriter(filename);
                if (format == "csv")
                {
                    WriteGroupsToCsvFile(groups, writer);
                }
                else if (format == "xml" && type == "groups")
                {
                    WriteGroupsToXmlFile(groups, writer);
                }
                else if (format == "xml" && type == "contacts")
                {
                    WriteUserToXmlFile(user, writer);
                }
                else if (format == "json" && type == "groups")
                {
                    WriteGroupsToJsonFile(groups, writer);
                }
                else if (format == "json" && type == "contacts")
                {
                    WriteUserToJsonFile(user, writer);
                }
                else
                {
                    Console.Out.Write("Unregognize format " + format);
                }

                writer.Close();

            }
           
        }
        static void WriteGroupsToExcelFile(List<GroupData> groups, string filename)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet;
            int row = 1;
            foreach (GroupData group in groups)
            {
                sheet.Cells[row, 1] = group.Name;
                sheet.Cells[row, 2] = group.Header;
                sheet.Cells[row, 3] = group.Footer;
                row++;
            }
            string fullpath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullpath);
            wb.SaveAs(fullpath);
            app.Visible = false;
            wb.Close();
            app.Quit();
        }
        static void WriteGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Footer, group.Header));

            }
        }
        static void WriteGroupsToXmlFile(List<GroupData> group, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, group);
        }
        static void WriteGroupsToJsonFile(List<GroupData> group, StreamWriter writer)
        {
           writer.Write(JsonConvert.SerializeObject(group,Newtonsoft.Json.Formatting.Indented));
        }
        static void WriteUserToXmlFile(List<UserData> user, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<UserData>)).Serialize(writer, user);
        }
        static void WriteUserToJsonFile(List<UserData> user, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(user, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
