using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Szkolenie2602
{
    public class WebTest
    {
        ChromeDriver driver;

        [Test]
        public void SearchGoogle()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com");

            driver.FindElement(By.Name("q")).SendKeys("Look4App");

            Thread.Sleep(1000);

            driver.FindElement(By.Name("btnK")).Click();

            Assert.That(driver.Title.Contains("Look4App"));

            driver.Quit();

        }
    }
}
