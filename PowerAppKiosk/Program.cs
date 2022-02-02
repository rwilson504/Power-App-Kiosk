using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace PowerAppKiosk
{
    class Program
    {
        static void Main(string[] args)
        {
            SetDefaultConfigEncryption(true);

            var user = ConfigurationManager.AppSettings["dvuser"];
            var pass = ConfigurationManager.AppSettings["dvpass"];

            String test_url = ConfigurationManager.AppSettings["url"];
            test_url += string.Format(@"&hidenavbar=true&machinename={0}", Environment.MachineName);

            EdgeOptions edgeOptions = new EdgeOptions() { };
            edgeOptions.AddArgument("inprivate");
            edgeOptions.AddExcludedArgument("enable-automation");
            edgeOptions.AddArgument("--kiosk");
            IWebDriver driver = new EdgeDriver(edgeOptions);            

            driver.Url = test_url;
            System.Threading.Thread.Sleep(3000);

            IWebElement emailField = driver.FindElement(By.Id("i0116"));
            emailField.SendKeys(user);

            System.Threading.Thread.Sleep(3000);
            IWebElement nextButton = driver.FindElement(By.Id("idSIButton9"));
            nextButton.Click();

            System.Threading.Thread.Sleep(3000);
            IWebElement passwordField = driver.FindElement(By.Id("i0118"));
            passwordField.SendKeys(pass);

            System.Threading.Thread.Sleep(3000);
            IWebElement nextPassword = driver.FindElement(By.Id("idSIButton9"));
            nextPassword.Click();

            System.Threading.Thread.Sleep(3000);
            IWebElement noButton = driver.FindElement(By.Id("idBtn_Back"));
            noButton.Click();

            Console.WriteLine("Test Passed");
        }

        private static void SetDefaultConfigEncryption(bool encrypt)
        {
            SetConfigSectionEncryption(encrypt, "appSettings");
        }

        private static void SetConfigSectionEncryption(bool encrypt, string sectionKey)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConfigurationSection section = config.GetSection(sectionKey);
            if (section != null)
            {
                if (encrypt && !section.SectionInformation.IsProtected)
                {
                    section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
                }
                if (!encrypt && section.SectionInformation.IsProtected)
                {
                    section.SectionInformation.UnprotectSection();
                }
                section.SectionInformation.ForceSave = true;
                config.Save(ConfigurationSaveMode.Full);
            }
        }
    }
}
