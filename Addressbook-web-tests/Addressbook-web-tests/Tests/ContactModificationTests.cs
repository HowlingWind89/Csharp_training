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
    public class ContactModificationTests : ContactTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newContactData = new ContactData("QATesterov", "QATester");
            newContactData.FirstName = ("QATester");
            newContactData.LastName = ("QATesterov");

            if (app.Contact.IsContactExists() == true)
            {
                List<ContactData> oldContacts = app.Contact.GetContactList();
                ContactData oldData = oldContacts[0];

                app.Contact.ModifyContact(0, newContactData);

                Assert.AreEqual(oldContacts.Count, app.Contact.GetContactCount());

                List<ContactData> newContacts = app.Contact.GetContactList();
                oldContacts[0].LastName = newContactData.LastName;
                oldContacts[0].FirstName = newContactData.FirstName;
                oldContacts.Sort();
                newContacts.Sort();
                Assert.AreEqual(oldContacts, newContacts);

                foreach(ContactData contact in newContacts)
                {
                    if(contact.Id == oldData.Id)
                    {
                        Assert.AreEqual(newContactData.LastName, contact.LastName);
                        Assert.AreEqual(newContactData.FirstName, contact.FirstName);
                    }
                }
            }
            else if(app.Contact.IsContactExists() == false)
            {
                ContactData contact = new ContactData("Testerov", "Tester");
                app.Contact.CreateContact(contact);
            }
        }
    }
}
