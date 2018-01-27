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
        public GroupHelper(ApplicationManager manager) : base(manager)
        {

        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();

            InitNewGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Remove(int v)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(1);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper InitNewGroupCreation()
        {
            base.driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            base.driver.FindElement(By.Name("group_name")).Clear();
            base.driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            base.driver.FindElement(By.Name("group_header")).Clear();
            base.driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            base.driver.FindElement(By.Name("group_footer")).Clear();
            base.driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
            return this;
        }


        public GroupHelper SubmitGroupCreation()
        {
            base.driver.FindElement(By.Name("submit")).Click();
            return this;
        }


        public GroupHelper ReturnToGroupsPage()
        {
            base.driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            base.driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            base.driver.FindElement(By.Name("delete")).Click();
            return this;
        }

    }
}
