using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Support.UI;
using System;

namespace RozetkaLib
{
    public class LoginPage
    {
        private readonly AndroidDriver<AndroidElement> driver;
        private readonly By _loginField = By.Id("ua.com.rozetka.shop:id/sign_in_et_login");
        private readonly By _passField = By.Id("ua.com.rozetka.shop:id/sign_in_et_password");
        private readonly By _btnLogin = By.Id("ua.com.rozetka.shop:id/sign_in_tv_login");
        private readonly By _noneOfTheAbove = By.Id("com.google.android.gms:id/cancel");
        // private readonly By _noneOfTheAbove = MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"NONE OF THE ABOVE\")");

        private AndroidElement LoginField { get => driver.FindElement(_loginField); }
        private AndroidElement PassField { get => driver.FindElement(_passField); }
        private AndroidElement BtnLogin { get => driver.FindElement(_btnLogin); }
        private AndroidElement NoneOfTheAboveButton => driver.FindElement(_noneOfTheAbove);

        public LoginPage(AndroidDriver<AndroidElement> driver)
        {
            this.driver = driver;
        }

        public void LogIn(string login, string pass)
        {
            LoginField.SendKeys(login);
            PassField.SendKeys(pass);
            if (!ElemHelper.IsElementVisible(driver, _btnLogin))
            {
                ISendsKeyEvents keyEvents = driver;
                keyEvents.PressKeyCode(AndroidKeyCode.Back);
            }
            BtnLogin.Click();
        }

        public void LogIn(string login, string pass, WebDriverWait wait)
        {
            wait.Until(d => ElemHelper.IsElementVisible(driver, _noneOfTheAbove));
            NoneOfTheAboveButton.Click();
            
            wait.Until(d => ElemHelper.IsElementVisible(driver, _loginField));
            LoginField.SendKeys(login);
            PassField.SendKeys(pass);
            if (!ElemHelper.IsElementVisible(driver, _btnLogin))
            {
                ISendsKeyEvents keyEvents = driver;
                keyEvents.PressKeyCode(AndroidKeyCode.Back);
                wait.Until(d => ElemHelper.IsElementVisible(driver, _btnLogin));
            }
            BtnLogin.Click();
        }
    }
}
