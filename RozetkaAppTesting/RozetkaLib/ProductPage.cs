using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;

namespace RozetkaLib
{
    public class ProductPage
    {
        private AndroidDriver<AndroidElement> driver;
        private readonly By _productName = By.XPath("//android.widget.FrameLayout[1]/android.widget.LinearLayout/android.widget.RelativeLayout[2]/android.widget.TextView");
        private readonly By _productAvailability = By.XPath("//android.widget.RelativeLayout[4]/android.widget.LinearLayout[1]/android.widget.LinearLayout/android.widget.TextView[1]");
        private readonly By _productPrice = By.XPath("android.widget.RelativeLayout[4]/android.widget.LinearLayout[1]/android.widget.LinearLayout/android.widget.TextView[2]");

        public readonly String _allAboutProductTab = "Все о товаре";
        public readonly String _characteristicsTab = "Характеристики";
        public readonly String _commentsTab = "Отзывы";
        public readonly String _accessoriestTab = "Аксессуары";
        public readonly String _toCompare = "В сравнение";
        public readonly String _toCart = "В корзину";
        public readonly String _toWishList = "В список";

        public String ProductName { get => driver.FindElement(_productName).Text; }
        public String ProductAvailability { get => driver.FindElement(_productAvailability).Text; }
        public String ProductPrice { get => driver.FindElement(_productPrice).Text; }
        public AndroidElement AllAboutProductTab { get => driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"" + _allAboutProductTab + "\")")); }
        public AndroidElement CharacteristicsTab { get => driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"" + _characteristicsTab + "\")")); }
        public AndroidElement CommentsTab { get => driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"" + _commentsTab + "\")")); }
        public AndroidElement AccessoriestTab { get => driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"" + _accessoriestTab + "\")")); }
        public AndroidElement ToCompare { get => driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"" + _toCompare + "\")")); }
        public AndroidElement ToCart { get => driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"" + _toCart + "\")")); }
        public AndroidElement ToWishList { get => driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"" + _toWishList + "\")")); }

        public ProductPage(AndroidDriver<AndroidElement> driver)
        {
            this.driver = driver;
        }
    }
}
