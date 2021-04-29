using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using OpenQA.Selenium.Appium;

namespace RozetkaLib
{
    public class LaptopsCategory
    {
        private readonly AndroidDriver<AndroidElement> driver;
        private readonly By _btnAllLaptops = By.Id("ua.com.rozetka.shop:id/tv_block_title_all");
        private readonly By _availableCategories = By.XPath("//android.support.v7.widget.RecyclerView/android.widget.RelativeLayout");
        private readonly By _categoryName = By.XPath(".//android.widget.Button");
            
        private readonly By _laptops = By.XPath("//android.widget.Button[@resource-id=\"ua.com.rozetka.shop:id/item_section_btn_section\" and @text=\"Ноутбуки\"]");
        private AndroidElement Laptops => driver.FindElement(_laptops);

        private AndroidElement BtnAllLaptops { get => driver.FindElement(_btnAllLaptops); }

        public LaptopsCategory(AndroidDriver<AndroidElement> driver)
        {
            this.driver = driver;
        }

        private IList<AndroidElement> GetAvailableCategoriesList()
        {
            return driver.FindElements(_availableCategories);
        }

        private AndroidElement GetCategoryByName(String catName)
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
            var tacts = new TouchAction(driver);
            wait.Until(d => ElemHelper.IsElementVisible(driver, _laptops));
            tacts.Tap(Laptops).Perform();
            return new ProductsListPage(driver);
        }
    }
}
