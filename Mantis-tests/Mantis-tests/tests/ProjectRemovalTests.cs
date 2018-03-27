using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Mantis_tests
{
    [TestFixture]
    public class ProjectRemovalTests : TestBase
    {
        [Test]
        public void ProjectRemovalTest()
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

            app.projectHelper.DeleteProject(credentials, projectData);
        }
    }
}
