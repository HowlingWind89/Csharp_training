using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Mantis_tests
{
    public class RegistrationHelper : HelperBase
    {
        public RegistrationHelper(ApplicationManager manager) : base(manager) { }

        public void Register(AccountData account)
        {
            OpenMainPage();
            OpenRegistrationForm();
            FillRegistrationForm(account);
            SubmitRegistration();
            Proceed();
            String url = GetConfirmationUrl(account);
            FillPasswordForm(url, account);
            FillRealName(account);
            SubmitPasswordForm();
        }

        private string GetConfirmationUrl(AccountData account)
        {
            String message = manager.Mail.GetLastMail(account);
            Match match = Regex.Match(message, @"http://\S*");
            return match.Value;
        }

        private void OpenMainPage()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.12.0/login_page.php";
        }

        private void OpenRegistrationForm()
        {
            driver.FindElement(By.CssSelector("a.back-to-login-link.pull-left")).Click();
        }

        private void FillRegistrationForm(AccountData account)
        {
            System.Threading.Thread.Sleep(5000);
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            driver.FindElement(By.Name("email")).SendKeys(account.Email);
        }

        private void SubmitRegistration()
        {
            driver.FindElement(By.CssSelector("input[value='Signup']")).Click();
        }

        private void Proceed()
        {
            driver.FindElement(By.CssSelector("a.width-40.btn.btn-inverse.bigger-110.btn-success")).Click();
        }

        public void FillRealName(AccountData account)
        {
            driver.FindElement(By.Id("realname")).SendKeys(account.RealName);
        }

        private void FillPasswordForm(string url, AccountData account)
        {
            driver.Url = url;
            driver.FindElement(By.Name("password")).SendKeys(account.Password);
            driver.FindElement(By.Name("password_confirm")).SendKeys(account.Password);
        }

        private void SubmitPasswordForm()
        {
            driver.FindElement(By.CssSelector("span.submit-button")).Click();
        }
    }
}
