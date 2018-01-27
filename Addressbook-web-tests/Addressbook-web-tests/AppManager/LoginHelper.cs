using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        {
 
        }


        public void Login(AccountData account)
        {
            base.driver.FindElement(By.Name("user")).Clear();
            base.driver.FindElement(By.Name("user")).SendKeys(account.Username);
            base.driver.FindElement(By.Name("pass")).Clear();
            base.driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            base.driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }
    }
}
