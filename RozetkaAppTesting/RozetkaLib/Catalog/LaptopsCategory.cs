using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace RozetkaLib
{
    public class LaptopsCategory
    {
        private readonly AndroidDriver<AndroidElement> driver;
        public readonly By _btnAllLaptops = By.Id("ua.com.rozetka.shop:id/tv_block_title_all");
        public readonly By _availableCategories = By.XPath("//android.support.v7.widget.RecyclerView/android.widget.RelativeLayout");
        private readonly By _categoryName = By.XPath(".//android.widget.TextView");

        public AndroidElement BtnAllLaptops { get => driver.FindElement(_btnAllLaptops); }

        public LaptopsCategory(AndroidDriver<AndroidElement> driver)
        {
            this.driver = driver;
        }

        public IList<AndroidElement> GetAvailableCategoriesList()
        {
            return driver.FindElements(_availableCategories);
        }

        public AndroidElement GetCategoryByName(String catName)
        {
            ElemHelper.ScrollToElement(driver, catName);
            foreach (var item in GetAvailableCategoriesList())
            {
                if (item.FindElement(_categoryName).Text.Contains(catName))
                    return item;
            }
            return null;
        }

        public ProductsListPage OpenAllLaptopsProductsList(WebDriverWait wait)
        {
            TouchAction tacts = new TouchAction(driver);
            tacts.Tap(GetCategoryByName("Ноутбуки")).Perform();
            wait.Until((d) => ElemHelper.IsElementVisible(driver, _btnAllLaptops));
            BtnAllLaptops.Click();
            return new ProductsListPage(driver);
        }
    }
}
