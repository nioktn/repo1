using NUnit.Framework;
using OpenQA.Selenium.Appium.Android;
using RozetkaLib;
using System;
using System.Collections.Generic;
using System.Threading;

namespace RozetkaTests
{
    public class Test : HollowTest
    {
        NavigationPanel navPan;

        [Test]
        public void Test_OpenNavPane()
        {
            navPan = new NavigationPanel(driver);
            navPan.Open(wait);
            Assert.IsTrue(navPan.IsNavigationPanelOpened());
        }

        [Test]
        public void Test_ClickNotVisibleButt()
        {
            navPan = new NavigationPanel(driver);
            navPan.Open(wait);
            //TouchActions touchActions = new TouchActions(driver);
            //touchActions.LongPress(recViewInstance.BtnCart).Move(recViewInstance.BtnMain.Location.X, recViewInstance.BtnMain.Location.Y).Release().Perform();

            ElemHelper.ScrollToElement(driver, "Просмотренные");
            navPan.BtnWatched.Click();
            Thread.Sleep(5000);
        }

        [Test]
        public void Test_CategoryClick()
        {
            navPan = new NavigationPanel(driver);
            navPan.Open(wait);

            navPan.BtnCatalog.Click();
            CatalogPage catPage = new CatalogPage(driver);

            //ElemHelper.ScrollToElement(driver, catPage._childProducts);
            //catPage.ChildProducts.Click();

            Thread.Sleep(5000);
        }


        [Test]
        public void ChooseSomeNotebooks()
        {
            navPan = new NavigationPanel(driver);
            navPan.OpenCatalogPage(wait).SelectCategory("Ноутбуки и компьютеры", wait);
            LaptopsCategory lapCat = new LaptopsCategory(driver);
            ProductsListPage productsList = lapCat.OpenAllLaptopsProductsList(wait);

            List<String> laptopsToAddNames = new List<String> { "90NB0HS1-M00450", "90NR0GN1-M03880", "80XL03UJRA" };

            foreach (var item in laptopsToAddNames)
            {
                AndroidElement currentProduct = productsList.GetProduct(item, wait);
                new ProductCompactView(driver, currentProduct).BtnAddToWishList.Click();
            }

            IList<AndroidElement> prodElemsInWishList = navPan.
                Open(wait).
                OpenWishLists(wait).
                OpenGuestWishList(wait).
                WishedProductsList;

            //List<String> wishListProductsNames = new List<String>();

            bool[] result = new bool[3];
            int count = 0;
            foreach (var item in prodElemsInWishList)
            {
                //wishListProductsNames.Add(new ProductCompactView(driver, item).ProductName.Text);
                result[count] = new ProductCompactView(driver, item).ProductName.Text.Contains(laptopsToAddNames[count]);
                count++;
            }

            //CollectionAssert.AreEquivalent(wishListProductsNames, laptopsToAddNames);
            Assert.IsTrue(result[0] & result[1] & result[2]);
        }

        [Test]
        public void SearchTest()
        {
            navPan = new NavigationPanel(driver);
            Thread.Sleep(5000);
            navPan.Close();
            SearchPage searchPage = new SearchPage(driver);
            searchPage.Open(wait)
                .EnterSearchQuery("notebook", wait);
            Thread.Sleep(3000);
            Thread.Sleep(5000);


        }
    }
}
