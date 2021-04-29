using NUnit.Framework;
using OpenQA.Selenium.Appium.Android;
using RozetkaLib;
using System;
using System.Collections.Generic;

namespace RozetkaTests
{
    public class WishListsTests : BaseTest
    {
        private NavigationPanel _navPanel;
        private const string TestEmail = "testmail@outlook.com";
        private const string TestPassword = "Testpassword1";
        private const string ExpectedEmptyWishListTitle = "Этот список пуст";

        private const string LaptopsCategoryTitle = "Ноутбуки и компьютеры";

        private List<string> _laptopsModels =
            new List<string> {"20QV00CERT", "6CK24AV_V2", "6WS50EA"};

        [Test]
        public void Test_AccountWishListOpen()
        {
            _navPanel = new NavigationPanel(driver);
            wait.Until(d => _navPanel.IsNavigationPanelOpened());
            _navPanel.OpenMore(wait)
                .OpenLoginPage(wait)
                .LogIn(TestEmail, TestPassword, wait);
            
            var localWishList = _navPanel
                .OpenWishLists(wait)
                .OpenGuestWishList(wait);

            var actualTitle = localWishList.EmptyTitle.Text;
            StringAssert.AreEqualIgnoringCase(ExpectedEmptyWishListTitle, actualTitle);
        }

        [Test]
        public void Test_WishListAddRemoveProducts()
        {
            var laptopsAddedToWishList = AddLaptopsToWishList();
            var laptopsRemovedFromWishList = RemoveLaptopsFromWishList();
            Assert.IsTrue(laptopsAddedToWishList && laptopsRemovedFromWishList);
        }

        public bool AddLaptopsToWishList()
        {
            _navPanel = new NavigationPanel(driver);
            _navPanel.OpenCatalogPage(wait).SelectCategory(LaptopsCategoryTitle, wait);
            LaptopsCategory lapCat = new LaptopsCategory(driver);
            ProductsListPage productsList = lapCat.OpenAllLaptopsProductsList(wait);
            productsList.OpenSortPanel(wait).
             RbtnExpensiveCheap.Click();

            foreach (var item in _laptopsModels)
            {
                AndroidElement currentProduct = productsList.GetProduct(item, wait);
                //if (currentProduct != null) new ProductCompactView(driver, currentProduct).AddToWishList(wait);
                //else continue;
                new ProductCompactView(driver, currentProduct).AddToWishList(wait);
            }
            driver.PressKeyCode(AndroidKeyCode.Back);
            var prodElemsInWishList = _navPanel.
                OpenWishLists(wait).
                OpenGuestWishList(wait).
                WishedProductsList;
            // _laptopsModels.Reverse();

            var matchNames = new bool[3];
            var count = 0;
            foreach (var item in prodElemsInWishList)
            {
                matchNames[count] = new ProductCompactView(driver, item).ProductName.Text.Contains(_laptopsModels[count]);
                count++;
            }
            return matchNames[0] && matchNames[1] && matchNames[2];
        }

        public bool RemoveLaptopsFromWishList()
        {
            WishList rmWishList = new WishList(driver);
            var currentWishedProductsList = rmWishList.WishedProductsList;
            for (var i = currentWishedProductsList.Count - 1; i >= 0; i--)
            {
                new ProductCompactView(driver, currentWishedProductsList[i]).DeleteFromWishList(wait);
            }
            return wait.Until(d => rmWishList.IsEmpty());
        }
    }
}
