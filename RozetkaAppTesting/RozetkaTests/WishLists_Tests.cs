using NUnit.Framework;
using OpenQA.Selenium.Appium.Android;
using RozetkaLib;
using System;
using System.Collections.Generic;

namespace RozetkaTests
{
    public class WishLists_Tests : HollowTest
    {
        NavigationPanel navPanel;

        [Test]
        public void Test_AccountWishListOpen()
        {
            navPanel = new NavigationPanel(driver);
            wait.Until((d) => navPanel.IsNavigationPanelOpened());
            navPanel.OpenLoginPage(wait)
                .LogIn("testmail@outlook.com", "Testpassword1", wait);

            WishList localWishList = navPanel
                .Open(wait)
                .OpenWishLists(wait)
                .OpenGuestWishList(wait);

            String actualTitle = localWishList.EmptyTitle.Text;
            String expectedTitle = "Этот список пуст";
            StringAssert.AreEqualIgnoringCase(expectedTitle, actualTitle);
        }

        [Test]
        public void Test_WishListAddRemoveProducts()
        {
            bool laptopsAddedToWishList = AddLaptopsToWishList();
            bool laptopsRemovedFromWishList = RemoveLaptopsFromWishList();
            Assert.IsTrue(laptopsAddedToWishList & laptopsRemovedFromWishList);
        }

        public bool AddLaptopsToWishList()
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
                //if (currentProduct != null) new ProductCompactView(driver, currentProduct).AddToWishList(wait);
                //else continue;
                new ProductCompactView(driver, currentProduct).AddToWishList(wait);
            }

            IList<AndroidElement> prodElemsInWishList = navPanel.
                Open(wait).
                OpenWishLists(wait).
                OpenGuestWishList(wait).
                WishedProductsList;

            bool[] matchNames = new bool[3];
            int count = 0;
            foreach (var item in prodElemsInWishList)
            {
                matchNames[count] = new ProductCompactView(driver, item).ProductName.Text.Contains(laptopsModels[count]);
                count++;
            }
            return matchNames[0] & matchNames[1] & matchNames[2];
        }

        public bool RemoveLaptopsFromWishList()
        {
            WishList rmWishList = new WishList(driver);
            var currentWishedProductsList = rmWishList.WishedProductsList;
            for (int i = currentWishedProductsList.Count - 1; i >= 0; i--)
            {
                new ProductCompactView(driver, currentWishedProductsList[i]).DeleteFromWishList(wait);
            }
            return wait.Until((d) => rmWishList.IsEmpty());
        }
    }
}
