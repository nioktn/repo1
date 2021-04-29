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
        private readonly By _categoriesList = By.XPath("//android.widget.FrameLayout/android.support.v7.widget.RecyclerView/android.widget.RelativeLayout");

        public IList<AndroidElement> CategoriesList { get => driver.FindElements(_categoriesList); }
        //public readonly String _laptopsAndComputers = "Ноутбуки и компьютеры";
        //public readonly String _smartphonesTvAndElectronic = "Смартфоны, ТВ и электроника";
        //public readonly String _householdAppliances = "Бытовая техника";
        //public readonly String _householdProducts = "Товары для дома";
        //public readonly String _instrumentsAndAutoproducts = "Инструменты и автотовары";
        //public readonly String _plumbingAndRepair = "Сантехника и ремонт";
        //public readonly String _clothesShoesJewelry = "Одежда, обувь и украшения";
        //public readonly String _sportAndHobby = "Красота и здоровье";
        //public readonly String _cottegeKitchenGarden = "Дача, сад и огород";
        //public readonly String _childProducts = "Детские товары";
        //public readonly String _officeProducts = "Канцтовары и книги";
        //public readonly String _alcoholAndFood = "Алкогольные напитки и продукты";
        //public readonly String _businessProducts = "Товары для бизнеса";

        //public AndroidElement LaptopsAndComputers { get => driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"" + _laptopsAndComputers + "\")")); }
        //public AndroidElement SmartphonesTvAndElectronic { get => driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"" + _smartphonesTvAndElectronic + "\")")); }
        //public AndroidElement HouseholdAppliances { get => driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"" + _householdAppliances + "\")")); }
        //public AndroidElement HouseholdProducts { get => driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"" + _householdProducts + "\")")); }
        //public AndroidElement InstrumentsAndAutoproducts { get => driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"" + _instrumentsAndAutoproducts + "\")")); }
        //public AndroidElement PlumbingAndRepair { get => driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"" + _plumbingAndRepair + "\")")); }
        //public AndroidElement ClothesShoesJewelry { get => driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"" + _clothesShoesJewelry + "\")")); }
        //public AndroidElement SportAndHobby { get => driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"" + _sportAndHobby + "\")")); }
        //public AndroidElement CottegeKitchenGarden { get => driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"" + _cottegeKitchenGarden + "\")")); }
        //public AndroidElement ChildProducts { get => driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"" + _childProducts + "\")")); }
        //public AndroidElement OfficeProducts { get => driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"" + _officeProducts + "\")")); }
        //public AndroidElement AlcoholAndFood { get => driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"" + _alcoholAndFood + "\")")); }
        //public AndroidElement BusinessProducts { get => driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"" + _businessProducts + "\")")); }

        public CatalogPage(AndroidDriver<AndroidElement> driver)
        {
            this.driver = driver;
        }

        public void SelectCategory(String catName, WebDriverWait wait)
        {
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(_categoriesList));
            ElemHelper.ScrollToElement(driver, catName);
            try
            {
                driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"" + catName + "\")")).Click();
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
