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

        public ContactHelper CreateContact(ContactData contact)
        {
            manager.Navigator.GoToAddNewPage();

            FillNewContactForm(contact);
            SubmitNewContactCreation(contact);
            manager.Navigator.ReturnToMainPage();
            return this;
        }

        public ContactHelper Remove()
        {

            SelectContact();
            RemoveContact();
            manager.Navigator.ReturnToMainPage();

            return this;
        }
        public ContactHelper FillNewContactForm(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
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
    }
}
