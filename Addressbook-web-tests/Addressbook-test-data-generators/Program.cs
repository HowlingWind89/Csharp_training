﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddressbookTests;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;

namespace Addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            string filename = args[1];
            string format = args[2];
            string dataType = args[3];

            if (args[3] == "group")
            {
                if (args[1] == "groups.xml" || args[1] == "groups.csv" || args[1] == "groups.json" || args[1] == "groups.xlsx")
                {
                    List<GroupData> groups = new List<GroupData>();
                    for (int i = 0; i < count; i++)
                    {
                        groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                        {
                            Header = TestBase.GenerateRandomString(100),
                            Footer = TestBase.GenerateRandomString(100)
                        });
                    }

                    if(format == "excel")
                    {
                        writeGroupsToExcelFile(groups, filename);
                    }
                    else
                    {
                        StreamWriter writer = new StreamWriter(filename);

                        if (format == "csv")
                        {
                            writeGroupsToCsvFile(groups, writer);
                        }
                        else if (format == "xml")
                        {
                            writeGroupsToXmlFile(groups, writer);
                        }
                        else if (format == "json")
                        {
                            writeGroupsToJsonFile(groups, writer);
                        }
                        else
                        {
                            System.Console.Out.Write("Unrecognized format: " + format);
                        }
                        writer.Close();
                    }
                }
            }
            else if (args[3] == "contact")
            {
                if (args[1] == "contacts.xml" || args[1] == "contacts.csv" || args[1] == "contacts.json" || args[1] == "contacts.xlsx")
                {
                    List<ContactData> contacts = new List<ContactData>();
                    for (int i = 0; i < count; i++)
                    {
                        contacts.Add(new ContactData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10))
                        {

                        });
                    }

                    if (format == "excel")
                    {
                        writeContactsToExcelFile(contacts, filename);
                    }
                    else
                    {
                        StreamWriter writer = new StreamWriter(filename);

                        if (format == "csv")
                        {
                            writeContactsToCsvFile(contacts, writer);
                        }
                        else if (format == "xml")
                        {
                            writeContactsToXmlFile(contacts, writer);
                        }
                        else if (format == "json")
                        {
                            writeContactsToJsonFile(contacts, writer);
                        }
                        else
                        {
                            System.Console.Out.Write("Unrecognized format: " + format);
                        }
                        writer.Close();
                    }
                }
            }
            else
            {
                System.Console.Out.Write("Unrecognized data type: " + dataType + 
                    "\nAcceptable data types are 'group' and 'contact'");
            }
        }

        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }
        }

        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void writeContactsToCsvFile(List<ContactData> contacts, StreamWriter writer)
        {
            foreach (ContactData contact in contacts)
            {
                writer.WriteLine(String.Format("${0},${1}",
                    contact.FirstName, contact.LastName));
            }
        }

        static void writeContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

        static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }

        static void writeContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }

        static void writeGroupsToExcelFile(List<GroupData> groups, string filename)
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
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullPath);
            wb.SaveAs(filename);

            wb.Close();
            app.Visible = false;
            app.Quit();
        }

        static void writeContactsToExcelFile(List<ContactData> contacts, string filename)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet;

            int row = 1;
            foreach (ContactData contact in contacts)
            {
                sheet.Cells[row, 1] = contact.FirstName;
                sheet.Cells[row, 2] = contact.LastName;
                row++;
            }
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullPath);
            wb.SaveAs(filename);

            wb.Close();
            app.Visible = false;
            app.Quit();
        }
    }
}