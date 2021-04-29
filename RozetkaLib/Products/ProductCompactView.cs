using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RozetkaLib
{
    public class ProductCompactView
    {
        private readonly AndroidDriver<AndroidElement> driver;
        private readonly AndroidElement baseElement;
        private readonly By _oldPrice = By.XPath(".//*[contains(@resource-id, 'ua.com.rozetka.shop:id/view_price_tv_old_price')]");
        private readonly By _newPrice = By.XPath(".//*[contains(@resource-id, 'ua.com.rozetka.shop:id/view_price_ll_price')]");
        private readonly By _productName = By.XPath(".//*[contains(@resource-id, 'ua.com.rozetka.shop:id/section_offer_tv_title')]");
        private readonly By _btnAddToCart = By.XPath(".//*[contains(@resource-id, 'ua.com.rozetka.shop:id/section_offer_cv_cart')]");
        private readonly By _btnAddToWishList = By.XPath(".//*[contains(@resource-id, 'ua.com.rozetka.shop:id/section_offer_fl_wish')]");
        
        private readonly By _btnSettings = By.XPath(".//*[contains(@resource-id, 'ua.com.rozetka.shop:id/item_wishlist_offer_fl_menu')]");
        private readonly By _btnDelete = By.XPath("//android.widget.LinearLayout]");
        private readonly By _btnSettingsDelete = By.XPath(".//*[contains(@resource-id, 'ua.com.rozetka.shop:id/title')]");

        public AndroidElement OldPrice { get => baseElement.FindElement(_oldPrice) as AndroidElement; }
        public AndroidElement NewPrice { get => baseElement.FindElement(_newPrice) as AndroidElement; }
        public AndroidElement ProductName { get => baseElement.FindElement(_productName) as AndroidElement; }
        public AndroidElement BtnAddToCart { get => baseElement.FindElement(_btnAddToCart) as AndroidElement; }
        public AndroidElement BtnAddToWishList { get => baseElement.FindElement(_btnAddToWishList) as AndroidElement; }
        public AndroidElement BtnSettings { get => baseElement.FindElement(_btnSettings) as AndroidElement; }
        public AndroidElement BtnSettingsDelete { get => driver.FindElement(_btnSettingsDelete) as AndroidElement; }

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
            return baseElement.FindElements(_productName).Any() ? ProductName.Text : string.Empty;
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
        
        public bool IsProductTitleVisible()
        {
            return ElemHelper.IsElementVisible(driver, _productName, baseElement);
        }
        
        public void DeleteFromWishList(WebDriverWait wait)
        {
            wait.Until(d => ElemHelper.IsElementVisible(driver, _btnSettings));
            driver.FindElement(_btnSettings).Click();
            wait.Until(d => ElemHelper.IsElementVisible(driver, _btnSettingsDelete));
            BtnSettingsDelete.Click();
        }
    }
}
