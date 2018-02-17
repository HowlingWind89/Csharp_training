using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            if (app.Groups.IsGroupExists() == true)
            {
                List<GroupData> oldGroups = app.Groups.GetGroupList();
                GroupData oldData = oldGroups[0];

                app.Groups.Remove(0);

                Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

                List<GroupData> newGroups = app.Groups.GetGroupList();

                GroupData toBeRemoved = oldGroups[0];
                oldGroups.RemoveAt(0);
                Assert.AreEqual(oldGroups, newGroups);

                foreach(GroupData group in newGroups)
                {
                    Assert.AreNotEqual(group.Id, oldData.Id);
                }
            }
            else if(app.Groups.IsGroupExists() == false)
            {
                GroupData group = new GroupData("test");
                app.Groups.Create(group);
            }
        }
    }
}
