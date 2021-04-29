using NUnit.Framework;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;

namespace RozetkaTests
{
    public class HollowTest
    {
        protected AndroidDriver<AndroidElement> driver;
        protected WebDriverWait wait;
        DesiredCapabilities capabilities;

        [OneTimeSetUp]
        public virtual void FirstInitialize()
        {
            capabilities = new DesiredCapabilities();
            capabilities.SetCapability(MobileCapabilityType.App, @"C:\Users\Nikita\source\repos\Mobile_testing\Rozetka+v2.21.6.apk");
            capabilities.SetCapability(MobileCapabilityType.DeviceName, "emulator-5554");
            capabilities.SetCapability(MobileCapabilityType.Udid, "emulator-5554");
            capabilities.SetCapability(MobileCapabilityType.PlatformVersion, "6.0.0");
            capabilities.SetCapability(MobileCapabilityType.PlatformName, "Android");
            capabilities.SetCapability(MobileCapabilityType.FullReset, "false");
        }

        [SetUp]
        public virtual void Initialize()
        {
            driver = new AndroidDriver<AndroidElement>(new Uri("http://localhost:4723/wd/hub"), capabilities);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
        }

        [TearDown]
        public virtual void CleanUp()
        {
            driver.CloseApp();
        }

        [OneTimeTearDown]
        public virtual void LastCleanUp()
        {
            driver.Quit();
        }
    }
}
