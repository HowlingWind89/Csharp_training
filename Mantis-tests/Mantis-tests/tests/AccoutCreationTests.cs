using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;

namespace Mantis_tests
{
    [TestFixture]
    public class AccoutCreationTests : TestBase
    {
        [OneTimeSetUp]
        public void setupConfig()
        {
            
            app.Ftp.BackupFile("/config_inc.php");
            Environment.CurrentDirectory = TestContext.CurrentContext.TestDirectory;
            using (Stream localFile = File.Open("config_inc.php", FileMode.Open))
            {
                app.Ftp.Upload("/config_inc.php", localFile);
            }
        }
        [Test]
        public void TestAccountRegistration()
        {
            AccountData account = new AccountData
            {
                Name = "TesterovQA",
                Password = "password",
                Email = "testerovQA@localhost.localdomain",
                RealName = "Ivan"
            };

            app.James.Delete(account);
            app.James.Add(account);

            app.Registration.Register(account);
        }

        [OneTimeTearDown]
        public void restoreCofig()
        {
            app.Ftp.RestoreBackupFile("/config_inc.php");
        }
    }
}
