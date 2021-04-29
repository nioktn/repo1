using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace RozetkaLib
{
    public class CartPage
    {
        private readonly AndroidDriver<AndroidElement> driver;
        private readonly By _cartItems = By.XPath("//android.support.v7.widget.RecyclerView/android.widget.FrameLayout");
        private readonly By _checkoutOrder = By.XPath("//*[contains(@resource-id, 'll_background')]");
        private readonly By _btnMain = By.XPath("//*[contains(@text, 'Главная')]");
        private readonly By _emptyTitle = By.XPath("//*[contains(@text, 'Корзина пуста')]");
        private readonly By _totalPrice = By.XPath("//*[contains(@resource-id, 'tv_price_total')]");

        public IList<AndroidElement> CartItems { get => driver.FindElements(_cartItems); }
        public AndroidElement BtnCatalog { get => driver.FindElement(_btnMain); }
        public AndroidElement EmptyTitle { get => driver.FindElement(_emptyTitle); }
        public AndroidElement CheckoutOrder { get => driver.FindElement(_checkoutOrder); }
        public AndroidElement TotalPrice { get => driver.FindElement(_totalPrice); }

        public CartPage(AndroidDriver<AndroidElement> driver)
        {
            this.driver = driver;
        }

        public String GetTitle(WebDriverWait wait)
        {
            wait.Until((d) => ElemHelper.IsElementVisible(driver, _emptyTitle));
            return EmptyTitle.Text;
        }

        public IList<AndroidElement> GetCartItems(WebDriverWait wait)
        {
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(_cartItems));
            return CartItems;
        }

        public bool IsEmpty()
        {
            return EmptyTitle.Text.Contains("Корзина пуста") & ElemHelper.IsElementExists(driver, _btnMain);
        }
    }
}
