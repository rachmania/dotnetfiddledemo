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
    /*
     *   Test 2 (If your first name starts with letter “Q-R-S-T-U”):
     *   Click “Save” button
     *   Check that “Log In” window appeared
     */

    public class DotNetFiddleHomeTest
    {
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

            //  Create DotNetFiddleHome instance
            DotNetFiddleHome dnfh = new DotNetFiddleHome(driver);

            //  Navigate to DotNetFiddleHome
            dnfh.GoToDotNetFiddleHomePage();

            //  Get "Log In Modal" object
            dnfh.GetLogInModal();

            //  Get DotNetFiddleHome Save button
            dnfh.GetSaveButton();

            //  Click on the Save button
            dnfh.ClickSaveButton();

            //  Assert that "Log In" modal is displayed; using Shouldly assertion library
            dnfh.GetLogInModal().ShouldBeTrue();

        }

        //  Close browser
        [TearDown]
        public void Shutdown()
        {
            driver.Quit();
        }
    }
}