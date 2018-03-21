using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Mantis_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        {
 
        }

        public void Login(LoginData credentials)
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.12.0/login_page.php";

            driver.FindElement(By.Name("username")).SendKeys(credentials.UserName);
            driver.FindElement(By.CssSelector("input[value='Login']")).Click();

            driver.FindElement(By.Name("password")).SendKeys(credentials.Password);
            driver.FindElement(By.CssSelector("input[value='Login']")).Click();
        }
    }
}
