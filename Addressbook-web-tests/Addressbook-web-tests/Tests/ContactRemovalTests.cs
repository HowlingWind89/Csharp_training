using System;
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
            if (app.Contact.IsContactExists() == true)
            {
                List<ContactData> oldContacts = app.Contact.GetContactList();
                ContactData oldData = oldContacts[0];

                app.Contact.Remove(0);

                Assert.AreEqual(oldContacts.Count - 1, app.Contact.GetContactCount());

                List<ContactData> newContacts = app.Contact.GetContactList();

                ContactData toBeRemoved = oldContacts[0];
                oldContacts.RemoveAt(0);
                Assert.AreEqual(oldContacts, newContacts);

                foreach (ContactData contact in newContacts)
                {
                    Assert.AreNotEqual(contact.Id, oldData.Id);
                }
            }
            else if (app.Contact.IsContactExists() == false)
            {
                ContactData contact = new ContactData("Testerov", "Tester");
                app.Contact.CreateContact(contact);
            }
        }
    }
}
