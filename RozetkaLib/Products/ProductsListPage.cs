using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace RozetkaLib
{
    public class ProductsListPage
    {
        private readonly AndroidDriver<AndroidElement> driver;
        private readonly By _btnSort = By.Id("ua.com.rozetka.shop:id/rl_sort");
        private readonly By _btnFilter = By.XPath("ua.com.rozetka.shop:id/rl_filter");
        private readonly By _btnView = By.XPath("ua.com.rozetka.shop:id/rl_filter");
        private readonly By _productsList = By.XPath("//*[contains(@resource-id, 'ua.com.rozetka.shop:id/section_offer_cl_layout')]");
        private readonly By _productName = By.XPath(".//android.widget.TextView");

        public AndroidElement BtnSort { get => driver.FindElement(_btnSort); }
        public AndroidElement BtnFilter { get => driver.FindElement(_btnFilter); }
        public AndroidElement BtnView { get => driver.FindElement(_btnView); }
        public IList<AndroidElement> ProductsList
        {
            get
            {
                return driver.FindElements(_productsList);
            }
        }

        public ProductsListPage(AndroidDriver<AndroidElement> driver)
        {
            this.driver = driver;
        }

        public List<AndroidElement> GetAvailableProducts()
        {
            return ProductsList as List<AndroidElement>;
        }

        public SortPanel OpenSortPanel()
        {
            BtnSort.Click();
            return new SortPanel(driver);
        }

        public SortPanel OpenSortPanel(WebDriverWait wait)
        {
            wait.Until((d) => ElemHelper.IsElementVisible(driver, _btnSort));
            BtnSort.Click();
            SortPanel srtPanelInstance = new SortPanel(driver);
            wait.Until((d) => srtPanelInstance.IsOpened());
            return srtPanelInstance;
        }

        public IList<AndroidElement> GetAvailableProducts(WebDriverWait wait)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(_productsList));
            return ProductsList;
        }

        public AndroidElement GetProduct(String namePart)
        {
            ElemHelper.ScrollToElement(driver, namePart);
            foreach (var item in ProductsList)
            {
                if (new ProductCompactView(driver, item).ProductName.Text.Contains(namePart)) return item;
            }
            return null;
        }

        public AndroidElement GetProduct(String namePart, WebDriverWait wait)
        {
            ElemHelper.ScrollToElement(driver, namePart);
            var currentProductsList = GetAvailableProducts(wait);

            for (int i = currentProductsList.Count - 1; i >= 0; i--)
            {
                if (new ProductCompactView(driver, currentProductsList[i]).GetTitle(wait).Contains(namePart))
                    return currentProductsList[i];
            }
            return null;
        }
    }
}