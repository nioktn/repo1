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
        private readonly By _loginField = By.Id("ua.com.rozetka.shop:id/f_sign_in_et_login");
        private readonly By _passField = By.Id("ua.com.rozetka.shop:id/f_sign_in_et_password");
        private readonly By _btnLogin = By.Id("ua.com.rozetka.shop:id/ll_background");

        public AndroidElement LoginField { get => driver.FindElement(_loginField); }
        public AndroidElement PassField { get => driver.FindElement(_passField); }
        public AndroidElement BtnLogin { get => driver.FindElement(_btnLogin); }

        public LoginPage(AndroidDriver<AndroidElement> driver)
        {
            this.driver = driver;
        }

        public void LogIn(String login, String pass)
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

        public void LogIn(String login, String pass, WebDriverWait wait)
        {
            wait.Until((d) => ElemHelper.IsElementVisible(driver, _loginField));
            LoginField.SendKeys(login);
            PassField.SendKeys(pass);
            if (!ElemHelper.IsElementVisible(driver, _btnLogin))
            {
                ISendsKeyEvents keyEvents = driver;
                keyEvents.PressKeyCode(AndroidKeyCode.Back);
                wait.Until((d) => ElemHelper.IsElementVisible(driver, _btnLogin));
            }
            BtnLogin.Click();
        }
    }
}
