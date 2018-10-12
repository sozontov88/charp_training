using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Threading.Tasks;
using WebAddressbookTest;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;

namespace contact_test_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = args[0];
            int count = Convert.ToInt32(args[1]);
            string name = args[2];
            string format = args[3];
            
            StreamWriter writer = new StreamWriter(name);
            List<UserData> user = new List<UserData>();
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i<count; i++)
            {
               
                    user.Add(new UserData(TestBase.GenereteRandomString(10),
                    TestBase.GenereteRandomString(10))
                    {
                        Address = TestBase.GenereteRandomString(10),
                        Address2 = TestBase.GenereteRandomString(10),
                        Email = TestBase.GenereteRandomString(10)
                    });
                }
            for (int i = 0; i < count; i++)
            {
                
                groups.Add(new GroupData(TestBase.GenereteRandomString(10))
            {
                Header = TestBase.GenereteRandomString(20),
                Footer = TestBase.GenereteRandomString(20)
            });

        }
                            
            
           if(format == "xml" && type =="user")
            {
                WriteUserToXmlFile(user, writer);
            }
            else if (format == "xml" && type == "groups")
            {
                WriteGroupsToXmlFile(groups, writer);
            }
            else if (format == "json" && type == "user")
            {
                WriteUserToJsonFile(user, writer);
            }

            else if (format == "json" && type == "groups")
            {
                WriteGroupsToJsonFile(groups, writer);
            }
           
            else
            {
                Console.Out.Write("Unregognize format " + format);
            }
            writer.Close();
        }
      

     
        static void WriteUserToXmlFile(List<UserData> user, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<UserData>)).Serialize(writer, user);
        }
        static void WriteUserToJsonFile(List<UserData> user, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(user, Newtonsoft.Json.Formatting.Indented));
        }
        static void WriteGroupsToXmlFile(List<GroupData> group, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, group);
        }
        static void WriteGroupsToJsonFile(List<GroupData> group, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(group, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
