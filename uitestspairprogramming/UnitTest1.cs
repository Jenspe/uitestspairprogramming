using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;  
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
namespace uitestspairprogramming
{
        
        [TestClass]
        public class UnitTest1
        {
        private static readonly string DriverDirectory = "C:\\Users\\syv22\\OneDrive\\Dokumenter\\1.Datamatiker_ting\\Web_drivers";
        //private static readonly string DriverDirectory = "C:\\Users\\jens6\\source\\repos\\chromedriver";

        private static IWebDriver _driver;

            [ClassInitialize]
            public static void Setup(TestContext context)
            {
                _driver = new ChromeDriver(DriverDirectory); // fast
                                                             //_driver = new FirefoxDriver(DriverDirectory);  // slow
                                                             //_driver = new EdgeDriver(DriverDirectory); //  not working ... now working

            }
            [ClassCleanup]
            public static void TearDown()
            {
                _driver.Dispose();
            }
            string url = "https://pairprogramminghtml.azurewebsites.net/";

        [TestMethod]
        public void TestGetAll()
        {

            _driver.Navigate().GoToUrl(url);
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement buttonElement = _driver.FindElement(By.Id("getAllButton"));
            buttonElement.Click();

            //IWebElement inputElement1 = wait.Until(d => d.FindElement(By.Id("getBookId")));
            //inputElement1.SendKeys("2");



            IWebElement foundRecord = wait.Until(d => d.FindElement(By.Id("Recordslist")));


            Assert.IsTrue(foundRecord.Text.Contains("Ben"));
        }
        [TestMethod]
        public void TestGetById()
        {

            _driver.Navigate().GoToUrl(url);
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement inputElement1 = wait.Until(d => d.FindElement(By.Id("GetByIdInput")));
            inputElement1.SendKeys("1");
            IWebElement buttonElement = _driver.FindElement(By.Id("GetByIdButton"));
            buttonElement.Click();


            IWebElement foundRecord = wait.Until(d => d.FindElement(By.Id("FoundRecord")));


            Assert.IsTrue(foundRecord.Text.Contains("John"));
        }


    }

}
    

