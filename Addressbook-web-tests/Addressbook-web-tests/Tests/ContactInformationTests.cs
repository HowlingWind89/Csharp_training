using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace WebAddressbookTests 
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]

        public void TestContactInformation()
        {
            ContactData fromTable = app.Contact.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contact.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromTable.FirstName, fromForm.FirstName);
            Assert.AreEqual(fromTable.LastName, fromForm.LastName);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }

        [Test]
        public void TestContactDetailsPage()
        {
            ContactData fromForm = app.Contact.GetContactInformationFromEditForm(0);

            if (fromForm.FirstName != "" && fromForm.LastName != "" && fromForm.HomePhone != "" &&
                fromForm.MobilePhone != "" && fromForm.WorkPhone != "" &&
                fromForm.Email != "" && fromForm.Email2 != "" && fromForm.Email3 != "")
            {
                ContactData fromDetailsPage = app.Contact.GetContactInformationFromDetailsPage(0);
                Assert.AreEqual(fromForm.FirstName + " " + fromForm.LastName + "\r\n"
                   + "\r\nH: " + fromForm.HomePhone + "\r\nM: " + fromForm.MobilePhone + "\r\nW: " + fromForm.WorkPhone + "\r\n"
                   + "\r\n" + fromForm.Email + "\r\n" + fromForm.Email2 + "\r\n" + fromForm.Email3, fromDetailsPage.ContactDetailsPageText);
            }
            else if (fromForm.FirstName == "" || fromForm.LastName == "" || fromForm.HomePhone == "" ||
                fromForm.MobilePhone == "" || fromForm.WorkPhone == "" ||
                fromForm.Email == "" || fromForm.Email2 == "" || fromForm.Email3 == "")
            { 
                ContactData fromDetailsPageTrim = app.Contact.GetContactInformationFromDetailsPageAndTrim(0);
                Assert.AreEqual(fromForm.FirstName + fromForm.LastName
                + fromForm.HomePhone + fromForm.MobilePhone + fromForm.WorkPhone
                + fromForm.Email + fromForm.Email2 + fromForm.Email3, fromDetailsPageTrim.ContactDetailsPageTextTrim);
            } 
        }
    }
}
