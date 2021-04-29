using System;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;

namespace RozetkaTests
{
    public class BaseTest
    {
        protected AndroidDriver<AndroidElement> driver;
        protected WebDriverWait wait;

        private AppiumOptions options;


        [OneTimeSetUp]
        public virtual void FirstInitialize()
        {
            options = new AppiumOptions();
            options.AddAdditionalCapability("app", "/home/nikita/Downloads/Rozetka+5.1.0-50100.apk");
            options.AddAdditionalCapability("udid", "R58N84BWTVA");
            options.AddAdditionalCapability("deviceName", "R58N84BWTVA");
            options.AddAdditionalCapability("fullReset", "false");
            options.AddAdditionalCapability("platformName", "Android");
        }
        
        [SetUp]
        public virtual void Initialize()
        {
            driver = new AndroidDriver<AndroidElement>(new Uri("http://localhost:4723/wd/hub"), options);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
        }

        [OneTimeTearDown]
        public virtual void LastCleanUp()
        {
            driver.Quit();
        }
    }
}