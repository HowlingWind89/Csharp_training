using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public bool acceptNextAlert;

        public ContactHelper(ApplicationManager manager) : base(manager)
        {

        }

        public ContactHelper ModifyContact(ContactData newContactData)
        {
            manager.Navigator.ReturnToMainPage();

                SelectContact();
                InitContactModification();
                FillNewContactForm(newContactData);
                SubmitContactModification();
                manager.Navigator.ReturnToMainPage();
                return this;
        }

        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.CssSelector("img[alt=\"Edit\"]")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.CssSelector("input[name='update']")).Click();
            return this;
        }

        public ContactHelper CreateContact(ContactData contact)
        {
            manager.Navigator.ReturnToMainPage();
            manager.Navigator.GoToAddNewPage();
            FillNewContactForm(contact);
            SubmitNewContactCreation(contact);
            manager.Navigator.ReturnToMainPage();
            return this;
        }

        public ContactHelper Remove()
        {
            manager.Navigator.ReturnToMainPage();
                SelectContact();
                RemoveContact();
                ConfirmAlert();
                manager.Navigator.ReturnToMainPage();
                return this;
        }

        public ContactHelper FillNewContactForm(ContactData contact)
        {

            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("lastname"), contact.LastName);
            return this;
        }


        public ContactHelper SubmitNewContactCreation(ContactData contact)
        {
            driver.FindElement(By.CssSelector("input[value=\"Enter\"]")).Click();
            return this;
        }



        public ContactHelper SelectContact()
        {
            driver.FindElement(By.CssSelector("input[name=\"selected[]\"]")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public ContactHelper ConfirmAlert()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.AlertIsPresent());
            IAlert confirmAlert = driver.SwitchTo().Alert();
            confirmAlert.Accept();
            return this;
        }

        public ContactHelper CancelAlert()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.AlertIsPresent());
            IAlert cancelAlert = driver.SwitchTo().Alert();
            cancelAlert.Dismiss();
            return this;
        }

        public ContactHelper IsContactExistsAndRemove()
        {
            if (IsElementPresent(By.CssSelector("input[name=\"selected[]\"]")))
            {
                manager.Contact.Remove();
            }
            else
            {
                ContactData contact = new ContactData("Tester");
                contact.LastName = ("Testerov");
                manager.Contact.CreateContact(contact);
            }
            return this;
        }

        public ContactHelper IsContactExistsAndModify(ContactData newContactData)
        {
            if (IsElementPresent(By.CssSelector("input[name=\"selected[]\"]")))
            {
                manager.Contact.ModifyContact(newContactData);
            }
            else
            {
                ContactData contact = new ContactData("Tester");
                contact.LastName = ("Testerov");
                manager.Contact.CreateContact(contact);
            }
            return this;
        }

        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.ReturnToMainPage();
            ICollection<IWebElement>elements = driver.FindElements(By.CssSelector("td.center"));
            foreach(IWebElement element in elements)
            {
                //ContactData contact = new ContactData(element.Text);
                contacts.Add(new ContactData(element.Text));
            }
            return contacts;
        }

    }
}
