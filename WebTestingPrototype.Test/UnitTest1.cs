using System.IO;
using System.Reflection;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebTestingPrototype.Test
{
    public class Tests
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
        }

        [Test]
        public void Test()
        {
            _driver.Url = "https://www.google.de";
        }

        [TearDown]
        public void Close()
        {
            _driver.Close();
        }
    }
}