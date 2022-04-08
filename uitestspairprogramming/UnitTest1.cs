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

            [TestMethod]
            public void TestAddition()
            {
                //string url = "file:C:\\Users\\syv22\\OneDrive\\Dokumenter\\1.Datamatiker_ting\\3.SemesteV2\\Programmering\\Vue\\Calculator\\Index.html";
                string url = "file:C:\\Users\\syv22\\OneDrive\\Dokumenter\\1.Datamatiker_ting\\3.SemesteV2\\Programmering\\GetPostDelete\\Index.html";

                _driver.Navigate().GoToUrl(url);
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
                IWebElement inputElement1 = wait.Until(d => d.FindElement(By.Id("getBookId")));
                inputElement1.SendKeys("2");



                IWebElement buttonElement = _driver.FindElement(By.Id("getBookIdButton"));
                buttonElement.Click();


                IWebElement foundBook = wait.Until(d => d.FindElement(By.Id("foundBookById")));


                Assert.IsTrue(foundBook.Text.Contains(""));
            }


        }
    
}
