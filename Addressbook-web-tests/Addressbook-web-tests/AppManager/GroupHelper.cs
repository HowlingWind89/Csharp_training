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
    public class GroupHelper : HelperBase
    {
        //private IWebDriver driver;

        public GroupHelper(IWebDriver driver) : base(driver)
        {

        }

        public void InitNewGroupCreation()
        {
            base.driver.FindElement(By.Name("new")).Click();
        }

        public void FillGroupForm(GroupData group)
        {
            base.driver.FindElement(By.Name("group_name")).Clear();
            base.driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            base.driver.FindElement(By.Name("group_header")).Clear();
            base.driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            base.driver.FindElement(By.Name("group_footer")).Clear();
            base.driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
        }


        public void SubmitGroupCreation()
        {
            base.driver.FindElement(By.Name("submit")).Click();
        }


        public void ReturnToGroupsPage()
        {
            base.driver.FindElement(By.LinkText("group page")).Click();
        }

        public void SelectGroup(int index)
        {
            base.driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
        }

        public void RemoveGroup()
        {
            base.driver.FindElement(By.Name("delete")).Click();
        }

    }
}
