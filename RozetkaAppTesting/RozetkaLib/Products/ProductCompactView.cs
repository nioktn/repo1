using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace RozetkaLib
{
    public class ProductCompactView
    {
        private readonly AndroidDriver<AndroidElement> driver;
        private readonly AndroidElement baseElement;
        private readonly By _oldPrice = MobileBy.AndroidUIAutomator("new UiSelector().resourceId(\"ua.com.rozetka.shop:id/view_price_2_tv_old_price\")");
        private readonly By _newPrice = MobileBy.AndroidUIAutomator("new UiSelector().resourceId(\"ua.com.rozetka.shop:id/view_price_2_tv_price\")");
        private readonly By _productName = MobileBy.AndroidUIAutomator("new UiSelector().resourceId(\"ua.com.rozetka.shop:id/tv_title\")");
        private readonly By _btnAddToCart = MobileBy.AndroidUIAutomator("new UiSelector().resourceId(\"ua.com.rozetka.shop:id/iv_cart\")");
        private readonly By _btnAddToWishList = MobileBy.AndroidUIAutomator("new UiSelector().resourceId(\"ua.com.rozetka.shop:id/iv_wish\")");
        private readonly By _btnSettings = By.XPath("//*[contains(@resource-id, 'iv_menu')]");
        private readonly By _btnDelete = By.XPath("//android.widget.LinearLayout");
        private readonly By _settingsOptions = By.XPath("//android.widget.FrameLayout/android.widget.ListView/android.widget.LinearLayout");
        private readonly By _btnSettingsDelete = By.XPath("//*[contains(@text, 'Удалить товар')]");

        public AndroidElement OldPrice { get => baseElement.FindElement(_oldPrice) as AndroidElement; }
        public AndroidElement NewPrice { get => baseElement.FindElement(_newPrice) as AndroidElement; }
        public AndroidElement ProductName { get => baseElement.FindElement(_productName) as AndroidElement; }
        public AndroidElement BtnAddToCart { get => baseElement.FindElement(_btnAddToCart) as AndroidElement; }
        public AndroidElement BtnAddToWishList { get => baseElement.FindElement(_btnAddToWishList) as AndroidElement; }
        public AndroidElement BtnSettings { get => baseElement.FindElement(_btnSettings) as AndroidElement; }
        public AndroidElement BtnSettingsDelete { get => driver.FindElement(_btnSettingsDelete) as AndroidElement; }
        public IList<AndroidElement> SettingsOptions { get => driver.FindElements(_settingsOptions) as IList<AndroidElement>; }

        public ProductCompactView(AndroidDriver<AndroidElement> driver, AndroidElement baseElement)
        {
            this.driver = driver;
            this.baseElement = baseElement;
        }

        public void DeleteFromWishList()
        {
            BtnSettings.Click();
        }

        public String GetTitle(WebDriverWait wait)
        {
            wait.Until((d) => ElemHelper.IsElementVisible(driver, _productName, baseElement));
            return ProductName.Text;
        }

        public void AddToWishList()
        {
            BtnAddToWishList.Click();
        }

        public void AddToWishList(WebDriverWait wait)
        {
            wait.Until((d) => ElemHelper.IsElementVisible(driver, _btnAddToWishList, baseElement));
            BtnAddToWishList.Click();
        }

        public void AddToCart()
        {
            BtnAddToWishList.Click();
        }

        public void AddToCart(WebDriverWait wait)
        {
            wait.Until((d) => ElemHelper.IsElementVisible(driver, _btnAddToCart, baseElement));
            BtnAddToCart.Click();
        }

        public AndroidElement SelectFromSettings(String option)
        {
            foreach (var item in SettingsOptions)
            {
                if (item.FindElement(By.XPath(".//android.widget.TextView")).Text.Contains(option)) return item;
            }
            return null;
        }

        public bool IsProductTitleVisible()
        {
            return ElemHelper.IsElementVisible(driver, _productName, baseElement);
        }

        public void OpenProductSettings(WebDriverWait wait)
        {
            wait.Until((d) => ElemHelper.IsElementVisible(driver, _btnSettings, baseElement));
            baseElement.FindElement(_btnSettings).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(_settingsOptions));
        }

        public void DeleteFromWishList(WebDriverWait wait)
        {
            OpenProductSettings(wait);
            SelectFromSettings("Удалить товар").Click();
        }
    }
}
