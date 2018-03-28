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

            List<ProjectData> projects = app.Admin.GetAllProjects(credentials, projectData);

            if (projects == null)
            {
                app.projectHelper.CareateProject(credentials, projectData);
            }
            else
            {
                app.projectHelper.DeleteProject(credentials, projectData);
                app.projectHelper.CareateProject(credentials, projectData);
            }
        }
    }
}
