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
    public class ContactRemovalTests : ContactTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            if (app.Contact.IsContactExists() == true)
            {
                List<ContactData> oldContacts = ContactData.GetAll();
                //ContactData oldData = oldContacts[0];
                ContactData toBeRemoved = oldContacts[0];

                app.Contact.Remove(toBeRemoved);

                Assert.AreEqual(oldContacts.Count - 1, app.Contact.GetContactCount());

                List<ContactData> newContacts = ContactData.GetAll();

                //ContactData toBeRemoved = oldContacts[0];
                oldContacts.RemoveAt(0);
                Assert.AreEqual(oldContacts, newContacts);

                foreach (ContactData contact in newContacts)
                {
                    Assert.AreNotEqual(contact.Id, toBeRemoved);
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
