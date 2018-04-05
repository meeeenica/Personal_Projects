using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class TestCase
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost:46918/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser 
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void NameTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/AddCar.aspx");
            driver.FindElement(By.Id("fname")).SendKeys("");
            driver.FindElement(By.Id("lname")).SendKeys("");
            driver.FindElement(By.Id("submit")).Click();
            string nameTest = driver.FindElement(By.Id("lblemptyField")).Text;
            Assert.AreEqual("Please Enter Firstname and Lastname.", nameTest);
        }

        [Test]
        public void AddressBlankTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/AddCar.aspx");
            driver.FindElement(By.Id("address")).SendKeys("");
            driver.FindElement(By.Id("submit")).Click();
            string addresstest = driver.FindElement(By.Id("lblemptyFieldAddress")).Text;
            Assert.AreEqual("Please Enter Address.", addresstest);
        }

        [Test]
        public void CarDetailsBlankTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/AddCar.aspx");
            driver.FindElement(By.Id("model")).SendKeys("");
            driver.FindElement(By.Id("year")).SendKeys("");
            driver.FindElement(By.Id("price")).SendKeys("");
            driver.FindElement(By.Id("submit")).Click();
            string cardetails = driver.FindElement(By.Id("lblemptyFieldCar")).Text;
            Assert.AreEqual("Please Enter Complete Car Details.", cardetails);
        }

        [Test]
        [TestCase("@com")]
        [TestCase("1@a")]
        [TestCase(".com")]
        public void TheEmaiLTest(string email)
        {
            driver.Navigate().GoToUrl(baseURL + "/AddCar.aspx");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //driver.FindElement(By.XPath("/html/body/div[@class='container marketing']/form[@id='ctl01']/div[@class='featurette'][1]/div[@class='lead']/input[@id='email']")).SendKeys(email);
            driver.FindElement(By.Id("email")).SendKeys(email);
            driver.FindElement(By.Id("phone")).Click();
            //string emailTest = driver.FindElement(By.XPath("/html/body/div[@class='container marketing']/form[@id='ctl01']/div[@class='featurette'][1]/div[@class='lead']/span[@id='RegularExpressionValidator1']")).Text;
            string emailTest = driver.FindElement(By.Id("RegularExpressionValidator1")).Text;
            Assert.AreEqual("Invalid Email.", emailTest);
        }

        [Test]
        [TestCase("1")]
        [TestCase("22694597")]
        [TestCase("(1234567891)")]
        public void PhoneTest(string phone)
        {
            driver.Navigate().GoToUrl(baseURL + "/AddCar.aspx");
            driver.FindElement(By.XPath("/html/body/div[@class='container marketing']/form[@id='ctl01']/div[@class='featurette'][1]/div[@class='lead']/input[@id='phone']")).SendKeys(phone);
            driver.FindElement(By.Id("email")).Click();
            string emailTest = driver.FindElement(By.Id("regexpName")).Text;
            //string emailTest = driver.FindElement(By.XPath("/html/body/div[@class='container marketing']/form[@id='ctl01']/div[@class='featurette'][1]/div[@class='lead']/span[@id='regexpName']")).Text;
            Assert.AreEqual("Invalid Phone number.", emailTest);
        }
        
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
