using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;

namespace RozetkaLib
{
    public class RegistrationPage
    {
        private readonly AndroidDriver<AndroidElement> driver;
        private readonly By _loginField = By.Id("ua.com.rozetka.shop:id/f_sign_in_et_login");
        private readonly By _passField = By.Id("ua.com.rozetka.shop:id/f_sign_in_et_password");

        public AndroidElement LoginField { get => driver.FindElement(_loginField); }
        public AndroidElement PassField { get => driver.FindElement(_passField); }
    }
}
