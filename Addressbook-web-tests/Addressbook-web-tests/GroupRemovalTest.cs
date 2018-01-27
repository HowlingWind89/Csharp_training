using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            navigationHelper.GoToHomePage();
            loginHelper.Login(new AccountData ("admin", "secret"));
            navigationHelper.GoToGroupsPage();
            groupHelper.SelectGroup(1);
            groupHelper.RemoveGroup();
            groupHelper.ReturnToGroupsPage();
        }
    }
}
