using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Mantis_tests
{
    [TestFixture]
    public class AddNewIssueTests : TestBase
    {
        [Test]
        public void AddNewIssue()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root1"
            };

            IssueData issue = new IssueData()
            {
                Summary = "test",
                Description = "test",
                Category = "General"
            };

            ProjectData projet = new ProjectData()
            {
                Id = "1"
            };

            app.Api.CreateNewIssue(account, projet, issue);
        }
    }
}
