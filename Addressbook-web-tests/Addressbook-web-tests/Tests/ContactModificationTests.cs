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
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newContactData = new ContactData("QATesterov", "QATester");
            newContactData.FirstName = ("QATester");
            newContactData.LastName = ("QATesterov");

            List<ContactData> oldContacts = app.Contact.GetContactList();

            if (app.Contact.IsContactExists() == true)
            {
                app.Contact.ModifyContact(0, newContactData);

                List<ContactData> newContacts = app.Contact.GetContactList();
                oldContacts[0].LastName = newContactData.LastName;
                oldContacts[0].FirstName = newContactData.FirstName;
                oldContacts.Sort();
                newContacts.Sort();
                Assert.AreEqual(oldContacts, newContacts);
            }
            else if(app.Contact.IsContactExists() == false)
            {
                ContactData contact = new ContactData("Testerov", "Tester");
                app.Contact.CreateContact(contact);
            }
        }
    }
}
