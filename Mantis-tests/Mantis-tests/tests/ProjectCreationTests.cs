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

            List<ProjectData> projects = app.Admin.GetAllProjects();

            ProjectData projectData = new ProjectData
            {
                ProjectName = "Tester"
            };

            ProjectData ExistingProject = projects.Find(x => x.ProjectName == projectData.ProjectName);

            app.projectHelper.DeleteProject(credentials, ExistingProject);

            app.projectHelper.CareateProject(credentials, projectData);
        }
    }
}
