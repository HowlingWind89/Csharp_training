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
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            navigationHelper.GoToHomePage();
            loginHelper.Login(new AccountData ("admin", "secret"));
            navigationHelper.GoToGroupsPage();
            groupHelper.InitNewGroupCreation();
            GroupData group = new GroupData("test");
            group.Header = ("test");
            group.Footer = ("test");
            groupHelper.FillGroupForm (group);
            groupHelper.SubmitGroupCreation();
            groupHelper.ReturnToGroupsPage();
        }
    }
}