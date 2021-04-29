using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;


namespace RozetkaLib
{
    public class CatalogPage
    {
        private readonly AndroidDriver<AndroidElement> driver;

        // private readonly By _categoriesList = By.XPath("//android.widget.FrameLayout/android.support.v7.widget.RecyclerView/android.widget.RelativeLayout");
        private readonly By _categoriesList = By.Id("ua.com.rozetka.shop:id/fat_menu_rv_top_sections");

        public IList<AndroidElement> CategoriesList
        {
            get => driver.FindElements(_categoriesList);
        }

        private readonly string _laptopsAndComputers = "Ноутбуки и компьютеры";
        private readonly string _smartphonesTvAndElectronic = "Смартфоны, ТВ и электроника";
        private readonly string _householdAppliances = "Бытовая техника";
        private readonly string _householdProducts = "Товары для дома";
        private readonly string _instrumentsAndAutoproducts = "Инструменты и автотовары";
        private readonly string _plumbingAndRepair = "Сантехника и ремонт";
        private readonly string _clothesShoesJewelry = "Одежда, обувь и украшения";
        private readonly string _sportAndHobby = "Красота и здоровье";
        private readonly string _cottegeKitchenGarden = "Дача, сад и огород";
        private readonly string _childProducts = "Детские товары";
        private readonly string _officeProducts = "Канцтовары и книги";
        private readonly string _alcoholAndFood = "Алкогольные напитки и продукты";
        private readonly string _businessProducts = "Товары для бизнеса";

        public AndroidElement LaptopsAndComputers
        {
            get => driver.FindElement(
                MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"" + _laptopsAndComputers + "\")"));
        }

        public AndroidElement SmartphonesTvAndElectronic
        {
            get => driver.FindElement(
                MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"" + _smartphonesTvAndElectronic + "\")"));
        }

        public AndroidElement HouseholdAppliances
        {
            get => driver.FindElement(
                MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"" + _householdAppliances + "\")"));
        }

        public AndroidElement HouseholdProducts
        {
            get => driver.FindElement(
                MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"" + _householdProducts + "\")"));
        }

        public AndroidElement InstrumentsAndAutoproducts
        {
            get => driver.FindElement(
                MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"" + _instrumentsAndAutoproducts + "\")"));
        }

        public AndroidElement PlumbingAndRepair
        {
            get => driver.FindElement(
                MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"" + _plumbingAndRepair + "\")"));
        }

        public AndroidElement ClothesShoesJewelry
        {
            get => driver.FindElement(
                MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"" + _clothesShoesJewelry + "\")"));
        }

        public AndroidElement SportAndHobby
        {
            get => driver.FindElement(
                MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"" + _sportAndHobby + "\")"));
        }

        public AndroidElement CottegeKitchenGarden
        {
            get => driver.FindElement(
                MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"" + _cottegeKitchenGarden + "\")"));
        }

        public AndroidElement ChildProducts
        {
            get => driver.FindElement(
                MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"" + _childProducts + "\")"));
        }

        public AndroidElement OfficeProducts
        {
            get => driver.FindElement(
                MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"" + _officeProducts + "\")"));
        }

        public AndroidElement AlcoholAndFood
        {
            get => driver.FindElement(
                MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"" + _alcoholAndFood + "\")"));
        }

        public AndroidElement BusinessProducts
        {
            get => driver.FindElement(
                MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"" + _businessProducts + "\")"));
        }

        public CatalogPage(AndroidDriver<AndroidElement> driver)
        {
            this.driver = driver;
        }

        public void SelectCategory(string catName, WebDriverWait wait)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(_categoriesList));
            ElemHelper.ScrollToElement(driver, catName);
            try
            {
                driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"" + catName + "\")"))
                    .Click();
            }
            catch
            {
                throw new NotFoundException("Error occured during trying to find category");
            }
        }

        public bool IsOpened()
        {
            return ElemHelper.IsElementVisible(driver, _categoriesList);
        }
    }
}