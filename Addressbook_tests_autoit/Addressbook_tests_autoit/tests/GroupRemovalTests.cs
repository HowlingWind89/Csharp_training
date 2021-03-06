﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using NUnit.Framework;

namespace Addressbook_tests_autoit
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void TestGroupRemoval()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Remove();

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Remove(oldGroups[0]);
            oldGroups.Sort();
            newGroups.Sort();

            NUnit.Framework.Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
