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

        public ContactHelper ModifyContact(int v, ContactData newContactData)
        {
            manager.Navigator.ReturnToMainPage();

                SelectContact(v);
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

        public ContactHelper Remove(int v)
        {
            manager.Navigator.ReturnToMainPage();
                SelectContact(v);
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



        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
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


        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.ReturnToMainPage();
            ICollection<IWebElement> tableRows = driver.FindElements(By.CssSelector("tr[name=\"entry]"));
            foreach(IWebElement element in tableRows)
            {
                string LastName = element.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[2]/td[2]")).Text;
                string FirstName = element.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[2]/td[3]")).Text;
                contacts.Add(new ContactData(LastName, FirstName));
            }
            return contacts;

            
            /*foreach (IWebElement elementLast in LastName)
            foreach (IWebElement elementFirst in FirstName)
            {
                contacts.Add(new ContactData(elementLast.Text, elementFirst.Text));       
            }
            return contacts;*/

            /*manager.Navigator.ReturnToMainPage();
            ICollection <IWebElement> FirstName = tableRow = driver.FindElements(By.XPath("//table[@id='maintable']/tbody/tr[2]/td[3]"));
            foreach (IWebElement elementFirst in FirstName)
            {
                contacts.Add(new ContactData , elementFirst.Text));
            }
            return contacts;*/
        }
    }
}
