﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            List<ContactData> oldContacts = app.Contact.GetContactList();

            if (app.Contact.IsContactExists() == true)
            {
                app.Contact.Remove(0);

                List<ContactData> newContacts = app.Contact.GetContactList();
                oldContacts.RemoveAt(0);
                Assert.AreEqual(oldContacts, newContacts);
            }
            else if (app.Contact.IsContactExists() == false)
            {
                ContactData contact = new ContactData("Testerov", "Tester");
                app.Contact.CreateContact(contact);
            }
        }
    }
}
