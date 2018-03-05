using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("QA");
            newData.Header = (null);
            newData.Footer = (null);

            if(app.Groups.IsGroupExists() == true)
            {
                List<GroupData> oldGroups = app.Groups.GetGroupList();
                //GroupData oldData = oldGroups[0];
                GroupData toBeModified = oldGroups[0];

                app.Groups.Modify(toBeModified, newData);

                Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

                List<GroupData> newGroups = app.Groups.GetGroupList();
                oldGroups[0].Name = newData.Name;
                oldGroups.Sort();
                newGroups.Sort();
                Assert.AreEqual(oldGroups, newGroups);

                foreach (GroupData group in newGroups)
                {
                    if(group.Id == toBeModified.Id)
                    {
                        Assert.AreEqual(newData.Name, toBeModified.Name);
                    }
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
