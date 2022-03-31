using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using System;

namespace TestFabricSln.Test
{
    public class SeleniumTest
    {
        private IWebDriver _webDriver;

        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);

            //DesiredCapabilities capabilities = new DesiredCapabilities();
            //capabilities.setCapability("something", true);

            ChromeOptions option = new ChromeOptions();
            option.AddArgument("--headless");
            option.AddArgument("--disable-gpu");
            option.AddArguments("--window-size=1280,800");
            option.AddArguments("--allow-insecure-localhost");

            //specifically this line here :)
            option.AddAdditionalCapability("acceptInsecureCerts", true, true);

            //options.merge(capabilities);

            _webDriver = new ChromeDriver(option);
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);            
        }

        [Test]
        [Category("UITests")]
        public void VisitMicrosoft_CheckWindowsMenu()
        {
            _webDriver.Navigate().GoToUrl("https://www.microsoft.com/");
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            IWebElement winMenu = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_webDriver.FindElement(By.Id("shellmenu_2"))));

            Assert.AreEqual("Windows", winMenu.Text);
        }

        [TearDown]
        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}
