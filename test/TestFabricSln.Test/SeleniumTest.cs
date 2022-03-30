using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace TestFabricSln.Test
{
    class SeleniumTest
    {
        [Test]
        [Category("UITests")]
        public void VisitMicrosoft_CheckWindowsMenu()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.microsoft.com/");
            Thread.Sleep(10000);
            string Windows_Text = driver.FindElement(By.Id("shellmenu_2")).Text;
            Assert.AreEqual("Windows", Windows_Text);
            driver.Quit();
        }
    }
}
