using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Android;
using RozetkaLib;

namespace RozetkaTests
{
    public class CartTests : BaseTest
    {
        private NavigationPanel _navPanel;
        private const string TestEmail = "testmail@outlook.com";
        private const string TestPassword = "Testpassword1";
        private const string ExpectedEmptyCartTitle = "Корзина пуста";

        private const string LaptopsCategoryTitle = "Ноутбуки и компьютеры";

        private List<string> _laptopsModels =
            new List<string> {"20QV00CERT", "6CK24AV_V2", "6WS50EA"};

        [Test]
        public void Test_AccountCartOpen()
        {
            _navPanel = new NavigationPanel(driver);
            wait.Until(d => _navPanel.IsNavigationPanelOpened());
            _navPanel.OpenMore(wait)
                .OpenLoginPage(wait)
                .LogIn(TestEmail, TestPassword, wait);

            var cartPage = _navPanel
                .OpenCart(wait);

            var actualTitle = cartPage.GetTitle(wait);
            StringAssert.AreEqualIgnoringCase(ExpectedEmptyCartTitle, actualTitle);
        }

        [Test]
        public void Test_CartAddRemoveItems()
        {
            // var res1 = driver.FindElements(By.XPath("//*[contains(@resource-id, 'ua.com.rozetka.shop:id/section_offer_cl_layout')]"));
            // var res2 = res1.First()
            //     .FindElements(By.XPath("//*[contains(@resource-id, 'ua.com.rozetka.shop:id/section_offer_tv_title')]"));
            //
            var laptopsAddedToCart = AddLaptopsToCart();
            var laptopsRemovedFromCart = RemoveLaptopsFromCart();
            Assert.IsTrue(laptopsAddedToCart & laptopsRemovedFromCart);
        }

        private bool AddLaptopsToCart()
        {
            _navPanel = new NavigationPanel(driver);
            _navPanel
                .OpenCatalogPage(wait)
                .SelectCategory(LaptopsCategoryTitle, wait);
            var lapCat = new LaptopsCategory(driver);
            var productsList = lapCat.OpenAllLaptopsProductsList(wait);
            productsList.OpenSortPanel(wait).RbtnExpensiveCheap.Click();

            foreach (var item in _laptopsModels)
            {
                var currentProduct = productsList.GetProduct(item, wait);
                new ProductCompactView(driver, currentProduct).AddToCart(wait);
            }

            driver.PressKeyCode(AndroidKeyCode.Back);
            var cartItems = _navPanel
                .OpenCart(wait)
                .GetCartItems(wait);
            // _laptopsModels.Reverse();

            var matchNames = new bool[3];
            var count = 0;
            foreach (var item in cartItems)
            {
                var currText = new CartItemView(driver, item).GetTitle(wait);
                matchNames[count] = currText.Contains(_laptopsModels[count]);
                Console.WriteLine(currText + " = " + _laptopsModels[count]);
                count++;
            }

            return matchNames[0] && matchNames[1] && matchNames[2];
        }

        public bool RemoveLaptopsFromCart()
        {
            var cartPage = new CartPage(driver);
            var currCartItems = cartPage.CartItems;
            for (var i = currCartItems.Count - 1; i >= 0; i--)
            {
                new CartItemView(driver, currCartItems[i]).DeleteFromCart(wait);
            }

            return wait.Until(d => cartPage.IsEmpty());
        }
    }
}