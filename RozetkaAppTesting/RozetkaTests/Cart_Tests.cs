using NUnit.Framework;
using OpenQA.Selenium.Appium.Android;
using RozetkaLib;
using System;
using System.Collections.Generic;

namespace RozetkaTests
{
    public class Cart_Tests : HollowTest
    {
        NavigationPanel navPanel;

        [Test]
        public void Test_AccountCartOpen()
        {
            navPanel = new NavigationPanel(driver);
            wait.Until((d) => navPanel.IsNavigationPanelOpened());
            navPanel.OpenLoginPage(wait)
                .LogIn("testmail@outlook.com", "Testpassword1", wait);

            CartPage cartPage = navPanel
                .Open(wait)
                .OpenCart(wait);

            String actualTitle = cartPage.GetTitle(wait);
            String expectedTitle = "Корзина пуста";
            StringAssert.AreEqualIgnoringCase(expectedTitle, actualTitle);
        }

        [Test]
        public void Test_CartAddRemoveItems()
        {
            bool laptopsAddedToCart = AddLaptopsToCart();
            bool laptopsRemovedFromCart = RemoveLaptopsFromCart();
            Assert.IsTrue(laptopsAddedToCart & laptopsRemovedFromCart);
        }

        public bool AddLaptopsToCart()
        {
            navPanel = new NavigationPanel(driver);
            navPanel.OpenCatalogPage(wait).SelectCategory("Ноутбуки и компьютеры", wait);
            LaptopsCategory lapCat = new LaptopsCategory(driver);
            ProductsListPage productsList = lapCat.OpenAllLaptopsProductsList(wait);
            productsList.OpenSortPanel(wait).
             RbtnExpensiveCheap.Click();

            List<String> laptopsModels = new List<String> { "GT75VR7RE-230UA", "GT758RF-239UA", "MPTU35/Z0UE" };

            foreach (var item in laptopsModels)
            {
                AndroidElement currentProduct = productsList.GetProduct(item, wait);
                new ProductCompactView(driver, currentProduct).AddToCart(wait);
            }

            IList<AndroidElement> cartItems = navPanel.
                Open(wait).
                OpenCart(wait).
                GetCartItems(wait);
            laptopsModels.Reverse();

            bool[] matchNames = new bool[3];
            int count = 0;
            foreach (var item in cartItems)
            {
                var currText = new CartItemView(driver, item).GetTitle(wait);
                matchNames[count] = currText.Contains(laptopsModels[count]);
                Console.WriteLine(currText + " = " + laptopsModels[count]);
                count++;
            }
            return matchNames[0] & matchNames[1] & matchNames[2];
        }

        public bool RemoveLaptopsFromCart()
        {
            CartPage cartPage = new CartPage(driver);
            var currCartItems = cartPage.CartItems;
            for (int i = currCartItems.Count - 1; i >= 0; i--)
            {
                new CartItemView(driver, currCartItems[i]).DeleteFromCart(wait);
            }
            return wait.Until((d) => cartPage.IsEmpty());
        }
    }
}
