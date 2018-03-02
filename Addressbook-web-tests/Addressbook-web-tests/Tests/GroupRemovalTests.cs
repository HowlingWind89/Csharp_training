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
    public class GroupRemovalTests : GroupTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            if (app.Groups.IsGroupExists() == true)
            {
                List<GroupData> oldGroups = GroupData.GetAll();
                //GroupData oldData = oldGroups[0];
                GroupData toBeRemoved = oldGroups[0];

                app.Groups.Remove(toBeRemoved);

                Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

                List<GroupData> newGroups = GroupData.GetAll();

                oldGroups.RemoveAt(0);
                Assert.AreEqual(oldGroups, newGroups);

                foreach(GroupData group in newGroups)
                {
                    Assert.AreNotEqual(group.Id, toBeRemoved);
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
