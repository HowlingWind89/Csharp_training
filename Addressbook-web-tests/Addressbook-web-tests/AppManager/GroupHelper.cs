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

        public GroupHelper Modify(int v, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();

            if (IsElementPresent(By.CssSelector("input[name=\"selected[]\"]")))
            {
                SelectGroup();
                InitGroupModification();
                FillGroupForm(newData);
                SubmitGroupModification();
                ReturnToGroupsPage();
                return this;
            }
            else
            {
                GroupData group = new GroupData("test");
                manager.Groups.Create(group);
                manager.Groups.Modify(1, newData);
                return this;
            }
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper Remove()
        {
            manager.Navigator.GoToGroupsPage();

            if (IsElementPresent(By.CssSelector("input[name=\"selected[]\"]")))
            {
                SelectGroup();
                RemoveGroup();
                ReturnToGroupsPage();
                return this;
            }
            else
            {
                GroupData group = new GroupData("test");
                group.Header = ("test");
                group.Footer = ("test");
                manager.Groups.Create(group);
                manager.Groups.Remove();
                return this;
            }
        }

        public GroupHelper InitNewGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }


        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper SelectGroup()
        {
            driver.FindElement(By.CssSelector("input[name=\"selected[]\"]")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

    }
}
