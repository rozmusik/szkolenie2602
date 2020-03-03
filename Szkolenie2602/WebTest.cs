using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace Szkolenie2602
{
    public class WebTest
    {
        ChromeDriver driver;

        [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            driver = new ChromeDriver(options);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void SearchGoogle()
        {
            driver.Navigate().GoToUrl("https://www.google.com");

            driver.FindElement(By.Name("q")).SendKeys("Look4App");

            Thread.Sleep(1000);

            driver.FindElement(By.Name("btnK")).Click();

            Assert.That(driver.Title.Contains("Look4App"));
        }

        [Test]
        public void SearchElementsByAllSelector()
        {
            driver.Navigate().GoToUrl("https://www.phptravels.net/home");

            var header = driver.FindElement(By.Id("header-waypoint-sticky"));
            var rightArrow = driver.FindElement(By.ClassName("slick-next"));
            var search = driver.FindElement(By.CssSelector("#hotels .btn-block"));
            var faq = driver.FindElement(By.LinkText("FAQ"));
            var visa = driver.FindElement(By.XPath("//*[@id=\"mobileMenuMain\"]/nav/ul[2]/li[1]/a"));
            var firstDisplayedInput = driver.FindElements(By.TagName("input")).First(d=>d.Displayed);

            // elementy w elemencie
            var buttonsTable = driver.FindElement(By.ClassName("menu-horizontal-02"));
            var categories = buttonsTable.FindElements(By.TagName("li"));
            var tours = categories[2];
            tours.Click();
        }

        [Test]
        public void SelectDropDown()
        {
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/dropdown");

            var dropdownSelector = driver.FindElement(By.Id("dropdown"));
            var dropdown = new SelectElement(dropdownSelector);
            dropdown.SelectByIndex(2);
            dropdown.SelectByValue("1");
            dropdown.SelectByText("Option 2");

            Assert.AreEqual("Option 2", dropdown.SelectedOption.Text);
        }

        [Test]
        public void SelectNonDropDown()
        {
            driver.Navigate().GoToUrl("https://www.phptravels.net/home");

            var dropDownCurrency = driver.FindElement(By.Id("dropdownCurrency"));
            dropDownCurrency.Click();

            var eur = driver.FindElement(By.LinkText("EUR"));
            eur.Click();

            Thread.Sleep(1000);

            var currentCurrency = driver.FindElement(By.Id("dropdownCurrency")).Text;

            Assert.AreEqual("EUR", currentCurrency);
        }
    }
}
