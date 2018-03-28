using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SimpleBrowser.WebDriver;
using System.Text.RegularExpressions;

namespace Mantis_tests
{
    public class AdminHelper : HelperBase
    {
        private string baseURL;

        public AdminHelper(ApplicationManager manager, String baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public List<AccountData> GetAllAccouts()
        {
            List<AccountData> accounts = new List<AccountData>();

            OpenAppAndLogin();
            driver.Url = baseURL + "/manage_user_edit_page.php";
            IList<IWebElement> rows = driver.FindElements(By.CssSelector("table tr.row-1, table tr.row-2"));
            foreach(IWebElement row in rows)
            {
                IWebElement link= driver.FindElement(By.TagName("a"));
                string name = link.Text;
                string href = link.GetAttribute("href");
                Match m = Regex.Match(href, @"\d+$");
                string id = m.Value;

                accounts.Add(new AccountData()
                {
                    Name = name,
                    Id = id
                });
            }
            return accounts;
        }

        public void DeleteAccout(AccountData account)
        {
            OpenAppAndLogin();
            driver.Url = baseURL + "/manage_user_edit_page.php?user_id=" + account.Id;
            driver.FindElement(By.CssSelector("input[value='Delete User']")).Click();
            driver.FindElement(By.CssSelector("input[value='Delete Account']")).Click();
        }

        public void OpenAppAndLogin()
        {
            driver.Url = baseURL + "/login_page.php";
            System.Threading.Thread.Sleep(2000);
            driver.FindElement(By.Name("username")).SendKeys("administrator");
            driver.FindElement(By.CssSelector("input[value='Login']")).Click();
            driver.FindElement(By.Name("password")).SendKeys("root1");
            driver.FindElement(By.CssSelector("input[value='Login']")).Click();
        }

        public List<ProjectData> GetAllProjects(LoginData credentials, ProjectData projectData)
        {
            List<ProjectData> projects = new List<ProjectData>();
            driver.Url = baseURL + "/manage_proj_page.php";
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData accessibleProjects = new Mantis.ProjectData();
            accessibleProjects.name = projectData.ProjectName;
            accessibleProjects.name = projectData.Id;
            client.mc_projects_get_user_accessible(credentials.UserName, credentials.Password);

            IList<IWebElement> rows = driver.FindElements(By.CssSelector("tbody tr"));
            foreach (IWebElement row in rows)
            {
                IWebElement link = driver.FindElement(By.TagName("a"));
                string name = link.Text;
                string href = link.GetAttribute("href");
                Match m = Regex.Match(href, @"\d+$");
                string id = m.Value;

                projects.Add(new ProjectData()
                {
                    ProjectName = name,
                    Id = id
                });
            }
            return projects;
        }

        public void AddProjectMantis(LoginData credentials, ProjectData projectData)
        {
                Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
                Mantis.ProjectData project = new Mantis.ProjectData();
                project.name = projectData.ProjectName;
                client.mc_project_add(credentials.UserName, credentials.Password, project);
        }
    }
}
