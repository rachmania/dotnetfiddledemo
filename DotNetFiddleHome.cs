using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetFiddleDemo
{
    class DotNetFiddleHome
    {

        //  Create instance of WebDriver and WebDriverWait
        private IWebDriver driver;
        private WebDriverWait wait;

        //  Create url object
        public string fiddleUrl = "https://dotnetfiddle.net/";

        //  Constructor
        public DotNetFiddleHome(IWebDriver driver)
        {

            this.driver = driver;

            //  Wait for page to load
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);

            //  Maximize window
            driver.Manage().Window.Maximize();

        }

        //  Create "Save" button object
        [FindsBy(How= How.Id, Using= "save-button")]
        [CacheLookup]
        private IWebElement saveButton;

        //  Create "Log In" modal object
        [FindsBy(How = How.ClassName, Using = "modal-content")]
        [CacheLookup]
        private IWebElement loginModal;

        //  Navigate to DotNetFiddle.net
        public void GoToDotNetFiddleHomePage()
        {
            driver.Navigate().GoToUrl(fiddleUrl);
        }

        //  Return Page Title
        public String GetPageTitle()
        {
            return driver.Title;
        }

        //  Verify that the "Save" button is displayed
        public bool GetSaveButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            saveButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("save-button")));
            return saveButton.Displayed;
        }

        //  Click the "Save" button
        public void ClickSaveButton()
        {
            saveButton.Click();
        }

        //  Verify that the "Log In" modal is displayed
        public bool GetLogInModal()
        {
            loginModal = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("save-button")));
            return loginModal.Displayed;
        }
    }
}
