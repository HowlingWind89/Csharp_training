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
            ContactData newContactData = new ContactData(null, "QATester");
            newContactData.FirstName = ("QATester");
            newContactData.LastName = (null);

            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.ModifyContact(0, newContactData);

            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts[0].FirstName = newContactData.FirstName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
