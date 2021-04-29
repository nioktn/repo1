using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace RozetkaLib
{
    public class CartItemView
    {
        private readonly AndroidDriver<AndroidElement> driver;
        private readonly AndroidElement baseElement;
        private readonly By _itemTitle = By.XPath(".//*[contains(@resource-id, 'ua.com.rozetka.shop:id/item_cart_offer_tv_title')]");
        private readonly By _itemSeller = By.XPath(".//*[contains(@resource-id, 'tv_cart_offer_item_seller')]");
        private readonly By _btnQtyMinus = By.XPath(".//*[contains(@resource-id, 'tv_minus')]");
        private readonly By _btnQtyPlus = By.XPath(".//*[contains(@resource-id, 'tv_plus')]");
        private readonly By _itemsQty = By.XPath(".//*[contains(@resource-id, 'tv_value')]");
        private readonly By _itemPrice = By.XPath(".//*[contains(@resource-id, 'tv_cart_offer_item_price')]");
        private readonly By _btnSettings = By.XPath(".//*[contains(@resource-id, 'ua.com.rozetka.shop:id/item_cart_offer_iv_menu')]");
        private readonly By _settingsOptions = By.XPath("//android.widget.FrameLayout/android.widget.ListView/android.widget.LinearLayout");

        public AndroidElement ItemTitle { get => baseElement.FindElement(_itemTitle) as AndroidElement; }
        public AndroidElement ItemSeller { get => baseElement.FindElement(_itemSeller) as AndroidElement; }
        public AndroidElement BtnQtyMinus { get => baseElement.FindElement(_btnQtyMinus) as AndroidElement; }
        public AndroidElement BtnQtyPlus { get => baseElement.FindElement(_btnQtyPlus) as AndroidElement; }
        public AndroidElement ItemsQty { get => baseElement.FindElement(_itemsQty) as AndroidElement; }
        public AndroidElement ItemPrice { get => baseElement.FindElement(_itemPrice) as AndroidElement; }
        public AndroidElement BtnSettings { get => baseElement.FindElement(_btnSettings) as AndroidElement; }
        public IList<AndroidElement> SettingsOptions { get => driver.FindElements(_settingsOptions) as IList<AndroidElement>; }

        public CartItemView(AndroidDriver<AndroidElement> driver, AndroidElement baseElement)
        {
            this.driver = driver;
            this.baseElement = baseElement;
        }

        public void DeleteFromCart(WebDriverWait wait)
        {
            OpenProductSettings(wait);
            SelectFromSettings("Удалить из корзины").Click();
        }

        public String GetTitle(WebDriverWait wait)
        {
            wait.Until(d => ElemHelper.IsElementVisible(driver, _itemTitle, baseElement));
            return ItemTitle.Text;
        }

        public AndroidElement SelectFromSettings(String option)
        {
            foreach (var item in SettingsOptions)
            {
                if (item.FindElement(By.XPath(".//*[contains(@resource-id, 'ua.com.rozetka.shop:id/title')]")).Text.Contains(option)) return item;
            }
            return null;
        }

        public void OpenProductSettings(WebDriverWait wait)
        {
            wait.Until((d) => ElemHelper.IsElementVisible(driver, _btnSettings, baseElement));
            baseElement.FindElement(_btnSettings).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(_settingsOptions));
        }
    }
}
