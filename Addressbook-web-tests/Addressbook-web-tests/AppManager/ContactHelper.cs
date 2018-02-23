using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;

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
                InitContactModification(0);
                FillNewContactForm(newContactData);
                SubmitContactModification();
                manager.Navigator.ReturnToMainPage();
                return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.CssSelector("input[name='update']")).Click();
            contactCache = null;
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
            contactCache = null;
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
            contactCache = null;
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

        public bool IsContactExists()
        {
            manager.Navigator.ReturnToMainPage();
            if (IsElementPresent(By.CssSelector("input[name=\"selected[]\"]")))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.ReturnToMainPage();
                ICollection<IWebElement> tableRows = driver.FindElements(By.CssSelector("tr[name=entry]"));
                foreach (IWebElement element in tableRows)
                {
                    string LastName = element.FindElement(By.XPath("./td[2]")).Text;
                    string FirstName = element.FindElement(By.XPath("./td[3]")).Text;
                    contactCache.Add(new ContactData(FirstName, LastName)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });

                }
            }
            return new List<ContactData>(contactCache);
        }
        public int GetContactCount()
        {
            return driver.FindElements(By.CssSelector("tr[name=entry]")).Count;
        }
        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.ReturnToMainPage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));

            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllEmails = allEmails,
                AllPhones = allPhones
            };
        }
        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.ReturnToMainPage();
            InitContactModification(0);
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone
            };
        }

        public int GetNumberOfSearchResults()
        {
            manager.Navigator.ReturnToMainPage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }

        public ContactHelper OpenContactDetailsPage(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a")).Click();
            return this;
        }

        public ContactData GetContactInformationFromDetailsPage(int index)
        {
            manager.Navigator.ReturnToMainPage();
            OpenContactDetailsPage(0);
            string contactDetailsPageText = driver.FindElement(By.CssSelector("#content")).Text;
            contactDetailsPageText = Regex.Replace(contactDetailsPageText, "[ HMW:\r\n]", "").Trim();

            return new ContactData("", "")
            {
                ContactDetailsPageText = contactDetailsPageText
            };

        }
    }
}
