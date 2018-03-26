using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;

namespace Mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : TestBase
    {
        [Test]
        public void ProjectCreationTest()
        {
            LoginData credentials = new LoginData
            {
                UserName = "administrator",
                Password = "root1",
            };

            ProjectData projectData = new ProjectData
            {
                ProjectName = "Tester"
            };

            app.projectHelper.CareateProject(credentials, projectData);
        }
    }
}
