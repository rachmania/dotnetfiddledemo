using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Shouldly;
using System;
using System.Security.Policy;
using Xunit.Sdk;

namespace DotNetFiddleDemo
{
    public class DotNetFiddleDemo
    {
        //  Identify URL
        string test_url = "https://dotnetfiddle.net/";
        
        //  Declare WebDriver instance
        IWebDriver driver;

        //  Launch browser
        [SetUp]
        public void Startup()
        {
            //  Specify Chromedriver (make sure it's installed in same directory as Chrome executable)
            driver = new ChromeDriver();
        }

        //  Click "Save" button method
        [Test]
        public void SaveFiddle() {

            //  Navigate to test_url
            driver.Url = test_url;

            //  Maximize window
            driver.Manage().Window.Maximize();

            //  Implement wait for page to load
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //  Create element and implement wait for "Save" button to be **clickable**
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            IWebElement saveButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("save-button")));

            //  Click "Save" button
            saveButton.Click();

            //  Implement wait for "Log In" modal to be **visible**
            WebDriverWait waiting = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            IWebElement loginModal = waiting.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("modal-content")));

            //  Assert that "Log In" modal is displayed; using Shouldly assertion library
            loginModal.Displayed.ShouldBe(true);

        }

        //  Close browser
        [TearDown]
        public void Shutdown()
        {
            driver.Quit();
        }
    }
}