using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace RozetkaLib
{
    public class SearchPage
    {
        private readonly AndroidDriver<AndroidElement> driver;
        private readonly By _srchOpenButton = By.Id("ua.com.rozetka.shop:id/action_search");
        private readonly By _srchInputField = By.Id("ua.com.rozetka.shop:id/et_search_section");
        private readonly By _srchOpenField = By.Id("ua.com.rozetka.shop:id/ll_search");
        private readonly By _srchBackButton = By.Id("ua.com.rozetka.shop:id/iv_back_btn");
        private readonly By _srchClearButton = By.Id("ua.com.rozetka.shop:id/iv_clear_btn");

        public AndroidElement SearchOpenButton { get => driver.FindElement(_srchOpenButton); }
        public AndroidElement SearchInputField { get => driver.FindElement(_srchInputField); }
        public AndroidElement SearchOpenField { get => driver.FindElement(_srchOpenField); }
        public AndroidElement SrchBackButton { get => driver.FindElement(_srchBackButton); }
        public AndroidElement SrchClearButton { get => driver.FindElement(_srchClearButton); }

        public SearchPage(AndroidDriver<AndroidElement> driver)
        {
            this.driver = driver;
        }

        public SearchPage Open(WebDriverWait wait)
        {
            if (ElemHelper.IsElementVisible(driver, _srchOpenButton))
            {
                SearchOpenButton.Click();
            }
            else if (ElemHelper.IsElementVisible(driver, _srchOpenField))
            {
                SearchOpenField.Click();
            }
            ISendsKeyEvents sendsKeyEvents = driver;
            wait.Until((d) => ElemHelper.IsElementExists(d, _srchInputField));
            Thread.Sleep(1000);
            sendsKeyEvents.PressKeyCode(AndroidKeyCode.Back);
            return this;
        }

        public void EnterSearchQuery(String query, WebDriverWait wait)
        {
            wait.Until((d) => ElemHelper.IsElementVisible(driver, _srchInputField));
            SearchInputField.SendKeys(query);
            ISendsKeyEvents sendsKeyEvents = driver;
            SearchInputField.Click();

            SearchInputField.SendKeys(Keys.Enter);
            sendsKeyEvents.PressKeyCode(AndroidKeyCode.KeycodeNumpad_ENTER);
            sendsKeyEvents.PressKeyCode(AndroidKeyCode.Enter);
            sendsKeyEvents.PressKeyCode(AndroidKeyCode.Keycode_ENTER);
            sendsKeyEvents.PressKeyCode(AndroidKeyCode.Keycode_SEARCH);
            sendsKeyEvents.PressKeyCode(66);
        }
    }
}
