using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Runtime.CompilerServices;
using OpenQA.Selenium.Appium.Android.UiAutomator;

namespace RozetkaLib
{
    public static class ElemHelper
    {
        public static bool IsElementVisible(IWebDriver driver, By Locator)
        {
            try { return driver.FindElement(Locator).Displayed; }
            catch { return false; }
        }

        public static bool IsElementVisible(IWebDriver driver, By Locator, AndroidElement baseElement)
        {
            try { return baseElement.FindElement(Locator).Displayed; }
            catch { return false; }
        }

        public static bool IsElementExists(IWebDriver driver, By Locator)
        {
            try
            {
                driver.FindElement(Locator);
                return true;
            }
            catch { return false; }
        }

        public static void ScrollToElement(AndroidDriver<AndroidElement> driver, String textContent)
        {
            driver.FindElement(MobileBy.AndroidUIAutomator("new UiScrollable(new UiSelector().scrollable(true).instance(0)).scrollIntoView(new UiSelector().textContains(\"" + textContent + "\").instance(0))"));
        }

        public static void ScrollToResourceId(AndroidDriver<AndroidElement> driver, String resourceId)
        {
            driver.FindElement(MobileBy.AndroidUIAutomator("new UiScrollable(new UiSelector().scrollable(true).instance(0)).scrollIntoView(new UiSelector().resourceId(\"" + resourceId + "\").instance(0))"));
        }

        public static void ScrollToUiSelector(AndroidDriver<AndroidElement> driver, String UiSelector)
        {
            driver.FindElement(MobileBy.AndroidUIAutomator("new UiScrollable(new UiSelector().scrollable(true).instance(0)).scrollIntoView(" + UiSelector + ").instance(0)"));
        }
    }
}