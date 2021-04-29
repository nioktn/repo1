using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace RozetkaLib
{
    public class CartPage
    {
        private readonly AndroidDriver<AndroidElement> _driver;
        private readonly By _cartItems = By.XPath("//androidx.cardview.widget.CardView");
        private readonly By _checkoutOrder = By.XPath("//*[contains(@resource-id, 'll_background')]");
        private readonly By _btnMain = By.XPath("//*[contains(@text, 'Главная')]");
        private readonly By _emptyTitle = By.XPath("//*[contains(@text, 'Корзина пуста')]");
        private readonly By _totalPrice = By.XPath("//*[contains(@resource-id, 'tv_price_total')]");

        public IList<AndroidElement> CartItems { get => _driver.FindElements(_cartItems); }
        public AndroidElement BtnCatalog { get => _driver.FindElement(_btnMain); }
        private AndroidElement EmptyTitle { get => _driver.FindElement(_emptyTitle); }
        public AndroidElement CheckoutOrder { get => _driver.FindElement(_checkoutOrder); }
        public AndroidElement TotalPrice { get => _driver.FindElement(_totalPrice); }

        public CartPage(AndroidDriver<AndroidElement> driver)
        {
            this._driver = driver;
        }

        public String GetTitle(WebDriverWait wait)
        {
            wait.Until((d) => ElemHelper.IsElementVisible(_driver, _emptyTitle));
            return EmptyTitle.Text;
        }

        public IList<AndroidElement> GetCartItems(WebDriverWait wait)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(_cartItems));
            return CartItems;
        }

        public bool IsEmpty()
        {
            return EmptyTitle.Text.Contains("Корзина пуста") & ElemHelper.IsElementExists(_driver, _btnMain);
        }
    }
}
