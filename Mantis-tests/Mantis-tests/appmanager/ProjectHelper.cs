using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Threading.Tasks;

namespace Mantis_tests
{
    public class ProjectHelper : HelperBase
    {
        public ProjectHelper(ApplicationManager manager) : base(manager)
        {

        }

        public void CareateProject(LoginData credentials, ProjectData projectData)
        {
            manager.loginHelper.Login(credentials);
            GoToProjectManagementPage();
            OpenNewProjectCreationForm();
            FillNewProjectCreationForm(projectData);
            SumitProjectCreation();
        }

        public void DeleteProject(LoginData credentials)
        {
            manager.loginHelper.Login(credentials);
            OpenProject();
            Delete();
            ConfirmProjectDelete();
        }

        public void GoToProjectManagementPage()
        {
            driver.FindElement(By.CssSelector("i.menu-icon.fa.fa-gears")).Click();
            driver.FindElement(By.LinkText("Manage Projects")).Click();
        }

        public void OpenNewProjectCreationForm()
        {
            driver.FindElement(By.CssSelector("button.btn.btn-primary.btn-white.btn-round")).Click();
        }

        private void FillNewProjectCreationForm(ProjectData projectData)
        {
            driver.FindElement(By.CssSelector("input[id='project-name']")).SendKeys(projectData.ProjectName);
        }
        public void SumitProjectCreation()
        {
            driver.FindElement(By.CssSelector("input[value='Add Project']")).Click();
        }

        public void OpenProject()
        {
            GoToProjectManagementPage();
            System.Threading.Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("td > a")).Click();
        }

        public void Delete()
        {
            System.Threading.Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("input[value='Delete Project']")).Click();
        }

        public void ConfirmProjectDelete()
        {
            System.Threading.Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("input[value='Delete Project']")).Click();
        }
    }
}
