using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using System.Collections.Generic;

namespace RozetkaLib
{
    public class WishList
    {
        private readonly AndroidDriver<AndroidElement> driver;
        private readonly By _wishedProductsList = By.XPath("//*[contains(@resource-id, 'rl_background')]");
        private readonly By _btnCatalog = By.XPath("//*[contains(@resource-id, 'll_background')]");
        private readonly By _emptyTitle = By.XPath("//*[contains(@resource-id, 'tv_title')]");

        public IList<AndroidElement> WishedProductsList { get => driver.FindElements(_wishedProductsList); }
        public AndroidElement BtnCatalog { get => driver.FindElement(_btnCatalog); }
        public AndroidElement EmptyTitle { get => driver.FindElement(_emptyTitle); }

        public WishList(AndroidDriver<AndroidElement> driver)
        {
            this.driver = driver;
        }

        public bool IsEmpty()
        {
            return EmptyTitle.Text.Contains("Этот список пуст") & ElemHelper.IsElementExists(driver, _btnCatalog);
        }
    }
}
