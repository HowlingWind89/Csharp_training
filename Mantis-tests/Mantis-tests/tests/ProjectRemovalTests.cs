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

            ProjectData projectData = new ProjectData
            {
                ProjectName = "Tester"
            };

            List<ProjectData> projects = app.Admin.GetAllProjects(credentials, projectData);

            if (projects != null)
            {
                app.projectHelper.DeleteProject(credentials, projectData);
            }
            else
            {
                app.Admin.AddProjectMantis(credentials, projectData);
                app.projectHelper.DeleteProject(credentials, projectData);
            }
        }
    }
}
