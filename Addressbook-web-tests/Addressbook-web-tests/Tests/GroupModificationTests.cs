using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("QA");
            newData.Header = (null);
            newData.Footer = (null);

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            if(app.Groups.IsGroupExists() == true)
            {
                app.Groups.Modify(0, newData);

                List<GroupData> newGroups = app.Groups.GetGroupList();
                oldGroups[0].Name = newData.Name;
                oldGroups.Sort();
                newGroups.Sort();
                Assert.AreEqual(oldGroups, newGroups);
            }
            else if(app.Groups.IsGroupExists() == false)
            {
                GroupData group = new GroupData("test");
                app.Groups.Create(group);
            }
          


        }

    }
}
