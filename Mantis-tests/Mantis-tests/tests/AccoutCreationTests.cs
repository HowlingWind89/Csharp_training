﻿using System;
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
                Name = "TesterovQA1",
                Password = "password",
                Email = "testerovQA1@localhost.localdomain",
                RealName = "Ivan"
            };

            List<AccountData> accounts = app.Admin.GetAllAccouts();

            AccountData existingAccount = accounts.Find(x => x.Name == account.Name);

            if(existingAccount != null)
            {
                app.Admin.DeleteAccout(existingAccount);
            }

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
