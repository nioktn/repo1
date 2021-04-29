using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace RozetkaLib
{
    public class SearchPage
    {
        private readonly AndroidDriver<AndroidElement> _driver;
        private readonly By _searchOpenButton = By.Id("ua.com.rozetka.shop:id/item_main_v_search");
        private readonly By _searchInputField = By.Id("ua.com.rozetka.shop:id/search_et_query");
        private readonly By _searchOpenField = By.Id("ua.com.rozetka.shop:id/ll_search");
        private readonly By _searchBackButton = By.Id("ua.com.rozetka.shop:id/search_iv_back");
        private readonly By _searchClearButton = By.Id("ua.com.rozetka.shop:id/search_iv_clear");
        private readonly By _emptySearchTitle = By.Id("ua.com.rozetka.shop:id/empty_base_tv_title");

        public AndroidElement SearchOpenButton
        {
            get => _driver.FindElement(_searchOpenButton);
        }

        public AndroidElement SearchInputField
        {
            get => _driver.FindElement(_searchInputField);
        }

        public AndroidElement SearchOpenField
        {
            get => _driver.FindElement(_searchOpenField);
        }

        public AndroidElement SearchBackButton
        {
            get => _driver.FindElement(_searchBackButton);
        }

        public AndroidElement SearchClearButton
        {
            get => _driver.FindElement(_searchClearButton);
        }

        public AndroidElement SearchEmptyTitle
        {
            get => _driver.FindElement(_emptySearchTitle);
        }

        public SearchPage(AndroidDriver<AndroidElement> driver)
        {
            this._driver = driver;
        }

        public SearchPage OpenSearch(WebDriverWait wait)
        {
            wait.Until(d => ElemHelper.IsElementVisible(d, _searchOpenButton));
            SearchOpenButton.Click();
            wait.Until(d => ElemHelper.IsElementExists(d, _searchInputField));
            Thread.Sleep(1000);
            _driver.PressKeyCode(AndroidKeyCode.Back);
            return this;
        }

        public void EnterSearchQuery(String query, WebDriverWait wait)
        {
            wait.Until(d => ElemHelper.IsElementVisible(_driver, _searchInputField));
            SearchInputField.SendKeys(query);
            var dict = new Dictionary<string, string>
            {
                {"action", "search"}
            };
            _driver.ExecuteScript("mobile: performEditorAction", dict);
            Thread.Sleep(1000);
        }

        public string GetSearchTitle(WebDriverWait wait)
        {
            wait.Until(d => ElemHelper.IsElementVisible(d, _emptySearchTitle));
            var titleTextValue = SearchEmptyTitle.Text;
            return titleTextValue;
        }
    }
}